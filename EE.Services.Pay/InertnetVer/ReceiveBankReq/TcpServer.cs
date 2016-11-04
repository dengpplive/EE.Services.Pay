using System;
using System.Net;
using System.Net.Sockets;
using EE.Services.Pay.Common;
using System.Threading;
using NLog;
using EE.Services.Pay.Model;

namespace EE.Services.Pay.InertnetVer.ReceiveBankReq
{
    /// <summary>
    /// TCP接收请求
    /// </summary>
    public class TcpServer
    {
        ExHashTable hashtable = new ExHashTable();
        PinganPayConfig pinganPayConfig = null;
        Thread serverThread = null;
        TcpListener tcpListener = null;
        bool mStopped = false;

        public TcpServer()
        {
            pinganPayConfig = ConfigManage.GetPinganPayConfig();
        }
        /// <summary>
        /// 启动监听的服务
        /// </summary>
        public void Start()
        {
            Stop();
            mStopped = false;
            serverThread = new Thread(new ThreadStart(ListenerProc));
            serverThread.IsBackground = true;
            serverThread.Start();
        }
        /// <summary>
        /// 停止监听的服务
        /// </summary>
        public void Stop()
        {
            mStopped = true;
            try
            {
                if (tcpListener != null) tcpListener.Stop();
            }
            catch { }
            try
            {
                if (serverThread != null && serverThread.IsAlive) serverThread.Abort();
            }
            catch { }
            serverThread = null;
            tcpListener = null;
        }

        /// <summary>
        /// 创建监听对象 并且开始监听指定的端口号
        /// </summary>
        private void CreateTcpListener()
        {
            tcpListener = new TcpListener(IPAddress.Any, pinganPayConfig.DownSetting.ListenPort);          
            tcpListener.Start();
            Console.WriteLine("启动tcp监听端口号:" + pinganPayConfig.DownSetting.ListenPort);
            FileHelper.SaveFile("text.txt", $"{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}启动监听端口号:{pinganPayConfig.DownSetting.ListenPort}");
        }
        /// <summary> 
        /// 同步处理请求
        /// </summary>
        private void ListenerProc()
        {
            //创建监听对象
            CreateTcpListener();
            while (!mStopped)
            {
                try
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    MessageHandler handler = new MessageHandler(tcpClient);
                    handler.Start();
                }
                catch (Exception ex)
                {
                    //记录日志
                    LogManager.GetCurrentClassLogger().Error(ex);
                    FileHelper.SaveFile("text.txt", ex.Message + "\r\n\r\n");
                }
            }
        }
    }
}
