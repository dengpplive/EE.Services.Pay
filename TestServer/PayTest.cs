using EE.Services.Pay.Common;
using EE.Services.Pay.Common.Ext;
using EE.Services.Pay.DataAccess;
using EE.Services.Pay.InertnetVer;
using EE.Services.Pay.Model;
using EE.Services.Pay.Model.DiskFile;
using EE.Services.Pay.Model.Req;
using EE.Services.Pay.Model.Res;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TestServer.PAPayServices;
namespace EE.Services.Pay.PayTestDemo
{
    public class PayTest
    {

        #region BankEnterpriseDirectInterface 466

        public void Test_4002()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4002 = new Req_4002();
            req_4002.Account = "11009692398603";// "11011781161701";// "11002873390701";
            var result = be.QueryErpTodayTradeDetailInterface(serialNumber, req_4002);
            var rs = result.ToModel<DynamicXml>();
            var res_4002 = rs.To_4002();
        }
        public void Test_S001()
        {
            // string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var result = be.SystemStatusProbeInterface();
        }
        public void Test_4018()//结果需要4015查询
        {
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4018 = new Req_4018();
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            req_4018.ThirdVoucher = thirdVoucher;//相当于流水号
            req_4018.totalCts = 2;
            req_4018.totalAmt = 2m;
            //req_4018.BatchSummary = "测试批量转账";
            //req_4018.BSysFlag = "N";
            //req_4018.CcyCode = "RMB";
            req_4018.OutAcctNo = "11009692398603";
            req_4018.OutAcctName = "平安测试六零零零三四一三七一零三";
            //req_4018.OutAcctAddr = "";
            req_4018.BookingDate = System.DateTime.Now.ToString("yyyyMMdd");
            req_4018.PayType = 1;
            //开头部分
            string tThirdVoucher = AssistantHelper.GetOrderId(3, "yyyyMMddHHmmss", "");


            HOResultSet4018R hOResultSet4018R = new HOResultSet4018R();
            req_4018.HOResultSet4018R.Add(hOResultSet4018R);
            hOResultSet4018R.SThirdVoucher = tThirdVoucher + 1.ToString().PadLeft(3, '0');
            //hOResultSet4018R.CstInnerFlowNo = "";
            //hOResultSet4018R.InAcctBankNode = "";
            //hOResultSet4018R.InAcctRecCode = "";
            hOResultSet4018R.InAcctNo = "11002923034501";//收款人账户
            hOResultSet4018R.InAcctName = "平安测试六零零零三三八二八五九八";//收款人账户户名
            hOResultSet4018R.InAcctBankName = "0821";//收款人开户行名称
            hOResultSet4018R.TranAmount = 1m;//转出金额 
            hOResultSet4018R.UseEx = "测试资金2";//资金用途
            hOResultSet4018R.UnionFlag = 1;//行内跨行标志
            hOResultSet4018R.AddrFlag = 1;//同城/异地标志
            //hOResultSet4018R.MainAcctNo = "法人清算号";


            hOResultSet4018R = new HOResultSet4018R();
            req_4018.HOResultSet4018R.Add(hOResultSet4018R);
            hOResultSet4018R.SThirdVoucher = tThirdVoucher + 2.ToString().PadLeft(3, '0');
            //hOResultSet4018R.CstInnerFlowNo = "";
            //hOResultSet4018R.InAcctBankNode = "";
            //hOResultSet4018R.InAcctRecCode = "";
            hOResultSet4018R.InAcctNo = "11007429009401";//收款人账户
            hOResultSet4018R.InAcctName = "平安测试六零零零三四零五六二五零";//收款人账户户名
            hOResultSet4018R.InAcctBankName = "0306";//收款人开户行名称
            hOResultSet4018R.TranAmount = 1m;//转出金额 
            hOResultSet4018R.UseEx = "测试资金3";//资金用途
            hOResultSet4018R.UnionFlag = 1;//行内跨行标志
            hOResultSet4018R.AddrFlag = 1;//同城/异地标志


            /* 银企代码:00101079900009999000
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            qiyeLargeBatchMoneyTransfer.ThirdVoucher = thirdVoucher;//相当于流水号
            qiyeLargeBatchMoneyTransfer.totalCts = 2;
            qiyeLargeBatchMoneyTransfer.totalAmt = 0.02m;
            //qiyeLargeBatchMoneyTransfer.BatchSummary = "测试批量转账";
            qiyeLargeBatchMoneyTransfer.BSysFlag = "N";
            qiyeLargeBatchMoneyTransfer.OutAcctNo = "11002873390701";// "11002873403401";
            qiyeLargeBatchMoneyTransfer.OutAcctName = "EBANK";// "ebt";              
            //qiyeLargeBatchMoneyTransfer.OutAcctAddr = "";
            qiyeLargeBatchMoneyTransfer.BookingDate = System.DateTime.Now.ToString("yyyyMMdd");
            //qiyeLargeBatchMoneyTransfer.PayType = 1;
            //开头部分
            string tThirdVoucher = AssistantHelper.GetOrderId(3, "yyyyMMddHHmmss", "");
            for (int i = 1; i < 3; i++)
            {
                HOResultSet4018R hOResultSet4018R = new HOResultSet4018R();
                qiyeLargeBatchMoneyTransfer.HOResultSet4018R.Add(hOResultSet4018R);
                hOResultSet4018R.SThirdVoucher = tThirdVoucher + i.ToString().PadLeft(3, '0');
                //hOResultSet4018R.CstInnerFlowNo = "";
                //hOResultSet4018R.InAcctBankNode = "";
                //hOResultSet4018R.InAcctRecCode = "";
                hOResultSet4018R.InAcctNo = "11002873403401";// "11002873390701";//收款人账户
                hOResultSet4018R.InAcctName = "ebt";// "EBANK";//收款人账户户名
                hOResultSet4018R.InAcctBankName = "anything";//收款人开户行名称
                hOResultSet4018R.TranAmount = 0.01m;//转出金额 
                hOResultSet4018R.UseEx = "testreturn";//资金用途
                hOResultSet4018R.UnionFlag = 1;//行内跨行标志
                hOResultSet4018R.AddrFlag = 1;//同城/异地标志

                //hOResultSet4018R.MainAcctNo = "法人清算号";
            }
            */
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            var result = be.QiyeLargeBatchMoneyTransferInterface(serialNumber, req_4018);
            var Rs = result.ToModel<DynamicXml>();
            var res_4018 = Rs.To_4018();
        }

        public void Test_4004()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();

            //跨行转账
            var req_4004 = new Req_4004();
            req_4004.ThirdVoucher = thirdVoucher;
            req_4004.OutAcctNo = "11009692398603";
            req_4004.OutAcctName = "平安测试六零零零三四一三七一零三";
            //超级网银渠道 加急
            req_4004.InAcctNo = "6214837820338196";// "6214978800000024";
            req_4004.InAcctName = "陈格娟";// "何兆启";
            req_4004.InAcctBankName = "招商银行";// "313736000019";
            req_4004.SysFlag = "N";// "2";
            req_4004.UseEx = "跨行转账";
            req_4004.TranAmount = 5m;
            req_4004.UnionFlag = 0;
            req_4004.AddrFlag = 1;
            var result = be.QiyeSingleMoneyTransferInterface(serialNumber, req_4004);

            /*
            // 行内转账
            var req_4004 = new Req_4004();
            req_4004.ThirdVoucher = thirdVoucher;
            //req_4004.CcyCode = "RMB";
            req_4004.OutAcctNo = "11009692398603";
            req_4004.OutAcctName = "平安测试六零零零三四一三七一零三";
            req_4004.InAcctNo = "11002923034501";
            req_4004.InAcctName = "平安测试六零零零三三八二八五九八";
            req_4004.InAcctBankName = "0821";
            req_4004.TranAmount = 12m;
            req_4004.UnionFlag = 1;
            req_4004.AddrFlag = 1;
            //可选
            // req_4004.CstInnerFlowNo = "";           
            // req_4004.OutAcctAddr = "";
            // req_4004.InAcctBankNode = "";
            // req_4004.InAcctRecCode = "";
            // req_4004.InAcctProvinceCode = "";
            // req_4004.InAcctCityName = "";
            // req_4004.AmountCode = "";
            // req_4004.UseEx = "";
            //// req_4004.SysFlag = "2";
            // req_4004.MainAcctNo = "";
            // req_4004.Mobile = "";
            // req_4004.zdJType = "";
            // req_4004.zdZType = "";
            // req_4004.zdBAcc = "";
            //代理行信息
            req_4004.ProxyPayName = "蔡丹丹";
            req_4004.ProxyPayAcc = "6224280000212105";
            req_4004.ProxyPayBankName = "宁夏银行";

            // req_4004.InIDType = "";
            // req_4004.InIDNo = "";
            // req_4004.BFJTranType = "";
            // req_4004.BFJBizType = "";          
            var result = be.QiyeSingleMoneyTransferInterface(serialNumber, req_4004);
            */
        }
        public void Test_400401()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_400401 = new Req_400401();
            req_400401.ThirdVoucher = thirdVoucher;
            req_400401.OutAcctNo = "11009692398603";
            req_400401.OutAcctName = "平安测试六零零零三四一三七一零三";
            req_400401.InAcctNo = "11005577115901";
            req_400401.InAcctName = "平安测试六零零零六九二七四零二六";
            req_400401.InAcctBankName = "0881";
            req_400401.TranAmount = 20m;
            req_400401.UnionFlag = 1;
            req_400401.AddrFlag = 1;

            //可选
            //req_400401.CstInnerFlowNo = "";
            //req_400401.OutAcctAddr = "";
            //req_400401.InAcctBankNode = "";
            //req_400401.InAcctRecCode = "";
            //req_400401.InAcctProvinceCode = "";
            //req_400401.InAcctCityName = "";
            //req_400401.AmountCode = "";
            //req_400401.UseEx = "";
            //req_400401.SysFlag = "";
            //req_400401.BFJTranType = "";
            //req_400401.BFJBizType = "";

            var result = be.SingleSubmitTransferSummaryBatchInterface(serialNumber, req_400401);
        }
        public void Test_4014()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4014 = new Req_4014();
            req_4014.ThirdVoucher = thirdVoucher;
            req_4014.totalCts = 3;
            req_4014.totalAmt = 33m;
            //可选
            req_4014.BatchSummary = "";


            string SThirdVoucher = AssistantHelper.GetOrderId(3, "yyyyMMddHHmmss", "");
            var hoResultSet4014R = new HOResultSet4014R();
            req_4014.HOResultSet4014R.Add(hoResultSet4014R);
            hoResultSet4014R.OutAcctNo = "11009692398603";
            hoResultSet4014R.OutAcctName = "平安测试六零零零三四一三七一零三";
            hoResultSet4014R.InAcctNo = "11002923034501";
            hoResultSet4014R.InAcctName = "平安测试六零零零三三八二八五九八";
            hoResultSet4014R.InAcctBankName = "0821";
            hoResultSet4014R.TranAmount = 11m;
            hoResultSet4014R.UseEx = "11";
            hoResultSet4014R.UnionFlag = 1;
            hoResultSet4014R.AddrFlag = "1";
            //可选
            hoResultSet4014R.SThirdVoucher = SThirdVoucher + "1".PadLeft(3, '0');
            //hoResultSet4014R.CstInnerFlowNo = "";
            //hoResultSet4014R.OutAcctAddr = "";
            //hoResultSet4014R.InAcctBankNode = "";
            //hoResultSet4014R.InAcctRecCode = "";
            //hoResultSet4014R.InAcctProvinceCode = "";
            //hoResultSet4014R.InAcctCityName = "";
            //hoResultSet4014R.AmountCode = "";
            //hoResultSet4014R.SysFlag = "N";
            //hoResultSet4014R.MainAcctNo = "";
            //hoResultSet4014R.BookingDate = "";
            hoResultSet4014R.ProxyPayName = "平安测试三四六五九";
            hoResultSet4014R.ProxyPayAcc = "6230580000074308748";
            hoResultSet4014R.ProxyPayBankName = "0577";
            //hoResultSet4014R.BFJTranType = "";
            //hoResultSet4014R.BFJBizType = "";


            hoResultSet4014R = new HOResultSet4014R();
            req_4014.HOResultSet4014R.Add(hoResultSet4014R);
            hoResultSet4014R.OutAcctNo = "11009692398603";
            hoResultSet4014R.OutAcctName = "平安测试六零零零三四一三七一零三";
            hoResultSet4014R.InAcctNo = "11007429009401";
            hoResultSet4014R.InAcctName = "平安测试六零零零三四零五六二五零";
            hoResultSet4014R.InAcctBankName = "0821";
            hoResultSet4014R.TranAmount = 11m;
            hoResultSet4014R.UseEx = "11";
            hoResultSet4014R.UnionFlag = 1;
            hoResultSet4014R.AddrFlag = "1";
            //可选
            hoResultSet4014R.SThirdVoucher = SThirdVoucher + "2".PadLeft(3, '0');

            hoResultSet4014R = new HOResultSet4014R();
            req_4014.HOResultSet4014R.Add(hoResultSet4014R);
            hoResultSet4014R.OutAcctNo = "11009692398603";
            hoResultSet4014R.OutAcctName = "平安测试六零零零三四一三七一零三";
            hoResultSet4014R.InAcctNo = "11009280990201";
            hoResultSet4014R.InAcctName = "平安测试六零零零三四一二二五七八";
            hoResultSet4014R.InAcctBankName = "0821";
            hoResultSet4014R.TranAmount = 11m;
            hoResultSet4014R.UseEx = "11";
            hoResultSet4014R.UnionFlag = 1;
            hoResultSet4014R.AddrFlag = "1";
            //可选
            hoResultSet4014R.SThirdVoucher = SThirdVoucher + "3".PadLeft(3, '0');

            var result = be.QiyeBatchNoDelayMoneyTransferInterface(serialNumber, req_4014);
            var Rs = result.ToModel<DynamicXml>();
            var rr = Rs.To_4014();
        }

        public void Test_4005()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4005 = new Req_4005();
            req_4005.OrigThirdLogNo = serialNumber;
            req_4005.OrigThirdVoucher = "20160808111023652436";// "20160720111206063841";// "20160715090124806767";//转账凭证号
            req_4005.OrigFrontLogNo = "8043431608085100818912";// "8043431607205101431912";//银行流水号 8043431607205101431912
            var result = be.SingleTransferCmdQueryInterface(serialNumber, req_4005);
            var Rs = result.ToModel<DynamicXml>();
            var res_4005 = Rs.To_4005();
        }
        public void Test_4006()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4006 = new Req_4006();
            var result = be.ErpTradeDetailInfoQueryInterface(serialNumber, req_4006);
            var Rs = result.ToModel<DynamicXml>();
        }
        public void Test_4008()//4008为4002和4006的组合。
        {
            //00102063000000002000
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4008 = new Req_4008();
            req_4008.AcctNo = "11009692398603";
            var result = be.QueryErpTodayTradeDetailedInterface(serialNumber, req_4008, true);
            //var Rs = result.ToModel<DynamicXml>();
            //var res_4008 = Rs.To_4008();
        }
        public void Test_4015()
        {
            //用于查询4014，4018，4034上送的批量转账结果信息

            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            // string origThirdVoucher = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var largeBatchTransferCmdQuery = new Req_4015();
            largeBatchTransferCmdQuery.OrigThirdVoucher = "20160808145642732452";// "20160720112036363063";//"20160715090124806767";// origThirdVoucher;//批量转账凭证号

            string sThirdVoucher = AssistantHelper.GetOrderId(3, "yyyyMMddHHmmss", "");
            for (int i = 1; i < 3; i++)
            {
                var hOResultSet4015R = new HOResultSet4015R();
                largeBatchTransferCmdQuery.HOResultSet4015R.Add(hOResultSet4015R);
                //单笔转账凭证号 20160808144000656001    "20160720113120360"
                hOResultSet4015R.SThirdVoucher = "20160808144000656" + i.ToString().PadLeft(3, '0');
            }

            var result = be.LargeBatchTransferCmdQueryInterface(serialNumber, largeBatchTransferCmdQuery);

            var r = result.ToModel<DynamicXml>().To_4015();
        }

        public void Test_4034()
        {
            //用于查询4014，4018，4034上送的批量转账结果信息

            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4034 = new Req_4034();
            req_4034.ThirdVoucher = thirdVoucher;
            req_4034.totalCts = 1;
            req_4034.totalAmt = 50m;
            req_4034.OutAcctNo = "11009692398603";
            req_4034.OutAcctName = "平安测试六零零零三四一三七一零三";
            //req_4034.BSysFlag = "N";
            //可选
            //req_4034.OutAcctAddr = "";
            //req_4034.BatchSummary = "";

            string sThirdVoucher = AssistantHelper.GetOrderId(3, "yyyyMMddHHmmss", "");
            var hOResultSet4018R = new HOResultSet4018R();
            req_4034.HOResultSet4018R.Add(hOResultSet4018R);
            hOResultSet4018R.SThirdVoucher = sThirdVoucher + "1".PadLeft(3, '0');
            hOResultSet4018R.InAcctNo = "11007429009401";
            hOResultSet4018R.InAcctName = "平安测试六零零零三四零五六二五零";
            hOResultSet4018R.InAcctBankName = "0306";
            hOResultSet4018R.InAcctProvinceCode = "";
            hOResultSet4018R.InAcctCityName = "";
            hOResultSet4018R.TranAmount = 10m;
            hOResultSet4018R.UseEx = "4034";
            //hOResultSet4018R.UnionFlag = 1;
            //hOResultSet4018R.AddrFlag = 1;
            //可选
            //hOResultSet4018R.CstInnerFlowNo = "";
            //hOResultSet4018R.InAcctBankNode = "";
            //hOResultSet4018R.InAcctRecCode = "";
            //hOResultSet4018R.MainAcctNo = "";


            var result = be.QiyeSummaryMoneyTransferInterface(serialNumber, req_4034);
            var result1 = be.QiyeSummaryMoneyTransfer_403401Interface(serialNumber, req_4034);

            var Rs = result.ToModel<DynamicXml>();
            var res_4034 = Rs.To_4034();
        }

        public void Test_4012()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4012 = new Req_4012();
            req_4012.Account = "11009692398603";// "11002873390701";
            req_4012.RptDate = "20160514";
            req_4012.Reserve = "";
            var result = be.HistoryBalanceQueryInterface(serialNumber, req_4012);
            //var rsXML = result.ToModel<DynamicXml>();
            //var res_4012 = rsXML.To_4012();
        }

        public void Test_4013()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4013 = new Req_4013();
            req_4013.AcctNo = "11009692398603";// "11002873390701";
            //不输入查询当日 输入查询历史
            req_4013.BeginDate = "20160613";
            req_4013.EndDate = "20160824";
            var result = be.QueryTodayHistoryTransactionDetailInterface(serialNumber, req_4013);
            //dynamic Rs = result.ToModel<DynamicXml>();
            //if (Rs != null)
            //{
            //    //取元素的值 Rs.元素名.Value和属性的值Rs.元素名["属性名称"]
            //    var AcctNo = Rs.AcctNo.Value;
            //    var CcyCode = Rs.CcyCode.Value;
            //    var Reserve = Rs.Reserve.Value;
            //    var PageRecCount = Rs.PageRecCount.Value;
            //    var PageNo = Rs.PageNo.Value;
            //    var PageSize = Rs.PageSize.Value;

            //    var res_4013 = (Rs as DynamicXml).To_4013();
            //}
            //返回集合XeElement
            // var d = Rs.list;
            //获取单元素内部的XML字符串
            //var x1 = Rs.InnerXml;
            //获取集合内部的XML字符串 两种方法
            //var x1xml = Utils.InnerXml(Rs.list);
            //var x2xml = (Rs.list as List<DynamicXml>).InnerXml();


            //string xml = "<?xml version=\"1.0\" encoding=\"GBK\" ?><Result><AcctNo>11002873390701</AcctNo><CcyCode>RMB</CcyCode><EndFlag>Y</EndFlag><Reserve></Reserve><PageRecCount>5</PageRecCount><PageNo>1</PageNo><PageSize>30</PageSize><list><AcctDate>20160518</AcctDate><TxTime>093040</TxTime><HostTrace>3240791605180000620387</HostTrace><BussSeqNo>8043431607135101151572</BussSeqNo><OutNode>0821</OutNode><OutBankNo></OutBankNo><OutBankName>平安银行</OutBankName><OutAcctNo>11002923034501</OutAcctNo><OutAcctName>平安测试六零零零三三八二八五九八</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>100.00</TranAmount><InNode>0800</InNode><InBankNo></InBankNo><InBankName></InBankName><InAcctNo>11002873390701</InAcctNo><InAcctName>平安测试六零零零三三七七九五零九</InAcctName><DcFlag>C</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose>代30200002426233平安测试六零零零三三八二八五九八 收款 （本行入金）</Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160518</AcctDate><TxTime>093054</TxTime><HostTrace>3240791605180000620511</HostTrace><BussSeqNo>8043431607135101151591</BussSeqNo><OutNode>0800</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11002873390701</OutAcctNo><OutAcctName>平安测试六零零零三三七七九五零九</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>2.20</TranAmount><InNode>0821</InNode><InBankNo></InBankNo><InBankName>平安银行</InBankName><InAcctNo>11002923034501</InAcctNo><InAcctName>平安测试六零零零三三八二八五九八</InAcctName><DcFlag>D</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose>代30200002426233平安测试六零零零三三八二八五九八 付款 （ZZZZZ）</Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160518</AcctDate><TxTime>112754</TxTime><HostTrace>3240791605180000707051</HostTrace><BussSeqNo>8043431607135101156640</BussSeqNo><OutNode>0800</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11002873390701</OutAcctNo><OutAcctName>平安测试六零零零三三七七九五零九</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>7.80</TranAmount><InNode>0881</InNode><InBankNo></InBankNo><InBankName>平安银行</InBankName><InAcctNo>11005749455802</InAcctNo><InAcctName>平安测试六零零零三三九五九七八五</InAcctName><DcFlag>D</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose>代30200002000001平安测试六零零零三三七七九五零九 付款 （ZZZZZww）</Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160518</AcctDate><TxTime>113542</TxTime><HostTrace>3240791605180000713174</HostTrace><BussSeqNo>8043431607135101157985</BussSeqNo><OutNode>0800</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11002873390701</OutAcctNo><OutAcctName>平安测试六零零零三三七七九五零九</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>9.90</TranAmount><InNode>0800</InNode><InBankNo></InBankNo><InBankName>平安银行</InBankName><InAcctNo>30200002000001</InAcctNo><InAcctName>平安测试六零零零三三七七九五零九</InAcctName><DcFlag>D</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose>ZZZZZee</Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160518</AcctDate><TxTime>113542</TxTime><HostTrace>3240791605180000713174</HostTrace><BussSeqNo>8043431607135101157985</BussSeqNo><OutNode>0800</OutNode><OutBankNo></OutBankNo><OutBankName>平安银行</OutBankName><OutAcctNo>11002873390701</OutAcctNo><OutAcctName>平安测试六零零零三三七七九五零九</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>9.90</TranAmount><InNode>0800</InNode><InBankNo></InBankNo><InBankName></InBankName><InAcctNo>11002873390701</InAcctNo><InAcctName>平安测试六零零零三三七七九五零九</InAcctName><DcFlag>C</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose>代30200002000001平安测试六零零零三三七七九五零九 收款 （ZZZZZee）</Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list></Result>";
        }

        public void Test_4011()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4011 = new Req_4011();
            req_4011.AcctNo = "11009692398603";// "11002873390701";
            var result = be.ProxyBankPayTodayTradeQueryInterface(serialNumber, req_4011);

            var rs = result.ToModel<DynamicXml>();
        }
        public void Test_4016()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4016 = new Req_4016();
            req_4016.ACNO = "11009692398603";// "11002873390701";
            req_4016.LNNO = "1";
            var result = be.LoanAccountDetailQueryInterface(serialNumber, req_4016, true);
            var rs = result.ToModel<DynamicXml>();
            var r_4016 = rs.To_4016();
        }
        public void Test_4017()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4017 = new Req_4017();
            req_4017.BankNo = "103";
            req_4017.KeyWord = "1";//相当于开户行
            req_4017.BankName = "";//可选
            var result = be.BankContactNumberQueryInterface(serialNumber, req_4017);

            var rs = result.ToModel<DynamicXml>();
            var r_4017 = rs.To_4017();
        }

        public void Test_4020()
        {
            //3.12 离岸账户转账
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4020 = new Req_4020();
            req_4020.ThirdVoucher = thirdVoucher;
            req_4020.TranType = 1;
            req_4020.PayerAcctNo = "11009692398603";
            req_4020.AcctCurrencyNo = "USD";//RMB
            req_4020.PayerName = "平安测试六零零零三四一三七一零三";
            req_4020.RemitterCurrency = "RMB";
            req_4020.Amount = 1m;
            req_4020.RemitteeAcctNo = "11002923034501";
            req_4020.RemitteeName = "平安测试六零零零三三八二八五九八";
            req_4020.RemitteeBankName = "0821";
            req_4020.feeType = 1;
            req_4020.Remark = "1";
            //可选
            req_4020.RemitteeAddr = "";
            req_4020.SwiftNo = "";
            req_4020.BankNo = "";
            req_4020.RemitteeBankAddr = "";
            req_4020.RemitteeBankUnitNo = "";
            req_4020.Intermediary = "";
            req_4020.ContractNo = "";
            req_4020.InvoiceNo = "";
            req_4020.UrgentMark = "";
            req_4020.Contactman = "";
            req_4020.phone = "";
            req_4020.AcctBalance = "";

            var result = be.OffshoreAccountTransferInterface(serialNumber, req_4020);
        }

        public void Test_4019()//3.20 支付指令退票查询
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4019 = new Req_4019();
            req_4019.AccNo = "11009692398603";// "11002873390701";
            req_4019.StartDate = "20160501";
            req_4019.EndDate = "20160825";
            req_4019.PageNo = 1;
            req_4019.PageCts = "30";
            var result = be.PayCmdRefundQueryInterface(serialNumber, req_4019, true);

            //var Rs = result.ToModel<DynamicXml>();
            //var res_4019 = Rs.To_4019();

        }
        public void Test_4047()//跨行暂不支持
        {
            //00101079900009999000
            //入账方式
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            string thirdVoucher = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4047 = new Req_4047();
            /* 批量代收
            req_4047.ThirdVoucher = thirdVoucher;
            req_4047.AGREE_NO = "E000010903";//N
            req_4047.BusiType = "M8SBF";
            req_4047.PayType = 0;
            //req_4047.Currency = "RMB";//
            //req_4047.OthBankFlag = "N";//N
            req_4047.SrcAccNo = "11002873390701";
            req_4047.TotalNum = 1;
            req_4047.TotalAmount = 0.02m;
            req_4047.SettleType = 0;
            string tThirdVoucher = AssistantHelper.GetOrderId(3, "yyyyMMddHHmmss", "");
            for (int i = 1; i < 3; i++)
            {
                var hOResultSet4047R = new HOResultSet4047R();
                req_4047.HOResultSet4047R.Add(hOResultSet4047R);
                
                hOResultSet4047R.SThirdVoucher = tThirdVoucher + i.ToString().PadLeft(3, '0');
                if (i == 1)
                {
                    hOResultSet4047R.OppAccNo = "30100002000002";//
                    hOResultSet4047R.OppAccName = "测试六零零零三三七七九五零九";
                    hOResultSet4047R.Amount = 0.01m;
                }
                else if (i == 2)
                {
                    hOResultSet4047R.OppAccNo = "30100002000003";//
                    hOResultSet4047R.OppAccName = "测试六零零零三三七七九五零九";
                    hOResultSet4047R.Amount = 0.01m;
                }              
                //hOResultSet4047R.CstInnerFlowNo = "abc123";//
                //hOResultSet4047R.OthAreaFlag = "N";
                //hOResultSet4047R.IdType = "1";//
                //hOResultSet4047R.IdNo = "420821198710072018";//
                //hOResultSet4047R.OppBankName = "1";//
                //hOResultSet4047R.OppBranchId = "";//
                //hOResultSet4047R.Province = "";//
                //hOResultSet4047R.City = "";//
                //hOResultSet4047R.PostScript = "";//
                //hOResultSet4047R.RemarkFCR = "";//

            }
            var result = be.OnBehalfOfWithholdApplayInterface(serialNumber, req_4047);
            */
            /* 批量代付 限本行
            req_4047.ThirdVoucher = thirdVoucher;
            req_4047.AGREE_NO = "E000010904";//N
            req_4047.BusiType = "90804";
            req_4047.PayType = 1;
            //req_4047.Currency = "RMB";//
            //req_4047.OthBankFlag = "N";//N
            req_4047.SrcAccNo = "11002873390701";
            req_4047.TotalNum = 2;
            req_4047.TotalAmount = 2m;
            req_4047.SettleType = 0;
            string tThirdVoucher = AssistantHelper.GetOrderId(3, "yyyyMMddHHmmss", "");
            for (int i = 1; i < 3; i++)
            {
                var hOResultSet4047R = new HOResultSet4047R();
                req_4047.HOResultSet4047R.Add(hOResultSet4047R);

                hOResultSet4047R.SThirdVoucher = tThirdVoucher + i.ToString().PadLeft(3, '0');
                if (i == 1)
                {
                    hOResultSet4047R.OppAccNo = "30100002000002";//
                    hOResultSet4047R.OppAccName = "测试六零零零三三七七九五零九";
                    hOResultSet4047R.Amount = 1m;
                }
                else if (i == 2)
                {
                    hOResultSet4047R.OppAccNo = "30100002000003";//
                    hOResultSet4047R.OppAccName = "测试六零零零三三七七九五零九";
                    hOResultSet4047R.Amount = 1m;
                }
                //hOResultSet4047R.CstInnerFlowNo = "abc123";//
                //hOResultSet4047R.OthAreaFlag = "N";
                //hOResultSet4047R.IdType = "1";//
                //hOResultSet4047R.IdNo = "420821198710072018";//
                //hOResultSet4047R.OppBankName = "1";//
                //hOResultSet4047R.OppBranchId = "";//
                //hOResultSet4047R.Province = "";//
                //hOResultSet4047R.City = "";//
                //hOResultSet4047R.PostScript = "";//
                //hOResultSet4047R.RemarkFCR = "";//

            }
            var result = be.OnBehalfOfWithholdApplayInterface(serialNumber, req_4047);
            */


            req_4047.ThirdVoucher = thirdVoucher;
            req_4047.AGREE_NO = "E000090885";//N
            req_4047.BusiType = "05102";
            req_4047.PayType = 1;
            //req_4047.Currency = "RMB";//
            //req_4047.OthBankFlag = "N";//N
            req_4047.SrcAccNo = "11002873390701";
            req_4047.TotalNum = 2;
            req_4047.TotalAmount = 2m;
            req_4047.SettleType = 0;
            string tThirdVoucher = AssistantHelper.GetOrderId(3, "yyyyMMddHHmmss", "");
            for (int i = 1; i < 3; i++)
            {
                var hOResultSet4047R = new HOResultSet4047R();
                req_4047.HOResultSet4047R.Add(hOResultSet4047R);

                hOResultSet4047R.SThirdVoucher = tThirdVoucher + i.ToString().PadLeft(3, '0');
                if (i == 1)
                {
                    hOResultSet4047R.OppAccNo = "30100002000002";//
                    hOResultSet4047R.OppAccName = "测试六零零零三三七七九五零九";
                    hOResultSet4047R.Amount = 1m;
                }
                else if (i == 2)
                {
                    hOResultSet4047R.OppAccNo = "30100002000003";//
                    hOResultSet4047R.OppAccName = "测试六零零零三三七七九五零九";
                    hOResultSet4047R.Amount = 1m;
                }
                //hOResultSet4047R.CstInnerFlowNo = "abc123";//客户自定义凭证号
                //hOResultSet4047R.OthAreaFlag = "N";//异地标志
                //hOResultSet4047R.IdType = "1";//
                //hOResultSet4047R.IdNo = "420821198710072018";//
                //hOResultSet4047R.OppBankName = "对方开户行名";//
                //hOResultSet4047R.OppBranchId = "对方联行号";//
                //hOResultSet4047R.Province = "省份";//
                //hOResultSet4047R.City = "城市";//
                //hOResultSet4047R.PostScript = "附言、备注";//
                //hOResultSet4047R.RemarkFCR = "个人账户备注";//
            }
            var result = be.OnBehalfOfWithholdApplayInterface(serialNumber, req_4047);

        }
        public void Test_4048()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4048 = new Req_4048();
            req_4048.ThirdVoucher = "20160808154438857450";// "20160720111112152561";
            var result = be.OnBehalfOfWithholdResultQueryInterface(serialNumber, req_4048);
        }
        public void Test_4009()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var silverCardTransferMoney = new Req_4009();
            silverCardTransferMoney.ThirdVoucher = thirdVoucher;
            silverCardTransferMoney.OpFlag = 0;
            silverCardTransferMoney.AcctNo = "11002873390701";
            silverCardTransferMoney.StockNo = "bb";
            silverCardTransferMoney.TranAmount = 0.01m;
            //可选
            silverCardTransferMoney.CstInnerFlowNo = "";
            silverCardTransferMoney.PwdEncryType = 0;
            silverCardTransferMoney.StockAccPwd = "";
            silverCardTransferMoney.UseEx = "";

            var result = be.SilverCardTransferMoneyInterface(serialNumber, silverCardTransferMoney);

        }
        public void Test_4010()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4010 = new Req_4010();
            req_4010.AcctNo = "1";
            req_4010.StockAccPwd = "";//可选
            var result = be.QueryBrokerCapitalStationBalanceInterface(serialNumber, req_4010);

        }

        public void Test_401802()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_401802 = new Req_401802();
            req_401802.ThirdVoucher = "20160808145642732452";// "20160715090124806767";
            req_401802.SThirdVoucher = "20160808144000656001";// "20160715090124806767";
            req_401802.OutAcctNo = "11009692398603";// "11002873390701";
            req_401802.InAcctNo = "11002923034501";// "11014501996009";
            req_401802.InAcctName = "平安测试六零零零三三八二八五九八";
            req_401802.TranAmount = 1m;
            var result = be.SummaryPatchPaymentReceiptBillInterface(serialNumber, req_401802);

            //var Rs = result.ToModel<DynamicXml>();
            //var res_401802 = Rs.To_401802();
        }

        public void Test_4027()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4027 = new Req_4027();
            req_4027.ThirdVoucher = thirdVoucher;
            req_4027.totalCts = 2;
            req_4027.totalAmt = 4m;
            req_4027.OutAcctNo = "11009692398603";// "11002873390701";
            req_4027.OutAcctName = "平安测试六零零零三四一三七一零三";

            //开头部分
            string tThirdVoucher = AssistantHelper.GetOrderId(3, "yyyyMMddHHmmss", "");
            //for (int i = 1; i < 2; i++)
            //{
            var hOResultSet4018R = new HOResultSet4018R();
            req_4027.HOResultSet4018R.Add(hOResultSet4018R);
            hOResultSet4018R.SThirdVoucher = tThirdVoucher + 1.ToString().PadLeft(3, '0');
            hOResultSet4018R.InAcctNo = "11002923034501";// "11014501996009";
            hOResultSet4018R.InAcctName = "平安测试六零零零三三八二八五九八";
            hOResultSet4018R.InAcctBankName = "0821";
            hOResultSet4018R.TranAmount = 2m;
            hOResultSet4018R.UseEx = "111";
            hOResultSet4018R.UnionFlag = 1;
            hOResultSet4018R.AddrFlag = 1;

            hOResultSet4018R = new HOResultSet4018R();
            req_4027.HOResultSet4018R.Add(hOResultSet4018R);
            hOResultSet4018R.SThirdVoucher = tThirdVoucher + 2.ToString().PadLeft(3, '0');
            hOResultSet4018R.InAcctNo = "11014501996009";
            hOResultSet4018R.InAcctName = "bb";
            hOResultSet4018R.InAcctBankName = "xxxx";
            hOResultSet4018R.TranAmount = 2m;
            hOResultSet4018R.UseEx = "111";
            hOResultSet4018R.UnionFlag = 1;
            hOResultSet4018R.AddrFlag = 1;
            //}
            var result = be.BlendPatchTransferMoneyInterface(serialNumber, req_4027);

        }

        public void Test_4021()
        {
            //00901025000000002000  00901079800000018000
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4021 = new Req_4021();
            // string Account = "11002873390701";
            //req_4021.PageNo = 1;
            req_4021.AcctNo = "11006094988901";// "11002873390701";
            var result = be.FixedDepositAccountInfoQueryInterface(serialNumber, req_4021);
            //var rs = result.ToModel<DynamicXml>();
            //var res_4021 = rs.To_4021();
        }
        public void Test_4025()
        {  //00901025000000002000 00102063000000002000
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4025 = new Req_4025();
            // string Account = "11002873390701";         
            req_4025.ACNO = "11009692398603";// "11006094988901";// "11002873390701";
            //req_4025.ACSEQ = "1";
            var result = be.QueryLiveComReceiptInfoInterface(serialNumber, req_4025);
            var rs = result.ToModel<DynamicXml>();
            var res_4025 = rs.To_4025();

        }
        public void Test_4054()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4054 = new Req_4054();
            req_4054.AcctNo = "11006094988901";// "11002873390701";
            req_4054.subAccountNo = "11011391189501";
            req_4054.CheckRate = "1";
            var result = be.WithinGroupAccountPreKnotInterface(serialNumber, req_4054);
            var rs = result.ToModel<DynamicXml>();
            var res_4054 = rs.To_4054();
        }
        public void Test_DP00()
        {
            // string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();

            var result = be.DP00_Interface();
            var rs = result.ToModel<DynamicXml>();

        }
        public void Test_SC00()
        {
            // string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();

            var result = be.SC00_Interface();
            //var rs = result.ToModel<DynamicXml>();

        }
        public void Test_4057()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req = new Req_4057();
            req.ThirdVoucher = serialNumber;
            req.AcctNo = "11006094988901"; //"11002873390701";
            req.TranOutVirAcc = "11011391189501";// "30200002000003";
            req.TranInVirAcc = "11006094974001";// "30200002000002";
            req.TranAmount = 1m;
            //可选
            req.CstInnerFlowNo = "";
            req.TranOutVirAccName = "";
            req.TranInVirAccName = "";
            req.UseEx = "";
            var result = be.WithinGroupVirtualAccountBalanceAdjustInterface(serialNumber, req);
            var rs = result.ToModel<DynamicXml>();
            var res_4057 = rs.To_4057();
        }
        public void Test_4058()
        {
            //00901025000000002000
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            //string AcctNo = "11002873390701";
            var req = new Req_4058();
            req.AcctNo = "11006094988901";// "11002873390701";
            req.subAccountNo = "11011391189501";// "30200002000001";
            req.opType = "I";
            req.subAccountName = "平安测试六零零零三四一九六五一二";
            req.feeFlag = "Y";
            req.feeType = "D";
            req.upFee = 0.1m;
            req.dwFee = 0.01m;
            req.mFlag = "Y";

            var res = be.MoneyManageVirtualAccountContractAddOrUpdateOrDelInterface(serialNumber, req);
            var result = res.ToModel<DynamicXml>();

        }

        public void Test_4052()
        {
            //未通过
            //00901025000000002000
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req = new Req_4052();
            req.ThirdVoucher = serialNumber;
            req.AcctNo = "11006094988901";// "11002873390701";
            req.guiJiAreaOption = 1;
            req.subAccountNo = "11006094974001";// "30200002000001";
            //可选
            req.guiJiType = 1;
            req.Amount = 3m;
            var result = be.WithinGroupHandModeNotionalPoolDownPickInterface(serialNumber, req);
            var rs = result.ToModel<DynamicXml>();
            var res_4052 = rs.To_4052();
        }
        public void Test_4022()
        {
            //00901079800000018000
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4022 = new Req_4022();
            req_4022.AC = "11002816805501";// "11002873390701";
            var result = be.WithinGroupTotalAccountQueryInterface(serialNumber, req_4022);
            //var rs = result.ToModel<DynamicXml>();
            //var res_4022 = rs.To_4022();
            //  var x = result.ToModel<DynamicXml>();
            //string xml = "<?xml version=\"1.0\" encoding=\"GBK\" ?><Result><AC>11002873390701</AC><CCY>RMB</CCY><ACNAME>平安测试六零零零三三七七九五零九</ACNAME><GTYPE></GTYPE><WRDATE>20100828</WRDATE><DUEDATE></DUEDATE><CONCURNO></CONCURNO><UNITNO>0800</UNITNO><OVRT-BAL></OVRT-BAL><CURRBAL></CURRBAL><headAgreementState>3</headAgreementState><headAuthCirculateFlag>A</headAuthCirculateFlag><headAuthinnerCirculateType>2</headAuthinnerCirculateType><headHandCirculateFlag>Y</headHandCirculateFlag></Result>";
        }
        public void Test_4023()
        {
            //00901079800000018000
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4023 = new Req_4023();
            req_4023.AC = "11002816805501";// "11002873390701";
            var result = be.WithinGroupSubAccountListQueryInterface(serialNumber, req_4023);
            //var Rs = result.ToModel<DynamicXml>();
            //var res_4023 = Rs.To_4023();
            //string xml = "<?xml version=\"1.0\" encoding=\"GBK\" ?><Result><PAGE>N</PAGE><ALLCOUNT>1</ALLCOUNT><list><SUBAC>11002873403401</SUBAC><SUBNAME>平安测试六零零零三三八五六七六五</SUBNAME><CORSCONBR>0801</CORSCONBR><UPBALANCE>999999192.53</UPBALANCE><DOWNBALANCE>0.00</DOWNBALANCE><payRateComputeDown>0.00</payRateComputeDown><CURRBAL>1000.00</CURRBAL><dayOverBalance>0.00</dayOverBalance><dayOverLimit>0.00</dayOverLimit><upScore>0.00</upScore><downScore>0.00</downScore><subAccCount>0</subAccCount><accountGroupTypeFlag>1</accountGroupTypeFlag></list></Result>";
        }
        public void Test_4055()
        {  //00901025000000002000
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4055 = new Req_4055();
            req_4055.AC = "11006094988901";// "11002873390701";
            req_4055.SUBAC = "11006094974001";// "11002873390701";
            var result = be.CashMangeContractQueryInterface(serialNumber, req_4055);
            var res_4055 = result.ToModel<DynamicXml>().To_4055();
            //string xml = "<?xml version=\"1.0\" encoding=\"GBK\" ?><Result><headAccountNo>11002873390701</headAccountNo><headAccountName>平安测试六零零零三三七七九五零九</headAccountName><headOpenBranch>0800</headOpenBranch><headCurCode>RMB</headCurCode><supAccountNo></supAccountNo><supAccountName>平安测试六零零零三三七七九五零九</supAccountName><supOpenBranch>0800</supOpenBranch><supCurCode>RMB</supCurCode><subAccountNo>11002873390701</subAccountNo><subAccountName>平安测试六零零零三三七七九五零九</subAccountName><BranchNo>0800</BranchNo><currency>RMB</currency><accountGroupTypeFlag>1</accountGroupTypeFlag><subAccountLeve>1</subAccountLeve><agreementType>0</agreementType><authCirculateFlag>A</authCirculateFlag><handGuijiFlag>Y</handGuijiFlag><handXiaboFlag></handXiaboFlag><guiJiType>2</guiJiType><xiaboType></xiaboType><guiJiCycle></guiJiCycle><guiJiDate></guiJiDate><guiJiTime></guiJiTime><guiJiMode></guiJiMode><guiJiIntegerUnity></guiJiIntegerUnity><guiJiBalance>0.00</guiJiBalance><controlMode></controlMode><bigLimit>0.00</bigLimit><bookLimit>0.00</bookLimit><dayOverdraftFlag></dayOverdraftFlag><dayOverLimit>0.00</dayOverLimit><xiaboCycle></xiaboCycle><xiaboDate></xiaboDate><xiaboTime></xiaboTime><xiaboMode></xiaboMode><xiaboKeepAmt>0.00</xiaboKeepAmt><xiaboBalance>0.00</xiaboBalance><entrustLoanFlag></entrustLoanFlag><RateFlag></RateFlag><rateRemitInFlag></rateRemitInFlag><upRate>0.000000</upRate><downRate>0.000000</downRate><agreementState></agreementState><effectDate></effectDate><settleInterestsCycle></settleInterestsCycle><virAccBalance>1000013174.31</virAccBalance></Result>";
        }
        public void Test_4024()
        {  //00901025000000002000  00901079800000018000
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var ledgerRecordQuery = new Req_4024();
            ledgerRecordQuery.AcctNo = "30100002000002";// "11002816805501";// "11002873390701";
            ledgerRecordQuery.subAccountNo = "30100002000002";// "11002816805501";// "11002873390701";
            var result = be.LedgerRecordQueryInterface(serialNumber, ledgerRecordQuery);
            //var Rs = result.ToModel<DynamicXml>();
            //var res_4024 = Rs.To_4024();
        }
        public void Test_4056()
        {
            //00901025000000002000
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var jieXiParam = new Req_4056();
            jieXiParam.accountNo = "11002816805501";// "11002873390701";//"30200002000001";
            //可选    
            jieXiParam.AcctNo = "11002816805501";//11002873390701
            jieXiParam.TxDate = "";
            jieXiParam.EndDate = "";
            jieXiParam.HostSeqNo = "";
            var result = be.JieXiQueryInterface(serialNumber, jieXiParam);

            //var Rs = result.ToModel<DynamicXml>();
            //var res_4056 = Rs.To_4056();
        }
        public void Test_4059()
        {
            //00901025000000002000
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4059 = new Req_4059();
            req_4059.Account = "11011391189501"; // "11002873390701";
            var result = be.CashMangeSubAccountBalanceQueryInterface(serialNumber, req_4059);
            var Rs = result.ToModel<DynamicXml>();
            var res_4059 = Rs.To_4059();
        }
        public void Test_4001()//00102063000000002000
        {
            //00901025000000065000  11015065535007
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4001 = new Req_4001();
            req_4001.Account = "11009692398603";// "11015065535007";// "11009692398603";// "11011781161701";// "11002873390701";
            var result = be.QueryQiyeAccountBalanceInterface(serialNumber, req_4001);
            //直接取值
            //dynamic r = result.ToModel<DynamicXml>();
            //var Rs = result.ToModel<DynamicXml>();
            //var res_4001 = Rs.To_4001();
            //var Account = r.Account.Value;
            //转化为实体类
            //var res_4001 = result.ToModel<DynamicXml>().To_4001();

            //解析xml
            //string xml = result["BodyMsg"].ToString();
            //string xml = "<?xml version=\"1.0\" encoding=\"GBK\" ?><Result><Account>11002873390701</Account><CcyCod-e>RMB</CcyCod-e><CcyType></CcyType><AccountName>平安测试六零零零三三七七九五零九</AccountName><Balance>1100013059.62</Balance><TotalAmount>1100013059.62</TotalAmount><AccountType></AccountType><AccountStatus>A</AccountStatus><BankName></BankName><LastBalance>1100011059.55</LastBalance><HoldBalance>0.00</HoldBalance></Result>";
            //dynamic dyxml = Utils.LoadXML(xml);
            //换成下划线取值
            //var bb = dyxml.CcyCod_e.Value;
            //string Result = dyxml.InnerXml;
            //var  Account = dyxml.Account.Value;
            //var abc = dyxml.Account["abc"];
            //var CcyCode = dyxml.CcyCode.Value;
            //var AccountName = dyxml.AccountName.Value;
            //var Balance = dyxml.Balance.Value;
        }
        public void Test_400101()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_400101 = new Req_400101();
            req_400101.AccountNo = "6226090000000048";// "11002873390701";
            req_400101.AccountName = "张三";// "11002873390701";
            req_400101.CertType = "1";
            req_400101.CertNo = "510265790128303";
            req_400101.Mobile = "18100000000";
            var result = be.DebitCardCustomerInfoVerificationInterface(serialNumber, req_400101);

            //var Rs = result.ToModel<DynamicXml>();
            //var res_400101 = Rs.To_400101();
        }

        public void Test_F001()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_F001 = new Req_F001();
            req_F001.QueryDate = "20160825";
            req_F001.Account = "11014807950004";// "11002873390701";
            req_F001.BsnCode = "";// "4004";
            var result = be.DetailReportQueryInterface(serialNumber, req_F001);
            //var Rs = result.ToModel<DynamicXml>();
            //var res_F001 = Rs.To_F001();

        }

        #endregion

        #region CrossLineFastPaymentInterface  466
        string Dir = @"D:\webs\demo2.xx3700.com_8688\app\PinganFtp\UpFile";
        string UpFile = $"erp_{System.DateTime.Now.ToString("yyyyMMdd")}.txt";



        public void Test_FILE01()//上传文件
        {
            //< !--00102063000000002000-- >
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface be = new CrossLineFastPaymentInterface();
            var req_FILE01 = new Req_FILE01();
            req_FILE01.FileName = UpFile;
            req_FILE01.FilePath = Dir;
            req_FILE01.TradeSn = serialNumber;
            var result = be.FILE01_Interface(serialNumber, req_FILE01);
        }
        public void Test_FILE02()//文件上传和下载进度查询
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface be = new CrossLineFastPaymentInterface();
            string serialNumber = "20160825144403461267";// "20160825142940164538";// "20160825120434857427";// "20160825120157064214";// "20160825112034317624";// "20160818133048213720";
            var result = be.FILE02_Interface(serialNumber);
        }
        public void Test_FILE03()//下载文件
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface be = new CrossLineFastPaymentInterface();

            string TradeSn = "20160826111530652572";// "20160825144403461267";// "20160825142940164538";// "20160825120434857427";// "20160825120157064214";// "20160825112034317624";// "20160825105100815814";
            var rs = be.FILE02_Interface(TradeSn);

            var req_FILE03 = new Req_FILE03();
            req_FILE03.TradeSn = serialNumber;//下载文件的流水号
            req_FILE03.FileName = rs.Model.FileName;
            req_FILE03.RandomPwd = rs.Model.RandomPwd;
            //可选
            req_FILE03.FilePath = "";// Dir;
            //req_FILE03.SignData = rs.Model.SignData;
            //req_FILE03.HashData = rs.Model.HashData;
            var result = be.FILE03_Interface(req_FILE03);
        }
        public void Test_KHKF01()//批量付款文件提交
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface clfp = new CrossLineFastPaymentInterface();
            string TradeSn = "20160825144403461267";// "20160825142940164538";// "20160825120434857427";// "20160825120157064214";// "20160825112034317624";//上传的文件的流水号
            var rs = clfp.FILE02_Interface(TradeSn);
            var req_KHKF01 = new Req_KHKF01();
            req_KHKF01.BatchNo = serialNumber; //"201603260001";
            req_KHKF01.AcctNo = "11014807950004";// "11002873390701";// "11015193727003";// "11015065535007";//"11014891204004";
            req_KHKF01.BusiType = "00000";
            req_KHKF01.TotalNum = 4;
            req_KHKF01.TotalAmount = 10m;
            req_KHKF01.FileName = rs.Model.FileName;
            req_KHKF01.RandomPwd = rs.Model.RandomPwd;
            //可选           
            req_KHKF01.CorpId = "Q000001004";// "E000088334";//"E000070730";
            req_KHKF01.Remark = "让银行处理";
            //req_KHKF01.HashData = rs.Model.HashData;
            //req_KHKF01.SignData = rs.Model.SignData;
            var result = clfp.PatchPaymentFileCommitInterface(req_KHKF01);
            //var Rs = result.ToModel<DynamicXml>();
            //Res_KHKF01 res_KHKF01 = Rs.To_KHKF01();
        }
        public void Test_KHKF02()//需要下载才能查询到 先调用FILE03
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface clfp = new CrossLineFastPaymentInterface();
            var req_KHKF02 = new Req_KHKF02();
            req_KHKF02.AcctNo = "11014807950004";// "11015065535007";
            req_KHKF02.BatchNo = "20160825151642606758";// "20160818180519216306";

            var result = clfp.PatchPaymentResultQueryInterface(serialNumber, req_KHKF02);
        }
        public void Test_KHKF03()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface clfp = new CrossLineFastPaymentInterface();
            var req_KHKF03 = new Req_KHKF03();
            req_KHKF03.OrderNumber = serialNumber;
            req_KHKF03.AcctNo = "11014807950004";// "11015065535007";
            req_KHKF03.BusiType = "00000";
            req_KHKF03.TranAmount = 15m;
            req_KHKF03.InAcctNo = "6226090000000048";
            req_KHKF03.InAcctName = "张三";
            //--可选
            req_KHKF03.CorpId = "Q000001004";// "E000088334";
            //req_KHKF03.CcyCode = "RMB";
            req_KHKF03.InAcctBankName = "";
            req_KHKF03.InAcctBankNode = "";
            req_KHKF03.Mobile = "";
            req_KHKF03.Remark = "";

            var result = clfp.SinglePaymentApplayInterface(req_KHKF03);
        }
        public void Test_KHKF04()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface clfp = new CrossLineFastPaymentInterface();
            var req_KHKF04 = new Req_KHKF04();
            req_KHKF04.AcctNo = "11014807950004";// "11015065535007";
            //可选
            req_KHKF04.OrderNumber = "20160818181232067371";
            req_KHKF04.BussFlowNo = "8043431608186101091369";

            var result = clfp.SinglePaymentResultQueryInterface(req_KHKF04);

        }
        public void Test_KHKF05()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface clfp = new CrossLineFastPaymentInterface();
            var req_KHKF05 = new Req_KHKF05();
            req_KHKF05.Date = "20160826";
            req_KHKF05.AcctNo = "11014807950004";// "11015065535007";
            //可选
            req_KHKF05.FileType = ""; //KHKF01  KHKF02
            req_KHKF05.BatchNo = "";// "20160825151642606758";
            var result = clfp.ReconciliationOrErrorFileQueryInterface(serialNumber, req_KHKF05);
        }
        public void Test_GN()
        {
            //00901025000000065000  11015065535007 余额:785128168.03
            //4个文件
            SendDiskFile send = new SendDiskFile();
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            send.Summary.EntrustUintContractAccount = "11014807950004";// "11002873390701";// "11015193727003";// "11015065535007";
            send.Summary.TotalMoney = 10m;
            send.Summary.TotalNum = 4;
            string str = serialNumber.Increment(4);
            send.DetailList.Add(new SendDiskFile.DetailFiled()//招商银行
            {
                ThirdSerialNumber = str,
                RecvAcctId = "6226090000000048",
                RecvAcctName = "张三",
                Money = 1m,
                Sumup = "招商银行测试",
                Mobile = "18100000000"
            });
            str = str.Increment(4);
            send.DetailList.Add(new SendDiskFile.DetailFiled()//平安银行
            {
                ThirdSerialNumber = str,
                RecvAcctId = "6230580000054508325",
                RecvAcctName = "平安测试七八八零六",
                Money = 2m,
                Sumup = "平安银行测试"
            });
            str = str.Increment(4);
            send.DetailList.Add(new SendDiskFile.DetailFiled()//农业银行
            {
                ThirdSerialNumber = str,
                RecvAcctId = "5200831111111113",
                RecvAcctName = "全渠道",
                Money = 3m,
                Sumup = "农业银行测试",
                Mobile = "13552535506"
            });
            str = str.Increment(4);
            send.DetailList.Add(new SendDiskFile.DetailFiled()//华夏银行
            {
                ThirdSerialNumber = str,
                RecvAcctId = "6226388000000095",
                RecvAcctName = "张三",
                Money = 4m,
                Sumup = "华夏银行测试",
                Mobile = "18100000000"
            });
            send.Save("UpFile\\" + UpFile);

            //OfferDiskFile offer = new OfferDiskFile();
            //MistakeDiskFile miserror = new MistakeDiskFile();
            //CheckBillDiskFile check = new CheckBillDiskFile();
            //check.Summary.FailMoney = 12m;
            //check.Summary.FailNum = 5;
            //check.Summary.SuccessMoney = 21m;
            //check.Summary.SuccessNum = 4;
            //check.Summary.TotalMoney = 100;
            //check.Summary.TotalNum = 20;
            //check.DetailList.Add(new CheckBillDiskFile.DetailFiled()
            //{
            //    BatchNumber = "45454545",
            //    CounterFeeMoney = 11m,
            //    ErrorCode = "1212",
            //    ErrorMsg = "errmsg",
            //    Money = 99m,
            //    Note = "545",
            //    OrderId = "7777",
            //    RecordBillDate = "714",
            //    RecordBillSerialNumber = "111111",
            //    RecvAcctId = "2222222222222",
            //    SettleDate = "201600011111",
            //    TradeDate = "201622111",
            //    TradeTime = "545454"
            //});
            //check.DetailList.Add(new CheckBillDiskFile.DetailFiled()
            //{
            //    BatchNumber = "4646464646464",
            //    CounterFeeMoney = 13m,
            //    ErrorCode = "13131313",
            //    ErrorMsg = "errmsg13",
            //    Money = 99m,
            //    Note = "5353535553",
            //    OrderId = "88888",
            //    RecordBillDate = "99999",
            //    RecordBillSerialNumber = "222222",
            //    RecvAcctId = "444444",
            //    SettleDate = "2016000111111333",
            //    TradeDate = "201622111",
            //    TradeTime = "9994"
            //});

            //string strMsg = check.ToString();
            // FileHelper.SaveFile("UpFile\\" + UpFile, send.ToString(), true, Encoding.GetEncoding("GBK"));
            //FileHelper.SaveFile("offer.txt", offer.ToString(), true, Encoding.GetEncoding("GBK"));
            //FileHelper.SaveFile("check.txt", check.ToString(), true, Encoding.GetEncoding("GBK"));
            //FileHelper.SaveFile("miserror.txt", miserror.ToString(), true, Encoding.GetEncoding("GBK"));
        }

        #endregion


        #region ClientToBankInterface
        public void Test_1330()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1330 = new Model.Req.Req_1330();
            req_1330.FuncFlag = 1;
            req_1330.Reserve = "签到";
            var result = client.SignInOrOutInterface(serialNumber, req_1330);
            var r = result.ToModel<Model.Res.Res_1330>();
        }
        public void Test_1316()//金额从银行卡到会员子账户
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1316 = new Model.Req.Req_1316();
            req_1316.SupAcctId = "11014971070008";// "11014528489007";// "11014165191000";
            req_1316.CustAcctId = "888800000174433";// "888800000016258";
            req_1316.ThirdCustId = "02142081007";// "8545";//"V00000027";
            req_1316.IdType = "52";// "1";// "52";
            req_1316.IdCode = "67485615-5";// "420821198710072018";// "20130802-7";
            req_1316.TranAmount = 1m;// 0.01m;
            //易宝账户
            req_1316.InAcctId = "11014890513006";// "11014748658003";// "11002873403401";
            req_1316.InAcctIdName = "测试一";// "平安测试限公司客户备付金";// "ebt";

            //req_1316.InAcctId = "11014890513006";// "11014748658003";// "11002873403401";
            //req_1316.InAcctIdName = "测试一";// "平安测试限公司客户备付金";// "ebt";

            //inMoneyFromTradeNetwork.CcyCode = "RMB";
            req_1316.Reserve = "";


            var result = client.InMoneyFromTradeNetworkInterface(serialNumber, req_1316);
        }

        public void Test_1318()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1318 = new Model.Req.Req_1318();
            req_1318.TranWebName = "小象快运";
            req_1318.ThirdCustId = "02142081007";
            req_1318.IdType = "52";
            req_1318.IdCode = "757601035";
            //outMoneyFromTradeNetwork.TranOutType = 1;
            req_1318.CustAcctId = "888800000174433";
            req_1318.CustName = "测试一";
            req_1318.SupAcctId = "11014971070008";
            //outMoneyFromTradeNetwork.TranType = 1;
            req_1318.OutAcctId = "11014890513006";
            req_1318.OutAcctIdName = "测试一";
            req_1318.OutAcctIdBankName = "平安银行";
            req_1318.TranAmount = 0.01m;
            //--可选
            req_1318.OutAcctIdBankCode = "";
            req_1318.Address = "";
            req_1318.CcyCode = "";
            req_1318.FeeOutCustId = "";
            req_1318.Reserve = "";
            var result = client.OutMoneyFromTradeNetworkInterface(serialNumber, req_1318);
        }
        public void Test_1010()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1010 = new Model.Req.Req_1010();
            req_1010.SupAcctId = "11014971070008";
            //req_1010.ThirdCustId = "02142081007";
            //req_1010.CustAcctId = "888800000174433";
            req_1010.SelectFlag = 1;
            req_1010.PageNum = 1;
            req_1010.Reserve = "1010";
            var result = client.QueryBankMemberCapitalStationBalanceInterface(serialNumber, req_1010, true);
            var r = result.ToModel<Model.Res.Res_1010>();
        }
        public void Test_1021()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var bankMemberCapitalStationBalance = new Model.Req.Req_1010();
            var req_1021 = new Model.Req.Req_1021();
            //资金汇总账号
            req_1021.AcctId = "11014971070008";
            //交易网代码
            req_1021.TranWebCode = "8877";
            req_1021.Reserve = "";
            var result = client.QuerySuperviseAccountInfoInterface(serialNumber, req_1021);
            var res_1021 = result.ToModel<Model.Res.Res_1021>();
        }
        public void Test_1016()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1016 = new Model.Req.Req_1016();
            req_1016.SupAcctId = "11014971070008";
            req_1016.BeginDate = "20160804";
            req_1016.EndDate = "20160804";
            //queryTimeSlotMemberOpenOrCencelAccountInfo.PageNum = "";


            var result = client.QueryTimeSlotMemberOpenOrCencelAccountInfoInterface(serialNumber, req_1016);
        }

        public void Test_1020()//查询银行卡账号的余额
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1020 = new Req_1020();

            //req_1020.SupAcctId = "11014971070008";
            //req_1020.CustAcctId = "02142081007";
            //req_1020.ThirdCustId = "888800000174433";//可选  
            //req_1020.CustName = "测试一";
            //req_1020.AcctNo = "11014890513006";
            //req_1020.Reserve = "1020";


            //req_1020.SupAcctId = "11014971070008";
            //req_1020.ThirdCustId = "021420810014";
            //req_1020.CustAcctId = "888800000181282";
            //req_1020.CustName = "平安测试996154";
            //req_1020.AcctNo = "11014972687009";
            //req_1020.Reserve = "1020";           

            req_1020.SupAcctId = "11014971070008";
            req_1020.ThirdCustId = "02142081007";
            req_1020.CustAcctId = "888800000174433";
            req_1020.CustName = "测试一";
            req_1020.AcctNo = "11014890513006";
            req_1020.Reserve = "1020";
            // 11014971070008 & 021420810016 & 888800000181443 & 平安测试996156 & 11014972696003 & 1020 &
            var result = client.QueryMemberInOutMoneyAccountBankBalanceInterface(serialNumber, req_1020);
            var r = result.ToModel<Res_1020>();
        }
        public void Test_1324()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1324 = new Model.Req.Req_1324();
            req_1324.SupAcctId = "11014971070008";
            req_1324.OrigThirdLogNo = "";//可选
            req_1324.BeginDate = "20160810";
            req_1324.EndDate = "20160824";
            req_1324.PageNum = 1;
            req_1324.Reserve = "1324";
            var result = client.QueryMemberTradeFlowInfoInterface(serialNumber, req_1324, false);
            var r = result.ToModel<Model.Res.Res_1324>();
        }
        public void Test_1325()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1324 = new Model.Req.Req_1324();
            req_1324.SupAcctId = "11014971070008";
            req_1324.OrigThirdLogNo = "";//可选
            req_1324.BeginDate = "20160804";
            req_1324.EndDate = "20160823";
            req_1324.PageNum = 1;
            req_1324.Reserve = "1325";
            var result = client.QueryMemberInOutMoneyFlowInfoInterface(serialNumber, req_1324);
            var r = result.ToModel<Model.Res.Res_1325>();
        }
        public void Test_1327()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1327 = new Model.Req.Req_1327();
            //资金汇总账号
            req_1327.SupAcctId = "11014971070008";
            //支付指令号
            req_1327.PaySerialNo = "201608040708_1";// "10160804237010";
            req_1327.Reserve = "1327";
            var result = client.QueryPaySerialStatusInterface(serialNumber, req_1327);
            var r = result.ToModel<Model.Res.Res_1327>();
        }

        public void Test_1332()//子账户和子账户
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1332 = new Req_1332();
            req_1332.SupAcctId = "11014971070008";
            req_1332.FuncFlag = 2;
            //req_1332.OutCustAcctId = "888800000174532";
            //req_1332.OutThirdCustId = "02142081009";

            req_1332.OutCustAcctId = "888800000174433";
            req_1332.OutThirdCustId = "02142081007";

            //"888800000182062";// "888800000174433";
            req_1332.InCustAcctId = "888800000182282";
            // "02142081007";
            req_1332.InThirdCustId = "021420810061";

            req_1332.TranAmount = 2m;
            req_1332.HandFee = 0m;
            //"201608040708_17" "201608040708_8";// "201608040708_7";// "201608040708_4";
            req_1332.PaySerialNo = "201608040708_21";
            // "order_201608040709_17" "order_201608040709_8";// "order_201608040709_7";// "order_2016080407092";
            req_1332.ThirdHtId = "order_201608040709_21";

            //--可选
            req_1332.ThirdHtCont = "";
            req_1332.Note = "";
            req_1332.Reserve = "1332";
            var result = client.ChildAccountInDirectPayInterface(serialNumber, req_1332);


            //SupAcctId = "11014971070008";
            //FuncFlag = 1;
            //OutCustAcctId = "888800000174532";
            //OutThirdCustId = "02142081009";
            //InCustAcctId = "888800000181522";
            //InThirdCustId = "021420810017";
            //TranAmount = 2m;
            //HandFee = 0m;
            //PaySerialNo = "201608040708_9";
            //ThirdHtId = "order_201608040709_9";
            //ThirdHtCont = "";
            //Note = "";
            //Reserve = "1332";
        }
        public void Test_1333()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1333 = new Model.Req.Req_1333();
            //资金汇总账号
            req_1333.SupAcctId = "11014971070008";
            //支付指令号
            req_1333.PaySerialNo = "201608040708_16";
            req_1333.TranDate = "20160822";
            req_1333.Reserve = "1333";
            var result = client.QuerySubAccountPayResultInterface(serialNumber, req_1333);
            var r = result.ToModel<Model.Res.Res_1333>();
        }
        public void Test_1342()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1342 = new Model.Req.Req_1342();
            req_1342.SupAcctId = "11014971070008";
            req_1342.FuncFlag = 1;
            //1028 order_20160804117096
            //1030 order_201608040709_10
            req_1342.ThirdHtId = "order_201608040709_10";
            req_1342.Reserve = "1342";
            var result = client.QueryTradeResultByOrderIdInterface(serialNumber, req_1342);
            var r = result.ToModel<Model.Res.Res_1342>();
        }
        public void Test_1348()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1348 = new Model.Req.Req_1348();
            req_1348.SerialNo = "716081910910934";
            req_1348.Reserve = "1348";
            var result = client.QueryBankAuthenticationInterface(serialNumber, req_1348);
            var r = result.ToModel<Model.Res.Res_1348>();
        }

        public void Test_1349()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1349 = new Model.Req.Req_1349();
            req_1349.SupAcctId = "11014971070008";
            req_1349.FuncFlag = 21;
            req_1349.TranDate = "20160823";
            req_1349.Reserve = "1349";
            var result = client.QueryReconciliationFilePwdInterface(serialNumber, req_1349);
            var r = result.ToModel<Model.Res.Res_1349>();
        }

        public void Test_1350()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1350 = new Model.Req.Req_1350();
            req_1350.SupAcctId = "11014971070008";
            req_1350.FuncFlag = 1;
            req_1350.CustAcctId = "888800000174532";
            req_1350.ThirdCustId = "02142081009";
            req_1350.ThirdHtId = "order_20160804118003";
            req_1350.TranAmount = 1m;
            req_1350.Note = "测试充值";
            req_1350.Reserve = "1350";
            var result = client.MemberRechargeInterface(serialNumber, req_1350);
            var r = result.ToModel<Model.Res.Res_1350>();
        }

        public void Test_1328()//可冻结金额可解冻
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1328 = new Model.Req.Req_1328();
            req_1328.SupAcctId = "11014971070008";
            req_1328.FuncFlag = 1;
            req_1328.OutCustAcctId = "888800000174433";
            req_1328.OutThirdCustId = "02142081007";
            req_1328.InCustAcctId = "888800000174532";
            req_1328.InThirdCustId = "02142081009";
            req_1328.TranAmount = 5m;
            req_1328.HandFee = 0.00m;
            req_1328.PaySerialNo = "201608040708_5";//避免支付支付
            req_1328.ThirdHtId = "order_2016080407093";
            //---可选
            req_1328.ThirdHtCont = "第一次支付";
            req_1328.Note = "";
            req_1328.Reserve = "1328";
            var result = client.ChildAccountReviewPayInterface(serialNumber, req_1328);
        }

        public void Test_1331()//对冻结的资金进行支付 未过客户待确认期
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1331 = new Model.Req.Req_1331();
            req_1331.SupAcctId = "11014971070008";
            //会出现"未过客户待确认期"有时间限制
            req_1331.FuncFlag = 2;
            req_1331.PaySerialNo = "201608040708_3";
            req_1331.ThirdHtId = "order_2016080407091";
            req_1331.PayAmount = 1m;
            req_1331.PayFee = 0m;
            //---可选
            req_1331.Note = "";
            req_1331.Reserve = "对1328代理复合";
            var result = client.PlatformOperationPayInterface(serialNumber, req_1331);
        }
        public void Test_1329()//子账户和银行卡
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1329 = new Req_1329();
            //req_1329.OutCustAcctId = "888800000174433";
            //req_1329.OutThirdCustId = "02142081007";

            req_1329.SupAcctId = "11014971070008";
            req_1329.FuncFlag = 1;
            req_1329.OutCustAcctId = "888800000174532";
            req_1329.OutThirdCustId = "02142081009";
            req_1329.InCustAcctId = "888800000182282";
            req_1329.InThirdCustId = "021420810061";
            req_1329.TranAmount = 10m;
            req_1329.HandFee = 0m;
            req_1329.PaySerialNo = "201608040707_4";
            req_1329.ThirdHtId = "order_20160804117091";
            //--可选
            req_1329.ThirdHtCont = "测试子账户到银行卡";
            req_1329.Note = "1";
            req_1329.Reserve = "1329";
            var result = client.ChildAccountDirectPayInterface(serialNumber, req_1329);
        }
        public void Test_1028()//子账户间划转【1028】
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1028 = new Model.Req.Req_1028();
            req_1028.SupAcctId = "11014971070008";
            req_1028.FuncFlag = 1;
            req_1028.OutCustAcctId = "888800000174532";
            req_1028.OutThirdCustId = "02142081009";
            req_1028.InCustAcctId = "888800000174433";// "888800000182282";
            req_1028.InThirdCustId = "02142081007";// "021420810061";
            //req_1028.CcyCode = "RMB";
            req_1028.TranAmount = 2m;
            //可选
            req_1028.ThirdHtId = "order_20160804117095";//订单号不能重复
            req_1028.Note = "";
            req_1028.Reserve = "1028";
            //string ss = req_1028.ToString();
            var result = client.SubAccountPayInterface(serialNumber, req_1028);

        }

        public void Test_1029()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1029 = new Model.Req.Req_1029();
            req_1029.SupAcctId = "11014971070008";
            req_1029.FuncFlag = 2;//冻结/解冻是在原有基础上添加冻结/解冻金额
            req_1029.CustAcctId = "888800000174433";
            req_1029.ThirdCustId = "02142081007";
            req_1029.TranAmount = 21m;
            req_1029.ThirdHtId = "order_201608040709_9";
            //--可选         
            req_1029.Note = "冻结/解冻21元";
            req_1029.Reserve = "1029";
            var result = client.ChildAccountFrozenOrThawInterface(serialNumber, req_1029);
        }
        public void Test_1030()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1030 = new Model.Req.Req_1030();
            req_1030.SupAcctId = "11014971070008";
            req_1030.FuncFlag = 2;
            req_1030.CustAcctId = "888800000174433";
            req_1030.ThirdCustId = "02142081007";
            req_1030.TranAmount = 7m;//收费金额
            req_1030.ThirdHtId = "order_201608040709_10";
            //--可选         
            req_1030.Note = "平台退费7元";// "平台收费7元";
            req_1030.Reserve = "1030";
            var result = client.PlatformChargeOrRefundInterface(serialNumber, req_1030);
        }
        public void Test_1343()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1343 = new Model.Req.Req_1343();
            //-----------测试个人的
            //req_1343.SupAcctId = "11014971070008";
            //req_1343.ThirdCustId = "021420810010";
            //req_1343.AcctId = "6230580000000003108";
            //req_1343.CustName = "平安测试99615";
            //req_1343.IdType = "1";
            //req_1343.IdCode = "350181198612299615";
            //req_1343.CpFlag = 2;
            //req_1343.MobilePhone = "18782938121";
            //req_1343.BankType = 1;
            //req_1343.BankName = "平安银行";
            //req_1343.BankCode = "";
            //req_1343.SBankCode = "307584007998";

            //req_1343.SupAcctId = "11014971070008";
            //req_1343.ThirdCustId = "021420810011";
            //req_1343.AcctId = "6230580000000005053";
            //req_1343.CustName = "平安测试24577";
            //req_1343.IdType = "1";
            //req_1343.IdCode = "460102198801224577";
            //req_1343.CpFlag = 2;
            //req_1343.MobilePhone = "18782938131";
            //req_1343.BankType = 1;
            //req_1343.BankName = "平安银行";
            //req_1343.BankCode = "";
            //req_1343.SBankCode = "307584007998";


            //req_1343.SupAcctId = "11014971070008";
            //req_1343.ThirdCustId = "021420810015";
            //req_1343.AcctId = "6230580000000004932";
            //req_1343.CustName = "平安测试85083";
            //req_1343.IdType = "1";
            //req_1343.IdCode = "350583198401285083";
            //req_1343.CpFlag = 2;
            //req_1343.MobilePhone = "18782938135";
            //req_1343.BankType = 1;
            //req_1343.BankName = "平安银行";
            //req_1343.BankCode = "";
            //req_1343.SBankCode = "307584007998";




            //req_1343.SupAcctId = "11014971070008";
            //req_1343.ThirdCustId = "021420810061";
            //req_1343.AcctId = "6230580000000004841";
            //req_1343.CustName = "平安测试83361";
            //req_1343.IdType = "1";
            //req_1343.IdCode = "352227198212183361";
            //req_1343.CpFlag = 2;
            //req_1343.MobilePhone = "18782938135";
            //req_1343.BankType = 1;
            //req_1343.BankName = "平安银行";
            //req_1343.BankCode = "";
            //req_1343.SBankCode = "307584007998";

            //req_1343.SupAcctId = "11014971070008";
            //req_1343.ThirdCustId = "021420810071";
            //req_1343.AcctId = "6230580000000004833";
            //req_1343.CustName = "平安测试39633";
            //req_1343.IdType = "1";
            //req_1343.IdCode = "510622196906239633";
            //req_1343.CpFlag = 2;
            //req_1343.MobilePhone = "18782938137";
            //req_1343.BankType = 1;
            //req_1343.BankName = "平安银行";
            //req_1343.BankCode = "";
            //req_1343.SBankCode = "307584007998";

            //req_1343.SupAcctId = "11014971070008";
            //req_1343.ThirdCustId = "021420810072";
            //req_1343.AcctId = "6230580000000004791";
            //req_1343.CustName = "平安测试26077";
            //req_1343.IdType = "1";
            //req_1343.IdCode = "532128199110226077";
            //req_1343.CpFlag = 2;
            //req_1343.MobilePhone = "18782938138";
            //req_1343.BankType = 1;
            //req_1343.BankName = "平安银行";
            //req_1343.BankCode = "";
            //req_1343.SBankCode = "307584007998";

            req_1343.SupAcctId = "11014971070008";
            req_1343.ThirdCustId = "021420810072";
            req_1343.AcctId = "6230580000000004619";
            req_1343.CustName = "平安测试07302";
            req_1343.IdType = "1";
            req_1343.IdCode = "350581198802107302";
            req_1343.CpFlag = 2;
            req_1343.MobilePhone = "18782938139";
            req_1343.BankType = 1;
            req_1343.BankName = "平安银行";
            req_1343.BankCode = "";
            req_1343.SBankCode = "307584007998";

            //---------------测试企业的 平台账户要有钱------------------------------
            //req_1343.SupAcctId = "11014971070008";
            //req_1343.ThirdCustId = "021420810066";
            //req_1343.AcctId = "11014971611001";
            //req_1343.CustName = "乐都县宝发金属制品有限公司";
            //req_1343.IdType = "68";
            //req_1343.IdCode = "632123063003748";
            //req_1343.CpFlag = 1;
            //req_1343.MobilePhone = "18512341017";
            //req_1343.BankType = 1;
            //req_1343.BankName = "平安银行";
            //req_1343.BankCode = "";
            ////企业必输           
            //req_1343.SBankCode = "307584007998";
            //req_1343.RegAddress = "RegAddress-上海松江";
            //req_1343.Zip = "201600";
            //req_1343.Address = "Address-上海松江";
            //req_1343.ContactUser = "邓积远";
            ////可选
            //req_1343.EmailAddr = "dengpplive@163.com";
            //req_1343.Reserve = "1343";




            //req_1343.SupAcctId = "11014971070008";
            //req_1343.ThirdCustId = "021420810067";
            //req_1343.AcctId = "11014971610002";
            //req_1343.CustName = "青海祁连嘉业矿业有限公司";
            //req_1343.IdType = "68";
            //req_1343.IdCode = "632222001114265";
            //req_1343.CpFlag = 1;
            //req_1343.MobilePhone = "18512341016";
            //req_1343.BankType = 1;
            //req_1343.BankName = "平安银行";
            //req_1343.BankCode = "";
            ////企业必输           
            //req_1343.SBankCode = "307584007998";
            //req_1343.RegAddress = "RegAddress-上海松江";
            //req_1343.OpenLicense = "OpenLicense";//多了字段
            //req_1343.Zip = "201600";
            //req_1343.Address = "Address-上海松江";
            //req_1343.ContactUser = "邓积远";
            ////可选
            //req_1343.EmailAddr = "dengpplive@163.com";
            //req_1343.Reserve = "1343";

            var result = client.CustRegisterSignYeePayInterface(serialNumber, req_1343);
            //var res_1343 = result.ToModel<Res_1343>();

            //MemberInfoDataAccess.AddOrUpdateMemberInfo(req_1343, res_1343.SerialNo);
        }
        public void Test_1344()
        {
            //string sss = "A0010301018887                000000018400000011716022016081810375852016081810404412061000000交易成功                                                                                            000001            000000000001344020               20160818103758000000交易成功                                  00000006211716520160818104044120618887716081810903207&0&021420810010&888800000181213&11014972682004&";
            ////老版本接口处理  
            //Utils.ToModelFromString<Res_1344>("1344", sss);
            //return;

            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1344 = new Req_1344();
            req_1344.FuncFlag = 2;
            req_1344.SerialNo = "16082015320938";// "16081715236718";
            if (req_1344.FuncFlag == 1) req_1344.MessageCode = "111111";
            else if (req_1344.FuncFlag == 2) req_1344.CheckAmount = 0.01m;
            req_1344.Reserve = "1344";
            var result = client.CustRegisterSignYeePayValidateInterface(serialNumber, req_1344);

            // var res_1344 = result.ToModel<Res_1344>();
            //var ex = new ExHashTable();
            //Utils.ModelToHashTable<Res_1344>(new Res_1344(), ex);

            //更新数据库
            // MemberInfoDataAccess.AddOrUpdateMemberInfo(res_1344);

            //查询
            //var memberInfo = MemberInfoDataAccess.GetMemberInfo(mobile);

        }
        public void Test_1313()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1313 = new Model.Req.Req_1313();
            //默认数据
            //req_1313.TranOutType = 1;
            //req_1313.TranType = 3;
            //req_1313.CcyCode = "RMB";           
            req_1313.SupAcctId = "11014971070008";
            req_1313.ThirdCustId = "02142081009";
            req_1313.TranWebName = "小象快运";
            req_1313.CustAcctId = "888800000174532";
            req_1313.CustName = "测试二";

            //req_1313.ThirdCustId = "021420810061";
            //req_1313.CustAcctId = "888800000182282";
            //req_1313.CustName = "平安测试83361";


            //换成他行银行卡
            // "6226090000000048";// "11014890513006";//易宝账户
            req_1313.OutAcctId = "5200831111111113";// "11014890513006";
            //"张三";// "测试一";//易宝账户
            req_1313.OutAcctIdName = "全渠道";// "测试一";
            // "平安银行";
            req_1313.OutAcctIdBankName = "农业银行";// "平安银行";


            req_1313.TranAmount = 10m;
            //可选
            //req_1313.OutAcctIdBankCode = "";
            //req_1313.Address = "";
            //req_1313.FeeOutCustId = "";
            //req_1313.Reserve = "";

            var result = client.CrossBankPutAmountInterface(serialNumber, req_1313);
            //var res_1313 = result.ToModel<Model.Res.Res_1313>();
        }

        public void Test_1031()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1031 = new Model.Req.Req_1031();
            req_1031.SupAcctId = "11014971070008";
            req_1031.FuncFlag = 1;
            req_1031.CustAcctId = "888800000174433";
            req_1031.ThirdCustId = "02142081007";
            req_1031.TranAmount = 10m;
            req_1031.ThirdHtId = "order_201608040709_10";
            //--可选         
            req_1031.Note = "";
            req_1031.Reserve = "1031";


            var result = client.PlatformPayOrChargeInterface(serialNumber, req_1031);
        }
        #endregion

        #region 测试webServices
        public void Test_W1329()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranPayServicesSoapClient service = new SpotTranPayServicesSoapClient();
            ReqView_1329 req_1329 = new ReqView_1329();
            req_1329.SupAcctId = "11014971070008";
            req_1329.OutCustAcctId = "888800000174433";
            req_1329.OutThirdCustId = "02142081007";
            req_1329.InCustAcctId = "888800000174532";
            req_1329.InThirdCustId = "02142081009";
            req_1329.TranAmount = 10m;
            req_1329.HandFee = 0m;
            req_1329.PaySerialNo = "201608040708_3";
            req_1329.ThirdHtId = "order_2016080407091";
            //--可选
            req_1329.ThirdHtCont = "";
            req_1329.Note = "";
            var result = service.ChildAccountDirectPayInterface(serialNumber, req_1329);
        }
        public void Test_W1332()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranPayServicesSoapClient service = new SpotTranPayServicesSoapClient();
            ReqView_1332 req_1332 = new ReqView_1332();
            req_1332.SupAcctId = "11014971070008";
            req_1332.OutCustAcctId = "888800000174433";
            req_1332.OutThirdCustId = "02142081007";
            req_1332.InCustAcctId = "888800000174532";
            req_1332.InThirdCustId = "02142081009";
            req_1332.TranAmount = 10m;
            req_1332.HandFee = 0m;
            req_1332.PaySerialNo = "201608040708_3";
            req_1332.ThirdHtId = "order_2016080407091";
            //--可选
            req_1332.ThirdHtCont = "";
            req_1332.Note = "";
            var result = service.ChildAccountInDirectPayInterface(serialNumber, req_1332);
        }

        public void Test_W1343()
        {
            //PAPayServices
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranPayServicesSoapClient service = new SpotTranPayServicesSoapClient();
            ReqView_1343 req_1343 = new ReqView_1343();
            req_1343.SupAcctId = "11014971070008";
            req_1343.ThirdCustId = "021420810017"; ;// "021420810014";
            req_1343.AcctId = "6230580000000003117"; // "6230580000000003114";
            req_1343.CustName = "平安测试996157";// "平安测试996154";
            req_1343.IdType = "1";
            req_1343.IdCode = "420821198710072017"; // "420821198710072014";
            req_1343.MobilePhone = "18782938127"; // "18782938124";
            var result = service.CustRegisterSignYeePayInterface(serialNumber, req_1343);//16081715237986
            //继续测试下一个接口            
            //Test_W1344(result.SerialNo);
        }
        public void Test_W1344()//验证信息不存在
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranPayServicesSoapClient service = new SpotTranPayServicesSoapClient();
            ReqView_1344 req_1344 = new ReqView_1344();
            req_1344.SerialNo = "16081715237986";
            req_1344.MessageCode = "111111";
            var result = service.CustRegisterSignYeePayValidateInterface(serialNumber, req_1344);
        }
        public void Test_W1020()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranPayServicesSoapClient service = new SpotTranPayServicesSoapClient();
            ReqView_1020 req_1020 = new ReqView_1020();
            //req_1020.SupAcctId = "11014971070008";
            //req_1020.ThirdCustId = "021420810014";
            //req_1020.CustAcctId = "888800000181282";
            //req_1020.CustName = "平安测试996154";
            //req_1020.AcctNo = "11014972687009";

            //req_1020.SupAcctId = "11014971070008";
            //req_1020.ThirdCustId = "021420810015";
            //req_1020.CustAcctId = "888800000181292";
            //req_1020.CustName = "平安测试996155";
            //req_1020.AcctNo = "11014972688008";

            //req_1020.SupAcctId = "11014971070008";
            //req_1020.ThirdCustId = "021420810016";
            //req_1020.CustAcctId = "888800000181443";
            //req_1020.CustName = "平安测试996156";
            //req_1020.AcctNo = "11014972696003";

            //req_1020.SupAcctId = "11014971070008";
            //req_1020.ThirdCustId = "021420810017";
            //req_1020.CustAcctId = "888800000181522";
            //req_1020.CustName = "平安测试996157";
            //req_1020.AcctNo = "11014972698001";

            //req_1020.SupAcctId = "11014971070008"; 
            //req_1020.ThirdCustId = "02142081009";
            //req_1020.CustAcctId = "888800000174532";
            //req_1020.CustName = "测试二";
            //req_1020.AcctNo = "11014890514005";   


            req_1020.SupAcctId = "11014971070008";
            req_1020.ThirdCustId = "021420810011";
            req_1020.CustAcctId = "888800000182062";
            req_1020.CustName = "平安测试24577";
            req_1020.AcctNo = "11014972712000";



            var result = service.QueryMemberBankBalanceInterface(serialNumber, req_1020);


        }

        public void Test_Auth()
        {
            //添加认证
            SpotTranPayServicesSoapClient service = new SpotTranPayServicesSoapClient();
            MySoapHeader mysoap = new TestServer.PAPayServices.MySoapHeader();
            string aa = service.testA(mysoap);
        }
        #endregion


        #region 其他

        //测试银行发送给企业的数据 下行测试 开启监听后发送数据
        public void Test_Recv(string message)
        {
            ErpClient client = new ErpClient();
            //string message = "A0010301018877                0000000205000000EB001012016080414345916080410792993      999999                                                                                                    00000000000000000000000000000130101                20160804143459999999                                          000000083EB00116080410792993      88771&11014971070008&888800000174512&测试二&02142081008&52&789222662&1&0.00&0.00&0.00&&";
            // string message = "00000053<?xml version=\"1.0\" encoding=\"GBK\"?><Result></Result>";
            string result = client.SendDownMessage(message);
        }
        public void Test_GetMem()
        {
            var result = MemberInfoDataAccess.GetMemberInfo("02142081008");

        }
        public void Test_Dir()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Log");
            var result = FileHelper.ScanDirFile(path);
        }

        public void Test_A()
        {
            //var list = new List<Res_4013>();
            //var sssss = list.GetType();

            //var j = Activator.CreateInstance(list.GetType().GenericTypeArguments[0]);
            //var n = (list.GetType().GenericTypeArguments[0]).FullName;
            //return;

            string str = "<?xml version=\"1.0\" encoding=\"GBK\" ?><Result abc=\"54848\"><Account>11015065535007</Account><CcyCode>RMB</CcyCode><CcyType></CcyType><AccountName>平安测试六零零零六九六二一二九一</AccountName><Balance>785128168.03</Balance><TotalAmount>785128168.03</TotalAmount><AccountType></AccountType><AccountStatus>A</AccountStatus><BankName></BankName><LastBalance>785128168.03</LastBalance><HoldBalance>0.00</HoldBalance></Result>";
            str = "<?xml version=\"1.0\" encoding=\"GBK\" ?><Result><AcctNo>11009692398603</AcctNo><CcyCode>RMB</CcyCode><EndFlag>Y</EndFlag><Reserve></Reserve><PageRecCount>14</PageRecCount><PageNo>1</PageNo><PageSize>30</PageSize><list><AcctDate>20160914</AcctDate><TxTime>132756</TxTime><HostTrace>3240791609148800002810</HostTrace><BussSeqNo>8043431608256101190520</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>1.00</TranAmount><InNode>0821</InNode><InBankNo></InBankNo><InBankName>平安银行</InBankName><InAcctNo>11002923034501</InAcctNo><InAcctName>平安测试六零零零三三八二八五九八</InAcctName><DcFlag>D</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>132756</TxTime><HostTrace>3240791609148800002810</HostTrace><BussSeqNo>8043431608256101190520</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>4.00</TranAmount><InNode></InNode><InBankNo></InBankNo><InBankName></InBankName><InAcctNo></InAcctNo><InAcctName></InAcctName><DcFlag>D</DcFlag><AbstractStr>FEE</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>FEE</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>145510</TxTime><HostTrace>3240791609143900351361</HostTrace><BussSeqNo>8043431608256101191046</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>1.00</TranAmount><InNode>0821</InNode><InBankNo></InBankNo><InBankName>平安银行</InBankName><InAcctNo>11002923034501</InAcctNo><InAcctName>平安测试六零零零三三八二八五九八</InAcctName><DcFlag>D</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>145510</TxTime><HostTrace>3240791609143900351361</HostTrace><BussSeqNo>8043431608256101191046</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>4.00</TranAmount><InNode></InNode><InBankNo></InBankNo><InBankName></InBankName><InAcctNo></InAcctNo><InAcctName></InAcctName><DcFlag>D</DcFlag><AbstractStr>FEE</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>FEE</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>150158</TxTime><HostTrace>3240791609141800358331</HostTrace><BussSeqNo>8043431608256101191149</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>1.00</TranAmount><InNode>0821</InNode><InBankNo></InBankNo><InBankName>平安银行</InBankName><InAcctNo>11002923034501</InAcctNo><InAcctName>平安测试六零零零三三八二八五九八</InAcctName><DcFlag>D</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>150158</TxTime><HostTrace>3240791609141800358331</HostTrace><BussSeqNo>8043431608256101191149</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>4.00</TranAmount><InNode></InNode><InBankNo></InBankNo><InBankName></InBankName><InAcctNo></InAcctNo><InAcctName></InAcctName><DcFlag>D</DcFlag><AbstractStr>FEE</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>FEE</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>150230</TxTime><HostTrace>3240791609147500357943</HostTrace><BussSeqNo>8043431608256101191153</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>1.00</TranAmount><InNode>0821</InNode><InBankNo></InBankNo><InBankName>平安银行</InBankName><InAcctNo>11002923034501</InAcctNo><InAcctName>平安测试六零零零三三八二八五九八</InAcctName><DcFlag>D</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>150230</TxTime><HostTrace>3240791609147500357943</HostTrace><BussSeqNo>8043431608256101191153</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>4.00</TranAmount><InNode></InNode><InBankNo></InBankNo><InBankName></InBankName><InAcctNo></InAcctNo><InAcctName></InAcctName><DcFlag>D</DcFlag><AbstractStr>FEE</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>FEE</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>150239</TxTime><HostTrace>3240791609144100358910</HostTrace><BussSeqNo>8043431608256101191157</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>1.00</TranAmount><InNode>0821</InNode><InBankNo></InBankNo><InBankName>平安银行</InBankName><InAcctNo>11002923034501</InAcctNo><InAcctName>平安测试六零零零三三八二八五九八</InAcctName><DcFlag>D</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>150239</TxTime><HostTrace>3240791609144100358910</HostTrace><BussSeqNo>8043431608256101191157</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>4.00</TranAmount><InNode></InNode><InBankNo></InBankNo><InBankName></InBankName><InAcctNo></InAcctNo><InAcctName></InAcctName><DcFlag>D</DcFlag><AbstractStr>FEE</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>FEE</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>152702</TxTime><HostTrace>3240791609144500377491</HostTrace><BussSeqNo>8043431608256101191368</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>1.00</TranAmount><InNode>0821</InNode><InBankNo></InBankNo><InBankName>平安银行</InBankName><InAcctNo>11002923034501</InAcctNo><InAcctName>平安测试六零零零三三八二八五九八</InAcctName><DcFlag>D</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>152702</TxTime><HostTrace>3240791609144500377491</HostTrace><BussSeqNo>8043431608256101191368</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>4.00</TranAmount><InNode></InNode><InBankNo></InBankNo><InBankName></InBankName><InAcctNo></InAcctNo><InAcctName></InAcctName><DcFlag>D</DcFlag><AbstractStr>FEE</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>FEE</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>155046</TxTime><HostTrace>3240791609141800402777</HostTrace><BussSeqNo>8043431608256101191576</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>1.00</TranAmount><InNode>0821</InNode><InBankNo></InBankNo><InBankName>平安银行</InBankName><InAcctNo>11002923034501</InAcctNo><InAcctName>平安测试六零零零三三八二八五九八</InAcctName><DcFlag>D</DcFlag><AbstractStr>WEB</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>WEB</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list><list><AcctDate>20160914</AcctDate><TxTime>155046</TxTime><HostTrace>3240791609141800402777</HostTrace><BussSeqNo>8043431608256101191576</BussSeqNo><OutNode>0637</OutNode><OutBankNo></OutBankNo><OutBankName></OutBankName><OutAcctNo>11009692398603</OutAcctNo><OutAcctName>平安测试六零零零三四一三七一零三</OutAcctName><CcyCode>RMB</CcyCode><TranAmount>4.00</TranAmount><InNode></InNode><InBankNo></InBankNo><InBankName></InBankName><InAcctNo></InAcctNo><InAcctName></InAcctName><DcFlag>D</DcFlag><AbstractStr>FEE</AbstractStr><VoucherNo></VoucherNo><TranFee></TranFee><PostFee></PostFee><AcctBalance>0.00</AcctBalance><Purpose></Purpose><AbstractStr_Desc>FEE</AbstractStr_Desc><CVoucherNo></CVoucherNo><ProxyPayAcc></ProxyPayAcc><ProxyPayName></ProxyPayName><ProxyPayBankName></ProxyPayBankName></list></Result>";
            dynamic d = Utils.LoadXML(str);
            //var aa = d["Account"].Value;
            //var bbb = d["@abc"];
            //string ss = d.Account.Value;
            var res_4013 = new Res_4013();
            var t = Utils.ToModelFromXML<Res_4013>(res_4013, d);
        }

        public void Test_Query(string message)//查看解析结果
        {
            var data = new DataResult();
            //解析接收到的银行的数据
            BankInterface bankReq = new BankInterface();
            string TargetSystem = Utils.GetTargetSystem(message);
            if (TargetSystem == "03")
            {
                //老版本 交易资金03
                var retKeyDict = bankReq.ParsingTranMessageString(message);
                data = Utils.ToDataResult(retKeyDict, GlobalData.B2BSpotVersion);
            }
            else if (TargetSystem == "01")
            {
                //新版本 银企直连01
                var retKeyDict = bankReq.ParsingBankEnterpriseMessageString(message);
                data = Utils.ToDataResult(retKeyDict, GlobalData.DirectErpBankVersion);
            }
        }
        #endregion



        /// <summary>
        /// 根据接口交易码测试具体的接口
        /// </summary>
        /// <param name="code">接口交易码</param>
        public static void Invoke(string code, string param)
        {
            var test = Activator.CreateInstance(typeof(PayTest));
            var method = test.GetType().GetMethod("Test_" + code);
            if (method != null)
            {
                var obj = new object[] { };
                if (code == "Recv" || code == "Query")
                    obj = new object[] { param };
                method.Invoke(test, obj);
            }
            else
            {
                Console.WriteLine(code + "接口方法不存在");
            }
        }
    }
}
