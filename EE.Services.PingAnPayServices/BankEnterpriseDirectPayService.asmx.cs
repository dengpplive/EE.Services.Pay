using EE.Services.Pay.InertnetVer;
using EE.Services.Pay.Model.Req;
using EE.Services.PingAnPayServices.Common;
using EE.Services.PingAnPayServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EE.Services.PingAnPayServices
{
    /// <summary>
    /// BankEnterpriseDirectPayService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://demo2.xx3700.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BankEnterpriseDirectPayService : System.Web.Services.WebService
    {
        private bool IsSpecialLine = false;
        public BankEnterpriseDirectPayService(bool IsSpecialLine = false)
        {
            this.IsSpecialLine = IsSpecialLine;
        }

        #region 第三章 普通查询转账接口设计
        /// <summary>
        /// 系统状态探测(S001)
        /// </summary>
        /// <param name="counterId"></param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>系统状态探测(S001)</font>")]
        public Result SystemStatusProbeInterface(string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.SystemStatusProbeInterface();
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 企业账户余额查询(4001)  此接口适应银行所有币种的活期账户的余额查询，其中的可用余额只包含自身的资金状况，而不包括集团内部的资金池。账面余额，也只是自身账号的账面金额。
        /// 如果需要查询集团现金管理子账户的可用余额，需要调用“现金管理子账户余额查询[4059]”接口。
        /// </summary>   
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4001">请求数据</param>
        /// <param name="counterId">操作员 最大5位长度</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>企业账户余额查询(4001)</font>")]
        public Result QueryQiyeAccountBalanceInterface(string requestNumber, Req_4001 req_4001, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.QueryQiyeAccountBalanceInterface(requestNumber, req_4001, counterId);
            return CommUtils.ToResult(result);
        }

        /// <summary>
        /// 企业当日交易明细查询[4002]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4002">请求参数</param>
        /// <param name="counterId">操作员 最大5位长度</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>企业当日交易明细查询[4002]</font>")]
        public Result QueryErpTodayTradeDetailInterface(string requestNumber, Req_4002 req_4002, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.QueryErpTodayTradeDetailInterface(requestNumber, req_4002, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 企业当日交易详情查询[4008]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4008">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>企业当日交易详情查询[4008]</font>")]
        public Result QueryErpTodayTradeDetailedInterface(string requestNumber, Req_4008 req_4008, bool isAll = false, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.QueryErpTodayTradeDetailedInterface(requestNumber, req_4008, isAll, counterId);
            return CommUtils.ToResult(result);
        }

        /// <summary>
        /// 企业单笔资金划转(4004)
        /// </summary>
        /// <param name="req_4004">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <param name="attachment">附件文件</param>      
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>企业单笔资金划转(4004)</font>")]
        public Result QiyeSingleMoneyTransferInterface(string requestNumber, Req_4004 req_4004, string counterId = "", Attachment attachment = null)
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.QiyeSingleMoneyTransferInterface(requestNumber, req_4004, counterId, attachment);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 企业批量实时资金划转[4014]
        /// </summary>      
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4014">请求参数</param>
        /// <param name="counterId">操作员号</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>企业批量实时资金划转[4014]</font>")]
        public Result QiyeBatchNoDelayMoneyTransferInterface(string requestNumber, Req_4014 req_4014, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.QiyeBatchNoDelayMoneyTransferInterface(requestNumber, req_4014, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 单笔提交转汇总批量[400401]
        /// </summary>   
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="Req_400401">请求参数</param>
        /// <param name="counterId">操作员号</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>单笔提交转汇总批量[400401]</font>")]
        public Result SingleSubmitTransferSummaryBatchInterface(string requestNumber, Req_400401 req_400401, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.SingleSubmitTransferSummaryBatchInterface(requestNumber, req_400401, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 企业大批量资金划转[4018]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4018">请求参数</param>
        /// <param name="counterId">操作员号</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>企业大批量资金划转[4018]</font>")]
        public Result QiyeLargeBatchMoneyTransferInterface(string requestNumber, Req_4018 req_4018, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.QiyeLargeBatchMoneyTransferInterface(requestNumber, req_4018, counterId);
            return CommUtils.ToResult(result);
        }

        /// <summary>
        ///  企业汇总资金划转[4034]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4034">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>企业汇总资金划转[4034]</font>")]
        public Result QiyeSummaryMoneyTransferInterface(string requestNumber, Req_4034 req_4034, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.QiyeSummaryMoneyTransferInterface(requestNumber, req_4034, counterId);
            return CommUtils.ToResult(result);
        }

        /// <summary>
        /// 企业汇总资金划转[403401]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4034">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>企业汇总资金划转[403401]</font>")]
        public Result QiyeSummaryMoneyTransfer_403401Interface(string requestNumber, Req_4034 req_4034, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.QiyeSummaryMoneyTransfer_403401Interface(requestNumber, req_4034, counterId);
            return CommUtils.ToResult(result);
        }

        /// <summary>
        /// 单笔转账指令查询4005 上送必须输入如下三项中的一项，建议选择使用后两项。如果同时上送多项查询条件，则优先级如下：OrigThirdVoucher >  OrigFrontLogNo > OrigThirdLogNo
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4005">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>单笔转账指令查询[4005]</font>")]
        public Result SingleTransferCmdQueryInterface(string requestNumber, Req_4005 req_4005, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.SingleTransferCmdQueryInterface(requestNumber, req_4005, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 企业交易明细详细信息查询[4006]
        /// </summary>      
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4006">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>企业交易明细详细信息查询[4006]</font>")]
        public Result ErpTradeDetailInfoQueryInterface(string requestNumber, Req_4006 req_4006, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.ErpTradeDetailInfoQueryInterface(requestNumber, req_4006, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 批量转账指令查询[4015]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4015">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>批量转账指令查询[4015]</font>")]
        public Result LargeBatchTransferCmdQueryInterface(string requestNumber, Req_4015 req_4015, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.LargeBatchTransferCmdQueryInterface(requestNumber, req_4015, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 历史余额查询[4012]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4012">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>历史余额查询[4012]</font>")]
        public Result HistoryBalanceQueryInterface(string requestNumber, Req_4012 req_4012, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.HistoryBalanceQueryInterface(requestNumber, req_4012, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 查询账户当日历史交易明细[4013]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4013">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>查询账户当日历史交易明细[4013]</font>")]
        public Result QueryTodayHistoryTransactionDetailInterface(string requestNumber, Req_4013 req_4013, bool isAll = false, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.QueryTodayHistoryTransactionDetailInterface(requestNumber, req_4013, isAll, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 代理行支付当日交易查询[4011]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4011">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>代理行支付当日交易查询[4011]</font>")]
        public Result ProxyBankPayTodayTradeQueryInterface(string requestNumber, Req_4011 req_4011, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.ProxyBankPayTodayTradeQueryInterface(requestNumber, req_4011, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 贷款户明细查询[4016]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4016">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>贷款户明细查询[4016]</font>")]
        public Result LoanAccountDetailQueryInterface(string requestNumber, Req_4016 req_4016, bool isAll = false, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.LoanAccountDetailQueryInterface(requestNumber, req_4016, isAll, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 银行联行号查询[4017]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4017">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>银行联行号查询[4017]</font>")]
        public Result BankContactNumberQueryInterface(string requestNumber, Req_4017 req_4017, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.BankContactNumberQueryInterface(requestNumber, req_4017, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 离岸账户转账[4020]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4020">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>离岸账户转账[4020]</font>")]
        public Result OffshoreAccountTransferInterface(string requestNumber, Req_4020 req_4020, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.OffshoreAccountTransferInterface(requestNumber, req_4020, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 支付指令退票查询[4019]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4019">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>支付指令退票查询[4019]</font>")]
        public Result PayCmdRefundQueryInterface(string requestNumber, Req_4019 req_4019, bool isAll = false, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.PayCmdRefundQueryInterface(requestNumber, req_4019, isAll, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 代发代扣申请接口[4047]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4047">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>代发代扣申请接口[4047]</font>")]
        public Result OnBehalfOfWithholdApplayInterface(string requestNumber, Req_4047 req_4047, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.OnBehalfOfWithholdApplayInterface(requestNumber, req_4047, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 代发代扣结果查询接口[4048]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4048">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>代发代扣结果查询接口[4048]</font>")]
        public Result OnBehalfOfWithholdResultQueryInterface(string requestNumber, Req_4048 req_4048, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.OnBehalfOfWithholdResultQueryInterface(requestNumber, req_4048, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 银证转账[4009]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4009">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>银证转账[4009]</font>")]
        public Result SilverCardTransferMoneyInterface(string requestNumber, Req_4009 req_4009, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.SilverCardTransferMoneyInterface(requestNumber, req_4009, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 查询券商端资金台帐余额[4010]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4010">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>查询券商端资金台帐余额[4010]</font>")]
        public Result QueryBrokerCapitalStationBalanceInterface(string requestNumber, Req_4010 req_4010, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.QueryBrokerCapitalStationBalanceInterface(requestNumber, req_4010, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 汇总批量付款电子回单查询[401802]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_401802">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>汇总批量付款电子回单查询[401802]</font>")]
        public Result SummaryPatchPaymentReceiptBillInterface(string requestNumber, Req_401802 req_401802, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.SummaryPatchPaymentReceiptBillInterface(requestNumber, req_401802, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 混合批量转账接口[4027] 
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4027">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>混合批量转账接口[4027]</font>")]
        public Result BlendPatchTransferMoneyInterface(string requestNumber, Req_4027 req_4027, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.BlendPatchTransferMoneyInterface(requestNumber, req_4027, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 借记卡客户信息验证接口[400101]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_400101">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>借记卡客户信息验证接口[400101]</font>")]
        public Result DebitCardCustomerInfoVerificationInterface(string requestNumber, Req_400101 req_400101, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.DebitCardCustomerInfoVerificationInterface(requestNumber, req_400101, counterId);
            return CommUtils.ToResult(result);
        }
        #endregion

        #region 第四章 直连交易明细下载
        /// <summary>
        /// 明细报表查询接口[F001]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_F001">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>明细报表查询接口[F001]</font>")]
        public Result DetailReportQueryInterface(string requestNumber, Req_F001 req_F001, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.DetailReportQueryInterface(requestNumber, req_F001, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 明细报表生成通知接口[F002]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_F002">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>明细报表生成通知接口[F002]</font>")]
        public Result DetailReportCreateNotifyInterface(string requestNumber, Req_F002 req_F002, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.DetailReportCreateNotifyInterface(requestNumber, req_F002, counterId);
            return CommUtils.ToResult(result);
        }

        #endregion

        #region 第五章 现金管理接口设计
        /// <summary>
        /// 定期账户信息查询[4021]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4021">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>定期账户信息查询[4021]</font>")]
        public Result FixedDepositAccountInfoQueryInterface(string requestNumber, Req_4021 req_4021, bool isAll = false, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.FixedDepositAccountInfoQueryInterface(requestNumber, req_4021, isAll, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 查询定活通存单信息[4025]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4025">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>查询定活通存单信息[4025]</font>")]
        public Result QueryLiveComReceiptInfoInterface(string requestNumber, Req_4025 req_4025, bool isAll = false, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.QueryLiveComReceiptInfoInterface(requestNumber, req_4025, isAll, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 集团内账户预结息/结息 (4054)
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4054">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>集团内账户预结息/结息 (4054)</font>")]
        public Result WithinGroupAccountPreKnotInterface(string requestNumber, Req_4054 req_4054, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.WithinGroupAccountPreKnotInterface(requestNumber, req_4054, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 现金管理虚帐户合约建立/修改/删除(4058)
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4058">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>现金管理虚帐户合约建立/修改/删除(4058)</font>")]
        public Result MoneyManageVirtualAccountContractAddOrUpdateOrDelInterface(string requestNumber, Req_4058 req_4058, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.MoneyManageVirtualAccountContractAddOrUpdateOrDelInterface(requestNumber, req_4058, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 集团内手工归集下拨[4052]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4052">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>集团内手工归集下拨[4052]</font>")]
        public Result WithinGroupHandModeNotionalPoolDownPickInterface(string requestNumber, Req_4052 req_4052, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.WithinGroupHandModeNotionalPoolDownPickInterface(requestNumber, req_4052, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 集团内虚拟子账户余额调整[4057] 
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4057">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>集团内虚拟子账户余额调整[4057]</font>")]
        public Result WithinGroupVirtualAccountBalanceAdjustInterface(string requestNumber, Req_4057 req_4057, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.WithinGroupVirtualAccountBalanceAdjustInterface(requestNumber, req_4057, counterId);
            return CommUtils.ToResult(result);
        }

        /// <summary>
        /// 集团总账户查询[4022]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4022">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>集团总账户查询[4022]</font>")]
        public Result WithinGroupTotalAccountQueryInterface(string requestNumber, Req_4022 req_4022, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.WithinGroupTotalAccountQueryInterface(requestNumber, req_4022, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 集团子账户列表查询 [4023]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4023">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>集团子账户列表查询 [4023]</font>")]
        public Result WithinGroupSubAccountListQueryInterface(string requestNumber, Req_4023 req_4023, bool isAll = false, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.WithinGroupSubAccountListQueryInterface(requestNumber, req_4023, isAll, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 现金管理合约查询[4055] 查询集团总账户及下辖子账户间现金管理合约信息 
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4055">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>现金管理合约查询[4055] 查询集团总账户及下辖子账户间现金管理合约信息 </font>")]
        public Result CashMangeContractQueryInterface(string requestNumber, Req_4055 req_4055, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.CashMangeContractQueryInterface(requestNumber, req_4055, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 台账记录查询[4024] 
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4024">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>台账记录查询[4024]</font>")]
        public Result LedgerRecordQueryInterface(string requestNumber, Req_4024 req_4024, bool isAll = false, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.LedgerRecordQueryInterface(requestNumber, req_4024, isAll, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 结息查询[4056]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4056">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>结息查询[4056]</font>")]
        public Result JieXiQueryInterface(string requestNumber, Req_4056 req_4056, bool isAll = false, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.JieXiQueryInterface(requestNumber, req_4056, isAll, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 现金管理子账户余额查询[4059]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_4059">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>现金管理子账户余额查询[4059]</font>")]
        public Result CashMangeSubAccountBalanceQueryInterface(string requestNumber, Req_4059 req_4059, string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.CashMangeSubAccountBalanceQueryInterface(requestNumber, req_4059, counterId);
            return CommUtils.ToResult(result);
        }
        #endregion

        #region 第六章 票据接口设计
        /// <summary>
        /// 票据接口设计[DP00]
        /// </summary>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>票据接口设计[DP00]</font>")]
        public Result DP00_Interface(string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.DP00_Interface(counterId);
            return CommUtils.ToResult(result);
        }
        #endregion

        #region 第七章 供应链接口
        /// <summary>
        /// 供应链接口[SC00]
        /// </summary>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>供应链接口[SC00]</font>")]
        public Result SC00_Interface(string counterId = "")
        {
            var be = new BankEnterpriseDirectInterface(this.IsSpecialLine);
            var result = be.SC00_Interface(counterId);
            return CommUtils.ToResult(result);
        }
        #endregion



    }
}
