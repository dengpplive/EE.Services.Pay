using EE.Services.Pay.InertnetVer.HttpNotify;
using System;

namespace EE.Services.PayTestDemo
{
    /// <summary>
    /// 企业接收的请求 使用时RecvCode中去掉true或者改为false
    /// </summary>
    [RecvCode("erpreq", "企业接收的通知")]
    public class PayHttpHandler : IHttpHandler
    {
        public void Process(HttpRequest request, HttpResponse response, HttpHandResult result)
        {
            //result.Result = "fail";//成功失败的输出
            //result.LogResult = "success1233";

            //处理接收的请求           
        }
    }


}
