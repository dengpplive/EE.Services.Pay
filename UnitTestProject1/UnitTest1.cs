using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EE.Services.Pay.Model;
using EE.Services.Pay.Common;
using System.IO;
using System.Text;
using static EE.Services.Pay.Common.CommonEnums;
using EE.Services.Pay.Common.Ext;
using EnterpriseDT.Net.Ftp;
using EnterpriseDT.Util;
using EE.Services.Pay.Model.Res;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MyTestLength()
        {
            //string aa = "A001010101001010799000099990000000000220S001  00000022016071111591820160711115918747160000000:交易受理成功                                                                                       00000                       0";
            //int aaa = Encoding.Default.GetBytes(aa).Length;
            //string bb="1&11014165191000&888800000016258&上海新跃物流会员一&V00000027&52&20130802-7&1&0.00&0.00&0.00&&";
            //int cc = Encoding.GetEncoding("GBK").GetBytes(bb).Length+122;


            //string yewu = "1330020               20160714145704ERR087不能重复签到                              000000016PA001201607141459313678458545";
            //int len = Encoding.GetEncoding("GBK").GetBytes(yewu).Length;
            //string str = ":交易受理成功                                                                                       ";
            //int b = str.Length;
            //decimal a = 10m;
            //decimal a = 10.0m;
            //decimal a = 10.01m;
            //decimal a = 10.21m;
            //decimal a = 10.217m;
            //string astr = Utils.DecimalToString(a);
            //return;

            //QiyeLargeBatchMoneyTransfer qiyeLargeBatchMoneyTransfer = new QiyeLargeBatchMoneyTransfer();
            //qiyeLargeBatchMoneyTransfer.CcyCode = "RMB";
            //HOResultSet4018R hOResultSet4018R = new HOResultSet4018R();
            //qiyeLargeBatchMoneyTransfer.HOResultSet4018R.Add(hOResultSet4018R);
            //hOResultSet4018R.AddrFlag = 2;
            //string xml = Utils.ModelToXMLNode<QiyeLargeBatchMoneyTransfer>(qiyeLargeBatchMoneyTransfer);

            //string recvData = "A0010301018529                000000013800000053120022016071410535720160714105605060612ERR087不能重复签到                                                                                        000001            000000000001330020               20160714105357ERR087不能重复签到                              0000000165312020160714105605060612852916071410667468&&";
            //BankInterface bank = new BankInterface();
            //var result = bank.ParsingTranMessageString(recvData);

            //string resData = "A0010301018545                0000000138000000PA001022016071416090720160714161135654063ERR087不能重复签到                                                                                        000001            000000000001330020               20160714160907ERR087不能重复签到                              000000016PA00120160714161135654063854516071410668865&&";
            //var res = Utils.ToModelFromString<Res_1330>(resData);

            //string strReq = "130101                20160803151726999999                                          000000083EB00116080310773878      88771&11014971070008&888800000174252&测试一&02142081007&52&757601035&1&0.00&0.00&0.00&&";
            //byte[] bb1 = Utils.ToByte(strReq);
            //byte[] bb2 = Utils.ToByteUTF8(strReq);

            //int blength = bb1.Length;
            ////int bblength = bb2.Length;

            //var nn = IDType.中国护照.ToValue();
            //string strData = "A0010301018877                0000000205000000EB001012016080315172616080310773878      999999                                                                                                    00000000000000000000000000000130101                20160803151726999999                                          000000083EB00116080310773878      88771&11014971070008&888800000174252&测试一&02142081007&52&757601035&1&0.00&0.00&0.00&&";
            BankInterface bankReq = new BankInterface();
            //ExHashTable retKeyDict = bankReq.ParsingTranMessageString(strData);
            //string back = bankReq.GetTranMessageRes(retKeyDict);      

            //string recv = "A0010301018877                000000020700000099999012016080414074916080715018669      999999                                                                                                    000000000000000000000000000001310010               20160804140749999999                                          0000000859999916080715018669      887711014971070008&888800000174433&100.00&11014890513006&测试一&RMB&20160807&02142081007&";
            ////老版本 交易资金03
            //var retKeyDict = bankReq.ParsingTranMessageString(recv);

            ////暂时写死
            //retKeyDict.Set("RspCode", "000000");
            //retKeyDict.Set("RspMsg", "");

            //string back = bankReq.GetTranMessageRes(retKeyDict);

            //string recv1 = "A0010301018877                000000020800000099999012016080509494816080815033215      999999                                                                                                    000000000000000000000000000001310010               20160805094948999999                                          0000000869999916080815033215      887711014971070008&888800000174433&1000.00&11014890513006&测试一&RMB&20160808&02142081007&";
            //ExHashTable retKeyDict = bankReq.ParsingTranMessageString(recv1);
            //string back = bankReq.GetTranMessageRes(retKeyDict);   
            Console.ReadLine();
        }

        [TestMethod]
        public void CreateAnswerCodeXml()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"XmlConfig\AnswerList.xml");
            string str = FileHelper.ReadTextFile("error.txt");
            string[] strArr = str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var obj = new AnswerCode();
            for (int i = 0; i < strArr.Length; i++)
            {
                string[] item = strArr[i].Split('\t');
                if (item.Length >= 2)
                {
                    obj.AnswerList.Add(new RspStatus()
                    {
                        Code = item[0].Trim(),
                        Msg = item[1].Trim()
                    });
                }
            }
            ConfigHelper.XmlSerializeToFile(obj, path, Encoding.Default);
        }
        [TestMethod]
        public void CreatePinganPayConfig()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"XmlConfig\PinganPayConfig.xml");
            var pay = new PinganPayConfig();
            pay.OpenLog = true;
            pay.SleepTime = 500;

            pay.UpSetting = new UpSetting();
            pay.UpSetting.ReceiveTimeout = 120;
            pay.UpSetting.SendTimeout = 120;
            pay.UpSetting.SendBufferSize = 4096;
            pay.UpSetting.NoDelay = true;
            pay.UpSetting.IP = "127.0.0.1";
            pay.UpSetting.Port = 7072;

            pay.DownSetting = new DownSetting();
            pay.DownSetting.ListenIP = "127.0.0.1";
            pay.DownSetting.ListenPort = 3001;
            pay.UpSetting.ReceiveTimeout = 120;
            pay.UpSetting.SendTimeout = 120;
            pay.UpSetting.SendBufferSize = 4096;
            pay.UpSetting.NoDelay = true;

            pay.TranMessageNetHead_1_4 = new TranMessageNetHead_1_4();
            pay.TranMessageNetHead_1_4.BusinessMessageHead = new BusinessMessageHead();
            //pay.TranMessageNetHead_1_4.BusinessMessageHead.ServType = "01";
            pay.TranMessageNetHead_1_4.BusinessMessageHead.RspCode = "999999";
            pay.TranMessageNetHead_1_4.BusinessMessageHead.CounterId = "PA001";
            pay.TranMessageNetHead_1_4.BusinessMessageHead.Qydm = "8545";

            pay.TranMessageNetHead_1_4.NetMessageHead = new NetMessageHead();
            pay.TranMessageNetHead_1_4.NetMessageHead.MessageType = "A001";
            pay.TranMessageNetHead_1_4.NetMessageHead.TargetSystem = "03";
            pay.TranMessageNetHead_1_4.NetMessageHead.MessageEncoding = "01";
            pay.TranMessageNetHead_1_4.NetMessageHead.TeleProtocol = "01";
            pay.TranMessageNetHead_1_4.NetMessageHead.TradeCode = "000000";
            pay.TranMessageNetHead_1_4.NetMessageHead.Times = "000";
            pay.TranMessageNetHead_1_4.NetMessageHead.AttachCount = "0";
            //pay.TranMessageNetHead_1_4.NetMessageHead.ServType = "01";
            pay.TranMessageNetHead_1_4.NetMessageHead.RspCode = "999999";
            pay.TranMessageNetHead_1_4.NetMessageHead.CounterId = "";//PA001
            pay.TranMessageNetHead_1_4.NetMessageHead.Qydm = "00102079900001231000";

            pay.BankEnterpriseNetHead = new BankEnterpriseNetHead();
            pay.BankEnterpriseNetHead.NetMessageHead = new NetMessageHead();
            pay.BankEnterpriseNetHead.NetMessageHead.MessageType = "A001";
            pay.BankEnterpriseNetHead.NetMessageHead.TargetSystem = "01";
            pay.BankEnterpriseNetHead.NetMessageHead.MessageEncoding = "01";
            pay.BankEnterpriseNetHead.NetMessageHead.TeleProtocol = "01";
            pay.BankEnterpriseNetHead.NetMessageHead.Qydm = "00101079900009999000";
            pay.BankEnterpriseNetHead.NetMessageHead.CounterId = "00000";
            //pay.BankEnterpriseNetHead.NetMessageHead.ServType = "01";

            //pay.BankEnterpriseNetHead.AccountSetting = new AccountSetting();
            //pay.BankEnterpriseNetHead.AccountSetting.MainAccount = "11002873390701";
            //pay.BankEnterpriseNetHead.AccountSetting.MainAccountName = "平安测试六零零零三三七七九五零九";
            //添加子账号
            //pay.BankEnterpriseNetHead.AccountSetting.ChildAccount.Add(new AccountInfo()
            //{
            //    SubAccountNo = "30200002000001",
            //    SubAccName = "平安测试六零零零三三七七九五零九"
            //});
            //pay.BankEnterpriseNetHead.AccountSetting.ChildAccount.Add(new AccountInfo()
            //{
            //    SubAccountNo = "30100002000004",
            //    SubAccName = "平安测试六零零零三三七七九五零九"
            //});
            //pay.BankEnterpriseNetHead.AccountSetting.ChildAccount.Add(new AccountInfo()
            //{
            //    SubAccountNo = "30100002000005",
            //    SubAccName = "平安测试六零零零三三七七九五零九"
            //});
            //pay.BankEnterpriseNetHead.AccountSetting.ChildAccount.Add(new AccountInfo()
            //{
            //    SubAccountNo = "30100002000002",
            //    SubAccName = "平安测试六零零零三三七七九五零九"
            //});

            ConfigHelper.XmlSerializeToFile(pay, path, Encoding.Default);
        }

        [TestMethod]
        public void CreateProviceXML()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"XmlConfig\Province.xml");
            string str = FileHelper.ReadTextFile("ProviceCode.txt");
            string[] strArr = str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var obj = new ProviceCode();
            for (int i = 0; i < strArr.Length; i++)
            {
                string[] item = strArr[i].Split('\t');
                if (item.Length >= 2)
                {
                    obj.ProviceList.Add(new KeyCode()
                    {
                        Key = item[0].Trim(),
                        Desc = item[1].Trim()
                    });
                }
            }
            ConfigHelper.XmlSerializeToFile(obj, path, Encoding.Default);
        }

        [TestMethod]
        public void CreateBankCodeXML()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"XmlConfig\BankCode.xml");
            string str = FileHelper.ReadTextFile("bankCode.txt");
            string[] strArr = str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var obj = new BankCode();
            for (int i = 0; i < strArr.Length; i++)
            {
                string[] item = strArr[i].Split('\t');
                if (item.Length >= 2)
                {
                    obj.BankCodeList.Add(new KeyCode()
                    {
                        Desc = item[0].Trim(),
                        Key = item[1].Trim()
                    });
                }
            }
            ConfigHelper.XmlSerializeToFile(obj, path, Encoding.Default);
        }


        [TestMethod]
        public void MyMainMethod()
        {
            //设置银行客户端端地址和端口
            //string ServerIPAddress = "127.0.0.1";
            //int ServerPort = 7072;//默认端口

            //定义报文参数字典
            ExHashTable parmaKeyDict = new ExHashTable();//用于存放生成请求报文的参数
            ExHashTable retKeyDict = new ExHashTable();//用于存放

            /**
             * 第一部分：生成发送银行的请求的报文的实例
             * 
             */

            //生成随机数: 当前精确到秒的时间再加6位的数字随机序列
            string rdNum = System.DateTime.Now.ToString("yyyyMMddHHmmss");//设置日期格式
            Random random = new Random();
            int ird = random.Next(0, 999999);
            string srd = ird.ToString().PadLeft(6, '0');
            string thirdLogNo = rdNum + srd;

            //报文参数赋值
            parmaKeyDict.Add("TranFunc", "1330");//交易码，此处以【1320】接口为例子 1330
            parmaKeyDict.Add("Qydm", "00102079900001231000");//8545

            parmaKeyDict.Add("ThirdLogNo", thirdLogNo); //请求流水号，特别重要
            parmaKeyDict.Add("FuncFlag", "1");//1:签到 2：签退
            parmaKeyDict.Add("TxDate", "20151125");
            parmaKeyDict.Add("Reserve", "保留域");

            //获取请求报文
            BankInterface msg = new BankInterface();
            string tranMessage = msg.GetTranMessageReq(parmaKeyDict);//调用函数生成报文

            //输出报文结果
            Console.Write("[输出报文结果]:" + tranMessage);
            // FileHelper.SaveFile("out.txt", tranMessage + "\r\n");            
            /**
              * 第二部分：获取银行返回的报文的实例
              * 
              */
            //发送请求报文  //获取银行返回报文
            string recvMessage = msg.SendMessage(tranMessage);
            //输出报文结果
            Console.Write("第二部分：获取银行返回的报文");
            Console.Write(recvMessage);
            Console.Write("-------------------------------");

            /**
             * 第三部分：解析银行返回的报文的实例
             * 
             */
            retKeyDict = msg.ParsingTranMessageString(recvMessage);
            string rspCode = (string)retKeyDict.Get("RspCode");//银行返回的应答码
            string rspMsg = (string)retKeyDict.Get("RspMsg");//银行返回的应答描述
            string bodyMsg = (string)retKeyDict.Get("BodyMsg");
            string frontLogNo = (string)retKeyDict.Get("FrontLogNo");//银行返回的前置流水号

            //输出报文结果
            Console.Write("第三部分：解析银行返回的报文");
            Console.Write("返回应答码：");
            Console.Write(rspCode);
            Console.Write("返回应答码描述：");
            Console.Write(rspMsg);
            Console.Write("返回报文体：");
            Console.Write(bodyMsg);
            Console.Write("返回前置流水号：");
            Console.Write(frontLogNo);
            Console.Write("-------------------------------");

            Console.ReadLine();
        }


        [TestMethod]
        public void MyTestEnum()
        {
            var result = Utils.ToEnumProp<IDType>();
        }
        [TestMethod]
        public void MyTestFile()
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\erp_20160825.txt";
            string str = SecretHelper.SHA1File(path);
        }
        [TestMethod]
        public void MyTesSuffix()
        {
            var sstr = "123456789";
            string test = sstr.Increment();
            string test1 = sstr.Increment(3);
            string mm = "";
        }

        [TestMethod]
        public void MyTesDynamic()
        {
            //string str = "A0010101010090102500000006500000000004074001  00000022016082510324920160825103247284732000000:交易受理成功                                                                                       000001            0         0<?xml version=\"1.0\" encoding=\"GBK\" ?><Result><Account>11015065535007</Account><CcyCode>RMB</CcyCode><CcyType></CcyType><AccountName>平安测试六零零零六九六二一二九一</AccountName><Balance>785128168.03</Balance><TotalAmount>785128168.03</TotalAmount><AccountType></AccountType><AccountStatus>A</AccountStatus><BankName></BankName><LastBalance>785128168.03</LastBalance><HoldBalance>0.00</HoldBalance></Result>";
            //dynamic d = Utils.LoadXML(str);
            //string ss = d.Account.Value;
            //var res_4001 = new Res_4001();
            //Utils.Test<Res_4001>(res_4001, d);
        }

        [TestMethod]//功能弱
        public void MyFtpTest()
        {
            //string host = "121.15.166.119";
            //string userName = "pab2biuser";
            //string userPwd = "0_1@32&*s+udd~QhfsVfEW4*5<)";
            //var ftp = new FTPClient(host, 22);

            string host = "115.159.186.113";
            string userName = "b2bftp";
            string userPwd = "Djy123456Djy";
            var ftp = new FTPClient(host, 21);


            ftp.ControlEncoding = Encoding.GetEncoding("GBK");//设置编码   

            ftp.Login(userName, userPwd);
            ftp.ConnectMode = FTPConnectMode.PASV;
            ftp.TransferType = FTPTransferType.BINARY;

            string[] mm = ftp.Features();

            //获取文件列表
            string[] files = ftp.Dir();
            //上传文件
            //ftp.Put("error.txt", "error.txt");
            ftp.ChDir(files[1]);// ("61_平安银行银企直连接入规范文档(对客户)");
            files = ftp.Dir();
            //下载文件
            // ftp.Get(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "端口转发.exe");
            string strFile = files[12];

            //var bb = ftp.Get(strFile);
            MemoryStream ms = new MemoryStream();
            ftp.Get(ms, strFile);
            byte[] bb = ms.ToArray();

            //删除文件
            //ftp.Delete("Demo.cs");

            ftp.Quit();

        }

        [TestMethod]//功能强
        public void MyFtpTest1()
        {
            var ftp = new FTPConnection();
            ftp.ServerAddress = "115.159.186.113";
            ftp.ServerPort = 21;
            ftp.UserName = "b2bftp";
            ftp.Password = "Djy123456Djy";
            ftp.CommandEncoding = Encoding.GetEncoding("GBK");//设置编码
            //连接
            ftp.Connect();


            ftp.ConnectMode = FTPConnectMode.PASV;
            ftp.TransferType = FTPTransferType.BINARY;


            string[] files = ftp.GetFiles();
            FTPFile[] fileDetails = ftp.GetFileInfos();
            ////当前目录
            string directory = ftp.WorkingDirectory;
            ////切换目录 进入指定的目录
            bool change = ftp.ChangeWorkingDirectory("/tools/测试证书pfx/");


            files = ftp.GetFiles();
            fileDetails = ftp.GetFileInfos();



            ////切换到上级目录
            //bool b = ftp.ChangeWorkingDirectoryUp();
            ////上传文件
            //ftp.UploadFile(localFilePath, remoteFileName);
            ////上传文件 已存是否覆盖
            //ftp.UploadFile(localFilePath, remoteFileName, true);           
            ////下载文件
            //ftp.DownloadFile("b2bic-副本.rar", "/tools/b2bic-副本.rar");
            //将内存字节数据上传到远程服务器
            //ftp.UploadByteArray(bytes, remotFileName);
            //下载远程文件到本地内存
            //byte[] bytes = ftp.DownloadByteArray(remoteFileName);
            //删除远程文件
            //bool dFlag = ftp.DeleteFile(remoteFileName);
            //内存流上传到远程服务器
            //ftp.UploadStream(stream, remoteFileName);            
            //关闭
            ftp.Close();
        }
    }
}
