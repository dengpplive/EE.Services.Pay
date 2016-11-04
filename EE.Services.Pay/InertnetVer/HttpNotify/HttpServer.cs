using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using EE.Services.Pay.Common.Ext;
using NLog;
using System.Reflection;
using EE.Services.Pay.Common;
using System.Text;
namespace EE.Services.Pay.InertnetVer.HttpNotify
{
    /// <summary>
    /// 接收Http请求的封装
    /// </summary>
    public class HttpServer
    {
        HttpListener listener;
        string httpUrl = string.Empty;
        public HttpServer()
        {
            //----------------
            var pinganPayConfig = ConfigManage.GetPinganPayConfig();
            var host = pinganPayConfig.DownSetting.ListenIP;
            var port = pinganPayConfig.DownSetting.ListenPort;
            //----------------
            httpUrl = string.Format("http://{0}:{1}/", host, port);
            listener = new HttpListener();
            listener.Prefixes.Add(httpUrl);
        }
        volatile bool status = false;
        /// <summary>
        /// 开启监听请求
        /// </summary>
        public void Start()
        {
            Action<HttpListener> act = p =>
            {
                p.Start();
                Console.WriteLine($"{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}http开启监听请求:{httpUrl}");
                status = true;
                while (status)
                {
                    try
                    {
                        //等待..终断线程会报错        
                        var httpContext = p.GetContext();
                        ThreadPool.QueueUserWorkItem(Process, httpContext);
                    }
                    catch (Exception ex)
                    {
                        //记录日志
                        LogManager.GetCurrentClassLogger().Error(ex);
                    }
                }
            };
            act.BeginInvoke(listener, null, null);
        }
        /// <summary>
        /// 停止监听请求
        /// </summary>
        public void Stop()
        {
            listener.Stop();
            status = false;
        }
        /// <summary>
        /// 交给实现了处理接口的子类处理
        /// </summary>
        /// <param name="context">httpContext上下文</param>
        void Process(object context)
        {
            var httpContext = context as HttpListenerContext;
            var param = new DistributeParam();
            try
            {
                param.context = httpContext;
                HttpDistributer.Distribute(param);
                param.response = new HttpResponse(httpContext);
                param.request = new HttpRequest(httpContext);
                param.httpHandler.Process(param.request, param.response, param.result);
                if (!string.IsNullOrEmpty(param.result.Result))
                    param.response.Write(param.result.Result);
                param.response.Flush();
                param.response.Close();
            }
            catch (Exception ex)
            {
                //异常日志
                param.result.LogResult += ex.Message;
                param.result.Result = null;
                //记录日志
                LogManager.GetCurrentClassLogger().Error(ex);
            }
            finally
            {
                //记录请求日志
                param.WriteLog();
            }
        }
    }

    /// <summary>
    /// http请求对象
    /// </summary>
    public class HttpRequest
    {
        public HttpRequest(HttpListenerContext context)
        {
            this.Request = context.Request;
            this.HttpMethod = this.Request.HttpMethod;
            this.Context = context;
            this.Url = this.Request.Url;
            this.RawUrl = this.Request.RawUrl;
            this.RemoteEndPoint = this.Request.RemoteEndPoint;
            this.Form = new NameValueCollection();
            this.QueryString = new NameValueCollection();
            StreamReader sr = new StreamReader(this.Request.InputStream);
            var formStr = sr.ReadToEnd();
            if (!string.IsNullOrEmpty(formStr))
            {
                formStr.Split('&').Select(p =>
                {
                    var ps = p.Split('=');
                    return new
                    {
                        key = ps[0],
                        value = ps[1]
                    };
                }).ForEach(p =>
                {
                    Form.Add(p.key, p.value);
                });
            }
            if (!string.IsNullOrEmpty(this.Request.Url.Query))
            {
                var query = this.Request.Url.Query.Substring(1, this.Request.Url.Query.Length - 1);
                query.Split('&').Select(p =>
                {
                    var ps = p.Split('=');
                    return new
                    {
                        key = ps[0],
                        value = ps[1].UrlDecode()//解密
                    };
                }).ForEach(p =>
                {
                    QueryString.Add(p.key, p.value);
                });
            }

        }
        public HttpListenerContext Context;

        public HttpListenerRequest Request;
        public Uri Url { get; private set; }
        public NameValueCollection Form { get; private set; }
        public NameValueCollection QueryString { get; private set; }
        public IPEndPoint RemoteEndPoint { get; private set; }
        public string RawUrl { get; private set; }
        public string HttpMethod { get; private set; }

    }
    /// <summary>
    /// http响应对象
    /// </summary>
    public class HttpResponse : IDisposable
    {
        /// <summary>
        /// 上下文对象
        /// </summary>
        public HttpListenerContext Context;
        HttpListenerResponse response;
        StreamWriter sw;
        public HttpResponse(HttpListenerContext context)
        {
            this.Context = context;
            this.response = context.Response;
            sw = new StreamWriter(response.OutputStream);
        }
        public void Write(string value)
        {
            sw.Write(value);
        }
        public void WriteLine(string value)
        {
            sw.WriteLine(value);
        }
        public void WriteLine(int value)
        {
            sw.WriteLine(value);
        }
        public void WriteLine(bool value)
        {
            sw.WriteLine(value);
        }
        public void Flush()
        {
            sw.Flush();
        }
        public void Close()
        {
            sw.Close();
        }
        public void Dispose()
        {
            sw.Dispose();
        }
    }
    /// <summary>
    /// 请求分配器
    /// </summary>
    public class HttpDistributer
    {
        private static Assembly assembly = null;
        /// <summary>
        /// 根据请求的路由找到具体的实现了的接口类
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static void Distribute(DistributeParam dsp)
        {
            var path = dsp.context.Request.Url.AbsolutePath;
            // /favicon.ico
            var code = path.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0];
            try
            {
                if (!string.IsNullOrEmpty(code))
                {
                    if (assembly == null) assembly = Assembly.Load(GlobalData.assemblyName);
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (type.IsClass && !type.IsAbstract
                            && typeof(IHttpHandler).IsAssignableFrom(type))
                        {
                            var httpCode = type.GetCustomAttributes(typeof(RecvCodeAttribute), true).FirstOrDefault() as RecvCodeAttribute;
                            if (httpCode != null
                                && httpCode.Code.ToLower() == code.ToLower()
                                && !httpCode.Disabled
                                )
                            {
                                dsp.httpCodeAtt = httpCode as RecvCodeAttribute;
                                dsp.httpHandler = Activator.CreateInstance(type) as IHttpHandler;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                dsp.httpHandler = new DefaultHttpHandler();
            }
        }
    }
    /// <summary>
    /// 请求标识特性
    /// </summary>
    public class RecvCodeAttribute : Attribute
    {
        /// <summary>
        /// HttpCode
        /// </summary>
        /// <param name="code">请求http路由标识,tcp请求为空</param>
        /// <param name="desc">业务描述</param>
        /// <param name="Disabled">禁用</param>
        public RecvCodeAttribute(string code = "", string desc = "", bool disabled = false)
        {
            this.Code = code;
            this.Desc = desc;
            this.Disabled = disabled;
        }
        /// <summary>
        /// 请求的路径的第一个标识名称 不区分大小写
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }
    }
    /// <summary>
    /// 用于子类继承该接口实现通知的业务处理 
    /// </summary>
    public interface IHttpHandler
    {
        void Process(HttpRequest request, HttpResponse response, HttpHandResult result);
    }
    /// <summary>
    /// 调度的参数
    /// </summary>
    public class DistributeParam
    {

        public DistributeParam()
        {
        }
        public IHttpHandler httpHandler = new DefaultHttpHandler();
        public RecvCodeAttribute httpCodeAtt = new RecvCodeAttribute("idx", "默认");
        public HttpListenerContext context = null;
        public HttpResponse response = null;
        public HttpRequest request = null;
        public HttpHandResult result = new HttpHandResult();
        /// <summary>
        /// 记录请求日志
        /// </summary>
        public void WriteLog()
        {
            try
            {
                //日志
                StringBuilder sbLog = new StringBuilder();
                sbLog.AppendFormat("Start=========================={0}:{1}===========================================\r\n", httpCodeAtt.Code, httpCodeAtt.Desc);
                sbLog.Append("时间:" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\r\n");
                sbLog.Append("URL:" + this.request.Url + "\r\n");
                sbLog.AppendFormat("请求参数[{0}]:\r\n", request.HttpMethod);
                NameValueCollection nv = new NameValueCollection();
                nv.Add(request.Form);
                nv.Add(request.QueryString);
                foreach (string key in nv.Keys)
                {
                    sbLog.Append(key + "=" + nv[key] + "\r\n");
                }
                sbLog.AppendFormat("处理结果:{0}\r\n", this.result.LogResult);
                sbLog.AppendFormat("输出结果:{0}\r\n", this.result.Result);
                sbLog.Append("End=====================================================================\r\n\r\n");
                FileHelper.SaveFile(string.Format("Log\\{0}\\{0}_{1}.txt", httpCodeAtt.Code, System.DateTime.Now.ToString("yyyyMMdd")), sbLog.ToString());
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
            }
        }
    }
    /// <summary>
    /// http处理结果
    /// </summary>
    public class HttpHandResult
    {
        /// <summary>
        /// 成功或者失败的输出结果 为空不输出 用于返回接收方数据
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 业务处理结果 用于记录日志
        /// </summary>
        public string LogResult { get; set; }
    }
    /// <summary>
    /// 默认请求标识的处理
    /// </summary>
    [RecvCode("idx", "默认")]
    public class DefaultHttpHandler : IHttpHandler
    {
        public void Process(HttpRequest request, HttpResponse response, HttpHandResult result)
        {
            result.LogResult = "无效请求";
        }
    }
}
