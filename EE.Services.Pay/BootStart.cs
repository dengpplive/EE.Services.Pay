using EE.Services.Pay.Common;
using EE.Services.Pay.InertnetVer.HttpNotify;
using EE.Services.Pay.InertnetVer.ReceiveBankReq;
namespace EE.Services.Pay
{
    /// <summary>
    /// 启动Tcp或者Http的监听 接收银行的请求并且处理返回应答银行
    /// </summary>
    public class BootStart
    {
        static TcpServer tcpServer = new TcpServer();
        static HttpServer httpServer = new HttpServer();
        /// <summary>
        /// 启动/停止TCP监听的银行请求
        /// </summary>
        private static void TcpListener(bool isStop = false)
        {
            if (!isStop)
            {
                tcpServer.Start();
            }
            else
            {
                tcpServer.Stop();
            }
        }
        /// <summary>
        /// 启动/停止Http监听的银行请求
        /// </summary>
        private static void HttpListener(bool isStop = false)
        {
            if (!isStop)
            {
                httpServer.Start();
            }
            else
            {
                httpServer.Stop();
            }
        }
        public static void Start(string teleProtocol = "01")
        {
            if (teleProtocol == "01")
            {
                BootStart.TcpListener();
            }
            else if (teleProtocol == "02")
            {
                BootStart.HttpListener();
            }
        }
        public static void Stop(string teleProtocol = "01")
        {
            if (teleProtocol == "01")
            {
                BootStart.TcpListener(true);
            }
            else if (teleProtocol == "02")
            {
                BootStart.HttpListener(true);
            }
        }
    }
}
