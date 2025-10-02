namespace Simulator_PLC
{
    partial class frmClient
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
            this.pnPLC = new System.Windows.Forms.Panel();
            this.cbbStopbits = new System.Windows.Forms.ComboBox();
            this.cbbDatabits = new System.Windows.Forms.ComboBox();
            this.cbbParitys = new System.Windows.Forms.ComboBox();
            this.cbbBuadrate = new System.Windows.Forms.ComboBox();
            this.cbbCom = new System.Windows.Forms.ComboBox();
            this.btnConnectPLC = new System.Windows.Forms.Button();
            this.spPLC = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnManualBB300 = new System.Windows.Forms.Button();
            this.btnManualBB400 = new System.Windows.Forms.Button();
            this.cbAckKnowLage = new System.Windows.Forms.CheckBox();
            this.cbErrSilo1 = new System.Windows.Forms.CheckBox();
            this.cbErrSIlo2 = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmBB300 = new System.Windows.Forms.Timer(this.components);
            this.tmBB400 = new System.Windows.Forms.Timer(this.components);
            this.pnPLC.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnPLC
            // 
            this.pnPLC.Controls.Add(this.cbbStopbits);
            this.pnPLC.Controls.Add(this.cbbDatabits);
            this.pnPLC.Controls.Add(this.cbbParitys);
            this.pnPLC.Controls.Add(this.cbbBuadrate);
            this.pnPLC.Controls.Add(this.cbbCom);
            this.pnPLC.Location = new System.Drawing.Point(3, 2);
            this.pnPLC.Name = "pnPLC";
            this.pnPLC.Size = new System.Drawing.Size(896, 46);
            this.pnPLC.TabIndex = 8;
            // 
            // cbbStopbits
            // 
            this.cbbStopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStopbits.FormattingEnabled = true;
            this.cbbStopbits.Location = new System.Drawing.Point(718, 5);
            this.cbbStopbits.Name = "cbbStopbits";
            this.cbbStopbits.Size = new System.Drawing.Size(172, 33);
            this.cbbStopbits.TabIndex = 4;
            this.cbbStopbits.DropDown += new System.EventHandler(this.cbbCom_DropDown);
            this.cbbStopbits.DropDownClosed += new System.EventHandler(this.cbbStopbits_DropDownClosed);
            // 
            // cbbDatabits
            // 
            this.cbbDatabits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDatabits.FormattingEnabled = true;
            this.cbbDatabits.Location = new System.Drawing.Point(540, 5);
            this.cbbDatabits.Name = "cbbDatabits";
            this.cbbDatabits.Size = new System.Drawing.Size(172, 33);
            this.cbbDatabits.TabIndex = 3;
            this.cbbDatabits.DropDown += new System.EventHandler(this.cbbCom_DropDown);
            this.cbbDatabits.DropDownClosed += new System.EventHandler(this.cbbStopbits_DropDownClosed);
            // 
            // cbbParitys
            // 
            this.cbbParitys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbParitys.FormattingEnabled = true;
            this.cbbParitys.Location = new System.Drawing.Point(362, 5);
            this.cbbParitys.Name = "cbbParitys";
            this.cbbParitys.Size = new System.Drawing.Size(172, 33);
            this.cbbParitys.TabIndex = 2;
            this.cbbParitys.DropDown += new System.EventHandler(this.cbbCom_DropDown);
            this.cbbParitys.DropDownClosed += new System.EventHandler(this.cbbStopbits_DropDownClosed);
            // 
            // cbbBuadrate
            // 
            this.cbbBuadrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBuadrate.FormattingEnabled = true;
            this.cbbBuadrate.Location = new System.Drawing.Point(184, 5);
            this.cbbBuadrate.Name = "cbbBuadrate";
            this.cbbBuadrate.Size = new System.Drawing.Size(172, 33);
            this.cbbBuadrate.TabIndex = 1;
            this.cbbBuadrate.DropDown += new System.EventHandler(this.cbbCom_DropDown);
            this.cbbBuadrate.DropDownClosed += new System.EventHandler(this.cbbStopbits_DropDownClosed);
            // 
            // cbbCom
            // 
            this.cbbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCom.FormattingEnabled = true;
            this.cbbCom.Location = new System.Drawing.Point(6, 5);
            this.cbbCom.Name = "cbbCom";
            this.cbbCom.Size = new System.Drawing.Size(172, 33);
            this.cbbCom.TabIndex = 0;
            this.cbbCom.DropDown += new System.EventHandler(this.cbbCom_DropDown);
            this.cbbCom.DropDownClosed += new System.EventHandler(this.cbbStopbits_DropDownClosed);
            // 
            // btnConnectPLC
            // 
            this.btnConnectPLC.Location = new System.Drawing.Point(906, 6);
            this.btnConnectPLC.Name = "btnConnectPLC";
            this.btnConnectPLC.Size = new System.Drawing.Size(172, 36);
            this.btnConnectPLC.TabIndex = 7;
            this.btnConnectPLC.Text = "Connect";
            this.btnConnectPLC.UseVisualStyleBackColor = true;
            this.btnConnectPLC.Click += new System.EventHandler(this.btnConnectPLC_Click);
            // 
            // spPLC
            // 
            this.spPLC.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spPLC_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(6, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 137);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode Silo 1";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(10, 102);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(61, 29);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Auto";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(10, 67);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(100, 29);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.Text = "Semi-Auto";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 29);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.Text = "Manual";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Location = new System.Drawing.Point(169, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 137);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode Silo 2";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(10, 102);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(61, 29);
            this.radioButton4.TabIndex = 23;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Auto";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(10, 67);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(100, 29);
            this.radioButton5.TabIndex = 22;
            this.radioButton5.Text = "Semi-Auto";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(10, 32);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(75, 29);
            this.radioButton6.TabIndex = 21;
            this.radioButton6.Text = "Manual";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(332, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 137);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "สถานะ Silo 1";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Athiti Medium", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(337, 105);
            this.label4.TabIndex = 18;
            this.label4.Text = "ปิดวาล์ว";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(681, 54);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(343, 137);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "สถานะ Silo 2";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Athiti Medium", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 105);
            this.label1.TabIndex = 18;
            this.label1.Text = "ปิดวาล์ว";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnManualBB300
            // 
            this.btnManualBB300.Enabled = false;
            this.btnManualBB300.Location = new System.Drawing.Point(9, 197);
            this.btnManualBB300.Name = "btnManualBB300";
            this.btnManualBB300.Size = new System.Drawing.Size(196, 36);
            this.btnManualBB300.TabIndex = 27;
            this.btnManualBB300.Text = "Manual BB-300";
            this.btnManualBB300.UseVisualStyleBackColor = true;
            this.btnManualBB300.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnManualBB400
            // 
            this.btnManualBB400.Enabled = false;
            this.btnManualBB400.Location = new System.Drawing.Point(338, 197);
            this.btnManualBB400.Name = "btnManualBB400";
            this.btnManualBB400.Size = new System.Drawing.Size(229, 36);
            this.btnManualBB400.TabIndex = 28;
            this.btnManualBB400.Text = "Manual BB-400";
            this.btnManualBB400.UseVisualStyleBackColor = true;
            this.btnManualBB400.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbAckKnowLage
            // 
            this.cbAckKnowLage.AutoSize = true;
            this.cbAckKnowLage.ForeColor = System.Drawing.Color.Red;
            this.cbAckKnowLage.Location = new System.Drawing.Point(694, 209);
            this.cbAckKnowLage.Name = "cbAckKnowLage";
            this.cbAckKnowLage.Size = new System.Drawing.Size(93, 29);
            this.cbAckKnowLage.TabIndex = 29;
            this.cbAckKnowLage.Text = "PLC Alert";
            this.cbAckKnowLage.UseVisualStyleBackColor = true;
            this.cbAckKnowLage.CheckedChanged += new System.EventHandler(this.cbAckKnowLage_CheckedChanged);
            // 
            // cbErrSilo1
            // 
            this.cbErrSilo1.AutoSize = true;
            this.cbErrSilo1.ForeColor = System.Drawing.Color.Red;
            this.cbErrSilo1.Location = new System.Drawing.Point(793, 209);
            this.cbErrSilo1.Name = "cbErrSilo1";
            this.cbErrSilo1.Size = new System.Drawing.Size(66, 29);
            this.cbErrSilo1.TabIndex = 30;
            this.cbErrSilo1.Text = "Silo 1";
            this.cbErrSilo1.UseVisualStyleBackColor = true;
            this.cbErrSilo1.CheckedChanged += new System.EventHandler(this.cbErrSilo1_CheckedChanged);
            // 
            // cbErrSIlo2
            // 
            this.cbErrSIlo2.AutoSize = true;
            this.cbErrSIlo2.ForeColor = System.Drawing.Color.Red;
            this.cbErrSIlo2.Location = new System.Drawing.Point(892, 209);
            this.cbErrSIlo2.Name = "cbErrSIlo2";
            this.cbErrSIlo2.Size = new System.Drawing.Size(69, 29);
            this.cbErrSIlo2.TabIndex = 31;
            this.cbErrSIlo2.Text = "Silo 2";
            this.cbErrSIlo2.UseVisualStyleBackColor = true;
            this.cbErrSIlo2.CheckedChanged += new System.EventHandler(this.cbErrSIlo2_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 244);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1065, 562);
            this.richTextBox1.TabIndex = 32;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(223, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 30);
            this.label2.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(573, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 30);
            this.label3.TabIndex = 34;
            // 
            // tmBB300
            // 
            this.tmBB300.Interval = 10000;
            this.tmBB300.Tick += new System.EventHandler(this.tmBB300_Tick);
            // 
            // tmBB400
            // 
            this.tmBB400.Interval = 10000;
            this.tmBB400.Tick += new System.EventHandler(this.tmBB400_Tick);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 818);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cbErrSIlo2);
            this.Controls.Add(this.cbErrSilo1);
            this.Controls.Add(this.cbAckKnowLage);
            this.Controls.Add(this.btnManualBB400);
            this.Controls.Add(this.btnManualBB300);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnPLC);
            this.Controls.Add(this.btnConnectPLC);
            this.Font = new System.Drawing.Font("Athiti", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmClient";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.pnPLC.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnPLC;
        private System.Windows.Forms.ComboBox cbbStopbits;
        private System.Windows.Forms.ComboBox cbbDatabits;
        private System.Windows.Forms.ComboBox cbbParitys;
        private System.Windows.Forms.ComboBox cbbBuadrate;
        private System.Windows.Forms.ComboBox cbbCom;
        private System.Windows.Forms.Button btnConnectPLC;
        private System.IO.Ports.SerialPort spPLC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManualBB300;
        private System.Windows.Forms.Button btnManualBB400;
        private System.Windows.Forms.CheckBox cbAckKnowLage;
        private System.Windows.Forms.CheckBox cbErrSilo1;
        private System.Windows.Forms.CheckBox cbErrSIlo2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer tmBB300;
        private System.Windows.Forms.Timer tmBB400;
    }
}

