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
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.timerTicker = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTicks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCommCRCErrors = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCommHeaderErrors = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCommMsgOK = new System.Windows.Forms.TextBox();
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
            this.label5.Location = new System.Drawing.Point(1539, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Time:";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(1613, 85);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(84, 26);
            this.textBoxTime.TabIndex = 5;
            this.textBoxTime.Text = "0";
            // 
            // timerTicker
            // 
            this.timerTicker.Tick += new System.EventHandler(this.timerTicker_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1534, 134);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ticks:";
            // 
            // textBoxTicks
            // 
            this.textBoxTicks.Location = new System.Drawing.Point(1613, 130);
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
            this.label2.Location = new System.Drawing.Point(1534, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "CRC Errors:";
            // 
            // textBoxCommCRCErrors
            // 
            this.textBoxCommCRCErrors.Location = new System.Drawing.Point(1650, 178);
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
            this.label3.Location = new System.Drawing.Point(1534, 216);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Header Errors:";
            // 
            // textBoxCommHeaderErrors
            // 
            this.textBoxCommHeaderErrors.Location = new System.Drawing.Point(1650, 213);
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
            this.label4.Location = new System.Drawing.Point(1534, 250);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "MessagesOK:";
            // 
            // textBoxCommMsgOK
            // 
            this.textBoxCommMsgOK.Location = new System.Drawing.Point(1650, 247);
            this.textBoxCommMsgOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCommMsgOK.Name = "textBoxCommMsgOK";
            this.textBoxCommMsgOK.ReadOnly = true;
            this.textBoxCommMsgOK.Size = new System.Drawing.Size(84, 26);
            this.textBoxCommMsgOK.TabIndex = 13;
            this.textBoxCommMsgOK.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1773, 1031);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCommMsgOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCommHeaderErrors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCommCRCErrors);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxTicks);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPorts);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Load Cell V2 App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOpen;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTime;
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
    }
}

