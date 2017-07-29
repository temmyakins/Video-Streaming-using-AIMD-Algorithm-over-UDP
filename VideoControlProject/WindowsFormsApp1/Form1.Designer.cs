namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.servertext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bitRateComboBox = new System.Windows.Forms.ComboBox();
            this.sendVideoBtn = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.connectServerButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.videoOption = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // servertext
            // 
            this.servertext.Location = new System.Drawing.Point(12, 31);
            this.servertext.Name = "servertext";
            this.servertext.Size = new System.Drawing.Size(163, 20);
            this.servertext.TabIndex = 1;
            this.servertext.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server IP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.bitRateComboBox.Location = new System.Drawing.Point(422, 58);
            this.bitRateComboBox.Name = "bitRateComboBox";
            this.bitRateComboBox.Size = new System.Drawing.Size(121, 21);
            this.bitRateComboBox.TabIndex = 6;
            this.bitRateComboBox.SelectedIndexChanged += new System.EventHandler(this.bitRateComboBox_SelectedIndexChanged);
            // 
            // sendVideoBtn
            // 
            this.sendVideoBtn.Location = new System.Drawing.Point(422, 94);
            this.sendVideoBtn.Name = "sendVideoBtn";
            this.sendVideoBtn.Size = new System.Drawing.Size(208, 24);
            this.sendVideoBtn.TabIndex = 8;
            this.sendVideoBtn.Text = "Send Video";
            this.sendVideoBtn.UseVisualStyleBackColor = true;
            this.sendVideoBtn.Click += new System.EventHandler(this.sendVideoBtn_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(109, 146);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(500, 381);
            this.axWindowsMediaPlayer1.TabIndex = 9;
            // 
            // connectServerButton
            // 
            this.connectServerButton.Location = new System.Drawing.Point(35, 57);
            this.connectServerButton.Name = "connectServerButton";
            this.connectServerButton.Size = new System.Drawing.Size(109, 21);
            this.connectServerButton.TabIndex = 10;
            this.connectServerButton.Text = "Connect to server";
            this.connectServerButton.UseVisualStyleBackColor = true;
            this.connectServerButton.Click += new System.EventHandler(this.ConnectServer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(549, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Choose a video";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(549, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "kbits/second";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // videoOption
            // 
            this.videoOption.FormattingEnabled = true;
            this.videoOption.Items.AddRange(new object[] {
            "Wildlife.wmv"});
            this.videoOption.Location = new System.Drawing.Point(422, 26);
            this.videoOption.Name = "videoOption";
            this.videoOption.Size = new System.Drawing.Size(121, 21);
            this.videoOption.TabIndex = 14;
            this.videoOption.SelectedIndexChanged += new System.EventHandler(this.videoOption_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 548);
            this.Controls.Add(this.videoOption);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.connectServerButton);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.sendVideoBtn);
            this.Controls.Add(this.bitRateComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.servertext);
            this.Name = "Form1";
            this.Text = "VideoControlClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox servertext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox bitRateComboBox;
        private System.Windows.Forms.Button sendVideoBtn;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button connectServerButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox videoOption;
    }
}

