namespace TestServer
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnCall = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQiYeDaiMa = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.r1 = new System.Windows.Forms.RichTextBox();
            this.r2 = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtDownPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDownIP = new System.Windows.Forms.TextBox();
            this.ckLog = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(24, 326);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "启动下行监听";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(130, 326);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(97, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "停止下行监听";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(398, 326);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(134, 23);
            this.btnCall.TabIndex = 4;
            this.btnCall.Text = "调用测试接口";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "上行监听端口：";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(335, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(53, 21);
            this.txtPort.TabIndex = 6;
            this.txtPort.Text = "7072";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "企业代码：";
            // 
            // txtQiYeDaiMa
            // 
            this.txtQiYeDaiMa.Location = new System.Drawing.Point(92, 2);
            this.txtQiYeDaiMa.Name = "txtQiYeDaiMa";
            this.txtQiYeDaiMa.Size = new System.Drawing.Size(139, 21);
            this.txtQiYeDaiMa.TabIndex = 6;
            this.txtQiYeDaiMa.Text = "7072";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(447, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // r1
            // 
            this.r1.Location = new System.Drawing.Point(17, 85);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(498, 96);
            this.r1.TabIndex = 8;
            this.r1.Text = "";
            // 
            // r2
            // 
            this.r2.Location = new System.Drawing.Point(17, 209);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(498, 96);
            this.r2.TabIndex = 8;
            this.r2.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(440, 181);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtDownPort
            // 
            this.txtDownPort.Location = new System.Drawing.Point(479, 2);
            this.txtDownPort.Name = "txtDownPort";
            this.txtDownPort.Size = new System.Drawing.Size(45, 21);
            this.txtDownPort.TabIndex = 10;
            this.txtDownPort.Text = "8688";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "下行监听端口：";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(304, 32);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(72, 21);
            this.txtIP.TabIndex = 12;
            this.txtIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "上行IP：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "下行IP：";
            // 
            // txtDownIP
            // 
            this.txtDownIP.Location = new System.Drawing.Point(448, 29);
            this.txtDownIP.Name = "txtDownIP";
            this.txtDownIP.Size = new System.Drawing.Size(72, 21);
            this.txtDownIP.TabIndex = 12;
            this.txtDownIP.Text = "127.0.0.1";
            // 
            // ckLog
            // 
            this.ckLog.AutoSize = true;
            this.ckLog.Checked = true;
            this.ckLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckLog.Location = new System.Drawing.Point(17, 29);
            this.ckLog.Name = "ckLog";
            this.ckLog.Size = new System.Drawing.Size(72, 16);
            this.ckLog.TabIndex = 13;
            this.ckLog.Text = "记录日志";
            this.ckLog.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "测试交易码：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(106, 58);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(139, 21);
            this.txtCode.TabIndex = 6;
            this.txtCode.Text = "1343";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.ckLog);
            this.Controls.Add(this.txtDownIP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDownPort);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.r2);
            this.Controls.Add(this.r1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtQiYeDaiMa);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQiYeDaiMa;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox r1;
        private System.Windows.Forms.RichTextBox r2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtDownPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDownIP;
        private System.Windows.Forms.CheckBox ckLog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCode;
    }
}

