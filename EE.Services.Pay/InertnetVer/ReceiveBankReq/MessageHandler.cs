using System;
using System.Text;
using System.Net.Sockets;
using EE.Services.Pay.Common;
using System.Threading;
using NLog;
namespace EE.Services.Pay.InertnetVer.ReceiveBankReq
{
    /// <summary>
    /// 处理接收到的请求 下行通讯
    /// </summary>
    public class MessageHandler
    {
        TcpClient tcpClient = null;
        Thread socketThread = null;
        bool mStopped = false;

        public MessageHandler(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
        }
        public void Start()
        {
            //StopHandler();
            mStopped = false;
            this.socketThread = new Thread(new ThreadStart(Run));
            this.socketThread.Start();
        }
        public void Stop()
        {
            try
            {
                if (this.tcpClient != null)
                    this.tcpClient.Close();
            }
            catch { }
            try
            {
                if (this.socketThread != null && this.socketThread.IsAlive)
                    this.socketThread.Abort();
            }
            catch { }
            this.tcpClient = null;
            this.socketThread = null;
        }
        public void StopHandler()
        {
            mStopped = true;
            Stop();
        }
        /// <summary>
        /// 处理请求
        /// </summary>
        private void Run()
        {
            string recv = string.Empty;
            //没有停止并且保持连接的状态 才可以处理接收的数据
            while (!mStopped && this.tcpClient.Connected)
            {
                try
                {
                    //获取网络流对象
                    NetworkStream ns = this.tcpClient.GetStream();
                    recv = new ErpClient().RecvMessage(this.tcpClient.Client);

                    #region 无边界性的接收
                    //MemoryStream ms = new MemoryStream();
                    //byte[] buf = new byte[4096];
                    //int len = -1;
                    ////阻塞读取
                    //while ((len = ns.Read(buf, 0, buf.Length)) != -1)
                    //{
                    //    //断开连接或者超时
                    //    if (len == 0) break;
                    //    //写入到内存中
                    //    ms.Write(buf, 0, len);
                    //}
                    //ns.Close();

                    //byte[] resbyte = ms.ToArray();
                    //recv = Utils.ToGBK(resbyte, 0, resbyte.Length);
                    //ms.Close();
                    #endregion

                    //处理
                    HandleMessage(recv, ns);
                    //关闭
                    StopHandler();
                }
                catch (Exception ex)
                {
                    //记录日志 
                    if (!ex.Message.Contains("正在中止线程") 
                        && !ex.Message.Contains("强迫关闭")) LogManager.GetCurrentClassLogger().Error(ex);
                }
            }
        }
        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="recv">接收到的数据</param>
        /// <param name="ns">网络流对象</param>
        private void HandleMessage(string recv, NetworkStream ns)
        {
            //给银行的应答数据
            string back = string.Empty, TargetSystem = "", ExMessage = string.Empty;
            //解析的值
            ExHashTable retKeyDict = new ExHashTable();
            try
            {
                if (!string.IsNullOrEmpty(recv))
                {
                    //解析接收到的银行的数据
                    BankInterface bankReq = new BankInterface();
                    TargetSystem = Utils.GetTargetSystem(recv);
                    if (TargetSystem == "03")
                    {
                        //老版本 交易资金03
                        retKeyDict = bankReq.ParsingTranMessageString(recv);
                        back = bankReq.GetTranMessageRes(retKeyDict);
                    }
                    else if (TargetSystem == "01")
                    {
                        //新版本 银企直连01
                        retKeyDict = bankReq.ParsingBankEnterpriseMessageString(recv);
                        //构建返回数据给银行
                        back = string.Join("", bankReq.GetBankEnterpriseMessageRes(retKeyDict).ToArray());
                    }
                }
                byte[] BackBytes = Utils.ToByte(back);
                ns.Write(BackBytes, 0, BackBytes.Length);
                ns.Flush();
                ns.Close();
            }
            catch (Exception ex)
            {
                ExMessage = ex.Message;
                throw ex;
            }
            finally
            {
                StringBuilder sbLog = new StringBuilder();
                sbLog.AppendFormat("时间:{0}\r\n", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sbLog.AppendFormat("接收数据:{0}\r\n", recv);
                sbLog.AppendFormat("响应数据:{0}\r\n", back);
                if (!string.IsNullOrEmpty(ExMessage))
                    sbLog.AppendFormat("异常信息:{0}\r\n", ExMessage);
                sbLog.AppendFormat("解析结果:\r\n{0}\r\n\r\n\r\n", retKeyDict.ToString());
                if (GlobalData.LoadPinganConfig().OpenLog)
                    FileHelper.SaveFile(string.Format("Log\\Recv\\{0}{1}\\bankRecv_{2}.txt", (!string.IsNullOrEmpty(TargetSystem) ? (TargetSystem + "\\") : ""), System.DateTime.Now.ToString("yyyyMMdd"), System.DateTime.Now.ToString("HH")), sbLog.ToString());
            }
        }
    }
}
