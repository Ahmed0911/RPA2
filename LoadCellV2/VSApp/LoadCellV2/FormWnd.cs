using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Reflection;
using System.IO;

namespace LoadCellV2
{
    public partial class MainForm : Form
    {
        private Comm433MHz comm433 = new Comm433MHz();
        private BufferDownloader buffDownloader = new BufferDownloader();

        bool SendPingCommands = false;
        bool SendNewPing = true;

        // Data
        SCommEthData MainSystemData;

 
        // ADC Data, used for immediate AND buffer modes!
        struct SData
        {
            public uint IndexTimeMS;
            public uint ADCValue;
        };
        List<SData> dataList = new List<SData>();
        List<SData> downloadedDataList = new List<SData>();

        // OFFSET/GAIN
        private float LoadCellOffset = 2000;
        private float LoadCellGain = 0.01f;

        public MainForm()
        {
            InitializeComponent();

            // enumerate serial ports
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(ports);
            if (ports.Length > 0 ) comboBoxPorts.SelectedIndex = ports.Length - 1;

            textBoxOffset.Text = LoadCellOffset.ToString();
            textBoxGain.Text = LoadCellGain.ToString();

            // fix panel
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelGraph, new object[] { true });
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.BaudRate = 115200;
                serialPort1.PortName = (string)comboBoxPorts.SelectedItem;
                serialPort1.Open();

                buttonOpen.Enabled = false;
                timerTicker.Enabled = true;
                SendPingCommands = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timerTicker_Tick(object sender, EventArgs e)
        {
            // 1. Get data from serial
            int dataLen = serialPort1.BytesToRead;
            byte[] buffer = new byte[dataLen];
            serialPort1.Read(buffer, 0, dataLen);

            // 2. Process Command
            comm433.NewRXPacket(buffer, dataLen, ProcessMessage);

            // 3. Add Data To buffer and redraw
            if(MainSystemData.DataBufferIndex == 0)
            {
                // reset buffer
                dataList.Clear();
            }
            if(MainSystemData.DataBufferIndex > 0 && MainSystemData.DataBufferIndex < 50000)
            {
                SData dat = new SData();
                dat.IndexTimeMS = MainSystemData.DataBufferIndex;
                dat.ADCValue = MainSystemData.ADCValue;
                dataList.Add(dat);
                panelGraph.Refresh();
            }

            // 4. Update downloader (if needed)
            buffDownloader.Update(SendRequest);
            if( buffDownloader.Done() )
            {
                SendPingCommands = true; // restore ping after download is completed
            }

            // update data            
            textBoxCommMsgOK.Text = comm433.MsgReceivedOK.ToString();
            textBoxCommCRCErrors.Text = comm433.CrcErrors.ToString();
            textBoxCommHeaderErrors.Text = comm433.HeaderFails.ToString();

            // Loop/ADC
            textBoxTicks.Text = MainSystemData.LoopCounter.ToString();
            textBoxADCValue.Text = MainSystemData.ADCValue.ToString();
            textBoxBufferIndex.Text = MainSystemData.DataBufferIndex.ToString();
            float Newtons = (MainSystemData.ADCValue - LoadCellOffset) * LoadCellGain;
            textBoxForceN.Text = Newtons.ToString("0.0");

            // downloader
            textBoxDownloaderRequests.Text = buffDownloader.RequestsSent.ToString();
            textBoxDownloaderAnswers.Text = buffDownloader.AnswersReceived.ToString();
            textBoxDownloaderRetries.Text = buffDownloader.Retries.ToString();
            textBoxDownloaderStatus.Text = buffDownloader.Phase.ToString();
            textBoxDownloaderIndex.Text = buffDownloader.Index.ToString();

            // Launch
            string[] launchStatus = { "Idle", "Armed", "Firing" };
            textBoxWpnStatus1.Text = launchStatus[MainSystemData.LaunchStatus1];
            textBoxWpnStatus2.Text = launchStatus[MainSystemData.LaunchStatus2];

            if(MainSystemData.LaunchStatus1 != 0) buttonWpnArm1.Text = "Dearm";
            else buttonWpnArm1.Text = "Arm";
            if (MainSystemData.LaunchStatus2 != 0) buttonWpnArm2.Text = "Dearm";
            else buttonWpnArm2.Text = "Arm";

            // Send PING command
            if (SendPingCommands)
            {
                if (SendNewPing)
                {
                    byte[] buff = new byte[] { 1, 2, 3, 4 }; // dummy
                    byte[] outputPacket = new byte[100];
                    int size = comm433.GenerateTXPacket(0x10, buff, 4, outputPacket);
                    serialPort1.Write(outputPacket, 0, size);
                    SendNewPing = false;
                }
            }
        }

        private void ProcessMessage(byte type, byte[] data, byte len)
        {
            // data
            if (type == 0x20)
            {
                SCommEthData commData = (SCommEthData)Comm.FromBytes(data, new SCommEthData());
                MainSystemData = commData;
                SendNewPing = true;
            }
            if( type == 0x41)
            {
                for (uint i = 0; i != len; i += 2)
                {
                    ushort ADCVal = BitConverter.ToUInt16(data, (int)i);
                    uint index = buffDownloader.Index + (i/2);
                    SData chunk;
                    chunk.ADCValue = ADCVal;
                    chunk.IndexTimeMS = index;
                    downloadedDataList.Add(chunk);
                }
                buffDownloader.AnswerReceived();
            }
        }

        Font font = new Font("Times New Roman", 10); 
        private void panelGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // draw lines
            g.DrawLine(Pens.White, 30, 30, 30, 570);
            g.DrawLine(Pens.White, 30, 570, 970, 570);
            // draw ticks [N]
            for (int i = 0; i <= 50; i+=5 )
            {
                int y = 570-i*10;
                g.DrawLine(Pens.White, 25, y, 35, y);

                int off = 0;
                if (i == 0) off = 7;
                if (i > 99) off = -7;

                string s = i.ToString();
                g.DrawString(s, font, Brushes.White, 8+off, y-8);
            }
            // draw ticks [ms]
            for (int i = 0; i <= 50000; i += 5000)
            {
                int x = i /50 + 30;
                g.DrawLine(Pens.White, x, 560, x, 580);

                if (i == 0) x += 3;
                if (i > 99) x -= 7;

                string s = i.ToString();
                g.DrawString(s, font, Brushes.White, x - 8, 580);
            }

            // draw arrows
            g.DrawLine(Pens.White, 25, 40, 30, 30);
            g.DrawLine(Pens.White, 30, 30, 35, 40);

            g.DrawLine(Pens.White, 960, 565, 970, 570);
            g.DrawLine(Pens.White, 970, 570, 960, 575);


            // Draw Data
            if (radioButtonImmediate.Checked)
            {
                if (dataList.Count > 1)
                {
                    List<Point> points = new List<Point>();

                    for (int i = 0; i != dataList.Count; i++)
                    {
                        points.Add(ConvertPoint(dataList[i].IndexTimeMS, dataList[i].ADCValue));
                    }
                    g.DrawLines(Pens.Yellow, points.ToArray());
                }
            }
            else if(radioButtonBuffer.Checked)
            {
                if (downloadedDataList.Count > 1)
                {
                    List<Point> points = new List<Point>();

                    for (int i = 0; i != downloadedDataList.Count; i++)
                    {
                        points.Add(ConvertPoint(downloadedDataList[i].IndexTimeMS, downloadedDataList[i].ADCValue));
                    }
                    g.DrawLines(Pens.Green, points.ToArray());
                }
            }           
        }

       
        private Point ConvertPoint(float timeMS, float adcValue)
        {
            Point p = new Point();

            // Convert ADC to [N]
            float Newtons = (adcValue - LoadCellOffset) * LoadCellGain;

            p.X = (int)(timeMS / 50000 * 1000 + 30);          
            p.Y = (int)(570 - Newtons*10);

            return p;
        }

        private void buttonWpnCommand_Click(object sender, EventArgs e)
        {
            if (sender == buttonWpnArm1)
            {
                if (buttonWpnArm1.Text == "Arm")
                {
                    WpnCommand(0, 1);
                }
                else
                {
                    WpnCommand(0, 3);
                }
            }
            if (sender == buttonWpnArm2)
            {
                if (buttonWpnArm2.Text == "Arm")
                {
                    WpnCommand(1, 1);
                }
                else
                {
                    WpnCommand(1, 3);
                }
            }
            if (sender == buttonWpnFire1)
            {
                WpnCommand(0, 2);
            }
            if (sender == buttonWpnFire2)
            {
                WpnCommand(1, 2);
            }
        }

        public void WpnCommand(byte index, byte command)
        {
            System.Threading.Thread.Sleep(200);
            uint code = 0x43782843;
            uint timer = 2000; // ticks, 2 sec
            SCommLaunch launch = new SCommLaunch();
            launch.Command = command;
            launch.Index = index;
            if (command == 2) launch.CodeTimer = timer;
            else launch.CodeTimer = code;

            // Send
            byte[] toSend = Comm.GetBytes(launch);
            byte[] outputPacket = new byte[100];
            int size = comm433.GenerateTXPacket(0x30, toSend, (byte)toSend.Length, outputPacket);
            serialPort1.Write(outputPacket, 0, size);
            SendNewPing = true;
        }

        private void buttonUpdateOffsets_Click(object sender, EventArgs e)
        {
            LoadCellOffset = float.Parse(textBoxOffset.Text);
            LoadCellGain = float.Parse(textBoxGain.Text);
        }

        private void buttonBufferDownload_Click(object sender, EventArgs e)
        {
            // kill ping!
            SendPingCommands = false;

            // erase buffer
            downloadedDataList.Clear();

            // start downloader
            buffDownloader.ExecuteDownloader();
        }

        // Downloader stuff
        public void SendRequest(uint offset, uint size)
        {
            // Send
            SCommDownloaderRequest downloadRequest;
            downloadRequest.Offset = offset;
            downloadRequest.Size = size;
            byte[] toSend = Comm.GetBytes(downloadRequest);
            byte[] outputPacket = new byte[100];
            int bytesToSend = comm433.GenerateTXPacket(0x40, toSend, (byte)toSend.Length, outputPacket);
            serialPort1.Write(outputPacket, 0, bytesToSend);
        }

        private void buttonBufferDownloaderAbort_Click(object sender, EventArgs e)
        {
            buffDownloader.Abort();
        }

        private void radioButtonChanged(object sender, EventArgs e)
        {
            panelGraph.Refresh();
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            string extension =string.Format("{0}-{1}-{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            StreamWriter sw = File.CreateText(string.Format("outputlogimmediate-{0}.txt", extension));
            sw.WriteLine("TimeMS ADC");
            for (int i = 0; i != dataList.Count; i++)
            {
                sw.WriteLine("{0} {1}", dataList[i].IndexTimeMS, dataList[i].ADCValue);
            }
            sw.Close();

            sw = File.CreateText(string.Format("outputlogbuffer-{0}.txt", extension));
            sw.WriteLine("TimeMS ADC");
            for (int i = 0; i != downloadedDataList.Count; i++)
            {
                sw.WriteLine("{0} {1}", downloadedDataList[i].IndexTimeMS, downloadedDataList[i].ADCValue);
            }
            sw.Close();

            MessageBox.Show(string.Format("Immediate: {0}, Buffered: {1}", dataList.Count, downloadedDataList.Count), string.Format("Data Saved: {0}", extension));
        }

        private void buttonPing_Click(object sender, EventArgs e)
        {
            SendNewPing = true;
        }
    }
}
