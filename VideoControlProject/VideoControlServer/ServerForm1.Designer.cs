namespace VideoControlServer
{
    partial class ServerForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm1));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.loadVideoBtn = new System.Windows.Forms.Button();
            this.encodeVideoBtn = new System.Windows.Forms.Button();
            this.sendVideoBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bitRateComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Client_IP_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(121, 26);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(409, 270);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // loadVideoBtn
            // 
            this.loadVideoBtn.Location = new System.Drawing.Point(121, 331);
            this.loadVideoBtn.Name = "loadVideoBtn";
            this.loadVideoBtn.Size = new System.Drawing.Size(107, 34);
            this.loadVideoBtn.TabIndex = 1;
            this.loadVideoBtn.Text = "Load Video";
            this.loadVideoBtn.UseVisualStyleBackColor = true;
            this.loadVideoBtn.Click += new System.EventHandler(this.loadVideoBtn_Click);
            // 
            // encodeVideoBtn
            // 
            this.encodeVideoBtn.Location = new System.Drawing.Point(274, 331);
            this.encodeVideoBtn.Name = "encodeVideoBtn";
            this.encodeVideoBtn.Size = new System.Drawing.Size(115, 34);
            this.encodeVideoBtn.TabIndex = 2;
            this.encodeVideoBtn.Text = "Encode Video";
            this.encodeVideoBtn.UseVisualStyleBackColor = true;
            this.encodeVideoBtn.Click += new System.EventHandler(this.encodeVideoBtn_Click);
            // 
            // sendVideoBtn
            // 
            this.sendVideoBtn.Location = new System.Drawing.Point(421, 331);
            this.sendVideoBtn.Name = "sendVideoBtn";
            this.sendVideoBtn.Size = new System.Drawing.Size(109, 34);
            this.sendVideoBtn.TabIndex = 3;
            this.sendVideoBtn.Text = "Send Video";
            this.sendVideoBtn.UseVisualStyleBackColor = true;
            this.sendVideoBtn.Click += new System.EventHandler(this.sendVideoBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose BitRate";
            // 
            // bitRateComboBox
            // 
            this.bitRateComboBox.FormattingEnabled = true;
            this.bitRateComboBox.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "600",
            "800",
            "900",
            "1000",
            "1200",
            "1500",
            "1800"});
            this.bitRateComboBox.Location = new System.Drawing.Point(224, 408);
            this.bitRateComboBox.Name = "bitRateComboBox";
            this.bitRateComboBox.Size = new System.Drawing.Size(121, 21);
            this.bitRateComboBox.TabIndex = 5;
            this.bitRateComboBox.SelectedIndexChanged += new System.EventHandler(this.bitRateComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(364, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "kbits/sec";
            // 
            // Client_IP_txt
            // 
            this.Client_IP_txt.Location = new System.Drawing.Point(610, 26);
            this.Client_IP_txt.Name = "Client_IP_txt";
            this.Client_IP_txt.Size = new System.Drawing.Size(205, 20);
            this.Client_IP_txt.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(645, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Enter client IP Address";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(648, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 60);
            this.button1.TabIndex = 9;
            this.button1.Text = "Send Video FileName to Client";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(648, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 45);
            this.button2.TabIndex = 10;
            this.button2.Text = "Split Video";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ServerForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 579);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Client_IP_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bitRateComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendVideoBtn);
            this.Controls.Add(this.encodeVideoBtn);
            this.Controls.Add(this.loadVideoBtn);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServerForm1";
            this.Text = "Video Control Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button loadVideoBtn;
        private System.Windows.Forms.Button encodeVideoBtn;
        private System.Windows.Forms.Button sendVideoBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox bitRateComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Client_IP_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

