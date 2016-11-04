using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

/*
利用mysql ODBC把SQL Server中数据库中的数据导入到MySQL中

第一步：安装mysql ODBC；

        去相关的网站下载mysql ODBC进行安装。 

第二步：建立MySQL的DSN；

        在控制面板——>管理工具——>数据源(ODBC)中建立MySQL的DSN。

        例如： Data Source Name: MySQL DSN

               Server: localhost

               User: root

               Password: root

               Database: mysql



第三步：SQL Server中，选择要导出的数据库，右键选择All Tasks->Export Datas...开始DTS Export Wizerd...。 




第四步：Choose a Data Source；

        例如：Data Source: Microsoft OLE DB Provider for SQL Server

              Server: 11.64.0.13

              Username: admin

              Password: admin

              Database: ORDER



第五步：Choose a Destination。

        例如：Data Source: MySQL ODBC 3.15 Driver

              User/System DSN: MySQL DSN

              Username: root

              Password: root



第六步：Select Source Table。 




第七步：Run immediately, 下一步再选完成，就开始转换*/