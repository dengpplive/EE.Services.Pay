using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Common
{
    public class PayException : ApplicationException
    {
        /// 构造方法
        /// </summary>
        public PayException()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">消息</param>
        public PayException(string message)
            : base(message)
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="innerException">内部异常</param>
        public PayException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
