namespace SmartLampLight
{
    partial class Form1
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
            this.serialNumberBox = new System.Windows.Forms.ListBox();
            this.installButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.showBox = new System.Windows.Forms.ListBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.serialRefreshButton = new System.Windows.Forms.Button();
            this.apkBrowseButton = new System.Windows.Forms.Button();
            this.downAllButton = new System.Windows.Forms.Button();
            this.downSelButton = new System.Windows.Forms.Button();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.apkNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.installProgressBar = new System.Windows.Forms.ProgressBar();
            this.installingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serialNumberBox
            // 
            this.serialNumberBox.FormattingEnabled = true;
            this.serialNumberBox.ItemHeight = 12;
            this.serialNumberBox.Location = new System.Drawing.Point(35, 45);
            this.serialNumberBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.serialNumberBox.Name = "serialNumberBox";
            this.serialNumberBox.Size = new System.Drawing.Size(186, 52);
            this.serialNumberBox.TabIndex = 1;
            this.serialNumberBox.SelectedIndexChanged += new System.EventHandler(this.serialNumberBox_SelectedIndexChanged);
            // 
            // installButton
            // 
            this.installButton.Location = new System.Drawing.Point(532, 45);
            this.installButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(63, 80);
            this.installButton.TabIndex = 2;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(418, 205);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(79, 30);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(514, 205);
            this.stopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(81, 30);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // showBox
            // 
            this.showBox.FormattingEnabled = true;
            this.showBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.showBox.IntegralHeight = false;
            this.showBox.ItemHeight = 12;
            this.showBox.Location = new System.Drawing.Point(35, 258);
            this.showBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showBox.Name = "showBox";
            this.showBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.showBox.Size = new System.Drawing.Size(560, 308);
            this.showBox.TabIndex = 5;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(35, 204);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(79, 31);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // serialRefreshButton
            // 
            this.serialRefreshButton.Location = new System.Drawing.Point(149, 102);
            this.serialRefreshButton.Name = "serialRefreshButton";
            this.serialRefreshButton.Size = new System.Drawing.Size(72, 23);
            this.serialRefreshButton.TabIndex = 7;
            this.serialRefreshButton.Text = "Refresh";
            this.serialRefreshButton.UseVisualStyleBackColor = true;
            this.serialRefreshButton.Click += new System.EventHandler(this.serialRefreshButton_Click);
            // 
            // apkBrowseButton
            // 
            this.apkBrowseButton.Location = new System.Drawing.Point(422, 102);
            this.apkBrowseButton.Name = "apkBrowseButton";
            this.apkBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.apkBrowseButton.TabIndex = 8;
            this.apkBrowseButton.Text = "Browse";
            this.apkBrowseButton.UseVisualStyleBackColor = true;
            this.apkBrowseButton.Click += new System.EventHandler(this.apkBrowseButton_Click);
            // 
            // downAllButton
            // 
            this.downAllButton.Location = new System.Drawing.Point(35, 608);
            this.downAllButton.Name = "downAllButton";
            this.downAllButton.Size = new System.Drawing.Size(230, 42);
            this.downAllButton.TabIndex = 9;
            this.downAllButton.Text = "Download Full Log";
            this.downAllButton.UseVisualStyleBackColor = true;
            this.downAllButton.Click += new System.EventHandler(this.downAllButton_Click);
            // 
            // downSelButton
            // 
            this.downSelButton.Location = new System.Drawing.Point(346, 608);
            this.downSelButton.Name = "downSelButton";
            this.downSelButton.Size = new System.Drawing.Size(249, 42);
            this.downSelButton.TabIndex = 10;
            this.downSelButton.Text = "Download Selected";
            this.downSelButton.UseVisualStyleBackColor = true;
            this.downSelButton.Click += new System.EventHandler(this.downSelButton_Click);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(559, 680);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(56, 12);
            this.linkLabel.TabIndex = 11;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "sookylee";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(35, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "device S/N";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(263, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "apk File";
            // 
            // apkNameBox
            // 
            this.apkNameBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.apkNameBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.apkNameBox.Location = new System.Drawing.Point(266, 76);
            this.apkNameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.apkNameBox.Name = "apkNameBox";
            this.apkNameBox.ReadOnly = true;
            this.apkNameBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.apkNameBox.Size = new System.Drawing.Size(232, 21);
            this.apkNameBox.TabIndex = 14;
            this.apkNameBox.Text = "None";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "filename : ";
            // 
            // installProgressBar
            // 
            this.installProgressBar.Location = new System.Drawing.Point(35, 135);
            this.installProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.installProgressBar.Name = "installProgressBar";
            this.installProgressBar.Size = new System.Drawing.Size(559, 18);
            this.installProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.installProgressBar.TabIndex = 16;
            this.installProgressBar.Visible = false;
            // 
            // installingLabel
            // 
            this.installingLabel.AutoSize = true;
            this.installingLabel.Location = new System.Drawing.Point(272, 162);
            this.installingLabel.Name = "installingLabel";
            this.installingLabel.Size = new System.Drawing.Size(79, 12);
            this.installingLabel.TabIndex = 17;
            this.installingLabel.Text = "installing..0%";
            this.installingLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 702);
            this.Controls.Add(this.installingLabel);
            this.Controls.Add(this.installProgressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.apkNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.downSelButton);
            this.Controls.Add(this.downAllButton);
            this.Controls.Add(this.apkBrowseButton);
            this.Controls.Add(this.serialRefreshButton);
            this.Controls.Add(this.showBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.serialNumberBox);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "CheckLampLight  ver.1.1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox serialNumberBox;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ListBox showBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button serialRefreshButton;
        private System.Windows.Forms.Button apkBrowseButton;
        private System.Windows.Forms.Button downAllButton;
        private System.Windows.Forms.Button downSelButton;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox apkNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar installProgressBar;
        private System.Windows.Forms.Label installingLabel;
    }
}

