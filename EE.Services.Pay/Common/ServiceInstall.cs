using System;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
namespace EE.Services.Pay.Common
{
    public class ServiceInstall : ServiceBase
    {
        public ServiceInstall()
        {
            CanPauseAndContinue = true;
        }
        #region Start & Stop  &   Pause & Continue

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("try start " + GlobalData.serviceName);
            //BootStart.Start();
            NLog.LogManager.GetCurrentClassLogger().Info(GlobalData.serviceName + " is start");
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        protected override void OnStop()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("try stop " + GlobalData.serviceName);
            //BootStart.Stop();
            NLog.LogManager.GetCurrentClassLogger().Info(GlobalData.serviceName + " is stop");
        }

        /// <summary>
        /// 暂停
        /// </summary>
        protected override void OnPause()
        {

        }

        /// <summary>
        /// 继续执行
        /// </summary>
        protected override void OnContinue()
        {

        }



        #endregion

        public static void RunMain(string[] args)
        {
            //无参数时直接运行服务
            if ((!Environment.UserInteractive))
            {
                RunAsService();
                return;
            }
            if (args != null && args.Length > 0)
            {
                if (args[0].Equals("-i", StringComparison.OrdinalIgnoreCase))
                {
                    SelfInstaller.InstallMe();
                    return;
                }
                if (args[0].Equals("-u", StringComparison.OrdinalIgnoreCase))
                {
                    SelfInstaller.UninstallMe();
                    return;
                }
                if (args[0].Equals("-t", StringComparison.OrdinalIgnoreCase) ||
                    args[0].Equals("-c", StringComparison.OrdinalIgnoreCase))
                {
                    RunAsConsole(args);
                    return;
                }
                const string tip =
                    "Invalid argument! note:\r\n -i is install the service.;\r\n -u is uninstall the service.;\r\n -t or -c is run the service on console.";
                Console.WriteLine(tip);
                Console.ReadLine();
            }
            else
            {
#if DEBUG             
                RunAsConsole(args);
#endif
            }
        }

        private static void RunAsConsole(string[] args)
        {
            BootStart.Start();
            Console.ReadLine();
        }

        private static void RunAsService()
        {
            var service = new ServiceInstall();
            Run(service);
        }



        #region 服务自安装
        /// <summary>
        /// 服务自安装
        /// </summary>
        public class SelfInstaller
        {
            private static readonly string exePath = Assembly.GetEntryAssembly().Location;

            /// <summary>
            /// Install service
            /// </summary>
            /// <returns></returns>
            public static bool InstallMe()
            {
                try
                {
                    ManagedInstallerClass.InstallHelper(new[] { exePath });
                }
                catch
                {
                    return false;
                }
                return true;
            }

            /// <summary>
            /// Uninstall service
            /// </summary>
            /// <returns></returns>
            public static bool UninstallMe()
            {
                try
                {
                    ManagedInstallerClass.InstallHelper(new[] { "/u", exePath });
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        #endregion

        #region 服务安装配置

        /// <summary>
        /// 服务安装，安装后立即启动
        /// </summary>
        [RunInstaller(true)]
        public class ProjectInstaller : Installer
        {
            private static readonly string codeBase = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
            protected string ConfigServiceName = codeBase;
            protected string ConfigDescription = null;
            protected string DisplayName = codeBase;

            /// <summary>
            /// 安装
            /// </summary>
            public ProjectInstaller()
            {
                InitializeComponent(); //在安装中取得配置中的名字必须。
                Committed += ServiceInstallerCommitted;

                var serviceName = GlobalData.serviceName;
                var displayName = GlobalData.displayName;
                var desc = GlobalData.serviceDesc;

                if (!string.IsNullOrEmpty(serviceName)) ConfigServiceName = serviceName;
                if (!string.IsNullOrEmpty(displayName)) DisplayName = displayName;
                if (!string.IsNullOrEmpty(desc)) ConfigDescription = desc;

                var processInstaller = new ServiceProcessInstaller { Account = ServiceAccount.LocalSystem };
                var serviceInstaller = new ServiceInstaller
                {
                    //自动启动服务，手动的话，每次开机都要手动启动。
                    StartType = ServiceStartMode.Automatic,

                    DisplayName = DisplayName,
                    ServiceName = ConfigServiceName,
                    Description = ConfigDescription
                };


                Installers.Add(serviceInstaller);
                Installers.Add(processInstaller);

            }


            /// <summary>
            /// 服务安装完成后自动启动
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ServiceInstallerCommitted(object sender, InstallEventArgs e)
            {
                var controller = new ServiceController(ConfigServiceName);
                controller.Start();
            }

            /// <summary>
            /// 必需的设计器变量。
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary> 
            /// 清理所有正在使用的资源。
            /// </summary>
            /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    components?.Dispose();
                }
                base.Dispose(disposing);
            }

            #region 组件设计器生成的代码

            /// <summary>
            /// 设计器支持所需的方法 - 不要
            /// 使用代码编辑器修改此方法的内容。
            /// </summary>
            private void InitializeComponent()
            {
                components = new System.ComponentModel.Container();

            }

            #endregion


        }


        #endregion
    }

}
