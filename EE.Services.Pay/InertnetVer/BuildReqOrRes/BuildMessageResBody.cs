using EE.Services.Pay.Common;
using EE.Services.Pay.Common.Ext;
using EE.Services.Pay.Model;
using EE.Services.Pay.Model.Req;
using EE.Services.Pay.Model.Res;
using System;
using System.Text;

namespace EE.Services.Pay.InertnetVer
{
    /// <summary>
    /// 构建各个接口的响应报文体  [平安银行B2B现货接口文档V1.4]
    /// </summary>
    public class BuildMessageResBody
    {
        #region 构造函数
        /// <summary>
        /// 应答码列表
        /// </summary>
        private AnswerCode answerCode;
        public BuildMessageResBody()
        {
            this.answerCode = GlobalData.LoadAnswerCode();
        }
        #endregion

        #region 会员开销户接口
        /// <summary>
        /// 会员开销户确认【1301】
        /// 该接口仅用作与市场间核对会员身份，核对成功后返回银行成功，否则返回银行失败。该接口中的子账户账号请不要记录，因为如果1315接口通知失败，会进行回滚。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1301(ExHashTable parmaKeyDict)
        {
            string result = string.Empty;
            //接收的数据
            var req = Utils.ToDataResult(parmaKeyDict, GlobalData.B2BSpotVersion);
            if (req != null)
            {
                Req_1301 reqModel = req.ToModel<Req_1301>();
                var resModel = new Res_1301();
                var notifyResult = new NotifyResult()
                {
                    ReqData = reqModel,
                    RspData = resModel,
                    DataResult = req
                };
                //处理业务                
                var handler = BuildHandler.GetHandler();
                if (handler != null) handler.Process(req.FuncCode, notifyResult);
                //业务处理成功后更改 响应码:RspCode 为成功 "000000"
                parmaKeyDict.Set("RspCode", notifyResult.RspStatus.Code);
                parmaKeyDict.Set("RspMsg", notifyResult.RspStatus.Msg);
                //返回内容
                result = Utils.JoinModelString<Res_1301>(notifyResult.RspData);
            }
            return result;
        }
        /// <summary>
        /// 会员签解约维护【1303】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1303(ExHashTable parmaKeyDict)
        {
            string result = string.Empty;
            //接收的数据
            var req = Utils.ToDataResult(parmaKeyDict, GlobalData.B2BSpotVersion);
            if (req != null)
            {
                Req_1303 reqModel = req.ToModel<Req_1303>();
                var resModel = new Res_1303();
                var notifyResult = new NotifyResult()
                {
                    ReqData = reqModel,
                    RspData = resModel,
                    DataResult = req
                };
                //处理业务                
                var handler = BuildHandler.GetHandler();
                if (handler != null) handler.Process(req.FuncCode, notifyResult);
                //业务处理成功后更改 响应码:RspCode 为成功 "000000"
                parmaKeyDict.Set("RspCode", notifyResult.RspStatus.Code);
                parmaKeyDict.Set("RspMsg", notifyResult.RspStatus.Msg);
                //返回内容
                result = Utils.JoinModelString<Res_1303>(notifyResult.RspData);
            }
            return result;
        }
        /// <summary>
        /// 出入金账户维护【1315】
        /// 平台需记录该接口通知的子账户和出/入金账号，出/入金账号是会员绑定的用于转入和转出资金的账号，属于会员自己的账号。
        /// 若会员在银行端修改了自己绑定的账号，银行使用功能标志2：修改，通知平台。（目前银行端不支持修改，为预留功能）
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1315(ExHashTable parmaKeyDict)
        {
            string result = string.Empty;
            //接收的数据
            var req = Utils.ToDataResult(parmaKeyDict, GlobalData.B2BSpotVersion);
            if (req != null)
            {
                Req_1315 reqModel = req.ToModel<Req_1315>();
                var resModel = new Res_1315();
                var notifyResult = new NotifyResult()
                {
                    ReqData = reqModel,
                    RspData = resModel,
                    DataResult = req
                };
                //处理业务                
                //处理业务                
                var handler = BuildHandler.GetHandler();
                if (handler != null) handler.Process(req.FuncCode, notifyResult);
                //业务处理成功后更改 响应码:RspCode 为成功 "000000"
                parmaKeyDict.Set("RspCode", notifyResult.RspStatus.Code);
                parmaKeyDict.Set("RspMsg", notifyResult.RspStatus.Msg);
                result = Utils.JoinModelString<Res_1315>(resModel);
            }
            return result;
        }

        #endregion

        #region 出入金模块

        /// <summary>
        /// 入金（银行发起）【1310】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1310(ExHashTable parmaKeyDict)
        {
            string result = string.Empty;
            //接收的数据
            var req = Utils.ToDataResult(parmaKeyDict, GlobalData.B2BSpotVersion);
            if (req != null)
            {
                Req_1310 reqModel = req.ToModel<Req_1310>();
                var resModel = new Res_1310();
                var notifyResult = new NotifyResult()
                {
                    ReqData = reqModel,
                    RspData = resModel,
                    DataResult = req
                };
                //处理业务                
                var handler = BuildHandler.GetHandler();
                if (handler != null) handler.Process(req.FuncCode, notifyResult);
                //业务处理成功后更改 响应码:RspCode 为成功 "000000"
                parmaKeyDict.Set("RspCode", notifyResult.RspStatus.Code);
                parmaKeyDict.Set("RspMsg", notifyResult.RspStatus.Msg);
                result = Utils.JoinModelString<Res_1310>(resModel);
            }
            return result;
        }



        /// <summary>
        /// 出金（银行发起）【1312】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1312(ExHashTable parmaKeyDict)
        {
            string result = string.Empty;
            var req = Utils.ToDataResult(parmaKeyDict, GlobalData.B2BSpotVersion);
            if (req != null)
            {
                var reqModel = req.ToModel<Req_1312>();
                var resModel = new Res_1312();
                var notifyResult = new NotifyResult()
                {
                    ReqData = reqModel,
                    RspData = resModel,
                    DataResult = req
                };
                //处理业务                
                var handler = BuildHandler.GetHandler();
                if (handler != null) handler.Process(req.FuncCode, notifyResult);
                //业务处理成功后更改 响应码:RspCode 为成功 "000000"
                parmaKeyDict.Set("RspCode", notifyResult.RspStatus.Code);
                parmaKeyDict.Set("RspMsg", notifyResult.RspStatus.Msg);
                result = Utils.JoinModelString<Res_1312>(resModel);
            }
            return result;
        }
        #endregion

        #region 查询类接口             
        /// <summary>
        /// 查交易网端会员管理账户余额【1019】
        /// 银行发起查询会员在市场端余额的信息。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1019(ExHashTable parmaKeyDict)
        {
            string result = string.Empty;
            var req = Utils.ToDataResult(parmaKeyDict, GlobalData.B2BSpotVersion);
            if (req != null)
            {
                var reqModel = req.ToModel<Req_1019>();
                var resModel = new Res_1019();
                var notifyResult = new NotifyResult()
                {
                    ReqData = reqModel,
                    RspData = resModel,
                    DataResult = req
                };
                //处理业务                
                var handler = BuildHandler.GetHandler();
                if (handler != null) handler.Process(req.FuncCode, notifyResult);
                //业务处理成功后更改 响应码:RspCode 为成功 "000000"
                parmaKeyDict.Set("RspCode", notifyResult.RspStatus.Code);
                parmaKeyDict.Set("RspMsg", notifyResult.RspStatus.Msg);
                result = Utils.JoinModelString<Res_1019>(resModel);
            }
            return result;
        }

        #endregion

        #region 会员交易接口

        /// <summary>
        /// 银行复核通知【1326】
        /// 在发送【1328】申请支付后，银行受理成功后，会在银行界面显示让客户进行复核，客户复核后，银行将复核通知平台，平台返回成功，则银行执行支付指令，反之平台返回失败，指令保持原样不执行，客户依旧可以在银行重新点击确认。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1326(ExHashTable parmaKeyDict)
        {
            string result = string.Empty;
            var req = Utils.ToDataResult(parmaKeyDict, GlobalData.B2BSpotVersion);
            if (req != null)
            {
                var reqModel = req.ToModel<Req_1326>();
                var resModel = new Res_1326();
                var notifyResult = new NotifyResult()
                {
                    ReqData = reqModel,
                    RspData = resModel,
                    DataResult = req
                };
                //处理业务                
                var handler = BuildHandler.GetHandler();
                if (handler != null) handler.Process(req.FuncCode, notifyResult);
                //业务处理成功后更改 响应码:RspCode 为成功 "000000"
                parmaKeyDict.Set("RspCode", notifyResult.RspStatus.Code);
                parmaKeyDict.Set("RspMsg", notifyResult.RspStatus.Msg);
                result = Utils.JoinModelString<Res_1326>(resModel);
            }
            return result;
        }
        #endregion

        #region FILE04 ERP文件上传、下载结果通知
        public string BuildString_FILE04(ExHashTable parmaKeyDict)
        {
            string result = string.Empty;
            var req = Utils.ToDataResult(parmaKeyDict, GlobalData.B2BSpotVersion);
            if (req != null)
            {
                var reqModel = req.ToModel<DynamicXml>().To_FILE04();
                var notifyResult = new NotifyResult()
                {
                    ReqData = reqModel,
                    DataResult = req
                };
                //处理业务                
                var handler = BuildHandler.GetHandler();
                if (handler != null) handler.Process(req.FuncCode, notifyResult);
                //业务处理成功后更改 响应码:RspCode 为成功 "000000"
                parmaKeyDict.Set("RspCode", notifyResult.RspStatus.Code);
                parmaKeyDict.Set("RspMsg", notifyResult.RspStatus.Msg);
                result = "";
            }
            return result;
        }
        #endregion

        #region  明细报表生成通知接口F002
        public string BuildString_F002(ExHashTable parmaKeyDict)
        {
            string result = string.Empty;
            var req = Utils.ToDataResult(parmaKeyDict, GlobalData.B2BSpotVersion);
            if (req != null)
            {
                var reqModel = req.ToModel<DynamicXml>().To_F002();
                var notifyResult = new NotifyResult()
                {
                    ReqData = reqModel,
                    DataResult = req
                };
                //处理业务                
                var handler = BuildHandler.GetHandler();
                if (handler != null) handler.Process(req.FuncCode, notifyResult);
                //业务处理成功后更改 响应码:RspCode 为成功 "000000"
                parmaKeyDict.Set("RspCode", notifyResult.RspStatus.Code);
                parmaKeyDict.Set("RspMsg", notifyResult.RspStatus.Msg);
                result = string.Join(GlobalData.XMLHeadTemplate, "");
            }
            return result;
        }
        #endregion
    }
}
