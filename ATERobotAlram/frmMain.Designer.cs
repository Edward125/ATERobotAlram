namespace ATERobotAlram
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabATE = new System.Windows.Forms.TabControl();
            this.tabAS2 = new System.Windows.Forms.TabPage();
            this.tabAS4 = new System.Windows.Forms.TabPage();
            this.tabAS6 = new System.Windows.Forms.TabPage();
            this.tabAS9 = new System.Windows.Forms.TabPage();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.txtAS2IP = new System.Windows.Forms.MaskedTextBox();
            this.txtAS4IP = new System.Windows.Forms.MaskedTextBox();
            this.txtAS6IP = new System.Windows.Forms.MaskedTextBox();
            this.txtAS9IP = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAS2IPInfo = new System.Windows.Forms.TextBox();
            this.btnAS2Run = new System.Windows.Forms.Button();
            this.btnAS2Stop = new System.Windows.Forms.Button();
            this.lstAS2Alarm = new System.Windows.Forms.ListBox();
            this.lstAS2Info = new System.Windows.Forms.ListBox();
            this.timerRead_PLC_AS2 = new System.Windows.Forms.Timer(this.components);
            this.axActSupportMsg1 = new AxActSupportMsgLib.AxActSupportMsg();
            this.axActProgTypeAS9 = new AxActProgTypeLib.AxActProgType();
            this.axActProgTypeAS6 = new AxActProgTypeLib.AxActProgType();
            this.axActProgTypeAS4 = new AxActProgTypeLib.AxActProgType();
            this.axActProgTypeAS2 = new AxActProgTypeLib.AxActProgType();
            this.tabATE.SuspendLayout();
            this.tabAS2.SuspendLayout();
            this.tabSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axActSupportMsg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActProgTypeAS9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActProgTypeAS6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActProgTypeAS4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActProgTypeAS2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabATE
            // 
            this.tabATE.Controls.Add(this.tabAS2);
            this.tabATE.Controls.Add(this.tabAS4);
            this.tabATE.Controls.Add(this.tabAS6);
            this.tabATE.Controls.Add(this.tabAS9);
            this.tabATE.Controls.Add(this.tabSetting);
            this.tabATE.Location = new System.Drawing.Point(14, 24);
            this.tabATE.Name = "tabATE";
            this.tabATE.SelectedIndex = 0;
            this.tabATE.Size = new System.Drawing.Size(636, 562);
            this.tabATE.TabIndex = 0;
            // 
            // tabAS2
            // 
            this.tabAS2.Controls.Add(this.lstAS2Info);
            this.tabAS2.Controls.Add(this.lstAS2Alarm);
            this.tabAS2.Controls.Add(this.btnAS2Stop);
            this.tabAS2.Controls.Add(this.btnAS2Run);
            this.tabAS2.Controls.Add(this.txtAS2IPInfo);
            this.tabAS2.Controls.Add(this.label5);
            this.tabAS2.Location = new System.Drawing.Point(4, 23);
            this.tabAS2.Name = "tabAS2";
            this.tabAS2.Padding = new System.Windows.Forms.Padding(3);
            this.tabAS2.Size = new System.Drawing.Size(628, 535);
            this.tabAS2.TabIndex = 0;
            this.tabAS2.Text = "AS2";
            this.tabAS2.UseVisualStyleBackColor = true;
            // 
            // tabAS4
            // 
            this.tabAS4.Location = new System.Drawing.Point(4, 23);
            this.tabAS4.Name = "tabAS4";
            this.tabAS4.Padding = new System.Windows.Forms.Padding(3);
            this.tabAS4.Size = new System.Drawing.Size(491, 535);
            this.tabAS4.TabIndex = 1;
            this.tabAS4.Text = "AS4";
            this.tabAS4.UseVisualStyleBackColor = true;
            // 
            // tabAS6
            // 
            this.tabAS6.Location = new System.Drawing.Point(4, 23);
            this.tabAS6.Name = "tabAS6";
            this.tabAS6.Size = new System.Drawing.Size(491, 535);
            this.tabAS6.TabIndex = 2;
            this.tabAS6.Text = "AS6";
            this.tabAS6.UseVisualStyleBackColor = true;
            // 
            // tabAS9
            // 
            this.tabAS9.Location = new System.Drawing.Point(4, 23);
            this.tabAS9.Name = "tabAS9";
            this.tabAS9.Size = new System.Drawing.Size(491, 535);
            this.tabAS9.TabIndex = 3;
            this.tabAS9.Text = "AS9";
            this.tabAS9.UseVisualStyleBackColor = true;
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.btnSave);
            this.tabSetting.Controls.Add(this.label4);
            this.tabSetting.Controls.Add(this.label3);
            this.tabSetting.Controls.Add(this.label2);
            this.tabSetting.Controls.Add(this.label1);
            this.tabSetting.Controls.Add(this.txtAS9IP);
            this.tabSetting.Controls.Add(this.txtAS6IP);
            this.tabSetting.Controls.Add(this.txtAS4IP);
            this.tabSetting.Controls.Add(this.txtAS2IP);
            this.tabSetting.Location = new System.Drawing.Point(4, 23);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Size = new System.Drawing.Size(491, 535);
            this.tabSetting.TabIndex = 4;
            this.tabSetting.Text = "Setting";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // txtAS2IP
            // 
            this.txtAS2IP.Location = new System.Drawing.Point(122, 41);
            this.txtAS2IP.Mask = "999.999.999.999";
            this.txtAS2IP.Name = "txtAS2IP";
            this.txtAS2IP.PromptChar = ' ';
            this.txtAS2IP.Size = new System.Drawing.Size(191, 22);
            this.txtAS2IP.TabIndex = 0;
            this.txtAS2IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAS2IP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAS2IP_KeyDown);
            // 
            // txtAS4IP
            // 
            this.txtAS4IP.Location = new System.Drawing.Point(122, 69);
            this.txtAS4IP.Mask = "999.999.999.999";
            this.txtAS4IP.Name = "txtAS4IP";
            this.txtAS4IP.PromptChar = ' ';
            this.txtAS4IP.Size = new System.Drawing.Size(191, 22);
            this.txtAS4IP.TabIndex = 1;
            this.txtAS4IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAS4IP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAS4IP_KeyDown);
            // 
            // txtAS6IP
            // 
            this.txtAS6IP.Location = new System.Drawing.Point(122, 100);
            this.txtAS6IP.Mask = "999.999.999.999";
            this.txtAS6IP.Name = "txtAS6IP";
            this.txtAS6IP.PromptChar = ' ';
            this.txtAS6IP.Size = new System.Drawing.Size(191, 22);
            this.txtAS6IP.TabIndex = 2;
            this.txtAS6IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAS6IP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAS6IP_KeyDown);
            // 
            // txtAS9IP
            // 
            this.txtAS9IP.Location = new System.Drawing.Point(122, 125);
            this.txtAS9IP.Mask = "999.999.999.999";
            this.txtAS9IP.Name = "txtAS9IP";
            this.txtAS9IP.PromptChar = ' ';
            this.txtAS9IP.Size = new System.Drawing.Size(191, 22);
            this.txtAS9IP.TabIndex = 3;
            this.txtAS9IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAS9IP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAS9IP_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "AS2 Robot IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "AS4 Robot IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "AS6 Robot IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "AS9 Robot IP:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(338, 67);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 55);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "AS2 IP:";
            // 
            // txtAS2IPInfo
            // 
            this.txtAS2IPInfo.Location = new System.Drawing.Point(74, 16);
            this.txtAS2IPInfo.Name = "txtAS2IPInfo";
            this.txtAS2IPInfo.ReadOnly = true;
            this.txtAS2IPInfo.Size = new System.Drawing.Size(143, 22);
            this.txtAS2IPInfo.TabIndex = 1;
            this.txtAS2IPInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAS2Run
            // 
            this.btnAS2Run.Location = new System.Drawing.Point(238, 11);
            this.btnAS2Run.Name = "btnAS2Run";
            this.btnAS2Run.Size = new System.Drawing.Size(75, 28);
            this.btnAS2Run.TabIndex = 2;
            this.btnAS2Run.Text = "Run";
            this.btnAS2Run.UseVisualStyleBackColor = true;
            this.btnAS2Run.Click += new System.EventHandler(this.btnAS2Run_Click);
            // 
            // btnAS2Stop
            // 
            this.btnAS2Stop.Enabled = false;
            this.btnAS2Stop.Location = new System.Drawing.Point(319, 11);
            this.btnAS2Stop.Name = "btnAS2Stop";
            this.btnAS2Stop.Size = new System.Drawing.Size(75, 28);
            this.btnAS2Stop.TabIndex = 3;
            this.btnAS2Stop.Text = "Stop";
            this.btnAS2Stop.UseVisualStyleBackColor = true;
            this.btnAS2Stop.Click += new System.EventHandler(this.btnAS2Stop_Click);
            // 
            // lstAS2Alarm
            // 
            this.lstAS2Alarm.FormattingEnabled = true;
            this.lstAS2Alarm.ItemHeight = 14;
            this.lstAS2Alarm.Location = new System.Drawing.Point(6, 53);
            this.lstAS2Alarm.Name = "lstAS2Alarm";
            this.lstAS2Alarm.Size = new System.Drawing.Size(616, 214);
            this.lstAS2Alarm.TabIndex = 4;
            // 
            // lstAS2Info
            // 
            this.lstAS2Info.FormattingEnabled = true;
            this.lstAS2Info.ItemHeight = 14;
            this.lstAS2Info.Location = new System.Drawing.Point(6, 273);
            this.lstAS2Info.Name = "lstAS2Info";
            this.lstAS2Info.Size = new System.Drawing.Size(616, 256);
            this.lstAS2Info.TabIndex = 5;
            // 
            // timerRead_PLC_AS2
            // 
            this.timerRead_PLC_AS2.Tick += new System.EventHandler(this.timerRead_PLC_AS2_Tick);
            // 
            // axActSupportMsg1
            // 
            this.axActSupportMsg1.Enabled = true;
            this.axActSupportMsg1.Location = new System.Drawing.Point(478, 8);
            this.axActSupportMsg1.Name = "axActSupportMsg1";
            this.axActSupportMsg1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActSupportMsg1.OcxState")));
            this.axActSupportMsg1.Size = new System.Drawing.Size(32, 32);
            this.axActSupportMsg1.TabIndex = 5;
            // 
            // axActProgTypeAS9
            // 
            this.axActProgTypeAS9.Enabled = true;
            this.axActProgTypeAS9.Location = new System.Drawing.Point(436, 9);
            this.axActProgTypeAS9.Name = "axActProgTypeAS9";
            this.axActProgTypeAS9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActProgTypeAS9.OcxState")));
            this.axActProgTypeAS9.Size = new System.Drawing.Size(32, 32);
            this.axActProgTypeAS9.TabIndex = 4;
            // 
            // axActProgTypeAS6
            // 
            this.axActProgTypeAS6.Enabled = true;
            this.axActProgTypeAS6.Location = new System.Drawing.Point(398, 9);
            this.axActProgTypeAS6.Name = "axActProgTypeAS6";
            this.axActProgTypeAS6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActProgTypeAS6.OcxState")));
            this.axActProgTypeAS6.Size = new System.Drawing.Size(32, 32);
            this.axActProgTypeAS6.TabIndex = 3;
            // 
            // axActProgTypeAS4
            // 
            this.axActProgTypeAS4.Enabled = true;
            this.axActProgTypeAS4.Location = new System.Drawing.Point(360, 9);
            this.axActProgTypeAS4.Name = "axActProgTypeAS4";
            this.axActProgTypeAS4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActProgTypeAS4.OcxState")));
            this.axActProgTypeAS4.Size = new System.Drawing.Size(32, 32);
            this.axActProgTypeAS4.TabIndex = 2;
            // 
            // axActProgTypeAS2
            // 
            this.axActProgTypeAS2.Enabled = true;
            this.axActProgTypeAS2.Location = new System.Drawing.Point(322, 9);
            this.axActProgTypeAS2.Name = "axActProgTypeAS2";
            this.axActProgTypeAS2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActProgTypeAS2.OcxState")));
            this.axActProgTypeAS2.Size = new System.Drawing.Size(32, 32);
            this.axActProgTypeAS2.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 601);
            this.Controls.Add(this.axActSupportMsg1);
            this.Controls.Add(this.axActProgTypeAS9);
            this.Controls.Add(this.axActProgTypeAS6);
            this.Controls.Add(this.axActProgTypeAS4);
            this.Controls.Add(this.axActProgTypeAS2);
            this.Controls.Add(this.tabATE);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabATE.ResumeLayout(false);
            this.tabAS2.ResumeLayout(false);
            this.tabAS2.PerformLayout();
            this.tabSetting.ResumeLayout(false);
            this.tabSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axActSupportMsg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActProgTypeAS9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActProgTypeAS6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActProgTypeAS4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActProgTypeAS2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabATE;
        private System.Windows.Forms.TabPage tabAS2;
        private System.Windows.Forms.TabPage tabAS4;
        private System.Windows.Forms.TabPage tabAS6;
        private System.Windows.Forms.TabPage tabAS9;
        private AxActProgTypeLib.AxActProgType axActProgTypeAS2;
        private AxActProgTypeLib.AxActProgType axActProgTypeAS4;
        private AxActProgTypeLib.AxActProgType axActProgTypeAS6;
        private AxActProgTypeLib.AxActProgType axActProgTypeAS9;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.MaskedTextBox txtAS9IP;
        private System.Windows.Forms.MaskedTextBox txtAS6IP;
        private System.Windows.Forms.MaskedTextBox txtAS4IP;
        private System.Windows.Forms.MaskedTextBox txtAS2IP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAS2Stop;
        private System.Windows.Forms.Button btnAS2Run;
        private System.Windows.Forms.TextBox txtAS2IPInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstAS2Info;
        private System.Windows.Forms.ListBox lstAS2Alarm;
        private System.Windows.Forms.Timer timerRead_PLC_AS2;
        private AxActSupportMsgLib.AxActSupportMsg axActSupportMsg1;
    }
}

