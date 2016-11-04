using EE.Services.Pay.InertnetVer;
using EE.Services.Pay.Model;
using EE.Services.Pay.Common;
using EE.Services.Pay.Model.Req;
using EE.Services.Pay.InertnetVer.HttpNotify;
using EE.Services.Pay.DataAccess;
namespace EE.Services.PayTestDemo
{
    /// <summary>
    /// 处理通知数据 须在要处理的类上添加特性[RecvCode]并且实现接口INotifyHandler
    /// </summary>
    [RecvCode]
    public class PayNotifyProcess : INotifyHandler
    {
        public void Process(string funcCode, NotifyResult notifyResult)
        {
            //通讯信息
            var recvResult = notifyResult.DataResult;
            switch (funcCode)
            {
                case "1301":
                    {
                        //接收业务数据
                        Req_1301 req_1301 = notifyResult.ReqData as Req_1301;
                        //处理业务                       
                        //MemberInfoDataAccess.AddOrUpdateMemberInfo(req_1301);

                        //构造返回结果
                        string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
                        notifyResult.RspData.ThirdLogNo = serialNumber;
                        notifyResult.RspData.Reserve = "1301";

                        notifyResult.RspStatus.Code = "000000";
                        notifyResult.RspStatus.Msg = "交易成功";
                    }
                    break;
                case "1315"://出入金账户维护【1315】
                    {
                        Req_1315 req_1315 = notifyResult.ReqData as Req_1315;
                        //处理业务
                        //记录签约后返回来的子账户和出入金账号 后续用到
                        //MemberInfoDataAccess.AddOrUpdateMemberInfo(req_1315);
                        //构造返回结果
                        string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
                        notifyResult.RspData.ThirdLogNo = serialNumber;
                        notifyResult.RspData.Reserve = "1315";

                        notifyResult.RspStatus.Code = "000000";
                        notifyResult.RspStatus.Msg = "交易成功";

                    }
                    break;
                case "1303"://会员签解约维护【1303】
                    {
                        //接收业务数据
                        Req_1303 req_1303 = notifyResult.ReqData as Req_1303;
                        //处理业务                       
                        //MemberInfoDataAccess.AddOrUpdateMemberInfo(req_1303);

                        //构造返回结果
                        string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
                        notifyResult.RspData.ThirdLogNo = serialNumber;
                        notifyResult.RspData.Reserve = "1303";
                        notifyResult.RspStatus.Code = "000000";
                        notifyResult.RspStatus.Msg = "交易成功";
                    }
                    break;
                case "1310"://入金（银行发起）【1310】
                    {
                        Req_1310 req_1310 = notifyResult.ReqData as Req_1310;
                        //处理业务                        
                        //....

                        //构造返回结果
                        string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
                        notifyResult.RspData.ThirdLogNo = serialNumber;
                        notifyResult.RspData.Reserve = "1310";

                        notifyResult.RspStatus.Code = "000000";
                        notifyResult.RspStatus.Msg = "交易成功";
                    }
                    break;
                case "1312"://出金（银行发起）【1312】
                    {
                        Req_1312 req_1312 = notifyResult.ReqData as Req_1312;
                        //处理业务                        
                        //....

                        //构造返回结果
                        string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
                        notifyResult.RspData.ThirdLogNo = serialNumber;
                        notifyResult.RspData.Reserve = "1312";

                        notifyResult.RspStatus.Code = "000000";
                        notifyResult.RspStatus.Msg = "交易成功";
                    }
                    break;
                case "1019"://查交易网端会员管理账户余额
                    {
                        Req_1019 req_1019 = notifyResult.ReqData as Req_1019;
                        //处理业务                        
                        //....

                        //构造返回结果
                        string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
                        notifyResult.RspData.ThirdLogNo = serialNumber;
                        notifyResult.RspData.Reserve = "1019";

                        notifyResult.RspStatus.Code = "000000";
                        notifyResult.RspStatus.Msg = "交易成功";
                    }
                    break;
                case "1326"://银行复核通知
                    {
                        Req_1326 req_1326 = notifyResult.ReqData as Req_1326;
                        //处理业务                        
                        //....

                        //构造返回结果
                        string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
                        notifyResult.RspData.ThirdLogNo = serialNumber;
                        notifyResult.RspData.Reserve = "1326";

                        notifyResult.RspStatus.Code = "000000";
                        notifyResult.RspStatus.Msg = "交易成功";
                    }
                    break;
                case "FILE04"://ERP文件上传、下载结果通知
                    {
                        Req_FILE04 req_FILE04 = notifyResult.ReqData as Req_FILE04;
                        //处理业务 跨行快付的业务
                        //....
                        notifyResult.RspStatus.Code = "000000";
                        notifyResult.RspStatus.Msg = "交易成功";
                    }
                    break;
                case "F002"://银行通知 明细报表生成通知接口
                    {
                        Req_F002 req_F002 = notifyResult.ReqData as Req_F002;
                        //记录日志

                        notifyResult.RspStatus.Code = "000000";
                        notifyResult.RspStatus.Msg = "交易成功";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
