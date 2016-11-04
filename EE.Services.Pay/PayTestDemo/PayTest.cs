using EE.Services.Pay.Common;
using EE.Services.Pay.Common.Ext;
using EE.Services.Pay.DataAccess;
using EE.Services.Pay.InertnetVer;
using EE.Services.Pay.Model.DiskFile;
using EE.Services.Pay.Model.Req;
using EE.Services.Pay.Model.Res;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.PayTestDemo11111
{
    public class PayTest
    {

        #region BankEnterpriseDirectInterface

        public void Test_4002()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4002 = new Req_4002();
            req_4002.Account = "11009692398603";// "11011781161701";// "11002873390701";
            var result = be.QueryErpTodayTradeDetailInterface(req_4002);
            var rs = result.ToModel<DynamicXml>();
            var res_4002 = rs.To_4002();
        }
        public void Test_S001()
        {
            // string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var result = be.SystemStatusProbeInterface();
        }
        public void Test_4018()
        {
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var qiyeLargeBatchMoneyTransfer = new Req_4018();
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            qiyeLargeBatchMoneyTransfer.ThirdVoucher = thirdVoucher;//相当于流水号
            qiyeLargeBatchMoneyTransfer.totalCts = 2;
            qiyeLargeBatchMoneyTransfer.totalAmt = 2m;
            //qiyeLargeBatchMoneyTransfer.BatchSummary = "测试批量转账";
            qiyeLargeBatchMoneyTransfer.BSysFlag = "N";
            qiyeLargeBatchMoneyTransfer.OutAcctNo = "11009692398603";
            qiyeLargeBatchMoneyTransfer.OutAcctName = "平安测试六零零零三四一三七一零三";
            //qiyeLargeBatchMoneyTransfer.OutAcctAddr = "";
            qiyeLargeBatchMoneyTransfer.BookingDate = System.DateTime.Now.ToString("yyyyMMdd");
            //qiyeLargeBatchMoneyTransfer.PayType = 1;
            //开头部分
            string tThirdVoucher = AssistantHelper.GetOrderId(3, "yyyyMMddHHmmss", "");

            //for (int i = 1; i < 3; i++)
            //{
            HOResultSet4018R hOResultSet4018R = new HOResultSet4018R();
            qiyeLargeBatchMoneyTransfer.HOResultSet4018R.Add(hOResultSet4018R);
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
            qiyeLargeBatchMoneyTransfer.HOResultSet4018R.Add(hOResultSet4018R);
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
            //}

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
            var result = be.QiyeLargeBatchMoneyTransferInterface(qiyeLargeBatchMoneyTransfer);
            var Rs = result.ToModel<DynamicXml>();
            var res_4018 = Rs.To_4018();
        }

        public void Test_4004()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();

            //跨行转账
            var req_4004 = new Req_4004();
            req_4004.ThirdVoucher = thirdVoucher;
            req_4004.OutAcctNo = "11009692398603";// "11002873403401";//重要 11002873403401
            req_4004.OutAcctName = "平安测试六零零零三四一三七一零三";// "ebt";  //重要   ebt    
            req_4004.InAcctNo = "6214978800000024";// "11002873390701";//这个账号 重要 11002873390701
            req_4004.InAcctName = "何兆启";// "EBANK";//重要 EBANK
            req_4004.InAcctBankName = "313736000019";// "anything";////重要 anything 
            req_4004.TranAmount = 10m;        //重要
            req_4004.UseEx = "是这个";// "testreturn";
            req_4004.UnionFlag = 0;
            req_4004.SysFlag = "2";
            //qiyeSingleMoneyTransfer.RealFlag = "2";
            req_4004.AddrFlag = 1;
            var result = be.QiyeSingleMoneyTransferInterface(req_4004);
            var rs = result.ToModel<DynamicXml>();
            var res_4004 = rs.To_4004();
            /* 行内转账
            var req_4004 = new Req_4004();
            req_4004.ThirdVoucher = thirdVoucher;
            req_4004.OutAcctNo = "11009692398603";// "11002873403401";//重要 11002873403401
            req_4004.OutAcctName = "平安测试六零零零三四一三七一零三";// "ebt";  //重要   ebt    
            req_4004.InAcctNo = "11002923034501";// "11002873390701";//这个账号 重要 11002873390701
            req_4004.InAcctName = "平安测试六零零零三三八二八五九八";// "EBANK";//重要 EBANK
            req_4004.InAcctBankName = "0821";// "anything";////重要 anything 
            req_4004.TranAmount = 12m;        //重要
            req_4004.UseEx = "是这个";// "testreturn";
            req_4004.UnionFlag = 1;
            req_4004.SysFlag = "2";
            //qiyeSingleMoneyTransfer.RealFlag = "2";
            req_4004.AddrFlag = 1;
            var result = be.QiyeSingleMoneyTransferInterface(serialNumber, req_4004);
            var rs = result.ToModel<DynamicXml>();
            */

            /*
            var qiyeSingleMoneyTransfer = new QiyeSingleMoneyTransfer();
            qiyeSingleMoneyTransfer.ThirdVoucher = "20100811153416";
            qiyeSingleMoneyTransfer.OutAcctNo = "11000097408701";
            qiyeSingleMoneyTransfer.OutAcctName = "ebt";
            qiyeSingleMoneyTransfer.OutAcctAddr = "";
            qiyeSingleMoneyTransfer.InAcctBankNode = "";
            qiyeSingleMoneyTransfer.InAcctRecCode = "";
            qiyeSingleMoneyTransfer.InAcctNo = "11000098571501";
            qiyeSingleMoneyTransfer.InAcctName = "EBANK";
            qiyeSingleMoneyTransfer.InAcctBankName = "";
            qiyeSingleMoneyTransfer.TranAmount = "000.01";
            qiyeSingleMoneyTransfer.AmountCode = "";
            qiyeSingleMoneyTransfer.UseEx = "testreturn";
            qiyeSingleMoneyTransfer.UnionFlag = "1";
            qiyeSingleMoneyTransfer.SysFlag = "2";
            qiyeSingleMoneyTransfer.AddrFlag = "1";
            qiyeSingleMoneyTransfer.MainAcctNo = "";
            var attach = new Attachment();
            attach.AttachFileName = "123.txt";
            attach.AttachContent = "ABCD";
            var result = be.QiyeSingleMoneyTransferInterface(serialNumber, qiyeSingleMoneyTransfer);
            */
        }
        public void Test_400401()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
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

            var result = be.SingleSubmitTransferSummaryBatchInterface(req_400401);
            var Rs = result.ToModel<DynamicXml>();
            var res_400401 = Rs.To_400401();
        }
        public void Test_4014()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
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

            var result = be.QiyeBatchNoDelayMoneyTransferInterface(req_4014);
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
            var result = be.SingleTransferCmdQueryInterface(req_4005);
            var Rs = result.ToModel<DynamicXml>();
            var res_4005 = Rs.To_4005();
        }
        public void Test_4006()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4006 = new Req_4006();
            var result = be.ErpTradeDetailInfoQueryInterface(req_4006);
            var Rs = result.ToModel<DynamicXml>();
        }
        public void Test_4008()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4008 = new Req_4008();
            req_4008.AcctNo = "11009692398603";
            var result = be.QueryErpTodayTradeDetailedInterface(req_4008);
            var Rs = result.ToModel<DynamicXml>();
            var res_4008 = Rs.To_4008();
        }
        public void Test_4015()
        {
            //用于查询4014，4018，4034上送的批量转账结果信息

            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
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

            var result = be.LargeBatchTransferCmdQueryInterface(largeBatchTransferCmdQuery);

            var r = result.ToModel<DynamicXml>().To_4015();
        }

        public void Test_4034()
        {
            //用于查询4014，4018，4034上送的批量转账结果信息

            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
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


            var result = be.QiyeSummaryMoneyTransferInterface(req_4034);
            var result1 = be.QiyeSummaryMoneyTransfer_403401Interface(req_4034);

            var Rs = result.ToModel<DynamicXml>();
            var res_4034 = Rs.To_4034();
        }

        public void Test_4012()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4012 = new Req_4012();
            req_4012.Account = "11009692398603";// "11002873390701";
            req_4012.RptDate = "20160514";
            req_4012.Reserve = "";
            var result = be.HistoryBalanceQueryInterface(req_4012);
            var rsXML = result.ToModel<DynamicXml>();
            var res_4012 = rsXML.To_4012();
        }

        public void Test_4013()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var queryTodayHistoryTransactionDetail = new Req_4013();
            queryTodayHistoryTransactionDetail.AcctNo = "11009692398603";// "11002873390701";
            //不输入查询当日 输入查询历史
            //queryTodayHistoryTransactionDetail.BeginDate = "20160613";
            //queryTodayHistoryTransactionDetail.EndDate = "";
            var result = be.QueryTodayHistoryTransactionDetailInterface(queryTodayHistoryTransactionDetail);
            dynamic Rs = result.ToModel<DynamicXml>();
            if (Rs != null)
            {
                //取元素的值 Rs.元素名.Value和属性的值Rs.元素名["属性名称"]
                var AcctNo = Rs.AcctNo.Value;
                var CcyCode = Rs.CcyCode.Value;
                var Reserve = Rs.Reserve.Value;
                var PageRecCount = Rs.PageRecCount.Value;
                var PageNo = Rs.PageNo.Value;
                var PageSize = Rs.PageSize.Value;

                var res_4013 = (Rs as DynamicXml).To_4013();
            }
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
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4011 = new Req_4011();
            req_4011.AcctNo = "11009692398603";// "11002873390701";
            var result = be.ProxyBankPayTodayTradeQueryInterface(req_4011);

            var rs = result.ToModel<DynamicXml>();
        }
        public void Test_4016()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4016 = new Req_4016();
            req_4016.ACNO = "11009692398603";// "11002873390701";
            req_4016.LNNO = "1";
            var result = be.LoanAccountDetailQueryInterface(req_4016);
            var rs = result.ToModel<DynamicXml>();
            var r_4016 = rs.To_4016();
        }
        public void Test_4017()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4017 = new Req_4017();
            req_4017.BankNo = "103";
            req_4017.KeyWord = "1";//相当于开户行
            req_4017.BankName = "";//可选
            var result = be.BankContactNumberQueryInterface(req_4017);

            var rs = result.ToModel<DynamicXml>();
            var r_4017 = rs.To_4017();
        }

        public void Test_4020()
        {
            //3.12 离岸账户转账
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            string thirdVoucher = AssistantHelper.GetOrderId(8, "yyyyMMddHHss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var offshoreAccountTransfer = new Req_4020();
            offshoreAccountTransfer.ThirdVoucher = thirdVoucher;
            offshoreAccountTransfer.TranType = 1;
            offshoreAccountTransfer.PayerAcctNo = "11009692398603";
            offshoreAccountTransfer.AcctCurrencyNo = "USD";//RMB
            offshoreAccountTransfer.PayerName = "";
            offshoreAccountTransfer.RemitterCurrency = "RMB";
            offshoreAccountTransfer.Amount = 1m;
            offshoreAccountTransfer.RemitteeAcctNo = "11002923034501";
            offshoreAccountTransfer.RemitteeName = "平安测试六零零零三三八二八五九八";
            offshoreAccountTransfer.RemitteeBankName = "0821";
            offshoreAccountTransfer.feeType = 1;
            offshoreAccountTransfer.Remark = "1";
            //可选
            offshoreAccountTransfer.RemitteeAddr = "";
            offshoreAccountTransfer.SwiftNo = "";
            offshoreAccountTransfer.BankNo = "";
            offshoreAccountTransfer.RemitteeBankAddr = "";
            offshoreAccountTransfer.RemitteeBankUnitNo = "";
            offshoreAccountTransfer.Intermediary = "";
            offshoreAccountTransfer.ContractNo = "";
            offshoreAccountTransfer.InvoiceNo = "";
            offshoreAccountTransfer.UrgentMark = "";
            offshoreAccountTransfer.Contactman = "";
            offshoreAccountTransfer.phone = "";
            offshoreAccountTransfer.AcctBalance = "";

            var result = be.OffshoreAccountTransferInterface(offshoreAccountTransfer);
        }

        public void Test_4019()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4019 = new Req_4019();
            req_4019.AccNo = "11009692398603";// "11002873390701";
            req_4019.StartDate = "20160501";
            req_4019.EndDate = "20160811";
            req_4019.PageNo = "1";
            req_4019.PageCts = "30";
            var result = be.PayCmdRefundQueryInterface(req_4019);

            var Rs = result.ToModel<DynamicXml>();
            var res_4019 = Rs.To_4019();

        }
        public void Test_4047()
        {
            //入账方式

            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            string thirdVoucher = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var onBehalfOfWithholdApplay = new Req_4047();
            onBehalfOfWithholdApplay.ThirdVoucher = thirdVoucher;
            onBehalfOfWithholdApplay.AGREE_NO = "E000010903";//
            onBehalfOfWithholdApplay.BusiType = "M8SBF";
            onBehalfOfWithholdApplay.PayType = 0;
            //onBehalfOfWithholdApplay.Currency = "RMB";//
            onBehalfOfWithholdApplay.OthBankFlag = "N";//
            onBehalfOfWithholdApplay.SrcAccNo = "11002873390701";
            onBehalfOfWithholdApplay.TotalNum = 2;
            onBehalfOfWithholdApplay.TotalAmount = 0.02m;
            onBehalfOfWithholdApplay.SettleType = 1;


            string tThirdVoucher = AssistantHelper.GetOrderId(3, "yyyyMMddHHmmss", "");
            for (int i = 1; i < 3; i++)
            {
                var hOResultSet4047R = new HOResultSet4047R();
                onBehalfOfWithholdApplay.HOResultSet4047R.Add(hOResultSet4047R);

                hOResultSet4047R.SThirdVoucher = tThirdVoucher + i.ToString().PadLeft(3, '0');
                //hOResultSet4047R.CstInnerFlowNo = "abc123";//
                //hOResultSet4047R.OthAreaFlag = "N";
                //hOResultSet4047R.IdType = "1";//
                //hOResultSet4047R.IdNo = "420821198710072018";//
                //hOResultSet4047R.OppBankName = "1";//
                hOResultSet4047R.OppAccNo = "30100002000002";//
                hOResultSet4047R.OppAccName = "测试六零零零三三七七九五零九";
                //hOResultSet4047R.OppBranchId = "";//
                //hOResultSet4047R.Province = "";//
                //hOResultSet4047R.City = "";//
                hOResultSet4047R.Amount = 0.01m;
                //hOResultSet4047R.PostScript = "";//
                //hOResultSet4047R.RemarkFCR = "";//
            }
            var result = be.OnBehalfOfWithholdApplayInterface(onBehalfOfWithholdApplay);
        }
        public void Test_4048()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4048 = new Req_4048();
            req_4048.ThirdVoucher = "20160808154438857450";// "20160720111112152561";
            var result = be.OnBehalfOfWithholdResultQueryInterface(req_4048);
        }
        public void Test_4009()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
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

            var result = be.SilverCardTransferMoneyInterface(silverCardTransferMoney);

        }
        public void Test_4010()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4010 = new Req_4010();
            req_4010.AcctNo = "1";
            req_4010.StockAccPwd = "";//可选
            var result = be.QueryBrokerCapitalStationBalanceInterface(req_4010);

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
            var result = be.SummaryPatchPaymentReceiptBillInterface(req_401802);

            var Rs = result.ToModel<DynamicXml>();
            var res_401802 = Rs.To_401802();
        }

        public void Test_4027()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
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
            var result = be.BlendPatchTransferMoneyInterface(req_4027);

        }

        public void Test_4021()
        {
            //00901025000000002000
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4021 = new Req_4021();
            // string Account = "11002873390701";
            req_4021.PageNo = "1";
            req_4021.AcctNo = "11006094988901";// "11002873390701";
            var result = be.FixedDepositAccountInfoQueryInterface(req_4021);
            var rs = result.ToModel<DynamicXml>();
            var res_4021 = rs.To_4021();
        }
        public void Test_4025()
        {  //00901025000000002000
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4025 = new Req_4025();
            // string Account = "11002873390701";         
            req_4025.ACNO = "11006094988901";// "11002873390701";
            req_4025.ACSEQ = "1";
            var result = be.QueryLiveComReceiptInfoInterface(req_4025);
            var rs = result.ToModel<DynamicXml>();
            var res_4025 = rs.To_4025();

        }
        public void Test_4054()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4054 = new Req_4054();
            req_4054.AcctNo = "11006094988901";// "11002873390701";
            req_4054.subAccountNo = "11011391189501";
            req_4054.CheckRate = "1";
            var result = be.WithinGroupAccountPreKnotInterface(req_4054);
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
            var rs = result.ToModel<DynamicXml>();

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
            var result = be.WithinGroupVirtualAccountBalanceAdjustInterface(req);
            var rs = result.ToModel<DynamicXml>();
            var res_4057 = rs.To_4057();
        }
        public void Test_4058()
        {
            //00901025000000002000
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
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

            var res = be.MoneyManageVirtualAccountContractAddOrUpdateOrDelInterface(req);
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
            var result = be.WithinGroupHandModeNotionalPoolDownPickInterface(req);
            var rs = result.ToModel<DynamicXml>();
            var res_4052 = rs.To_4052();
        }
        public void Test_4022()
        {
            //00901025000000002000
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4022 = new Req_4022();
            req_4022.AC = "11006094988901";// "11002873390701";
            var result = be.WithinGroupTotalAccountQueryInterface(req_4022);
            var rs = result.ToModel<DynamicXml>();
            var res_4022 = rs.To_4022();
            //  var x = result.ToModel<DynamicXml>();
            string xml = "<?xml version=\"1.0\" encoding=\"GBK\" ?><Result><AC>11002873390701</AC><CCY>RMB</CCY><ACNAME>平安测试六零零零三三七七九五零九</ACNAME><GTYPE></GTYPE><WRDATE>20100828</WRDATE><DUEDATE></DUEDATE><CONCURNO></CONCURNO><UNITNO>0800</UNITNO><OVRT-BAL></OVRT-BAL><CURRBAL></CURRBAL><headAgreementState>3</headAgreementState><headAuthCirculateFlag>A</headAuthCirculateFlag><headAuthinnerCirculateType>2</headAuthinnerCirculateType><headHandCirculateFlag>Y</headHandCirculateFlag></Result>";
        }
        public void Test_4023()
        {
            //00901025000000002000
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4023 = new Req_4023();
            req_4023.AC = "11006094988901";// "11002873390701";
            var result = be.WithinGroupSubAccountListQueryInterface(req_4023);
            var Rs = result.ToModel<DynamicXml>();
            var res_4023 = Rs.To_4023();
            string xml = "<?xml version=\"1.0\" encoding=\"GBK\" ?><Result><PAGE>N</PAGE><ALLCOUNT>1</ALLCOUNT><list><SUBAC>11002873403401</SUBAC><SUBNAME>平安测试六零零零三三八五六七六五</SUBNAME><CORSCONBR>0801</CORSCONBR><UPBALANCE>999999192.53</UPBALANCE><DOWNBALANCE>0.00</DOWNBALANCE><payRateComputeDown>0.00</payRateComputeDown><CURRBAL>1000.00</CURRBAL><dayOverBalance>0.00</dayOverBalance><dayOverLimit>0.00</dayOverLimit><upScore>0.00</upScore><downScore>0.00</downScore><subAccCount>0</subAccCount><accountGroupTypeFlag>1</accountGroupTypeFlag></list></Result>";
        }
        public void Test_4055()
        {  //00901025000000002000
           // string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4055 = new Req_4055();
            req_4055.AC = "11006094988901";// "11002873390701";
            req_4055.SUBAC = "11006094974001";// "11002873390701";
            var result = be.CashMangeContractQueryInterface(req_4055);
            var res_4055 = result.ToModel<DynamicXml>().To_4055();
            //string xml = "<?xml version=\"1.0\" encoding=\"GBK\" ?><Result><headAccountNo>11002873390701</headAccountNo><headAccountName>平安测试六零零零三三七七九五零九</headAccountName><headOpenBranch>0800</headOpenBranch><headCurCode>RMB</headCurCode><supAccountNo></supAccountNo><supAccountName>平安测试六零零零三三七七九五零九</supAccountName><supOpenBranch>0800</supOpenBranch><supCurCode>RMB</supCurCode><subAccountNo>11002873390701</subAccountNo><subAccountName>平安测试六零零零三三七七九五零九</subAccountName><BranchNo>0800</BranchNo><currency>RMB</currency><accountGroupTypeFlag>1</accountGroupTypeFlag><subAccountLeve>1</subAccountLeve><agreementType>0</agreementType><authCirculateFlag>A</authCirculateFlag><handGuijiFlag>Y</handGuijiFlag><handXiaboFlag></handXiaboFlag><guiJiType>2</guiJiType><xiaboType></xiaboType><guiJiCycle></guiJiCycle><guiJiDate></guiJiDate><guiJiTime></guiJiTime><guiJiMode></guiJiMode><guiJiIntegerUnity></guiJiIntegerUnity><guiJiBalance>0.00</guiJiBalance><controlMode></controlMode><bigLimit>0.00</bigLimit><bookLimit>0.00</bookLimit><dayOverdraftFlag></dayOverdraftFlag><dayOverLimit>0.00</dayOverLimit><xiaboCycle></xiaboCycle><xiaboDate></xiaboDate><xiaboTime></xiaboTime><xiaboMode></xiaboMode><xiaboKeepAmt>0.00</xiaboKeepAmt><xiaboBalance>0.00</xiaboBalance><entrustLoanFlag></entrustLoanFlag><RateFlag></RateFlag><rateRemitInFlag></rateRemitInFlag><upRate>0.000000</upRate><downRate>0.000000</downRate><agreementState></agreementState><effectDate></effectDate><settleInterestsCycle></settleInterestsCycle><virAccBalance>1000013174.31</virAccBalance></Result>";
        }
        public void Test_4024()
        {  //00901025000000002000
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var ledgerRecordQuery = new Req_4024();
            ledgerRecordQuery.AcctNo = "11006094988901";// "11002873390701";
            ledgerRecordQuery.subAccountNo = "11011391189501";// "11002873390701";
            var result = be.LedgerRecordQueryInterface(ledgerRecordQuery);
            var Rs = result.ToModel<DynamicXml>();
            var res_4024 = Rs.To_4024();
        }
        public void Test_4056()
        {
            //00901025000000002000
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var jieXiParam = new Req_4056();
            jieXiParam.accountNo = "11011391189501";// "11002873390701";//"30200002000001";
            //可选    
            jieXiParam.AcctNo = "11006094988901";//11002873390701
            jieXiParam.TxDate = "";
            jieXiParam.EndDate = "";
            jieXiParam.HostSeqNo = "";
            var result = be.JieXiQueryInterface(jieXiParam);

            var Rs = result.ToModel<DynamicXml>();
            var res_4056 = Rs.To_4056();
        }
        public void Test_4059()
        {
            //00901025000000002000
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4059 = new Req_4059();
            req_4059.Account = "11011391189501"; // "11002873390701";
            var result = be.CashMangeSubAccountBalanceQueryInterface(req_4059);
            var Rs = result.ToModel<DynamicXml>();
            var res_4059 = Rs.To_4059();
        }
        public void Test_4001()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_4001 = new Req_4001();
            req_4001.Account = "11009692398603";// "11011781161701";// "11002873390701";
            var result = be.QueryQiyeAccountBalanceInterface(req_4001);
            //直接取值
            dynamic r = result.ToModel<DynamicXml>();
            var Rs = result.ToModel<DynamicXml>();
            var res_4001 = Rs.To_4001();
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
            var debitCardCustomerInfoVerification = new Req_400101();
            debitCardCustomerInfoVerification.AccountNo = "6226090000000048";// "11002873390701";
            debitCardCustomerInfoVerification.AccountName = "张三";// "11002873390701";
            debitCardCustomerInfoVerification.CertType = "1";
            debitCardCustomerInfoVerification.CertNo = "510265790128303";
            debitCardCustomerInfoVerification.Mobile = "18100000000";
            var result = be.DebitCardCustomerInfoVerificationInterface(debitCardCustomerInfoVerification);

            var Rs = result.ToModel<DynamicXml>();
            var res_400101 = Rs.To_400101();
        }





        public void Test_F001()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_F001 = new Req_F001();
            req_F001.QueryDate = "20160620";
            req_F001.Account = "11002873390701";
            req_F001.BsnCode = "4004";
            var result = be.DetailReportQueryInterface(req_F001);
            var Rs = result.ToModel<DynamicXml>();
            var res_F001 = Rs.To_F001();

        }
        public void Test_F002()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var detailReportCreateNotify = new Req_F002();
            detailReportCreateNotify.FileName = "";
            detailReportCreateNotify.FilePath = "";
            detailReportCreateNotify.RandomPwd = "";
            detailReportCreateNotify.SignData = "";
            detailReportCreateNotify.HashData = "";
            var result = be.DetailReportCreateNotifyInterface(detailReportCreateNotify);
            var Rs = result.ToModel<DynamicXml>();

        }
        public void Test_FILE01()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_FILE01 = new Req_FILE01();
            req_FILE01.FileName = "text.txt";
            // req_FILE01.FilePath = "/afe_ftp/00101079900009999000/";// System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase+ "text.txt";
            req_FILE01.TradeSn = serialNumber;
            var result = be.FILE01_Interface(req_FILE01);
        }
        public void Test_FILE02()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var result = be.FILE02_Interface();
        }
        public void Test_FILE03()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_FILE03 = new Req_FILE03();
            req_FILE03.TradeSn = serialNumber;
            var result = be.FILE03_Interface(req_FILE03);
        }
        public void Test_FILE04()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            BankEnterpriseDirectInterface be = new BankEnterpriseDirectInterface();
            var req_FILE04 = new Req_FILE04();
            req_FILE04.TradeSn = "";

            var result = be.FILE04_Interface(req_FILE04);
        }


        #endregion

        #region CrossLineFastPaymentInterface
        public void Test_KHKF01()
        {
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface clfp = new CrossLineFastPaymentInterface();
            var req_KHKF01 = new Req_KHKF01();
            req_KHKF01.BatchNo = serialNumber; //"201603260001";
            req_KHKF01.AcctNo = "11014982632003";//"11014891204004";
            req_KHKF01.BusiType = "00000";
            req_KHKF01.TotalNum = 1;
            req_KHKF01.TotalAmount = 1m;
            req_KHKF01.FileName = "a.txt";
            req_KHKF01.RandomPwd = "dbdbdbdb";
            //可选           
            req_KHKF01.CorpId = "E000087685";//"E000070730";
            req_KHKF01.Remark = "";
            req_KHKF01.HashData = "";
            req_KHKF01.SignData = "";
            var result = clfp.PatchPaymentFileCommitInterface(req_KHKF01);
            var Rs = result.ToModel<DynamicXml>();
            Res_KHKF01 res_KHKF01 = Rs.To_KHKF01();
        }
        public void Test_KHKF02()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface clfp = new CrossLineFastPaymentInterface();
            var req_KHKF02 = new Req_KHKF02();
            req_KHKF02.AcctNo = "";
            req_KHKF02.BatchNo = "";

            var result = clfp.PatchPaymentResultQueryInterface(req_KHKF02);
        }
        public void Test_KHKF03()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface clfp = new CrossLineFastPaymentInterface();
            var req_KHKF03 = new Req_KHKF03();
            req_KHKF03.OrderNumber = "";
            req_KHKF03.AcctNo = "";
            req_KHKF03.BusiType = "";
            req_KHKF03.TranAmount = "";
            req_KHKF03.InAcctNo = "";
            req_KHKF03.InAcctName = "";
            //--可选
            req_KHKF03.CorpId = "";
            req_KHKF03.CcyCode = "";
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
            req_KHKF04.AcctNo = "";
            //可选
            req_KHKF04.OrderNumber = "";
            req_KHKF04.BussFlowNo = "";

            var result = clfp.SinglePaymentResultQueryInterface(req_KHKF04);

        }
        public void Test_KHKF05()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            CrossLineFastPaymentInterface clfp = new CrossLineFastPaymentInterface();
            var req_KHKF05 = new Req_KHKF05();
            req_KHKF05.QueryDate = "";
            //可选
            req_KHKF05.AcctNo = "";
            req_KHKF05.FileType = "";
            req_KHKF05.BatchNo = "";
            var result = clfp.ReconciliationOrErrorFileQueryInterface(req_KHKF05);
        }
        public void Test_GN()
        {
            //4个文件
            SendDiskFile send = new SendDiskFile();
            OfferDiskFile offer = new OfferDiskFile();
            CheckBillDiskFile check = new CheckBillDiskFile();
            MistakeDiskFile miserror = new MistakeDiskFile();

            FileHelper.SaveFile("send.txt", send.ToString(), true, Encoding.GetEncoding("GBK"));
            FileHelper.SaveFile("offer.txt", offer.ToString(), true, Encoding.GetEncoding("GBK"));
            FileHelper.SaveFile("check.txt", check.ToString(), true, Encoding.GetEncoding("GBK"));
            FileHelper.SaveFile("miserror.txt", miserror.ToString(), true, Encoding.GetEncoding("GBK"));
        }

        #endregion


        #region ClientToBankInterface
        public void Test_1330()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1330 = new Req_1330();
            req_1330.FuncFlag = 1;
            req_1330.Reserve = "签到";
            var result = client.SignInOrOutInterface(req_1330);
            var r = result.ToModel<Res_1330>();
        }
        public void Test_1316()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1316 = new Req_1316();
            req_1316.SupAcctId = "11014971070008";// "11014528489007";// "11014165191000";
            req_1316.CustAcctId = "888800000174433";// "888800000016258";
            req_1316.ThirdCustId = "02142081007";// "8545";//"V00000027";
            req_1316.IdType = "52";// "1";// "52";
            req_1316.IdCode = "67485615-5";// "420821198710072018";// "20130802-7";
            req_1316.TranAmount = 1m;// 0.01m;
            //易宝账户
            req_1316.InAcctId = "11014890513006";// "11014748658003";// "11002873403401";
            req_1316.InAcctIdName = "测试一";// "平安测试限公司客户备付金";// "ebt";

            req_1316.InAcctId = "11014890513006";// "11014748658003";// "11002873403401";
            req_1316.InAcctIdName = "测试一";// "平安测试限公司客户备付金";// "ebt";

            //inMoneyFromTradeNetwork.CcyCode = "RMB";
            req_1316.Reserve = "";


            var result = client.InMoneyFromTradeNetworkInterface(req_1316);
        }

        public void Test_1318()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1318 = new Req_1318();
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
            var result = client.OutMoneyFromTradeNetworkInterface(req_1318);
        }
        public void Test_1010()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1010 = new Req_1010();
            req_1010.SupAcctId = "11014971070008";
            //bankMemberCapitalStationBalance.ThirdCustId = "02142081007";
            //bankMemberCapitalStationBalance.CustAcctId = "888800000174433";
            req_1010.SelectFlag = 1;
            req_1010.PageNum = 1;
            req_1010.Reserve = "";
            var result = client.QueryBankMemberCapitalStationBalanceInterface(req_1010);
            var r = result.ToModel<Res_1010>();
        }
        public void Test_1021()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var bankMemberCapitalStationBalance = new Req_1010();
            var req_1021 = new Req_1021();
            //资金汇总账号
            req_1021.AcctId = "11014971070008";
            //交易网代码
            req_1021.TranWebCode = "02142081007";
            req_1021.Reserve = "";
            var result = client.QuerySuperviseAccountInfoInterface(req_1021);
            var res_1021 = result.ToModel<Res_1021>();
        }
        public void Test_1016()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1016 = new Req_1016();
            req_1016.SupAcctId = "11014971070008";
            req_1016.BeginDate = "20160804";
            req_1016.EndDate = "20160804";
            //queryTimeSlotMemberOpenOrCencelAccountInfo.PageNum = "";


            var result = client.QueryTimeSlotMemberOpenOrCencelAccountInfoInterface(req_1016);
        }

        public void Test_1020()//查询银行卡账号的余额
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1020 = new Req_1020();
            req_1020.SupAcctId = "11014971070008";
            req_1020.CustAcctId = "02142081007";
            req_1020.ThirdCustId = "888800000174433";//可选  
            req_1020.CustName = "测试一";
            req_1020.AcctNo = "11014890513006";
            req_1020.Reserve = "1020";
            var result = client.QueryMemberInOutMoneyAccountBankBalanceInterface(req_1020);
            var r = result.ToModel<Res_1020>();
        }
        public void Test_1324()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1324 = new Req_1324();
            req_1324.SupAcctId = "11014971070008";
            req_1324.OrigThirdLogNo = "";//可选
            req_1324.BeginDate = "20160810";
            req_1324.EndDate = "20160810";
            req_1324.PageNum = 1;
            req_1324.Reserve = "1324";
            var result = client.QueryMemberTradeFlowInfoInterface(req_1324);
            var r = result.ToModel<Res_1324>();
        }
        public void Test_1325()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1324 = new Req_1324();
            req_1324.SupAcctId = "11014971070008";
            req_1324.OrigThirdLogNo = "";//可选
            req_1324.BeginDate = "20160804";
            req_1324.EndDate = "20160804";
            req_1324.PageNum = 1;
            req_1324.Reserve = "1325";
            var result = client.QueryMemberInOutMoneyFlowInfoInterface(req_1324);
            var r = result.ToModel<Res_1325>();
        }
        public void Test_1327()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1327 = new Req_1327();
            //资金汇总账号
            req_1327.SupAcctId = "11014971070008";
            //支付指令号
            req_1327.PaySerialNo = "201608040708_1";// "10160804237010";
            req_1327.Reserve = "1327";
            var result = client.QueryPaySerialStatusInterface(req_1327);
            var r = result.ToModel<Res_1327>();
        }
        public void Test_1328()//可冻结金额可解冻
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1328 = new Req_1328();
            req_1328.SupAcctId = "11014971070008";
            req_1328.FuncFlag = 1;
            req_1328.OutCustAcctId = "888800000174433";
            req_1328.OutThirdCustId = "02142081007";
            req_1328.InCustAcctId = "888800000174532";
            req_1328.InThirdCustId = "02142081009";
            req_1328.TranAmount = 100m;
            req_1328.HandFee = 0.00m;
            req_1328.PaySerialNo = "201608040708_1";//避免支付支付
            req_1328.ThirdHtId = "order_2016080407089";
            //---可选
            req_1328.ThirdHtCont = "第一次支付";
            req_1328.Note = "";
            req_1328.Reserve = "1328";
            var result = client.ChildAccountReviewPayInterface(req_1328);
        }

        public void Test_1331()//对冻结的资金进行支付 未过客户待确认期
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1331 = new Req_1331();
            req_1331.SupAcctId = "11014971070008";
            //会出现"未过客户待确认期"有时间限制
            req_1331.FuncFlag = 2;
            req_1331.PaySerialNo = "201608040708_1";
            req_1331.ThirdHtId = "order_2016080407089";
            req_1331.PayAmount = 10m;
            req_1331.PayFee = 0m;
            //---可选
            req_1331.Note = "";
            req_1331.Reserve = "对1328代理复合";
            var result = client.PlatformOperationPayInterface(req_1331);
        }
        public void Test_1329()//子账户和银行卡
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1329 = new Req_1329();
            req_1329.SupAcctId = "11014971070008";
            req_1329.FuncFlag = 2;
            req_1329.OutCustAcctId = "888800000174433";
            req_1329.OutThirdCustId = "02142081007";
            req_1329.InCustAcctId = "888800000174532";
            req_1329.InThirdCustId = "02142081009";
            req_1329.TranAmount = 10m;
            req_1329.HandFee = 0m;
            req_1329.PaySerialNo = "201608040708_3";// "201608040708_2";
            req_1329.ThirdHtId = "order_2016080407091";// "order_2016080407090";
            //--可选
            req_1329.ThirdHtCont = "";
            req_1329.Note = "";
            req_1329.Reserve = "1329";
            var result = client.ChildAccountDirectPayInterface(req_1329);
        }
        public void Test_1332()//子账户和子账户
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1332 = new Req_1332();
            req_1332.SupAcctId = "11014971070008";
            req_1332.FuncFlag = 2;//直接将原来有的冻结金额改为现有的冻结金额
            req_1332.OutCustAcctId = "888800000174433";
            req_1332.OutThirdCustId = "02142081007";
            req_1332.InCustAcctId = "888800000174532";
            req_1332.InThirdCustId = "02142081009";
            req_1332.TranAmount = 50m;
            req_1332.HandFee = 0m;
            req_1332.PaySerialNo = "201608040708_7";// "201608040708_4";
            req_1332.ThirdHtId = "order_201608040709_7";// "order_2016080407092";
            //--可选
            req_1332.ThirdHtCont = "";
            req_1332.Note = "";
            req_1332.Reserve = "1332";
            var result = client.ChildAccountInDirectPayInterface(req_1332);
        }
        public void Test_1029()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1029 = new Req_1029();
            req_1029.SupAcctId = "11014971070008";
            req_1029.FuncFlag = 2;//冻结/解冻是在原有基础上添加冻结/解冻金额
            req_1029.CustAcctId = "888800000174433";
            req_1029.ThirdCustId = "02142081007";
            req_1029.TranAmount = 60m;
            req_1029.ThirdHtId = "order_201608040709_8";
            //--可选         
            req_1029.Note = "冻结/解冻60元";
            req_1029.Reserve = "1029";
            var result = client.ChildAccountFrozenOrThawInterface(req_1029);
        }
        public void Test_1030()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1030 = new Req_1030();
            req_1030.SupAcctId = "11014971070008";
            req_1030.FuncFlag = 2;
            req_1030.CustAcctId = "888800000174433";
            req_1030.ThirdCustId = "02142081007";
            req_1030.TranAmount = 6m;//收费金额
            req_1030.ThirdHtId = "order_201608040709_9";
            //--可选         
            req_1030.Note = "平台收费6元";
            req_1030.Reserve = "1030";
            var result = client.PlatformChargeOrRefundInterface(req_1030);
        }
        string mobile = "13552535506";
        public void Test_1343()
        {
            // string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1343 = new Req_1343();
            req_1343.SupAcctId = "11014971070008";
            req_1343.ThirdCustId = "02142081007";
            req_1343.AcctId = "5200831111111113";
            req_1343.CustName = "全渠道";
            req_1343.IdType = "1";
            req_1343.IdCode = "341126197709218366";
            req_1343.CpFlag = 1;
            req_1343.MobilePhone = mobile;
            req_1343.BankType = 2;
            req_1343.BankName = "农业银行";
            req_1343.BankCode = "203";
            //企业必输
            if (req_1343.CpFlag == 1)
            {
                req_1343.SBankCode = "00111";
                req_1343.RegAddress = "上海松江";
                req_1343.Zip = "11111111";
                req_1343.Address = "上海松江";
                req_1343.ContactUser = "邓积远";
            }
            //可选
            req_1343.EmailAddr = "dengpplive@163.com";
            req_1343.Reserve = "1343";

            var result = client.CustRegisterSignYeePayInterface(req_1343);
            var res_1343 = result.ToModel<Res_1343>();

            //MemberInfoDataAccess.AddOrUpdateMemberInfo(req_1343, res_1343.SerialNo);
        }
        public void Test_1344()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1344 = new Req_1344();
            req_1344.FuncFlag = 1;
            req_1344.SerialNo = "";
            if (req_1344.FuncFlag == 1)
            {
                req_1344.MessageCode = "";
            }
            else if (req_1344.FuncFlag == 2)
            {
                req_1344.CheckAmount = 20m; ;
            }
            var result = client.CustRegisterSignYeePayValidateInterface(req_1344);
            var res_1344 = result.ToModel<Res_1344>();

            var ex = new ExHashTable();
            Utils.ModelToHashTable<Res_1344>(new Res_1344(), ex);

            //更新数据库
            // MemberInfoDataAccess.AddOrUpdateMemberInfo(res_1344);

            //查询
            //var memberInfo = MemberInfoDataAccess.GetMemberInfo(mobile);

        }
        public void Test_1313()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1313 = new Req_1313();
            req_1313.TranOutType = 1;
            req_1313.TranType = 3;
            req_1313.CcyCode = "RMB";
            req_1313.TranWebName = "小象快运";
            req_1313.ThirdCustId = "02142081007";
            req_1313.CustAcctId = "888800000174433";
            req_1313.CustName = "测试一";
            req_1313.SupAcctId = "11014971070008";
            //换成他行银行卡
            req_1313.OutAcctId = "6226090000000048";// "11014890513006";//易宝账户
            req_1313.OutAcctIdName = "张三";// "测试一";//易宝账户
            req_1313.OutAcctIdBankName = "招商银行";// "平安银行";

            req_1313.TranAmount = 10m;
            //可选
            //req_1313.OutAcctIdBankCode = "";
            //req_1313.Address = "";
            //req_1313.FeeOutCustId = "";
            //req_1313.Reserve = "";

            var result = client.CrossBankOutMoneyFromTradeNetworkInterface(req_1313);
            var res_1313 = result.ToModel<Res_1313>();
        }

        public void Test_1031()
        {
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            SpotTranInterface client = new SpotTranInterface();
            var req_1031 = new Req_1031();
            req_1031.SupAcctId = "11014971070008";
            req_1031.FuncFlag = 1;
            req_1031.CustAcctId = "888800000174433";
            req_1031.ThirdCustId = "02142081007";
            req_1031.TranAmount = 90m;
            req_1031.ThirdHtId = "order_201608040709_10";
            //--可选         
            req_1031.Note = "";
            req_1031.Reserve = "1031";
            var result = client.PlatformPayOrChargeInterface(req_1031);
        }
        #endregion




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



        #region 测试webServices



        #endregion
        /// <summary>
        /// 根据接口交易码测试具体的接口
        /// </summary>
        /// <param name="code">接口交易码</param>
        public static void Invoke(string code, string param)
        {
            string result = string.Empty;
            var asm = Assembly.Load(GalobalData.assemblyName);
            //默认请求的
            string strType = "EE.Services.Pay.PayTestDemo.PayTest";
            var type = asm.GetType(strType);
            var instance = asm.CreateInstance(strType);
            var method = type.GetMethod("Test_" + code);
            if (method != null)
            {
                var obj = new object[] { };
                if (code == "Recv")
                    obj = new object[] { param };
                method.Invoke(instance, obj);
            }
            else
            {
                Console.WriteLine(code + "接口方法不存在");
            }
        }
    }
}
