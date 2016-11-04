using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
//using Newtonsoft.Json;
#if !NET20
using System.Linq;
#endif
using System.Text;
using System.Threading;
using System.Net.Cache;
namespace EE.Services.Pay.Common
{   
    /// <summary>
    /// http协议的操作类
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// API接口异步调用
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="invoker">调用代理</param>
        /// <param name="callback">回调代理</param>
        public void AsyncInvoke<T>(AsyncInvokeDelegate<T> invoker, AsyncCallbackDelegate<T> callback)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state)
            {
                AsyncCallback<T> result;
                try
                {
                    T invoke = invoker();
                    result = new AsyncCallback<T>(invoke);
                    callback(result);

                }
                catch (Exception ex)
                {
                    result = new AsyncCallback<T>(ex, false);
                    callback(result);
                }
            }));
        }
        /// <summary>
        /// 代理设置
        /// </summary>
        public WebProxy Proxy
        {
            get;
            set;
        }
        /// <summary>
        /// 用POST方式发送请求
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">参数表</param>
        /// <returns></returns>
        public string Post(string url, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            List<RequestParameter> list = new List<RequestParameter>();
            foreach (var item in parameters)
            {
                list.Add(new RequestParameter(item.Key, item.Value));
            }
            return Post(url, list.ToArray());
        }
        /// <summary>
        /// 用POST方式发送请求
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">参数表</param>
        /// <returns></returns>
        public string Post(string url, params RequestParameter[] parameters)
        {
            return Request(url, RequestMethod.Post, parameters);
        }

        /// <summary>
        /// 用GET方式发送请求
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">参数表</param>
        /// <returns></returns>
        public string Get(string url, params RequestParameter[] parameters)
        {
            return Request(url, RequestMethod.Get, parameters);
        }
        /// <summary>
        /// 用GET方式发送请求
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">参数表</param>
        /// <returns></returns>
        public string Get(string url, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            List<RequestParameter> list = new List<RequestParameter>();
            foreach (var item in parameters)
            {
                list.Add(new RequestParameter(item.Key, item.Value));
            }
            return Request(url, RequestMethod.Get, list.ToArray());
        }
        internal string GetBoundary()
        {
            string pattern = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder boundaryBuilder = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var index = rnd.Next(pattern.Length);
                boundaryBuilder.Append(pattern[index]);
            }
            return boundaryBuilder.ToString();
        }
        internal string BuildQueryString(params RequestParameter[] parameters)
        {
            SortedDictionary<string, string> sortDicParam = new SortedDictionary<string, string>();
            foreach (var item in parameters)
            {
                if (item.IsBinaryData)
                    continue;
                var value = string.Format("{0}", item.Value);
                if (!string.IsNullOrEmpty(value))
                {
                    sortDicParam.Add(item.Name, value);
                }
            }
            StringBuilder queryBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in sortDicParam)
            {
                queryBuilder.Append(pair.Key + "=" + HttpUtility.UrlEncode(pair.Value, Encoding.UTF8) + "&");
            }
            return queryBuilder.ToString().Trim('&');
        }
        /// <summary>
        /// 创建Post Body
        /// </summary>
        /// <param name="boundary"></param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        internal static byte[] BuildPostData(string boundary, params RequestParameter[] parameters)
        {
            List<RequestParameter> pairs = new List<RequestParameter>(parameters);
            pairs.Sort(new RequestParameterComparer());
            MemoryStream buff = new MemoryStream();

            byte[] headerBuff = Encoding.ASCII.GetBytes(string.Format("\r\n--{0}\r\n", boundary));
            byte[] footerBuff = Encoding.ASCII.GetBytes(string.Format("\r\n--{0}--", boundary));


            StringBuilder contentBuilder = new StringBuilder();

            foreach (RequestParameter p in pairs)
            {
                if (!p.IsBinaryData)
                {
                    var value = string.Format("{0}", p.Value);
                    if (string.IsNullOrEmpty(value))
                    {
                        continue;
                    }


                    buff.Write(headerBuff, 0, headerBuff.Length);
                    byte[] dispositonBuff = Encoding.UTF8.GetBytes(string.Format("content-disposition: form-data; name=\"{0}\"\r\n\r\n{1}", p.Name, p.Value.ToString()));
                    buff.Write(dispositonBuff, 0, dispositonBuff.Length);

                }
                else
                {
                   
                    if (string.IsNullOrEmpty(p.Name))
                    {
                        byte[] dispositonBuff = (byte[])p.Value;
                        buff.Write(dispositonBuff, 0, dispositonBuff.Length);
                    }
                    else
                    {
                        buff.Write(headerBuff, 0, headerBuff.Length);
                        string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: \"image/unknow\"\r\nContent-Transfer-Encoding: binary\r\n\r\n";
                        byte[] fileBuff = System.Text.Encoding.UTF8.GetBytes(string.Format(headerTemplate, p.Name, string.Format("upload{0}", BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0))));
                        buff.Write(fileBuff, 0, fileBuff.Length);
                        byte[] file = (byte[])p.Value;
                        buff.Write(file, 0, file.Length);
                    }
                }
            }

            buff.Write(footerBuff, 0, footerBuff.Length);
            buff.Position = 0;

            byte[] contentBuff = new byte[buff.Length];
            buff.Read(contentBuff, 0, contentBuff.Length);
            buff.Close();
            buff.Dispose();
            return contentBuff;
        }
        internal string Request(string url, RequestMethod method = RequestMethod.Get, params RequestParameter[] parameters)
        {
            string rawUrl = string.Empty;
            UriBuilder uri = new UriBuilder(url);
            string result = string.Empty;

            bool multi = false;
#if !NET20
            multi = parameters.Count(p => p.IsBinaryData) > 0;
#else
			foreach (var item in parameters)
			{
				if (item.IsBinaryData)
				{
					multi = true;
					break;
				}
			}
#endif

            switch (method)
            {
                case RequestMethod.Get:
                    {
                        uri.Query = BuildQueryString(parameters);

                    }
                    break;
                case RequestMethod.Post:
                    {
                        if (!multi)
                        {
                            uri.Query = BuildQueryString(parameters);
                        }
                    }
                    break;
            }
            HttpWebRequest http = WebRequest.Create(uri.Uri) as HttpWebRequest;
            http.ServicePoint.Expect100Continue = false;
            http.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
            if (Proxy != null)
            {
                if (Proxy.Credentials != null)
                {
                    http.UseDefaultCredentials = true;
                }
                http.Proxy = Proxy;
            }
            switch (method)
            {
                case RequestMethod.Get:
                    {
                        http.Method = "GET";
                    }
                    break;
                case RequestMethod.Post:
                    {
                        http.Method = "POST";
                        if (multi)
                        {
                            string boundary = GetBoundary();
                            http.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
                            http.AllowWriteStreamBuffering = true;
                            using (Stream request = http.GetRequestStream())
                            {
                                try
                                {
                                    var raw =BuildPostData(boundary, parameters);
                                    request.Write(raw, 0, raw.Length);
                                }
                                finally
                                {
                                    request.Close();
                                }
                            }
                        }
                        else
                        {
                            http.ContentType = "application/x-www-form-urlencoded";

                            using (StreamWriter request = new StreamWriter(http.GetRequestStream()))
                            {
                                try
                                {
                                    request.Write(BuildQueryString(parameters));
                                }
                                finally
                                {
                                    request.Close();
                                }
                            }
                        }
                    }
                    break;
            }
            try
            {
                using (WebResponse response = http.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        try
                        {
                            result = reader.ReadToEnd();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }


                    response.Close();
                }
            }
            catch (System.Net.WebException webEx)
            {
                if (webEx.Response != null)
                {
                    using (StreamReader reader = new StreamReader(webEx.Response.GetResponseStream()))
                    {
                        string errorInfo = reader.ReadToEnd();
#if DEBUG
                        Debug.WriteLine(errorInfo);
#endif
                      
                        reader.Close();

                        throw new Exception(errorInfo);
                    }
                }
                else
                {
                    throw new Exception(webEx.Message);
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// 用POST方式发送请求
        /// </summary>
        ///  <param name="url">请求地址</param>
        /// <param name="contentType">请求类型</param>
        /// <param name="postData">请求数据</param>
        /// <param name="requestEncoding">请求编码</param>
        /// <returns></returns>
        public string Post(string url, string contentType, string postData, Encoding requestEncoding = null)
        {
            if (postData == null) return null;
            if (requestEncoding == null) requestEncoding = Encoding.UTF8;
            UriBuilder uri = new UriBuilder(url);
            string result = string.Empty;
            HttpWebRequest http = WebRequest.Create(uri.Uri) as HttpWebRequest;
            http.ServicePoint.Expect100Continue = false;
            http.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
            if (Proxy != null)
            {
                if (Proxy.Credentials != null)
                {
                    http.UseDefaultCredentials = true;
                }
                http.Proxy = Proxy;
            }
            http.Method = "POST";
            http.ContentType = contentType;
            http.AllowWriteStreamBuffering = true;
            byte[] bytes = requestEncoding.GetBytes(postData);
            using (Stream requestStream = http.GetRequestStream())
            {
                try
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
                finally
                {
                    requestStream.Close();
                }
            }

            try
            {
                using (WebResponse response = http.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        try
                        {
                            result = reader.ReadToEnd();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                    response.Close();
                }
            }
            catch (System.Net.WebException webEx)
            {
                if (webEx.Response != null)
                {
                    using (StreamReader reader = new StreamReader(webEx.Response.GetResponseStream()))
                    {
                        string errorInfo = reader.ReadToEnd();
#if DEBUG
                        Debug.WriteLine(errorInfo);
#endif
                        reader.Close();
                        throw new Exception(errorInfo);
                    }
                }
                else
                {
                    throw new Exception(webEx.Message);
                }
            }
            return result;
        }

        /// <summary>
        /// 生成要请求给支付宝的参数数组
        /// </summary>
        /// <param name="dicArray">请求前的参数数组</param>
        /// <param name="isUrlEncoding">参数是否要编码</param>
        /// <returns>要请求的参数数组字符串</returns>
        public string BuildRequestParam(Dictionary<string, string> dicArray, bool isUrlEncoding)
        {
            StringBuilder builderParam = new StringBuilder();
            if (isUrlEncoding)
            {
                foreach (KeyValuePair<string, string> temp in dicArray)
                {
                    builderParam.Append(temp.Key + "=" + HttpUtility.UrlEncode(temp.Value) + "&");
                }
            }
            else
            {
                foreach (KeyValuePair<string, string> temp in dicArray)
                {
                    builderParam.Append(temp.Key + "=" + temp.Value + "&");
                }
            }
            return builderParam.ToString().Trim('&');
        }

        /// <summary>
        /// 用POST方式发送请求 默认类型为application/x-www-form-urlencoded
        /// </summary>
        /// <param name="address">请求的地址</param>
        /// <param name="postData">请求的数据</param>
        /// <param name="encoding">请求的数据编码</param>
        /// <param name="timeout">超时(秒)</param>
        /// <returns></returns>
		public string Post(string address, string postData, Encoding encoding, int timeout=30)
        {
            string result = string.Empty;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(address);
                HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                request.CachePolicy = policy;
                request.Timeout = timeout * 0x3e8;
                request.KeepAlive = false;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; SV1; .NET CLR 2.0.1124)";
                request.Headers.Add("Cache-Control", "no-cache");
                request.Accept = "*/*";
                request.Credentials = CredentialCache.DefaultCredentials;
                //发送请求数据
                if (!string.IsNullOrEmpty(postData))
                {
                    byte[] bytes = encoding.GetBytes(postData);
                    request.ContentLength = bytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }
                response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), encoding);
                result = sr.ReadToEnd();
                sr.Close();
            }
            catch (TimeoutException ex)
            {
                result = "timeout";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                    request = null;
                }
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
            return result;
        }

    }

    internal enum RequestMethod
    {
        Get,
        Post
    }
    /// <summary>
    /// 异步调用中的函数调用代理
    /// </summary>
    /// <typeparam name="T">API返回的类型</typeparam>
    /// <returns>T</returns>
    public delegate T AsyncInvokeDelegate<T>();
    /// <summary>
    /// 异步调用中的回调代理
    /// </summary>
    /// <typeparam name="T">函数调用中的返回类型</typeparam>
    /// <param name="result">AsyncCallback对象</param>
    public delegate void AsyncCallbackDelegate<T>(AsyncCallback<T> result);
    /// <summary>
    /// DingPingParameter实现的IComparer接口
    /// </summary>
    internal class RequestParameterComparer : IComparer<RequestParameter>
    {
        public int Compare(RequestParameter x, RequestParameter y)
        {
            return StringComparer.CurrentCulture.Compare(x.Name, y.Name);
        }
    }
    /// <summary>
    /// 异步调用的回调参数
    /// </summary>
    /// <typeparam name="T">返回值类型</typeparam>
    public class AsyncCallback<T>
    {
        /// <summary>
        /// 调用是否成功
        /// </summary>
        public bool IsSuccess
        {
            get;
            private set;
        }
        /// <summary>
        /// 返回值
        /// </summary>
        public T Data
        {
            get;
            private set;
        }

        internal AsyncCallback(T result)
        {
            this.Data = result;
            this.IsSuccess = true;
            this.Error = null;
        }

        internal AsyncCallback(Exception ex, bool success)
        {
            this.IsSuccess = success;
            this.Error = ex;
        }

        /// <summary>
        /// 异常对象，如果IsSuccess为true则本对象为null
        /// </summary>
        public Exception Error
        {
            get;
            private set;
        }
    }
    /// <summary>
    /// html请求参数
    /// </summary>
    public class RequestParameter
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 参数值
        /// </summary>
        public object Value
        {
            get;
            set;
        }

        /// <summary>
        /// 是否为二进制参数（如图片、文件等）
        /// </summary>
        public bool IsBinaryData
        {
            get
            {
                if (Value != null && Value.GetType() == typeof(byte[]))
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public RequestParameter()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="value">value</param>
        public RequestParameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="value">value</param>
        public RequestParameter(string name, bool value)
        {
            this.Name = name;
            this.Value = value ? "1" : "0";
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="value">value</param>
        public RequestParameter(string name, int value)
        {
            this.Name = name;
            this.Value = string.Format("{0}", value);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="value">value</param>
        public RequestParameter(string name, long value)
        {
            this.Name = name;
            this.Value = string.Format("{0}", value);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="value">value</param>
        public RequestParameter(string name, byte[] value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="value">value</param>
        public RequestParameter(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
