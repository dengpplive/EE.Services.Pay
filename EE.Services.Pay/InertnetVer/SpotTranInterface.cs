using EE.Services.Pay.Common;
using EE.Services.Pay.Model;
using EE.Services.Pay.Model.Req;
using EE.Services.Pay.Model.Res;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EE.Services.Pay.InertnetVer
{
    /// <summary>
    /// [平安银行B2B现货接口文档V1.4]
    /// 上行接口 包括互联网和专线两种接入方式  企业客户端请求银行的接口 
    /// </summary>
    public class SpotTranInterface
    {
        #region 会员开销户接口
        /// <summary>
        /// 会员注册签约易宝【1343】
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1343">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult CustRegisterSignYeePayInterface(string serialNumber, Req_1343 req_1343, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1343");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1343);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1343>();
            return retKeyDict;
        }
        /// <summary>
        /// 会员注册签约易宝-回填验证【1344】
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1344">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult CustRegisterSignYeePayValidateInterface(string serialNumber, Req_1344 req_1344, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1344");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1344);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1344>();
            return retKeyDict;
        }
        #endregion

        #region 签到/签退交易接口
        /// <summary>
        /// 签到/签退交易
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1330">请求参数</param>      
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult SignInOrOutInterface(string serialNumber, Req_1330 req_1330, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码     
            parmaKeyDict.Add("TranFunc", "1330");
            //请求流水号           
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1330);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1330>();
            return retKeyDict;
        }
        #endregion

        #region 出入金模块

        /// <summary>
        /// 入金（交易网发起）[1316]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1316">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult InMoneyFromTradeNetworkInterface(string serialNumber, Req_1316 req_1316, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1316");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1316);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1316>();
            return retKeyDict;
        }

        /// <summary>
        /// 出金（交易网发起) [1318]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1318">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult OutMoneyFromTradeNetworkInterface(string serialNumber, Req_1318 req_1318, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //报文参数赋值
            parmaKeyDict.Add("TranFunc", "1318");//交易码
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1318);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1318>();
            return retKeyDict;
        }
        /// <summary>
        /// 跨行出金（交易网发起）【1313】
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1313">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult CrossBankPutAmountInterface(string serialNumber, Req_1313 req_1313, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //报文参数赋值
            parmaKeyDict.Add("TranFunc", "1313");//交易码
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1313);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1313>();
            return retKeyDict;
        }
        #endregion

        #region 查询类接口
        /// <summary>
        /// 查银行端会员资金台帐余额 [1010]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1010">请求信息</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult QueryBankMemberCapitalStationBalanceInterface(string serialNumber, Req_1010 req_1010, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //报文参数赋值
            parmaKeyDict.Add("TranFunc", "1010");//交易码
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1010);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<Res_1010>();
                var list = new List<AccountItem>();
                list.AddRange(model.AccountList);
                #region 处理查询所有
                if (isAll)
                {
                    var payPinganConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; i < maxCount && model != null && model.LastPage == "0"; i++)
                    {
                        req_1010.PageNum++;
                        //延时
                        Thread.Sleep(payPinganConfig.SleepTime);
                        var rs = QueryBankMemberCapitalStationBalanceInterface(serialNumber, req_1010, false, counterId);
                        if ((model = rs.Model) != null)
                        {
                            retKeyDict.RspContent += rs.RspContent;
                            model.RecordNum += rs.Model.AccountList.Count();
                            list.AddRange(rs.Model.AccountList);
                        }
                    }
                }
                #endregion
                model.AccountList = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }

        /// <summary>
        /// 监管账户信息查询 [1021]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1021">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult QuerySuperviseAccountInfoInterface(string serialNumber, Req_1021 req_1021, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //报文参数赋值
            parmaKeyDict.Add("TranFunc", "1021");//交易码
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1021);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1021>();
            return retKeyDict;
        }
        /// <summary>
        ///  查时间段会员开销户信息 [1016]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1016">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult QueryTimeSlotMemberOpenOrCencelAccountInfoInterface(string serialNumber, Req_1016 req_1016, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //报文参数赋值
            parmaKeyDict.Add("TranFunc", "1016");//交易码
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1016);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<Res_1016>();
                var list = new List<OpenAccountInfo>();
                list.AddRange(model.OpenAccountInfoList);
                #region 处理查询所有
                if (isAll)
                {
                    var payPinganConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; i < maxCount && model != null && model.LastPage == "0"; i++)
                    {
                        req_1016.PageNum++;
                        //延时
                        Thread.Sleep(payPinganConfig.SleepTime);
                        var rs = QueryTimeSlotMemberOpenOrCencelAccountInfoInterface(serialNumber, req_1016, false, counterId);
                        if ((model = rs.Model) != null)
                        {
                            retKeyDict.RspContent += rs.RspContent;
                            model.RecordNum += rs.Model.OpenAccountInfoList.Count();
                            list.AddRange(rs.Model.OpenAccountInfoList);
                        }
                    }
                }
                #endregion
                model.OpenAccountInfoList = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }

        /// <param name="serialNumber">请求流水号</param>
        /// <summary>
        /// 查会员出入金账号的银行余额 [1020]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1020">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult QueryMemberInOutMoneyAccountBankBalanceInterface(string serialNumber, Req_1020 req_1020, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //报文参数赋值
            parmaKeyDict.Add("TranFunc", "1020");//交易码
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1020);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1020>();
            return retKeyDict;
        }
        /// <summary>
        /// 查询时间段会员交易流水信息 [1324]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1324">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult QueryMemberTradeFlowInfoInterface(string serialNumber, Req_1324 req_1324, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //报文参数赋值
            parmaKeyDict.Add("TranFunc", "1324");//交易码
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1324);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<Res_1324>();
                var list = new List<TradeFlowiInfo>();
                list.AddRange(model.TradeFlowiInfoList);
                #region 处理查询所有
                if (isAll)
                {
                    var payPinganConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; i < maxCount && model != null && model.LastPage == "0"; i++)
                    {
                        req_1324.PageNum++;
                        //延时
                        Thread.Sleep(payPinganConfig.SleepTime);
                        var rs = QueryMemberTradeFlowInfoInterface(serialNumber, req_1324, false, counterId);
                        if ((model = rs.Model) != null)
                        {
                            retKeyDict.RspContent += rs.RspContent;
                            model.RecordNum += rs.Model.TradeFlowiInfoList.Count();
                            list.AddRange(rs.Model.TradeFlowiInfoList);
                        }
                    }
                }
                #endregion
                model.TradeFlowiInfoList = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 查询时间段会员出入金流水信息 [1325]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1324">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult QueryMemberInOutMoneyFlowInfoInterface(string serialNumber, Req_1324 req_1324, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1325");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1324);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<Res_1325>();
                var list = new List<AccessToGoldTradeInfo>();
                list.AddRange(model.AccessToGoldTradeInfoList);
                #region 处理查询所有
                if (isAll)
                {
                    var payPinganConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; i < maxCount && model != null && model.LastPage == "0"; i++)
                    {
                        req_1324.PageNum++;
                        //延时
                        Thread.Sleep(payPinganConfig.SleepTime);
                        var rs = QueryMemberInOutMoneyFlowInfoInterface(serialNumber, req_1324, false, counterId);
                        if ((model = rs.Model) != null)
                        {
                            retKeyDict.RspContent += rs.RspContent;
                            model.RecordNum += rs.Model.AccessToGoldTradeInfoList.Count();
                            list.AddRange(rs.Model.AccessToGoldTradeInfoList);
                        }
                    }
                }
                #endregion
                model.AccessToGoldTradeInfoList = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 查询支付指令状态[1327]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1327">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult QueryPaySerialStatusInterface(string serialNumber, Req_1327 req_1327, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1327");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1327);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1327>();
            return retKeyDict;
        }

        /// <summary>
        /// 查询子账户间支付的指令结果[1333] 用于查询【1332】接口提交的子账户间支付的指令处理结果
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1333">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult QuerySubAccountPayResultInterface(string serialNumber, Req_1333 req_1333, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1333");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1333);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1333>();
            return retKeyDict;
        }
        /// <summary>
        /// 根据订单号查询会员交易流水结果【1342】（郑大专用）
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1342">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>

        public DataResult QueryTradeResultByOrderIdInterface(string serialNumber, Req_1342 req_1342, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1342");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1342);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1342>();
            return retKeyDict;
        }

        /// <summary>
        /// 查询银行小额鉴权转账结果[1348] 用于查询1343接口发起的小额鉴权的转账结果。鉴权指令号是1343接口同步返回的
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1348">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult QueryBankAuthenticationInterface(string serialNumber, Req_1348 req_1348, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1348");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1348);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1348>();
            return retKeyDict;
        }

        /// <summary>
        /// 查询对账文件密码【1349】
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1349">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult QueryReconciliationFilePwdInterface(string serialNumber, Req_1349 req_1349, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1349");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1349);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1349>();
            return retKeyDict;
        }

        #endregion



        #region 会员交易接口
        /// <summary>
        /// 会员在途充值[1350]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1350">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult MemberRechargeInterface(string serialNumber, Req_1350 req_1350, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1350");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1350);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1350>();
            return retKeyDict;
        }
        /// <summary>
        /// 子账户间划转[1028]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1028">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult SubAccountPayInterface(string serialNumber, Req_1028 req_1028, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1028");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1028);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1028>();
            return retKeyDict;
        }
        /// <summary>
        /// 子账户复核支付 [1328]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1328">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult ChildAccountReviewPayInterface(string serialNumber, Req_1328 req_1328, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1328");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1328);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1328>();
            return retKeyDict;
        }


        /// <summary>
        /// 平台操作支付 [1331]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1331">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult PlatformOperationPayInterface(string serialNumber, Req_1331 req_1331, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1331");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1331);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1331>();
            return retKeyDict;
        }
        /// <summary>
        /// 子账户直接支付 [1329]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1329">请求信息</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult ChildAccountDirectPayInterface(string serialNumber, Req_1329 req_1329, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1329");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1329);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1329>();
            return retKeyDict;
        }
        /// <summary>
        /// 子账户间支付 [1332]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1332">请求信息</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult ChildAccountInDirectPayInterface(string serialNumber, Req_1332 req_1332, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1332");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1332);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1332>();
            return retKeyDict;
        }
        /// <summary>
        /// 子账户冻结解冻 [1029]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1029">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult ChildAccountFrozenOrThawInterface(string serialNumber, Req_1029 req_1029, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1029");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1029);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1029>();
            return retKeyDict;
        }
        /// <summary>
        /// 平台收费与退费 [1030]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1030">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult PlatformChargeOrRefundInterface(string serialNumber, Req_1030 req_1030, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1030");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1030);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1030>();
            return retKeyDict;
        }
        /// <summary>
        /// 平台支付与收取 [1031]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1031">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult PlatformPayOrChargeInterface(string serialNumber, Req_1031 req_1031, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "1031");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_1031);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<Res_1031>();
            return retKeyDict;
        }
        #endregion

        #region 系统
        /// <summary>
        /// 重新加载配置
        /// </summary>
        public PinganPayConfig ReLoadConfig()
        {
            return GlobalData.LoadPinganConfig(true);
        }
        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="pinganPayConfig"></param>
        public void SaveConfig(PinganPayConfig pinganPayConfig)
        {
            GlobalData.SavePinganConfig(pinganPayConfig);
        }
        #endregion



        #region 私有方法        
        /// <summary>
        /// 根据请求参数 返回结果
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        private DataResult GetResult(ExHashTable parmaKeyDict)
        {
            //记录日志
            StringBuilder sbLog = new StringBuilder();
            ExHashTable retKeyDict = new ExHashTable();
            try
            {
                //检测
                Utils.PayCheckData((string)parmaKeyDict.Get("ThirdLogNo"), (string)parmaKeyDict.Get("CounterId"));
                //获取请求报文
                BankInterface msg = new BankInterface();
                //调用函数生成请求的而完整报文
                string reqMessage = msg.GetTranMessageReq(parmaKeyDict, this.IsSpecialLine);
                sbLog.AppendFormat("时间:{0}\r\n", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sbLog.AppendFormat("请求:{0}\r\n", reqMessage);
                //发送请求报文  //获取银行返回报文
                string recvMessage = msg.SendMessage(reqMessage);
                sbLog.AppendFormat("响应:{0}\r\n", recvMessage);
                //解析返回结果
                retKeyDict = msg.ParsingTranMessageString(recvMessage);
                sbLog.AppendFormat("解析结果:\r\n{0}\r\n", retKeyDict.ToString());
            }
            catch (Exception ex)
            {
                sbLog.AppendFormat("异常信息:{0}\r\n", ex.Message);
                throw ex;
            }
            finally
            {
                //写入日志
                if (GlobalData.LoadPinganConfig().OpenLog)
                    FileHelper.SaveFile(string.Format("Log\\Req\\ReqData_{0}.txt", System.DateTime.Now.ToString("yyyyMMdd")), sbLog.ToString() + "\r\n\r\n");
            }
            //转换
            return Utils.ToDataResult(retKeyDict, GlobalData.B2BSpotVersion);
        }
        #endregion

        #region 构造函数

        private bool IsSpecialLine = false;
        /// <summary>
        ///  是否为专线 true专线 false互联网 默认互联网
        /// </summary>
        /// <param name="IsSpecialLine">是否为专线 默认为false</param>
        public SpotTranInterface(bool IsSpecialLine = false)
        {
            this.IsSpecialLine = IsSpecialLine;
        }
        #endregion
    }
}
