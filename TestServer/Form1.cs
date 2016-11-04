using System;
using System.Windows.Forms;
using EE.Services.Pay.InertnetVer.ReceiveBankReq;
using EE.Services.Pay.InertnetVer;
using EE.Services.Pay.Model.Req;
using EE.Services.Pay.Common;
using EE.Services.Pay.Model;
using EE.Services.Pay.Model.Res;
using EE.Services.Pay.Common.Ext;
using System.Collections.Generic;
using System.Threading;
using EE.Services.Pay;
using System.IO;
using EE.Services.Pay.PayTestDemo;

namespace TestServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.PinganPayConfig = GlobalData.LoadPinganConfig();
        }

        PinganPayConfig PinganPayConfig = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            //BootStart.HttpListener();
            BootStart.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //BootStart.HttpListener(true);
            BootStart.Stop();
        }
        //单笔代发请使用4004/4014/4018转账接口
        private void btnCall_Click(object sender, EventArgs e)
        {
            string strCode = txtCode.Text.Trim();
            string strMessage = r1.Text.Trim();
            new Thread(p =>
            {
                TestMethod(strCode, strMessage);
            }).Start();
        }
        public void TestMethod(string code, string message)
        {
            PayTest.Invoke(code, message);           
        }
        #region 设置
        PinganPayConfig pinganPayConfig = null;
        private void btnSave_Click(object sender, EventArgs e)
        {
            SpotTranInterface clientToBankInterface = new SpotTranInterface();
            pinganPayConfig.UpSetting.IP = txtIP.Text.Trim();
            pinganPayConfig.UpSetting.Port = int.Parse(txtPort.Text.Trim());
            pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.Qydm = txtQiYeDaiMa.Text.Trim();
            pinganPayConfig.DownSetting.ListenPort = int.Parse(txtDownPort.Text.Trim());
            pinganPayConfig.DownSetting.ListenIP = txtDownIP.Text.Trim();
            pinganPayConfig.OpenLog = ckLog.Checked;
            clientToBankInterface.SaveConfig(pinganPayConfig);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BankInterface.Console += new OutPut((a, b) =>
            {
                this.Invoke(new UIItem(() =>
                {
                    r1.Text = a;
                    r2.Text = b;
                }));
            });


            SpotTranInterface clientToBankInterface = new SpotTranInterface();
            pinganPayConfig = clientToBankInterface.ReLoadConfig();
            initUI();
        }
        public void initUI()
        {
            txtIP.Text = pinganPayConfig.UpSetting.IP;
            txtPort.Text = pinganPayConfig.UpSetting.Port.ToString();
            txtDownIP.Text = pinganPayConfig.DownSetting.ListenIP;
            txtDownPort.Text = pinganPayConfig.DownSetting.ListenPort.ToString();
            txtQiYeDaiMa.Text = pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.Qydm;

        }
        //直接发送测试
        private void btnSend_Click(object sender, EventArgs e)
        {
            string strMessage = r1.Text.Trim();
            new Thread(p =>
            {
                BankInterface bank = new BankInterface();
                string strResult = bank.SendMessage(strMessage);
            }).Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Environment.Exit(0);
                Application.Exit();
            }
            catch (Exception)
            {
            }
        }

        #endregion       
    }
}
