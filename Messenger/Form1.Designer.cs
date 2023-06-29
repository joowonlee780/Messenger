namespace Messenger
{
    partial class Messenger
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.disconnectedBox = new System.Windows.Forms.PictureBox();
            this.connectedBox = new System.Windows.Forms.PictureBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.sendBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.ListBox();
            this.serverRadioButton = new System.Windows.Forms.RadioButton();
            this.clientRadioButton = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.disconnectedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectedBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox5.Location = new System.Drawing.Point(20, 62);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(121, 37);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "Port";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox4.Location = new System.Drawing.Point(20, 12);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(121, 37);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "IP";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(156, 62);
            this.portBox.MaxLength = 5;
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(133, 32);
            this.portBox.TabIndex = 9;
            this.portBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Port_Box_Enter_Press);
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(156, 12);
            this.ipBox.MaxLength = 15;
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(300, 32);
            this.ipBox.TabIndex = 8;
            this.ipBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ip_Box_Enter_Press);
            // 
            // disconnectedBox
            // 
            this.disconnectedBox.BackColor = System.Drawing.Color.Red;
            this.disconnectedBox.Location = new System.Drawing.Point(833, 47);
            this.disconnectedBox.Name = "disconnectedBox";
            this.disconnectedBox.Size = new System.Drawing.Size(53, 47);
            this.disconnectedBox.TabIndex = 13;
            this.disconnectedBox.TabStop = false;
            // 
            // connectedBox
            // 
            this.connectedBox.BackColor = System.Drawing.Color.Lime;
            this.connectedBox.Location = new System.Drawing.Point(747, 47);
            this.connectedBox.Name = "connectedBox";
            this.connectedBox.Size = new System.Drawing.Size(53, 47);
            this.connectedBox.TabIndex = 12;
            this.connectedBox.TabStop = false;
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.connectButton.Location = new System.Drawing.Point(493, 68);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(190, 50);
            this.connectButton.TabIndex = 14;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.Connect_Button_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.startButton.Location = new System.Drawing.Point(493, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(190, 50);
            this.startButton.TabIndex = 15;
            this.startButton.Text = "Start Server";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.Server_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exitButton.Location = new System.Drawing.Point(924, 15);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 100);
            this.exitButton.TabIndex = 17;
            this.exitButton.Text = "나가기";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // sendBox
            // 
            this.sendBox.Location = new System.Drawing.Point(20, 942);
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(866, 32);
            this.sendBox.TabIndex = 20;
            this.sendBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Send_Box_Enter_Press);
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sendButton.Location = new System.Drawing.Point(920, 905);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(200, 100);
            this.sendButton.TabIndex = 19;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // messageBox
            // 
            this.messageBox.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.messageBox.FormattingEnabled = true;
            this.messageBox.ItemHeight = 26;
            this.messageBox.Location = new System.Drawing.Point(20, 180);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(1100, 680);
            this.messageBox.TabIndex = 21;
            // 
            // serverRadioButton
            // 
            this.serverRadioButton.AutoSize = true;
            this.serverRadioButton.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.serverRadioButton.Location = new System.Drawing.Point(156, 124);
            this.serverRadioButton.Name = "serverRadioButton";
            this.serverRadioButton.Size = new System.Drawing.Size(116, 31);
            this.serverRadioButton.TabIndex = 22;
            this.serverRadioButton.TabStop = true;
            this.serverRadioButton.Text = "Server";
            this.serverRadioButton.UseVisualStyleBackColor = true;
            this.serverRadioButton.Click += new System.EventHandler(this.Server_Check);
            // 
            // clientRadioButton
            // 
            this.clientRadioButton.AutoSize = true;
            this.clientRadioButton.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.clientRadioButton.Location = new System.Drawing.Point(278, 124);
            this.clientRadioButton.Name = "clientRadioButton";
            this.clientRadioButton.Size = new System.Drawing.Size(108, 31);
            this.clientRadioButton.TabIndex = 23;
            this.clientRadioButton.TabStop = true;
            this.clientRadioButton.Text = "Client";
            this.clientRadioButton.UseVisualStyleBackColor = true;
            this.clientRadioButton.Click += new System.EventHandler(this.Client_Check);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("굴림", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(20, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(121, 37);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "Mode";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Messenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1176, 1036);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.clientRadioButton);
            this.Controls.Add(this.serverRadioButton);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.sendBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.disconnectedBox);
            this.Controls.Add(this.connectedBox);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipBox);
            this.Name = "Messenger";
            this.Text = "Messenger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Close);
            ((System.ComponentModel.ISupportInitialize)(this.disconnectedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectedBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.PictureBox disconnectedBox;
        private System.Windows.Forms.PictureBox connectedBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox sendBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ListBox messageBox;
        private System.Windows.Forms.RadioButton serverRadioButton;
        private System.Windows.Forms.RadioButton clientRadioButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}

