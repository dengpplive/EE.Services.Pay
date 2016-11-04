using EE.Services.Pay.Common;
using EE.Services.Pay.Model.Req;
using System;
using System.Text;

namespace EE.Services.Pay.InertnetVer
{
    /// <summary>
    /// 构建各个接口的请求报文体  [平安银行B2B现货接口文档V1.4]
    /// </summary>
    public class BuildMessageReqBody
    {
        #region 签到/签退【1330】
        /// <summary>
        /// 签到、签退【1330】
        /// 签到后，受理平台发起的出入金，签退后，不受理任何出入金请求。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1330(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1330
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1330;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1330>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
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
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1301
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1301;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1301>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        /// <summary>
        /// 会员注册签约易宝【1343】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1343(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1343
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1343;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1343>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        /// <summary>
        /// 会员注册签约易宝-回填验证【1344】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1344(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1344
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1344;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1344>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
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
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1315
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1315;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1315>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
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
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1310
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1310;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1310>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 入金（交易网发起）【1316】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1316(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1316
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1316;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1316>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 出金（银行发起）【1312】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1312(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1312
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1312;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1312>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 出金（交易网发起）【1318】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1318(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1318
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1318;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1318>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        /// <summary>
        /// 跨行出金（交易网发起）【1313】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1313(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1313
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1313;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1313>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        #endregion

        #region 查询类接口
        /// <summary>
        /// 查银行端会员资金台帐余额【1010】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1010(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1010
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1010;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1010>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 监管账户信息查询【1021】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1021(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1021
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1021;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1021>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        /// <summary>
        /// 查时间段会员开销户信息【1016】
        /// 查询某个时间段会员签解约的信息。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1016(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1016
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1016;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1016>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        /// <summary>
        /// 查会员出入金账号的银行余额【1020】
        /// 查询会员绑定账号的余额，方便会员在平台查询确认自己有多少钱可以进行入金
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1020(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1020
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1020;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1020>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 查询时间段会员交易流水信息【1324】
        /// 查询时间段交易流水，可以提供平台进行每日对账使用。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1324(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1324
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1324;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1324>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 查询时间段会员出入金流水信息【1325】
        /// 查询时间段出入金流水，可以提供平台进行每日对账使用。
        ///若交易网流水号为空，则返回全部，此时返回的都是成功的记录。
        ///若交易网流水号不为空，则查询单笔交易，此时返回该笔交易的任何状态。在进行单笔查询时，若返回ERR020，则说明银行无此记录。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1325(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1324
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1324;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1324>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 查询支付指令状态【1327】
        /// 用于查询【1327】接口提交的申请支付的指令状态。
        /// 4：处理中是中间状态，若支付最终成功则变为2：已复核，若最终失败则为1：待复核。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1327(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1327
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1327;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1327>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        /// <summary>
        /// 查询子账户间支付的指令结果【1333】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1333(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1333
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1333;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1333>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        /// <summary>
        /// 根据订单号查询会员交易流水结果【1342】（郑大专用）
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1342(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1342
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1342;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1342>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        /// <summary>
        /// 查询子账户间支付的指令结果【1348】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1348(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1348
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1348;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1348>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        /// <summary>
        /// 查询对账文件密码【1349】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1349(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1349
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1349;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1349>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        #endregion

        #region 会员交易接口
        /// <summary>
        ///会员在途充值【1350】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1350(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1350
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1350;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1350>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        /// <summary>
        ///子账户间划转【1028】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1028(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1028
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1028;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1028>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        /// <summary>
        /// 子账户复核支付【1328】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1328(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1328
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1328;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1328>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 银行复核通知【1326】
        /// 在发送【1328】申请支付后，银行受理成功后，会在银行界面显示让客户进行复核，客户复核后，银行将复核通知平台，平台返回成功，则银行执行支付指令，反之平台返回失败，指令保持原样不执行，客户依旧可以在银行重新点击确认。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1326(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1326
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1326;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1326>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 平台操作支付【1331】
        /// 1、代理复核：
        //        发起【1328】复核支付后，若超过一定天数（该天数需告知银行进行参数维护），客户未进行复核，平台可调用该接口代理会员进行复核支付。支付金额和支付手续费与【1328】上送的一致。
        //  2、强制支付：
        //  发起【1328】复核支付后，若因违约纠纷或其它原因，需支付部分【1328】接口所冻结的金额到卖方或平台，则调用该接口，其中支付金额是需支付给卖方的金额（不超过【1328】所冻结的支付金额的一定比例，这个比例需告知银行进行参数维护），支付手续费是需支付给平台的金额，除去支付的部分，剩下的解冻退回会员，结束该笔支付指令。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1331(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1331
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1331;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1331>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 子账户直接支付【1329】
        /// 会员A直接支付给会员B。钱从会员A的子账户支付到会员B的银行卡。
        /// 可用支付：即从会员A子账户的可用余额里扣减，用来支付给B的银行卡。
        ///冻结支付：即从会员A子账户的冻结余额里扣减，用来支付给B的银行卡，方便平台先冻结会员资金，然后再进行支付。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1329(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1329
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1329;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1329>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 子账户间支付【1332】
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1332(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1332
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1332;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1332>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 子账户冻结解冻【1029】
        /// 冻结：将会员子账户的可用资金冻结，即会员子账户金额从可用金额变为冻结金额。
        /// 解冻：将会员子账户的已冻结资金解冻，即会员子账户金额从冻结金额变为可用金额。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1029(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1029
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1029;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1029>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 平台收费与退费【1030】
        /// 平台向会员收费退费接口。
        /// 收费：减少会员子账户可用余额，增加平台手续费子账户可用余额。
        /// 退费：减少平台手续费子账户可用余额，增加会员子账户可用余额。
        /// 冻结收费：从会员已冻结金额中收费，方便市场先冻结客户金额，然后再收费。
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1030(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1030
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1030;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1030>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }

        /// <summary>
        /// 平台支付与收取【1031】
        /// 平台与会员间结算。
        /// 会员支付到市场：减少会员子账户可用余额，增加市场的清收子账户可用余额，即平台收取会员的可用资金。
        /// 市场支付到会员：减少市场清收子账户可用余额，增加会员子账户可用余额。
        /// 会员冻结支付到市场：减少会员子账户冻结余额，增加市场的清收子账户可用余额，即平台收取会员的已冻结资金
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_1031(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && parmaKeyDict.Get("Model") is Req_1031
                )
            {
                var model = parmaKeyDict.Get("Model") as Req_1031;
                if (model != null)
                {
                    string result = Utils.JoinModelString<Req_1031>(model);
                    sbXml.Append(result);
                }
            }
            return sbXml.ToString();
        }
        #endregion





        #region 第三章 普通查询转账接口设计
        /// <summary>
        /// 系统状态探测 [S001]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_S001(ExHashTable parmaKeyDict)
        {
            return string.Format(GlobalData.XMLHeadTemplate, "");
        }
        /// <summary>
        /// 企业账户余额查询
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4001(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4001))
            {
                Req_4001 model = (Req_4001)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4001>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 企业当日交易明细查询[4002]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4002(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4002))
            {
                Req_4002 model = (Req_4002)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4002>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 3.15 企业当日交易详情查询[4008]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4008(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4008))
            {
                Req_4008 model = (Req_4008)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4008>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 企业单笔资金划转
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4004(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4004))
            {
                Req_4004 model = (Req_4004)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4004>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 单笔提交转汇总批量[400401]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_400401(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_400401))
            {
                Req_400401 model = (Req_400401)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_400401>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 企业批量实时资金划转[4014]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4014(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4014))
            {
                Req_4014 model = (Req_4014)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4014>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 企业大批量资金划转[4018]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4018(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4018))
            {
                Req_4018 model = (Req_4018)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4018>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        ///  企业汇总资金划转[4034]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4034(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4034))
            {
                Req_4034 model = (Req_4034)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4034>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 单笔转账指令查询[4005]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4005(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4005))
            {
                Req_4005 model = (Req_4005)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4005>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 企业交易明细详细信息查询[4006]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4006(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4006))
            {
                Req_4006 model = (Req_4006)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4006>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        ///  批量转账指令查询[4015]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4015(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4015))
            {
                Req_4015 model = (Req_4015)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4015>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 历史余额查询[4012]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4012(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4012))
            {
                Req_4012 model = (Req_4012)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4012>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 查询账户当日历史交易明细[4013]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4013(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4013))
            {
                Req_4013 model = (Req_4013)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4013>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 代理行支付当日交易查询[4011]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4011(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4011))
            {
                Req_4011 model = (Req_4011)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4011>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        ///贷款户明细查询[4016]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4016(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4016))
            {
                Req_4016 model = (Req_4016)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4016>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 银行联行号查询[4017]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4017(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4017))
            {
                Req_4017 model = (Req_4017)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4017>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 离岸账户转账[4020]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4020(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4020))
            {
                Req_4020 model = (Req_4020)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4020>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 支付指令退票查询[4019]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4019(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4019))
            {
                Req_4019 model = (Req_4019)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4019>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 代发代扣申请接口[4047]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4047(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4047))
            {
                Req_4047 model = (Req_4047)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4047>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 代发代扣结果查询接口[4048]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4048(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4048))
            {
                Req_4048 model = (Req_4048)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4048>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 银证转账[4009]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4009(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4009))
            {
                Req_4009 model = (Req_4009)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4009>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 查询券商端资金台帐余额[4010]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4010(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4010))
            {
                Req_4010 model = (Req_4010)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4010>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 汇总批量付款电子回单查询[401802]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_401802(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_401802))
            {
                Req_401802 model = (Req_401802)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_401802>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 混合批量转账接口[4027]      
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4027(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4027))
            {
                Req_4027 model = (Req_4027)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4027>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 借记卡客户信息验证接口[400101]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_400101(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_400101))
            {
                Req_400101 model = (Req_400101)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_400101>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        #endregion

        #region 第四章 直连交易明细下载
        /// <summary>
        /// 明细报表查询接口[F001]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_F001(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_F001))
            {
                Req_F001 model = (Req_F001)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_F001>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 4.2 明细报表生成通知接口F002
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_F002(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
               && (parmaKeyDict.Get("Model") is Req_F002))
            {
                Req_F002 model = (Req_F002)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_F002>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        #endregion

        #region 第五章 现金管理接口设计
        /// <summary>
        /// 定期账户信息查询[4021]       
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4021(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
               && (parmaKeyDict.Get("Model") is Req_4021))
            {
                Req_4021 model = (Req_4021)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4021>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 查询定活通存单信息[4025]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4025(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
               && (parmaKeyDict.Get("Model") is Req_4025))
            {
                Req_4025 model = (Req_4025)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4025>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 集团内账户预结息/结息 (4054)
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4054(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
               && (parmaKeyDict.Get("Model") is Req_4054))
            {
                Req_4054 model = (Req_4054)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4054>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 5.2.2 现金管理虚帐户合约建立/修改/删除(4058)
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4058(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4058))
            {
                Req_4058 model = (Req_4058)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4058>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 集团内手工归集下拨[4052]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4052(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4052))
            {
                Req_4052 model = (Req_4052)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4052>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 集团内虚拟子账户余额调整[4057] 
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4057(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4057))
            {
                Req_4057 model = (Req_4057)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4057>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 5.4.1 集团总账户查询[4022]     
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4022(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4022))
            {
                Req_4022 model = (Req_4022)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4022>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 5.4.2 集团子账户列表查询 [4023]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4023(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4023))
            {
                Req_4023 model = (Req_4023)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4023>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 5.4.3 现金管理合约查询[4055]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4055(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4055))
            {
                Req_4055 model = (Req_4055)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4055>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 台账记录查询[4024]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4024(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
               && (parmaKeyDict.Get("Model") is Req_4024))
            {
                Req_4024 model = (Req_4024)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4024>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 结息查询[4056]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4056(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4056))
            {
                Req_4056 model = (Req_4056)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4056>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 5.4.6 现金管理子账户余额查询[4059]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_4059(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_4059))
            {
                Req_4059 model = (Req_4059)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_4059>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        #endregion


        #region 第六章 票据接口设计
        public string BuildString_DP00(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        #endregion

        #region 第七章 供应链接口
        public string BuildString_SC00(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        #endregion




        #region 银企直连跨行快付接口
        /// <summary>
        /// 3.1 批量付款文件提交 [KHKF01]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_KHKF01(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_KHKF01))
            {
                Req_KHKF01 model = (Req_KHKF01)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_KHKF01>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 3.2 批量付款结果查询[KHKF02]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_KHKF02(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_KHKF02))
            {
                Req_KHKF02 model = (Req_KHKF02)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_KHKF02>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 3.3 单笔付款申请[KHKF03]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_KHKF03(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_KHKF03))
            {
                Req_KHKF03 model = (Req_KHKF03)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_KHKF03>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 3.4 单笔付款结果查询[KHKF04]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_KHKF04(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_KHKF04))
            {
                Req_KHKF04 model = (Req_KHKF04)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_KHKF04>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 3.5 对账/差错文件查询[KHKF05]
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_KHKF05(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
                && (parmaKeyDict.Get("Model") is Req_KHKF05))
            {
                Req_KHKF05 model = (Req_KHKF05)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_KHKF05>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        #endregion





        #region 文件传输
        /// <summary>
        /// 文件上传接口
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_FILE01(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
               && (parmaKeyDict.Get("Model") is Req_FILE01))
            {
                Req_FILE01 model = (Req_FILE01)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_FILE01>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// FILE02文件上传和下载进度查询
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_FILE02(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("TradeSn"))
            {
                string TradeSn = (string)parmaKeyDict.Get("TradeSn");
                sbXml.AppendFormat("<TradeSn>{0}</TradeSn>", TradeSn);
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// 5.3.4 FILE03文件下载
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_FILE03(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
               && (parmaKeyDict.Get("Model") is Req_FILE03))
            {
                Req_FILE03 model = (Req_FILE03)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_FILE03>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        /// <summary>
        /// FILE04通知客户ERP文件上传、下载结果
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        public string BuildString_FILE04(ExHashTable parmaKeyDict)
        {
            StringBuilder sbXml = new StringBuilder();
            if (parmaKeyDict.Contains("Model")
               && (parmaKeyDict.Get("Model") is Req_FILE04))
            {
                Req_FILE04 model = (Req_FILE04)parmaKeyDict.Get("Model");
                if (model != null)
                {
                    var strXml = Utils.ModelToXMLNode<Req_FILE04>(model);
                    sbXml.Append(strXml);
                }
            }
            return string.Format(GlobalData.XMLHeadTemplate, sbXml.ToString());
        }
        #endregion

    }
}
