using EE.Services.Pay;
using EE.Services.Pay.Common;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EE.Services.PayConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Utils.RunOne(() =>
            {
                if ((!Environment.UserInteractive))
                {
                    RunService();
                }
                else
                {
                    BootStart.Start();
                }
            });
        }
        /// <summary>
        /// 运行服务
        /// </summary>
        public static void RunService()
        {
            ServiceBase.Run(new ServiceBase[] {
                new PingAnService()
            });
        }
    }
}
