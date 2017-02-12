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

namespace LoadCellV2
{
    public partial class MainForm : Form
    {
        private int TickCount = 0;
        private Comm433MHz comm433 = new Comm433MHz();

        struct SData
        {
            public float Time;
            public float SetpTemperature;
            public float CurrentTemperature;
            public float CurrentPWM;
        };
        List<SData> dataList = new List<SData>();

        public MainForm()
        {
            InitializeComponent();

            // enumerate serial ports
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(ports);
            if (ports.Length > 0 ) comboBoxPorts.SelectedIndex = ports.Length - 1;

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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timerTicker_Tick(object sender, EventArgs e)
        {
            // 1. get data from serial
            int dataLen = serialPort1.BytesToRead;
            byte[] buffer = new byte[dataLen];
            serialPort1.Read(buffer, 0, dataLen);

            // 2. Process Command
            comm433.NewRXPacket(buffer, dataLen);

            textBoxTicks.Text = string.Format("{0}", TickCount);

            // 4. Add Data To buffer and redraw
            //SData dat = new SData();
            //dat.Time = Time;
            //dat.SetpTemperature = SetpTemperature;
            //dat.CurrentTemperature = CurrentTemperature;
            //dat.CurrentPWM = CurrentPWM;
            //dataList.Add(dat);            
            //panelGraph.Refresh();

            // update data
            textBoxCommMsgOK.Text = comm433.MsgReceivedOK.ToString();
            textBoxCommCRCErrors.Text = comm433.CrcErrors.ToString();
            textBoxCommHeaderErrors.Text = comm433.HeaderFails.ToString();

            // TEST
            //byte[] buff = new byte[] { 1, 2, 3, 4, 5 };
            //byte[] outputPacket = new byte[100];
            //int size = comm433.GenerateTXPacket(10, buff, 5, outputPacket);
            //comm433.NewRXPacket(outputPacket, size);
        }


        Font font = new Font("Times New Roman", 10); 
        private void panelGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // draw lines
            g.DrawLine(Pens.White, 30, 30, 30, 570);
            g.DrawLine(Pens.White, 30, 570, 970, 570);
            // draw ticks
            for (int i = 0; i <= 260; i+=20 )
            {
                int y = 570-i*2;
                g.DrawLine(Pens.White, 25, y, 35, y);

                int off = 0;
                if (i == 0) off = 7;
                if (i > 99) off = -7;

                string s = i.ToString();
                g.DrawString(s, font, Brushes.White, 8+off, y-8);
            }
            // draw ticks
            for (int i = 0; i <= 300; i += 30)
            {
                int x = i * 3 + 30;
                g.DrawLine(Pens.White, x, 560, x, 580);

                if (i == 0) x += 3;
                if (i > 99) x -= 4;

                string s = i.ToString();
                g.DrawString(s, font, Brushes.White, x - 8, 580);
            }

            // draw arrows
            g.DrawLine(Pens.White, 25, 40, 30, 30);
            g.DrawLine(Pens.White, 30, 30, 35, 40);

            g.DrawLine(Pens.White, 960, 565, 970, 570);
            g.DrawLine(Pens.White, 970, 570, 960, 575);

            // Draw Data
            if( dataList.Count > 1)
            { 
                List<Point> points1 = new List<Point>();
                List<Point> points2 = new List<Point>();
                List<Point> points3 = new List<Point>();
                for (int i = 0; i != dataList.Count; i++)
                {
                    points1.Add(ConvertPoint(dataList[i].Time, dataList[i].SetpTemperature));
                    points2.Add(ConvertPoint(dataList[i].Time, dataList[i].CurrentTemperature));
                    points3.Add(ConvertPoint(dataList[i].Time, dataList[i].CurrentPWM));
                }
            }
        }

        private Point ConvertPoint(float time, float temperature)
        {
            Point p = new Point();

            p.X = (int)(time * 3 + 30);
            p.Y = (int)(570 - temperature * 2);            

            return p;
        }
    }
}
