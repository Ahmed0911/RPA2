namespace LoadCellV2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panelGraph = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxADCValue = new System.Windows.Forms.TextBox();
            this.timerTicker = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTicks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCommCRCErrors = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCommHeaderErrors = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCommMsgOK = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.buttonWpnFire2 = new System.Windows.Forms.Button();
            this.textBoxWpnStatus2 = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.buttonWpnArm2 = new System.Windows.Forms.Button();
            this.buttonWpnFire1 = new System.Windows.Forms.Button();
            this.textBoxWpnStatus1 = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.buttonWpnArm1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxBufferIndex = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxForceN = new System.Windows.Forms.TextBox();
            this.textBoxOffset = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxGain = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonUpdateOffsets = new System.Windows.Forms.Button();
            this.buttonBufferDownload = new System.Windows.Forms.Button();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(74, 18);
            this.comboBoxPorts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(106, 28);
            this.comboBoxPorts.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(190, 15);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(112, 35);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.Black;
            this.panelGraph.Location = new System.Drawing.Point(18, 85);
            this.panelGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(1500, 923);
            this.panelGraph.TabIndex = 3;
            this.panelGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraph_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1542, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "ADC:";
            // 
            // textBoxADCValue
            // 
            this.textBoxADCValue.Location = new System.Drawing.Point(1614, 127);
            this.textBoxADCValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxADCValue.Name = "textBoxADCValue";
            this.textBoxADCValue.ReadOnly = true;
            this.textBoxADCValue.Size = new System.Drawing.Size(84, 26);
            this.textBoxADCValue.TabIndex = 5;
            this.textBoxADCValue.Text = "0";
            // 
            // timerTicker
            // 
            this.timerTicker.Tick += new System.EventHandler(this.timerTicker_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1542, 94);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ticks:";
            // 
            // textBoxTicks
            // 
            this.textBoxTicks.Location = new System.Drawing.Point(1614, 91);
            this.textBoxTicks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxTicks.Name = "textBoxTicks";
            this.textBoxTicks.ReadOnly = true;
            this.textBoxTicks.Size = new System.Drawing.Size(84, 26);
            this.textBoxTicks.TabIndex = 5;
            this.textBoxTicks.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1542, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "CRC Errors:";
            // 
            // textBoxCommCRCErrors
            // 
            this.textBoxCommCRCErrors.Location = new System.Drawing.Point(1658, 214);
            this.textBoxCommCRCErrors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCommCRCErrors.Name = "textBoxCommCRCErrors";
            this.textBoxCommCRCErrors.ReadOnly = true;
            this.textBoxCommCRCErrors.Size = new System.Drawing.Size(84, 26);
            this.textBoxCommCRCErrors.TabIndex = 9;
            this.textBoxCommCRCErrors.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1542, 252);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Header Errors:";
            // 
            // textBoxCommHeaderErrors
            // 
            this.textBoxCommHeaderErrors.Location = new System.Drawing.Point(1658, 249);
            this.textBoxCommHeaderErrors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCommHeaderErrors.Name = "textBoxCommHeaderErrors";
            this.textBoxCommHeaderErrors.ReadOnly = true;
            this.textBoxCommHeaderErrors.Size = new System.Drawing.Size(84, 26);
            this.textBoxCommHeaderErrors.TabIndex = 11;
            this.textBoxCommHeaderErrors.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1542, 286);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "MessagesOK:";
            // 
            // textBoxCommMsgOK
            // 
            this.textBoxCommMsgOK.Location = new System.Drawing.Point(1658, 283);
            this.textBoxCommMsgOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCommMsgOK.Name = "textBoxCommMsgOK";
            this.textBoxCommMsgOK.ReadOnly = true;
            this.textBoxCommMsgOK.Size = new System.Drawing.Size(84, 26);
            this.textBoxCommMsgOK.TabIndex = 13;
            this.textBoxCommMsgOK.Text = "0";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.buttonWpnFire2);
            this.groupBox10.Controls.Add(this.textBoxWpnStatus2);
            this.groupBox10.Controls.Add(this.label70);
            this.groupBox10.Controls.Add(this.buttonWpnArm2);
            this.groupBox10.Controls.Add(this.buttonWpnFire1);
            this.groupBox10.Controls.Add(this.textBoxWpnStatus1);
            this.groupBox10.Controls.Add(this.label69);
            this.groupBox10.Controls.Add(this.buttonWpnArm1);
            this.groupBox10.Location = new System.Drawing.Point(1526, 354);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(382, 176);
            this.groupBox10.TabIndex = 41;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Launch";
            // 
            // buttonWpnFire2
            // 
            this.buttonWpnFire2.Location = new System.Drawing.Point(278, 100);
            this.buttonWpnFire2.Name = "buttonWpnFire2";
            this.buttonWpnFire2.Size = new System.Drawing.Size(88, 56);
            this.buttonWpnFire2.TabIndex = 45;
            this.buttonWpnFire2.Text = "Fire";
            this.buttonWpnFire2.UseVisualStyleBackColor = true;
            this.buttonWpnFire2.Click += new System.EventHandler(this.buttonWpnCommand_Click);
            // 
            // textBoxWpnStatus2
            // 
            this.textBoxWpnStatus2.Location = new System.Drawing.Point(68, 116);
            this.textBoxWpnStatus2.Name = "textBoxWpnStatus2";
            this.textBoxWpnStatus2.Size = new System.Drawing.Size(128, 26);
            this.textBoxWpnStatus2.TabIndex = 44;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(8, 118);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(55, 20);
            this.label70.TabIndex = 43;
            this.label70.Text = "Wpn2:";
            // 
            // buttonWpnArm2
            // 
            this.buttonWpnArm2.Location = new System.Drawing.Point(202, 100);
            this.buttonWpnArm2.Name = "buttonWpnArm2";
            this.buttonWpnArm2.Size = new System.Drawing.Size(70, 56);
            this.buttonWpnArm2.TabIndex = 42;
            this.buttonWpnArm2.Text = "Arm";
            this.buttonWpnArm2.UseVisualStyleBackColor = true;
            this.buttonWpnArm2.Click += new System.EventHandler(this.buttonWpnCommand_Click);
            // 
            // buttonWpnFire1
            // 
            this.buttonWpnFire1.Location = new System.Drawing.Point(278, 28);
            this.buttonWpnFire1.Name = "buttonWpnFire1";
            this.buttonWpnFire1.Size = new System.Drawing.Size(88, 56);
            this.buttonWpnFire1.TabIndex = 41;
            this.buttonWpnFire1.Text = "Fire";
            this.buttonWpnFire1.UseVisualStyleBackColor = true;
            this.buttonWpnFire1.Click += new System.EventHandler(this.buttonWpnCommand_Click);
            // 
            // textBoxWpnStatus1
            // 
            this.textBoxWpnStatus1.Location = new System.Drawing.Point(68, 44);
            this.textBoxWpnStatus1.Name = "textBoxWpnStatus1";
            this.textBoxWpnStatus1.Size = new System.Drawing.Size(128, 26);
            this.textBoxWpnStatus1.TabIndex = 2;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(8, 46);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(55, 20);
            this.label69.TabIndex = 1;
            this.label69.Text = "Wpn1:";
            // 
            // buttonWpnArm1
            // 
            this.buttonWpnArm1.Location = new System.Drawing.Point(202, 28);
            this.buttonWpnArm1.Name = "buttonWpnArm1";
            this.buttonWpnArm1.Size = new System.Drawing.Size(70, 56);
            this.buttonWpnArm1.TabIndex = 0;
            this.buttonWpnArm1.Text = "Arm";
            this.buttonWpnArm1.UseVisualStyleBackColor = true;
            this.buttonWpnArm1.Click += new System.EventHandler(this.buttonWpnCommand_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1544, 167);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 43;
            this.label7.Text = "Index:";
            // 
            // textBoxBufferIndex
            // 
            this.textBoxBufferIndex.Location = new System.Drawing.Point(1614, 164);
            this.textBoxBufferIndex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxBufferIndex.Name = "textBoxBufferIndex";
            this.textBoxBufferIndex.ReadOnly = true;
            this.textBoxBufferIndex.Size = new System.Drawing.Size(84, 26);
            this.textBoxBufferIndex.TabIndex = 42;
            this.textBoxBufferIndex.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1711, 130);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 20);
            this.label8.TabIndex = 45;
            this.label8.Text = "Force [N]:";
            // 
            // textBoxForceN
            // 
            this.textBoxForceN.Location = new System.Drawing.Point(1796, 127);
            this.textBoxForceN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxForceN.Name = "textBoxForceN";
            this.textBoxForceN.ReadOnly = true;
            this.textBoxForceN.Size = new System.Drawing.Size(84, 26);
            this.textBoxForceN.TabIndex = 44;
            this.textBoxForceN.Text = "0";
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.Location = new System.Drawing.Point(1585, 12);
            this.textBoxOffset.Name = "textBoxOffset";
            this.textBoxOffset.Size = new System.Drawing.Size(128, 26);
            this.textBoxOffset.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1525, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 46;
            this.label9.Text = "Offset:";
            // 
            // textBoxGain
            // 
            this.textBoxGain.Location = new System.Drawing.Point(1585, 44);
            this.textBoxGain.Name = "textBoxGain";
            this.textBoxGain.Size = new System.Drawing.Size(128, 26);
            this.textBoxGain.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1525, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 20);
            this.label10.TabIndex = 48;
            this.label10.Text = "Gain";
            // 
            // buttonUpdateOffsets
            // 
            this.buttonUpdateOffsets.Location = new System.Drawing.Point(1728, 12);
            this.buttonUpdateOffsets.Name = "buttonUpdateOffsets";
            this.buttonUpdateOffsets.Size = new System.Drawing.Size(70, 56);
            this.buttonUpdateOffsets.TabIndex = 50;
            this.buttonUpdateOffsets.Text = "Set";
            this.buttonUpdateOffsets.UseVisualStyleBackColor = true;
            this.buttonUpdateOffsets.Click += new System.EventHandler(this.buttonUpdateOffsets_Click);
            // 
            // buttonBufferDownload
            // 
            this.buttonBufferDownload.Location = new System.Drawing.Point(1638, 619);
            this.buttonBufferDownload.Name = "buttonBufferDownload";
            this.buttonBufferDownload.Size = new System.Drawing.Size(104, 56);
            this.buttonBufferDownload.TabIndex = 51;
            this.buttonBufferDownload.Text = "Download";
            this.buttonBufferDownload.UseVisualStyleBackColor = true;
            this.buttonBufferDownload.Click += new System.EventHandler(this.buttonBufferDownload_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1031);
            this.Controls.Add(this.buttonBufferDownload);
            this.Controls.Add(this.buttonUpdateOffsets);
            this.Controls.Add(this.textBoxGain);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxOffset);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxForceN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxBufferIndex);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCommMsgOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCommHeaderErrors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCommCRCErrors);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxTicks);
            this.Controls.Add(this.textBoxADCValue);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPorts);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Load Cell V2 App";
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOpen;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxADCValue;
        private System.Windows.Forms.Timer timerTicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTicks;
        public System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCommCRCErrors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCommHeaderErrors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCommMsgOK;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button buttonWpnFire2;
        private System.Windows.Forms.TextBox textBoxWpnStatus2;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Button buttonWpnArm2;
        private System.Windows.Forms.Button buttonWpnFire1;
        private System.Windows.Forms.TextBox textBoxWpnStatus1;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Button buttonWpnArm1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxBufferIndex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxForceN;
        private System.Windows.Forms.TextBox textBoxOffset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxGain;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonUpdateOffsets;
        private System.Windows.Forms.Button buttonBufferDownload;
    }
}

