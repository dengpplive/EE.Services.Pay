using NLog;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace EE.Services.Pay.Common
{
    /// <summary>
    /// ErpClient 处理tcp的连接
    /// </summary>
    public class ErpClient
    {
        public ErpClient()
        {
        }
        /// <summary>
        /// 上行请求 发送请求
        /// </summary>
        /// <param name="message">发送的内容</param>
        /// <param name="setting">发送前的设置</param>
        /// <returns></returns>
        public string SendUpMessage(string message, Action<TcpClient> setting = null)
        {
            String recvMessage = string.Empty;
            try
            {
                var pinganPayConfig = ConfigManage.GetPinganPayConfig();
                using (TcpClient tcpClient = new TcpClient())
                {
                    if (setting == null)
                    {
                        //设置
                        tcpClient.SendTimeout = pinganPayConfig.UpSetting.SendTimeout * 1000;
                        tcpClient.ReceiveTimeout = pinganPayConfig.UpSetting.ReceiveTimeout * 1000;
                        tcpClient.NoDelay = pinganPayConfig.UpSetting.NoDelay;
                        tcpClient.SendBufferSize = pinganPayConfig.UpSetting.SendBufferSize;
                    }
                    else
                    {
                        setting(tcpClient);
                    }
                    //连接
                    tcpClient.Connect(pinganPayConfig.UpSetting.IP, pinganPayConfig.UpSetting.Port);
                    if (tcpClient.Connected)
                    {
                        NetworkStream ns = tcpClient.GetStream();
                        byte[] sendBytes = Utils.ToByte(message);
                        ns.Write(sendBytes, 0, sendBytes.Length);
                        ns.Flush();
                        //获取内容
                        recvMessage = RecvMessage(tcpClient.Client);
                        ns.Close();
                        tcpClient.Close();

                        #region 无边界性的接收
                        //MemoryStream ms = new MemoryStream();
                        //byte[] buf = new byte[pinganPayConfig.UpSetting.SendBufferSize];
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
                        //recvMessage = Utils.ToGBK(resbyte, 0, resbyte.Length);
                        //ms.Close();
                        #endregion

                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error("[请求数据]:" + message + " 返回:" + recvMessage, ex);
                //throw ex;
            }
            return recvMessage;
        }

        /// <summary>
        /// 银行和企业的  下行请求 发送请求
        /// </summary>
        /// <param name="message">发送的内容</param>
        /// <param name="setting">发送前的设置</param>
        /// <returns></returns>
        public string SendDownMessage(string message, Action<Socket> setting = null)
        {
            String recvMessage = string.Empty;
            try
            {
                var pinganPayConfig = ConfigManage.GetPinganPayConfig();
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    if (setting == null)
                    {
                        //设置                       
                        socket.SendTimeout = pinganPayConfig.DownSetting.SendTimeout * 1000;
                        socket.ReceiveTimeout = pinganPayConfig.DownSetting.ReceiveTimeout * 1000;
                        socket.NoDelay = pinganPayConfig.DownSetting.NoDelay;
                        socket.SendBufferSize = pinganPayConfig.DownSetting.SendBufferSize;
                        socket.ReceiveBufferSize = pinganPayConfig.DownSetting.SendBufferSize;
                    }
                    else
                    {
                        setting(socket);
                    }
                    //连接
                    socket.Connect(pinganPayConfig.DownSetting.ListenIP, pinganPayConfig.DownSetting.ListenPort);
                    if (socket.Connected)
                    {
                        //发送数据
                        byte[] sendBytes = Utils.ToByte(message);
                        int sendLen = socket.Send(sendBytes);

                        //测试
                        //Thread.CurrentThread.Join();
                        //接收数据
                        recvMessage = RecvMessage(socket);
                    }
                    socket.Close();
                }
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error("[请求数据]:" + message, ex);
                //throw ex;
            }
            return recvMessage;
        }

        /// <summary>
        /// Socket读取消息内容
        /// </summary>
        /// <param name="socket">Socket对象</param>
        /// <returns></returns>
        public string RecvMessage(Socket socket)
        {
            return Recv8or122Message(socket);
            #region old
            /*
             string result = string.Empty;
             try
             {
                 //报文头长度
                 int headLength = 222;
                 byte[] headBytes = new byte[headLength];
                 //报文体长度的标识数据
                 byte[] dataLength = new byte[10];
                 //偏移位置
                 int bytes = 0;
                 //读取总数
                 int totalbytes = 0;
                 while (totalbytes < headLength)
                 {
                     bytes = socket.Receive(headBytes, bytes, headLength - bytes, 0);
                     //断开连接或者超时
                     if (bytes <= 0)
                         break;
                     totalbytes += bytes;
                 }
                 //接收头部信息错误 返回空字串
                 if (headLength != totalbytes) return result;
                 //获取报文头中长度的标识字符串
                 Array.Copy(headBytes, 30, dataLength, 0, dataLength.Length);
                 string strDataLength = Encoding.UTF8.GetString(dataLength);
                 int len = Convert.ToInt32(strDataLength);
                 //存放报文体的数据
                 byte[] recvBytes = new byte[len];
                 bytes = 0;
                 totalbytes = 0;
                 while (totalbytes < len)
                 {
                     //从客户端接受信息
                     bytes = socket.Receive(recvBytes, bytes, len - bytes, 0);
                     //断开连接或者超时跳出
                     if (bytes <= 0)
                         break;
                     totalbytes += bytes;
                 }
                 //报文头部信息
                 string headStr = Utils.ToGBK(headBytes, 0, headBytes.Length);
                 //报文体信息
                 result = headStr + Utils.ToGBK(recvBytes, 0, recvBytes.Length);
             }
             catch (Exception ex)
             {
                 //记录日志
                 LogManager.GetCurrentClassLogger().Error(ex);
             }
             return result;
             */
            #endregion
        }

        /// <summary>
        /// 兼容性接收8+XML或者122+XML的数据
        /// </summary>
        /// <returns></returns>
        public string Recv8or122Message(Socket socket)
        {
            string result = string.Empty;
            try
            {
                //报文头长度
                int headLength = 222;
                int tempLength = 13;
                byte[] tempHeader = new byte[tempLength];
                byte[] headBytes = new byte[headLength];
                byte[] dataLength = null;
                byte[] recvBytes = null;
                int len = 0;//数据长度
                //偏移位置
                int bytes = 0;
                //读取总数
                int totalbytes = 0;
                while (totalbytes < tempLength)
                {
                    bytes = socket.Receive(tempHeader, totalbytes, tempLength - totalbytes, 0);
                    //断开连接或者超时
                    if (bytes <= 0)
                        break;
                    totalbytes += bytes;
                }
                //接收头部信息错误 返回空字串
                if (tempLength != totalbytes) return result;
                byte[] temp1Header = new byte[tempHeader.Length - 8];
                Array.Copy(tempHeader, 8, temp1Header, 0, temp1Header.Length);
                string strTempSource = Encoding.UTF8.GetString(temp1Header);
                if (strTempSource.ToLower().StartsWith("<?xml"))
                {
                    //8位+XML的数据
                    dataLength = new byte[8];
                    Array.Copy(tempHeader, 0, dataLength, 0, dataLength.Length);
                    string strDataLength = Encoding.UTF8.GetString(dataLength);
                    //剩余部分数据
                    len = Convert.ToInt32(strDataLength) - 5;
                    //存放报文体的数据
                    recvBytes = new byte[len];
                    headBytes = new byte[tempLength];
                    Array.Copy(tempHeader, 0, headBytes, 0, headBytes.Length);
                }
                else
                {
                    //122 + XML的数据
                    dataLength = new byte[10];
                    Array.Copy(tempHeader, 0, headBytes, 0, tempHeader.Length);
                    while (totalbytes < headLength)
                    {
                        bytes = socket.Receive(headBytes, totalbytes, headLength - totalbytes, 0);
                        totalbytes += bytes;
                        //断开连接或者超时
                        if (bytes <= 0)
                            break;
                    }
                    //接收头部信息错误 返回空字串
                    if (headLength != totalbytes) return result;
                    //获取报文头中长度的标识字符串
                    Array.Copy(headBytes, 30, dataLength, 0, dataLength.Length);
                    string strDataLength = Encoding.UTF8.GetString(dataLength);
                    //报文体长度
                    len = Convert.ToInt32(strDataLength);
                    recvBytes = new byte[len];
                }

                bytes = 0;
                totalbytes = 0;
                while (totalbytes < len)
                {
                    //从客户端接受信息
                    bytes = socket.Receive(recvBytes, totalbytes, len - totalbytes, 0);
                    //断开连接或者超时跳出
                    if (bytes <= 0)
                        break;
                    totalbytes += bytes;
                }
                //报文头部信息
                string headStr = Utils.ToGBK(headBytes, 0, headBytes.Length);
                //报文体信息
                result = headStr + Utils.ToGBK(recvBytes, 0, recvBytes.Length);
            }
            catch (Exception ex)
            {
                //记录日志
                if (!ex.Message.Contains("强迫关闭"))
                    LogManager.GetCurrentClassLogger().Error(ex);
                //throw ex;
            }
            return result;
        }
    }
}
