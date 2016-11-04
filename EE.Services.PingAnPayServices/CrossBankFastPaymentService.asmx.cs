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
    /// CrossBankFastPaymentService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://demo2.xx3700.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class CrossBankFastPaymentService : System.Web.Services.WebService
    {
        private bool IsSpecialLine = false;
        public CrossBankFastPaymentService(bool IsSpecialLine = false)
        {
            this.IsSpecialLine = IsSpecialLine;
        }
        #region 第三章 银企直连跨行快付接口
        /// <summary>
        /// 批量付款文件提交 [KHKF01]
        /// </summary>       
        /// <param name="req_KHKF01">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>批量付款文件提交 [KHKF01]</font>")]
        public Result PatchPaymentFileCommitInterface(Req_KHKF01 req_KHKF01, string counterId = "")
        {
            var clff = new CrossLineFastPaymentInterface(this.IsSpecialLine);
            var result = clff.PatchPaymentFileCommitInterface(req_KHKF01, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 批量付款结果查询[KHKF02]
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_KHKF02">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>批量付款结果查询[KHKF02]，需要先调用FILE03下载才能查询到数据</font>")]
        public Result PatchPaymentResultQueryInterface(string requestNumber, Req_KHKF02 req_KHKF02, string counterId = "")
        {
            var clff = new CrossLineFastPaymentInterface(this.IsSpecialLine);
            var result = clff.PatchPaymentResultQueryInterface(requestNumber, req_KHKF02, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 单笔付款申请[KHKF03]
        /// </summary>        
        /// <param name="req_KHKF03">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>单笔付款申请[KHKF03]</font>")]
        public Result SinglePaymentApplayInterface(Req_KHKF03 req_KHKF03, string counterId = "")
        {
            var clff = new CrossLineFastPaymentInterface(this.IsSpecialLine);
            var result = clff.SinglePaymentApplayInterface(req_KHKF03, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 单笔付款结果查询[KHKF04]
        /// </summary>     
        /// <param name="req_KHKF04">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>单笔付款结果查询[KHKF04]</font>")]
        public Result SinglePaymentResultQueryInterface(Req_KHKF04 req_KHKF04, string counterId = "")
        {
            var clff = new CrossLineFastPaymentInterface(this.IsSpecialLine);
            var result = clff.SinglePaymentResultQueryInterface(req_KHKF04, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 对账/差错文件查询[KHKF05] 
        /// </summary>
        /// <param name="requestNumber">请求流水号</param>
        /// <param name="req_KHKF05">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>对账/差错文件查询[KHKF05] </font>")]
        public Result ReconciliationOrErrorFileQueryInterface(string requestNumber, Req_KHKF05 req_KHKF05, string counterId = "")
        {
            var clff = new CrossLineFastPaymentInterface(this.IsSpecialLine);
            var result = clff.ReconciliationOrErrorFileQueryInterface(requestNumber, req_KHKF05, counterId);
            return CommUtils.ToResult(result);
        }
        #endregion


        #region 文件传输
        /// <summary>
        /// 文件上传接口[FILE01]
        /// </summary>       
        /// <param name="req_FILE01">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>文件上传接口[FILE01]</font>")]
        public Result FILE01_Interface(Req_FILE01 req_FILE01, string counterId = "")
        {
            var be = new CrossLineFastPaymentInterface(this.IsSpecialLine);
            var result = be.FILE01_Interface(req_FILE01.TradeSn, req_FILE01, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 文件上传和下载进度查询[FILE02]
        /// </summary>
        /// <param name="requestNumber">上传文件的流水号</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>文件上传和下载进度查询[FILE02]</font>")]
        public Result FILE02_Interface(string tradeSn, string counterId = "")
        {
            var be = new CrossLineFastPaymentInterface(this.IsSpecialLine);
            var result = be.FILE02_Interface(tradeSn, counterId);
            return CommUtils.ToResult(result);
        }
        /// <summary>
        /// 文件下载[FILE03]
        /// </summary>
        /// <param name="req_FILE03">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        [WebMethod(Description = "<font color='red'>文件下载[FILE03]</font>")]
        public Result FILE03_Interface(Req_FILE03 req_FILE03, string counterId = "")
        {
            var be = new CrossLineFastPaymentInterface(this.IsSpecialLine);
            var result = be.FILE03_Interface(req_FILE03, counterId);
            return CommUtils.ToResult(result);
        }
        #endregion
    }
}
