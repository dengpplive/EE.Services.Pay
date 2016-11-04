using EE.Services.Pay.InertnetVer.HttpNotify;
using EE.Services.Pay.Model;
using System;
using System.Linq;
using System.Reflection;

namespace EE.Services.Pay.InertnetVer
{
    public interface INotifyHandler
    {
        /// <summary>
        /// 将请求的数据进行业务处理 返回数据和状态码
        /// </summary>
        /// <param name="funcCode">接口交易码</param>
        /// <param name="notifyResult">处理业务需要的数据和返回数据以及状态码</param>
        void Process(string funcCode, NotifyResult notifyResult);
    }
    public class BuildHandler
    {
        private static INotifyHandler handler = null;
        public static INotifyHandler GetHandler()
        {
            //if (handler == null)
            //{
            var asms = System.AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly asm in asms)
            {
                var types = asm.GetTypes();
                foreach (Type type in types)
                {
                    if (type.IsClass && !type.IsAbstract
                        && typeof(INotifyHandler).IsAssignableFrom(type))
                    {
                        var httpCode = type.GetCustomAttributes(typeof(RecvCodeAttribute), true).FirstOrDefault() as RecvCodeAttribute;
                        if (httpCode != null
                            && !httpCode.Disabled
                            )
                        {
                            return Activator.CreateInstance(type) as INotifyHandler;
                        }
                    }
                }
            }
            //}
            return handler;
        }
    }
}
