using EE.Services.Pay.Common;
using EE.Services.Pay.InertnetVer;
using EE.Services.Pay.Model;
using EE.Services.Pay.Model.Req;
using EE.Services.PingAnPayServices.Common;
using EE.Services.PingAnPayServices.Credentials;
using EE.Services.PingAnPayServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using static EE.Services.Pay.Common.CommonEnums;

namespace EE.Services.PingAnPayServices
{
    /// <summary>
    /// SpotTranPayServices 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://demo2.xx3700.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SpotTranPayServices : System.Web.Services.WebService
    {
        #region 对接口添加认证
        /*
        public MySoapHeader mySoapHeader = new MySoapHeader();
        [SoapHeader("mySoapHeader")]
        [WebMethod(Description = "<font color='red'>testA</font>")]
        public string testA()
        {
            string returnStr = "";
            if (mySoapHeader.IsValid())
            {
                returnStr = "通过";
            }
            else
            {
                returnStr = "未通过";
            }
            return returnStr;
        }*/
        #endregion


        #region 会员开销户接口
        /// <summary>
        /// 个人开户 会员注册签约易宝开户和绑定银行卡 调用第一次开户  再次调用绑定银行卡
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="reqView_1343">请求信息</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>【适用个人】 会员注册签约易宝开户和绑定银行卡[1443]</font>")]
        public Result_1343 CustRegisterSignYeePayInterface(string requestNumber, ReqView_1343 reqView_1343)
        {
            SpotTranInterface client = new SpotTranInterface();
            var req_1343 = new Req_1343();
            req_1343.SupAcctId = reqView_1343.SupAcctId;
            req_1343.ThirdCustId = reqView_1343.ThirdCustId;
            req_1343.AcctId = reqView_1343.AcctId;
            req_1343.CustName = reqView_1343.CustName;
            req_1343.IdType = reqView_1343.IdType;
            req_1343.IdCode = reqView_1343.IdCode;
            req_1343.MobilePhone = reqView_1343.MobilePhone;

            req_1343.CpFlag = 2;
            req_1343.BankType = 1;
            req_1343.BankName = "平安银行";
            req_1343.BankCode = "";
            req_1343.Reserve = "1343";
            req_1343.SBankCode = "307584007998";
            var result = client.CustRegisterSignYeePayInterface(requestNumber, req_1343);

            var resview_1343 = new Result_1343();
            resview_1343.RspCode = result.RspCode;
            resview_1343.RspMsg = result.RspMsg;

            if (result.Model != null)
            {
                resview_1343.ThirdCustId = result.Model.ThirdCustId;
                resview_1343.SerialNo = result.Model.SerialNo;
                resview_1343.Reserve = result.Model.Reserve;
            }
            return resview_1343;
        }

        /// <summary>
        /// 会员注册签约易宝开户和绑定银行卡 调用第一次开户  再次调用绑定银行卡
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_1343">请求信息</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>【适用个人和企业】 会员注册签约易宝开户和绑定银行卡[1443]</font>")]
        public Result_1343 CustErpRegisterSignYeePayInterface(string requestNumber, Req_1343 req_1343)
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.CustRegisterSignYeePayInterface(requestNumber, req_1343);

            var resview_1343 = new Result_1343();
            resview_1343.RspCode = result.RspCode;
            resview_1343.RspMsg = result.RspMsg;

            if (result.Model != null)
            {
                resview_1343.ThirdCustId = result.Model.ThirdCustId;
                resview_1343.SerialNo = result.Model.SerialNo;
                resview_1343.Reserve = result.Model.Reserve;
            }
            return resview_1343;
        }

        /// <summary>
        /// 会员注册签约易宝-回填验证
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="reqView_1344">请求信息</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>会员注册签约易宝-回填验证[1344]</font>")]
        public Result_1344 CustRegisterSignYeePayValidateInterface(string requestNumber, ReqView_1344 reqView_1344)
        {
            SpotTranInterface client = new SpotTranInterface();
            var req_1344 = new Req_1344();
            req_1344.FuncFlag = 1;
            req_1344.SerialNo = reqView_1344.SerialNo;
            req_1344.MessageCode = reqView_1344.MessageCode;
            req_1344.Reserve = "1344";
            var result = client.CustRegisterSignYeePayValidateInterface(requestNumber, req_1344);
            var resview_1344 = new Result_1344();
            resview_1344.RspCode = result.RspCode;
            resview_1344.RspMsg = result.RspMsg;
            if (result.Model != null)
            {
                resview_1344.CustAcctId = result.Model.CustAcctId;
                resview_1344.DealStatus = result.Model.DealStatus;
                resview_1344.RelatedAcctId = result.Model.RelatedAcctId;
                //resview_1344.Reserve = result.Model.Reserve;
                resview_1344.SerialNo = result.Model.SerialNo;
                resview_1344.ThirdCustId = result.Model.ThirdCustId;
            }
            return resview_1344;
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
        [WebMethod(Description = "<font color='red'>签到/签退交易[1330]</font>")]
        public Result_1330 SignInOrOutInterface(string serialNumber, Req_1330 req_1330, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.SignInOrOutInterface(serialNumber, req_1330, counterId);
            return new Result_1330()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        #endregion

        #region 出入金模块

        /// <summary>
        /// 入金（交易网发起）
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1316">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>入金即充值[1316]，金额从银行卡到会员子账户</font>")]
        public Result_1316 InMoneyFromTradeNetworkInterface(string serialNumber, Req_1316 req_1316, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.InMoneyFromTradeNetworkInterface(serialNumber, req_1316, counterId);
            return new Result_1316()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }

        /// <summary>
        /// 出金（交易网发起)
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1318">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>出金即提现[1318],金额从会员子账户到银行卡</font>")]
        public Result_1318 OutMoneyFromTradeNetworkInterface(string serialNumber, Req_1318 req_1318, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.OutMoneyFromTradeNetworkInterface(serialNumber, req_1318, counterId);
            return new Result_1318()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        /// <summary>
        /// 跨行出金（交易网发起）【1313】
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1313">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>跨行出金[1313]</font>")]
        public Result_1313 CrossBankPutAmountInterface(string serialNumber, Req_1313 req_1313, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.CrossBankPutAmountInterface(serialNumber, req_1313, counterId);
            return new Result_1313()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        #endregion

        #region 查询类接口
        /// <summary>
        /// 查银行端会员资金台帐余额
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1010">请求信息</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>查银行端会员资金台帐余额[1010]</font>")]
        public Result_1010 QueryBankMemberCapitalStationBalanceInterface(string serialNumber, Req_1010 req_1010, bool isAll = false, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.QueryBankMemberCapitalStationBalanceInterface(serialNumber, req_1010, isAll, counterId);
            return new Result_1010()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }

        /// <summary>
        /// 监管账户信息查询
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1021">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>监管账户信息查询[1021]</font>")]
        public Result_1021 QuerySuperviseAccountInfoInterface(string serialNumber, Req_1021 req_1021, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.QuerySuperviseAccountInfoInterface(serialNumber, req_1021, counterId);
            return new Result_1021()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        /// <summary>
        ///  查时间段会员开销户信息
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1016">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>查时间段会员开销户信息[1016]</font>")]
        public Result_1016 QueryTimeSlotMemberOpenOrCencelAccountInfoInterface(string serialNumber, Req_1016 req_1016, bool isAll = false, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.QueryTimeSlotMemberOpenOrCencelAccountInfoInterface(serialNumber, req_1016, isAll, counterId);
            return new Result_1016()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }

        /// <summary>
        /// 查询会员出入金账号的银行余额
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="reqView_1020">请求信息</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>查询会员出入金账号的银行余额[1020]</font>")]
        public Result_1020 QueryMemberBankBalanceInterface(string requestNumber, ReqView_1020 reqView_1020)
        {
            SpotTranInterface client = new SpotTranInterface();
            var req_1020 = new Req_1020();
            req_1020.SupAcctId = reqView_1020.SupAcctId;
            req_1020.CustAcctId = reqView_1020.CustAcctId;
            req_1020.ThirdCustId = reqView_1020.ThirdCustId;//可选  
            req_1020.CustName = reqView_1020.CustName;
            req_1020.AcctNo = reqView_1020.AcctNo;
            req_1020.Reserve = "1020";
            var result = client.QueryMemberInOutMoneyAccountBankBalanceInterface(requestNumber, req_1020);
            var resview_1020 = new Result_1020();
            resview_1020.RspCode = result.RspCode;
            resview_1020.RspMsg = result.RspMsg;
            if (result.Model != null)
            {
                resview_1020.Balance = result.Model.Balance;
                resview_1020.Reserve = result.Model.Reserve;
            }
            return resview_1020;
        }

        /// <summary>
        /// 查询时间段会员交易流水信息
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1324">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>查询时间段会员交易流水信息[1324]</font>")]
        public Result_1324 QueryMemberTradeFlowInfoInterface(string serialNumber, Req_1324 req_1324, bool isAll = false, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.QueryMemberTradeFlowInfoInterface(serialNumber, req_1324, isAll, counterId);
            return new Result_1324()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }

        /// <summary>
        /// 查询时间段会员出入金流水信息
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1324">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>查询时间段会员出入金流水信息[1325]</font>")]
        public Result_1325 QueryMemberInOutMoneyFlowInfoInterface(string serialNumber, Req_1324 req_1324, bool isAll = false, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.QueryMemberInOutMoneyFlowInfoInterface(serialNumber, req_1324, isAll, counterId);
            return new Result_1325()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        /// <summary>
        /// 查询支付指令状态
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1327">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>查询支付指令状态[1327]</font>")]
        public Result_1327 QueryPaySerialStatusInterface(string serialNumber, Req_1327 req_1327, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.QueryPaySerialStatusInterface(serialNumber, req_1327, counterId);
            return new Result_1327()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        /// <summary>
        /// 查询子账户间支付的指令结果【1333】 用于查询【1332】接口提交的子账户间支付的指令处理结果
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1327">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>查询子账户间支付的指令结果[1333],用于查询【1332】接口提交的子账户间支付的指令处理结果</font>")]
        public Result_1333 QuerySubAccountPayResultInterface(string serialNumber, Req_1333 req_1333, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.QuerySubAccountPayResultInterface(serialNumber, req_1333, counterId);
            return new Result_1333()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        /// <summary>
        /// 根据订单号查询会员交易流水结果【1342】（郑大专用）
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1342">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>根据订单号查询会员交易流水结果【1342】（郑大专用）</font>")]
        public Result_1342 QueryTradeResultByOrderIdInterface(string serialNumber, Req_1342 req_1342, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.QueryTradeResultByOrderIdInterface(serialNumber, req_1342, counterId);
            return new Result_1342()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        /// <summary>
        /// 查询银行小额鉴权转账结果【1348】
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1348">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>询银行小额鉴权转账结果[1348],(用于企业用户) 用于查询1343接口发起的小额鉴权的转账结果。鉴权指令号是1343接口同步返回的</font>")]
        public Result_1348 QueryBankAuthenticationInterface(string serialNumber, Req_1348 req_1348, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.QueryBankAuthenticationInterface(serialNumber, req_1348, counterId);
            return new Result_1348()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        /// <summary>
        /// 查询对账文件密码【1349】
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1349">请求参数</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>查询对账文件密码[1349]</font>")]
        public Result_1349 QueryReconciliationFilePwdInterface(string serialNumber, Req_1349 req_1349, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.QueryReconciliationFilePwdInterface(serialNumber, req_1349, counterId);
            return new Result_1349()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
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
        [WebMethod(Description = "<font color='red'>会员在途充值[1350]，金额从银行卡到会员子账户</font>")]
        public Result_1350 MemberRechargeInterface(string serialNumber, Req_1350 req_1350, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.MemberRechargeInterface(serialNumber, req_1350, counterId);
            return new Result_1350()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }

        /// <summary>
        /// 子账户间划转[1028]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1028">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>子账户间划转[1028],即支付，会员间的子账户支付</font>")]
        public Result_1028 SubAccountPayInterface(string serialNumber, Req_1028 req_1028, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.SubAccountPayInterface(serialNumber, req_1028, counterId);
            return new Result_1028()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        /// <summary>
        /// 子账户复核支付
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1328">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>子账户复核支付[1328]</font>")]
        public Result_1328 ChildAccountReviewPayInterface(string serialNumber, Req_1328 req_1328, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.ChildAccountReviewPayInterface(serialNumber, req_1328, counterId);
            return new Result_1328()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }


        /// <summary>
        /// 平台操作支付
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1331">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>平台操作支付[1331]</font>")]
        public Result_1331 PlatformOperationPayInterface(string serialNumber, Req_1331 req_1331, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.PlatformOperationPayInterface(serialNumber, req_1331, counterId);
            return new Result_1331()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        /// <summary>
        /// 子账户之间直接支付 会员A直接支付给会员B。钱从会员A的子账户支付到会员B的银行卡。
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_1329">实体数据</param>
        /// <returns></returns>       
        [WebMethod(Description = "<font color='red'>子账户之间直接支付[1329],会员A直接支付给会员B,钱从会员A的子账户支付到会员B的银行卡</font>")]
        public Result_1329 ChildAccountDirectPayInterface(string requestNumber, ReqView_1329 reqView_1329)
        {
            SpotTranInterface client = new SpotTranInterface();
            var req_1329 = new Req_1329();
            req_1329.OutCustAcctId = reqView_1329.OutCustAcctId;
            req_1329.OutThirdCustId = reqView_1329.OutThirdCustId;
            req_1329.InCustAcctId = reqView_1329.InCustAcctId;
            req_1329.InThirdCustId = reqView_1329.InThirdCustId;
            req_1329.TranAmount = reqView_1329.TranAmount;
            req_1329.HandFee = reqView_1329.HandFee;
            req_1329.PaySerialNo = reqView_1329.PaySerialNo;
            req_1329.ThirdHtId = reqView_1329.ThirdHtId;
            req_1329.FuncFlag = 1;
            req_1329.SupAcctId = reqView_1329.SupAcctId;
            //--可选
            req_1329.ThirdHtCont = reqView_1329.ThirdHtCont;
            req_1329.Note = reqView_1329.Note;
            req_1329.Reserve = "1329";
            var result = client.ChildAccountDirectPayInterface(requestNumber, req_1329);
            var res_1329 = new Result_1329();
            res_1329.RspCode = result.RspCode;
            res_1329.RspMsg = result.RspMsg;
            if (result.Model != null)
            {
                res_1329.FrontLogNo = result.Model.FrontLogNo;
                res_1329.Reserve = result.Model.Reserve;
            }
            return res_1329;
        }

        /// <summary>
        /// 子账户间支付【1332】-基本 会员A直接支付给会员B。钱从会员A的子账户支付到会员B的子账户。
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="reqView_1332">实体数据</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>子账户间支付[1332],会员A直接支付给会员B,钱从会员A的子账户支付到会员B的子账户。</font>")]
        public Result_1332 ChildAccountInDirectPayInterface(string requestNumber, ReqView_1332 reqView_1332)
        {
            SpotTranInterface client = new SpotTranInterface();
            var req_1332 = new Req_1332();
            req_1332.SupAcctId = reqView_1332.SupAcctId;
            req_1332.FuncFlag = 1;
            req_1332.OutCustAcctId = reqView_1332.OutCustAcctId;
            req_1332.OutThirdCustId = reqView_1332.OutThirdCustId;
            req_1332.InCustAcctId = reqView_1332.InCustAcctId;
            req_1332.InThirdCustId = reqView_1332.InThirdCustId;
            req_1332.TranAmount = reqView_1332.TranAmount;
            req_1332.HandFee = reqView_1332.HandFee;
            req_1332.PaySerialNo = reqView_1332.PaySerialNo;
            req_1332.ThirdHtId = reqView_1332.ThirdHtId;
            //--可选
            req_1332.ThirdHtCont = reqView_1332.ThirdHtCont;
            req_1332.Note = reqView_1332.Note;
            req_1332.Reserve = "1332";
            var result = client.ChildAccountInDirectPayInterface(requestNumber, req_1332);
            var res_1332 = new Result_1332();
            res_1332.RspCode = result.RspCode;
            res_1332.RspMsg = result.RspMsg;
            if (result.Model != null)
            {
                res_1332.FrontLogNo = result.Model.FrontLogNo;
                res_1332.Reserve = result.Model.Reserve;
            }
            return res_1332;
        }
        /// <summary>
        /// 子账户冻结解冻 
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1029">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>子账户冻结解冻[1029],在原有金额基础上添加冻结/解冻金额</font>")]
        public Result_1029 ChildAccountFrozenOrThawInterface(string serialNumber, Req_1029 req_1029, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.ChildAccountFrozenOrThawInterface(serialNumber, req_1029, counterId);
            return new Result_1029()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        /// <summary>
        /// 平台收费与退费 
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1030">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>平台收费与退费[1030]</font>")]
        public Result_1030 PlatformChargeOrRefundInterface(string serialNumber, Req_1030 req_1030, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.PlatformChargeOrRefundInterface(serialNumber, req_1030, counterId);
            return new Result_1030()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        /// <summary>
        /// 平台支付与收取
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_1031">请求信息</param>
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>平台支付与收取[1031]</font>")]
        public Result_1031 PlatformPayOrChargeInterface(string serialNumber, Req_1031 req_1031, string counterId = "")
        {
            SpotTranInterface client = new SpotTranInterface();
            var result = client.PlatformPayOrChargeInterface(serialNumber, req_1031, counterId);
            return new Result_1031()
            {
                Data = result.Model,
                RspCode = result.RspCode,
                RspMsg = result.RspMsg
            };
        }
        #endregion

        /// <summary>
        /// 获取证件类型列表
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>获取证件类型列表</font>")]
        public CardType GetCardTypeInterface()
        {
            var cardType = new CardType();
            var result = Utils.ToEnumProp<IDType>();
            result.ForEach(p =>
            {
                cardType.list.Add(new CardType.IdType()
                {
                    Id = p.Value,
                    Desc = p.Desc
                });
            });
            return cardType;
        }

    }
}
