using EE.Services.Pay.Model.Req;
using EE.Services.Pay.Model.Res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace EE.Services.Pay.Common.Ext
{
    public static class Extender
    {
        /// <summary>
        /// 枚举类型扩展ForEach方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
        /// <summary>
        /// 获取枚举的Description值
        /// </summary>
        /// <param name="source">枚举对象</param>
        /// <returns>枚举描述</returns>
        public static string ToDesc(this Enum source)
        {
            if (source == null) throw new ArgumentException("source");
            var type = source.GetType();
            if (Enum.IsDefined(type, source))
            {
                var field = type.GetField(Enum.GetName(type, source));
                if (field != null)
                {
                    if (Attribute.IsDefined(field, typeof(DescriptionAttribute)))
                    {
                        var descriptionAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }
            return source.ToString();
        }
        /// <summary>
        ///获取枚举的整数值
        /// </summary>
        /// <param name="source">枚举值</param>
        /// <param name="len">指定的字符串长度 不足左侧补0</param>
        /// <returns></returns>
        public static string ToVal(this Enum source, int len = 0)
        {
            if (source == null) throw new ArgumentException("source");
            var obj = Convert.ChangeType(source, source.GetType());
            string str = ((int)obj).ToString();
            if (str.Length < len)
            {
                str = str.PadLeft(len, '0');
            }
            return str;
        }
        /// <summary>
        /// URL解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlDecode(this string str)
        {

            return HttpUtility.UrlDecode(str);
        }
        /// <summary>
        /// URL加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }
        /// <summary>
        /// URL路径加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlPathEncode(this string str)
        {
            return HttpUtility.UrlPathEncode(str);
        }

        /// <summary>
        /// 转换成32位带符号整数
        /// </summary>
        /// <param name="value">待转换的字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>转换失败时，返回默认值；成功时，返回正常值</returns>
        public static int ToInt(this string value, int defaultValue)
        {
            var result = ToNullableInt(value);
            return result ?? defaultValue;
        }
        /// <summary>
        /// 转换成可空32位带符号整数
        /// </summary>
        /// <param name="value">待转换的字符串</param>
        public static int? ToNullableInt(this string value)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            return null;
        }

        /// <summary>
        /// 字符串结尾是数字 截取后几位自增 返回自增后的字符串
        /// </summary>
        /// <param name="value">源字符串</param>
        /// <param name="suffixLen">取后几位数字</param>
        /// <returns></returns>
        public static string Increment(this string value, int suffixLen)
        {
            if (value.Length > suffixLen)
            {
                string prex = value.Substring(0, value.Length - suffixLen);
                string suffix = value.Substring(value.Length - suffixLen);
                int ival = suffix.ToInt(0);
                value = prex + (++ival).ToString();
            }
            return value;
        }
        /// <summary>
        /// 字符串结尾是数字默认2位  截取后2位自增 返回自增后的字符串
        /// </summary>
        /// <param name="value">源字符串</param>
        /// <returns></returns>
        public static string Increment(this string value)
        {
            if (value.Length > 2)
            {
                string prex = value.Substring(0, value.Length - 2);
                string suffix = value.Substring(value.Length - 2);
                int ival = suffix.ToInt(0);
                value = prex + (++ival).ToString();
            }
            return value;
        }

        /// <summary>
        /// 获取集合对象的字符串形式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string InnerXml(this List<DynamicXml> list)
        {
            StringBuilder sbxml = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                dynamic d = list[i];
                sbxml.Append(d.InnerXml);
            }
            return sbxml.ToString();
        }

        #region 银企直连接口的结果转换
        /// <summary>
        /// 转化为交易码为4001的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4001 To_4001(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4001 = new Res_4001();
            if (dynamicXml != null)
            {
                res_4001.Account = d.Account.Value;
                res_4001.CcyCode = d.CcyCode.Value;
                res_4001.CcyType = d.CcyType.Value;
                res_4001.AccountName = d.AccountName.Value;
                res_4001.Balance = d.Balance.Value;
                res_4001.TotalAmount = d.TotalAmount.Value;
            }
            return res_4001;
        }

        /// <summary>
        /// 转化为交易码为400101的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_400101 To_400101(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_400101 = new Res_400101();
            if (dynamicXml != null)
            {
                res_400101.Flag = d.Flag.Value;
                res_400101.Desc = d.Desc.Value;
            }
            return res_400101;
        }
        /// <summary>
        ///  转化为交易码为4004的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4004 To_4004(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4004 = new Res_4004();
            if (dynamicXml != null)
            {
                res_4004.ThirdVoucher = d.ThirdVoucher.Value;
                res_4004.FrontLogNo = d.FrontLogNo.Value;
                res_4004.CstInnerFlowNo = d.CstInnerFlowNo.Value;
                res_4004.CcyCode = d.CcyCode.Value;
                res_4004.OutAcctName = d.OutAcctName.Value;
                res_4004.OutAcctNo = d.OutAcctNo.Value;
                res_4004.InAcctBankName = d.InAcctBankName.Value;
                res_4004.InAcctNo = d.InAcctNo.Value;
                res_4004.InAcctName = d.InAcctName.Value;
                res_4004.TranAmount = d.TranAmount.Value;
                res_4004.UnionFlag = d.UnionFlag.Value;
                res_4004.Fee1 = d.Fee1.Value;
                res_4004.Fee2 = d.Fee2.Value;
                res_4004.SOA_VOUCHER = d.SOA_VOUCHER.Value;
                res_4004.hostFlowNo = d.hostFlowNo.Value;
                res_4004.Mobile = d.Mobile.Value;
            }
            return res_4004;
        }
        /// <summary>
        ///  转化为交易码为400401的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_400401 To_400401(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_400401 = new Res_400401();
            if (dynamicXml != null)
            {
                res_400401.ThirdVoucher = d.ThirdVoucher.Value;
                res_400401.FrontLogNo = d.FrontLogNo.Value;
                res_400401.CstInnerFlowNo = d.CstInnerFlowNo.Value;
                res_400401.CcyCode = d.CcyCode.Value;
                res_400401.OutAcctName = d.OutAcctName.Value;
                res_400401.OutAcctNo = d.OutAcctNo.Value;
                res_400401.InAcctBankName = d.InAcctBankName.Value;
                res_400401.InAcctNo = d.InAcctNo.Value;
                res_400401.InAcctName = d.InAcctName.Value;
                res_400401.TranAmount = d.TranAmount.Value;
                res_400401.UnionFlag = d.UnionFlag.Value;
            }
            return res_400401;
        }
        /// <summary>
        /// 转化为交易码为4018的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4018 To_4018(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4018 = new Res_4018();
            if (dynamicXml != null)
            {
                res_4018.ThirdVoucher = d.ThirdVoucher.Value;
            }
            return res_4018;
        }
        /// <summary>
        /// 转化为交易码为4018的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4005 To_4005(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4005 = new Res_4005();
            if (dynamicXml != null)
            {
                res_4005.OrigThirdVoucher = d.OrigThirdVoucher.Value;
                res_4005.FrontLogNo = d.FrontLogNo.Value;
                res_4005.CstInnerFlowNo = d.CstInnerFlowNo.Value;
                res_4005.CcyCode = d.CcyCode.Value;
                res_4005.OutAcctBankName = d.OutAcctBankName.Value;
                res_4005.OutAcctNo = d.OutAcctNo.Value;
                res_4005.InAcctBankName = d.InAcctBankName.Value;
                res_4005.InAcctNo = d.InAcctNo.Value;

                res_4005.InAcctName = d.InAcctName.Value;
                res_4005.TranAmount = d.TranAmount.Value;
                res_4005.UnionFlag = d.UnionFlag.Value;
                res_4005.Stt = d.Stt.Value;
                res_4005.IsBack = d.IsBack.Value;
                res_4005.BackRem = d.BackRem.Value;
                res_4005.Yhcljg = d.Yhcljg.Value;
                res_4005.SysFlag = d.SysFlag.Value;
                res_4005.Fee = d.Fee.Value;
                res_4005.TransBsn = d.TransBsn.Value;
                res_4005.submitTime = d.submitTime.Value;

                res_4005.AccountDate = d.AccountDate.Value;
                res_4005.hostFlowNo = d.hostFlowNo.Value;
                res_4005.hostErrorCode = d.hostErrorCode.Value;
                res_4005.ProxyPayName = d.ProxyPayName.Value;
                res_4005.ProxyPayAcc = d.ProxyPayAcc.Value;
                res_4005.ProxyPayBankName = d.ProxyPayBankName.Value;
            }
            return res_4005;
        }
        /// <summary>
        /// 转化为交易码为4006的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4006 To_4006(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4006 = new Res_4006();
            if (dynamicXml != null)
            {
                res_4006.PreHostCode = d.PreHostCode.Value;
                res_4006.BusinessType = d.BusinessType.Value;
                res_4006.PreNo = d.PreNo.Value;
                res_4006.CcyCode = d.CcyCode.Value;
                res_4006.TranDate1 = d.TranDate1.Value;
                res_4006.TranTime1 = d.TranTime1.Value;
                res_4006.Node = d.Node.Value;
                res_4006.SendName = d.SendName.Value;
                res_4006.SendBank = d.SendBank.Value;
                res_4006.SendAccount = d.SendAccount.Value;
                res_4006.AcctName = d.AcctName.Value;
                res_4006.AcctBank = d.AcctBank.Value;
                res_4006.AcctAccount = d.AcctAccount.Value;
                res_4006.TranAmount = d.TranAmount.Value;
                res_4006.CcyCode = d.CcyCode.Value;
                res_4006.Fee1 = d.Fee1.Value;
                res_4006.Fee2 = d.Fee2.Value;
                res_4006.Notes = d.Notes.Value;
                res_4006.Notes1 = d.Notes1.Value;
            }
            return res_4006;
        }

        /// <summary>
        /// 转化为交易码为4015的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4015 To_4015(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4015 = new Res_4015();
            if (dynamicXml != null)
            {
                res_4015.successCts = d.successCts.Value;
                res_4015.successAmt = d.successAmt.Value;
                res_4015.faildCts = d.faildCts.Value;
                res_4015.faildAmt = d.faildAmt.Value;
                res_4015.processCts = d.processCts.Value;
                res_4015.processAmt = d.processAmt.Value;
                res_4015.TotalCts = d.TotalCts.Value;
                res_4015.CTotalCts = d.CTotalCts.Value;
                res_4015.PTotalCts = d.PTotalCts.Value;
                res_4015.IsEnd = d.IsEnd.Value;
                res_4015.batchSTT = d.batchSTT.Value;
                res_4015.subBatchSTT = d.subBatchSTT.Value;

                Action<dynamic> act = item =>
                {
                    var result_4015 = new Result_4015();
                    res_4015.list.Add(result_4015);

                    result_4015.FrontLogNo = item.FrontLogNo.Value;
                    result_4015.SThirdVoucher = item.SThirdVoucher.Value;
                    result_4015.CstInnerFlowNo = item.CstInnerFlowNo.Value;
                    result_4015.CcyCode = item.CcyCode.Value;
                    result_4015.OutAcctBankName = item.OutAcctBankName.Value;


                    result_4015.OutAcctNo = item.OutAcctNo.Value;
                    result_4015.InAcctBankName = item.InAcctBankName.Value;
                    result_4015.InAcctNo = item.InAcctNo.Value;
                    result_4015.InAcctName = item.InAcctName.Value;
                    result_4015.TranAmount = item.TranAmount.Value;
                    result_4015.UnionFlag = item.UnionFlag.Value;
                    result_4015.Stt = item.Stt.Value;
                    result_4015.IsBack = item.IsBack.Value;
                    result_4015.BackRem = item.BackRem.Value;
                    result_4015.Yhcljg = item.Yhcljg.Value;
                    result_4015.SysFlag = item.SysFlag.Value;
                    result_4015.Fee = item.Fee.Value;
                    result_4015.TransBsn = item.TransBsn.Value;
                    result_4015.submitTime = item.submitTime.Value;
                    result_4015.AccountDate = item.AccountDate.Value;

                    result_4015.hostFlowNo = item.hostFlowNo.Value;
                    result_4015.ProxyPayName = item.ProxyPayName.Value;
                    result_4015.ProxyPayAcc = item.ProxyPayAcc.Value;
                    result_4015.ProxyPayBankName = item.ProxyPayBankName.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //列表
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4015;
        }

        /// <summary>
        /// 转化为交易码为4014的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4014 To_4014(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4014 = new Res_4014();
            if (dynamicXml != null)
            {
                res_4014.ThirdVoucher = d.ThirdVoucher.Value;
                res_4014.successCts = d.successCts.Value;
                res_4014.successAmt = d.successAmt.Value;
                res_4014.faildCts = d.faildCts.Value;
                res_4014.faildAmt = d.faildAmt.Value;
                Action<dynamic> act = item =>
                {
                    var result_4014 = new Result_4014();
                    res_4014.list.Add(result_4014);

                    result_4014.stt = item.stt.Value;
                    result_4014.sttDesc = item.sttDesc.Value;
                    result_4014.SThirdVoucher = item.SThirdVoucher.Value;
                    result_4014.CstInnerFlowNo = item.CstInnerFlowNo.Value;
                    result_4014.FrontLogNo = item.FrontLogNo.Value;


                    result_4014.CcyCode = item.CcyCode.Value;
                    result_4014.OutAcctName = item.OutAcctName.Value;
                    result_4014.OutAcctNo = item.OutAcctNo.Value;
                    result_4014.InAcctBankName = item.InAcctBankName.Value;
                    result_4014.InAcctNo = item.InAcctNo.Value;
                    result_4014.InAcctName = item.InAcctName.Value;
                    result_4014.TranAmount = item.TranAmount.Value;
                    result_4014.UnionFlag = item.UnionFlag.Value;
                    result_4014.Fee1 = item.Fee1.Value;
                    result_4014.Fee2 = item.Fee2.Value;
                    result_4014.SOA_VOUCHER = item.SOA_VOUCHER.Value;
                    result_4014.hostFlowNo = item.hostFlowNo.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //列表
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4014;
        }

        /// <summary>
        /// 转化为交易码为4012的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4012 To_4012(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4012 = new Res_4012();
            if (dynamicXml != null)
            {
                res_4012.Account = d.Account.Value;
                res_4012.CcyCode = d.CcyCode.Value;
                res_4012.CcyType = d.CcyType.Value;
                res_4012.HisBalance = d.HisBalance.Value;
                res_4012.HisBookBalance = d.HisBookBalance.Value;
            }
            return res_4012;
        }

        /// <summary>
        /// 转化为交易码为4013的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4013 To_4013(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4013 = new Res_4013();
            if (dynamicXml != null)
            {
                res_4013.AcctNo = d.AcctNo.Value;
                res_4013.CcyCode = d.CcyCode.Value;
                res_4013.EndFlag = d.EndFlag.Value;
                res_4013.Reserve = d.Reserve.Value;
                res_4013.PageNo = d.PageNo.Value;
                res_4013.PageRecCount = d.PageRecCount.Value;

                Action<dynamic> act = item =>
                {
                    var result_4013 = new Result_4013();
                    res_4013.list.Add(result_4013);
                    result_4013.AcctDate = item.AcctDate.Value;
                    result_4013.TxTime = item.TxTime.Value;
                    result_4013.HostTrace = item.HostTrace.Value;
                    result_4013.OutNode = item.OutNode.Value;
                    result_4013.OutBankNo = item.OutBankNo.Value;
                    result_4013.OutBankName = item.OutBankName.Value;
                    result_4013.OutAcctNo = item.OutAcctNo.Value;
                    result_4013.OutAcctName = item.OutAcctName.Value;
                    result_4013.CcyCode = item.CcyCode.Value;
                    result_4013.TranAmount = item.TranAmount.Value;
                    result_4013.InNode = item.InNode.Value;
                    result_4013.InBankNo = item.InBankNo.Value;
                    result_4013.InBankName = item.InBankName.Value;
                    result_4013.InAcctNo = item.InAcctNo.Value;
                    result_4013.InAcctName = item.InAcctName.Value;
                    result_4013.DcFlag = item.DcFlag.Value;
                    result_4013.AbstractStr = item.AbstractStr.Value;
                    result_4013.VoucherNo = item.VoucherNo.Value;
                    result_4013.TranFee = item.TranFee.Value;
                    result_4013.PostFee = item.PostFee.Value;
                    result_4013.AcctBalance = item.AcctBalance.Value;
                    result_4013.Purpose = item.Purpose.Value;
                    result_4013.CVoucherNo = item.CVoucherNo.Value;
                    result_4013.AbstractStr_Desc = item.AbstractStr_Desc.Value;
                    result_4013.ProxyPayName = item.ProxyPayName.Value;
                    result_4013.ProxyPayAcc = item.ProxyPayAcc.Value;
                    result_4013.ProxyPayBankName = item.ProxyPayBankName.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //多条
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4013;
        }

        /// <summary>
        /// 转化为交易码为4011的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4011 To_4011(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4011 = new Res_4011();
            if (dynamicXml != null)
            {
                res_4011.AcctNo = d.AcctNo.Value;
                res_4011.CcyCode = d.CcyCode.Value;
                res_4011.TranDate = d.TranDate.Value;
                res_4011.EndFlag = d.EndFlag.Value;
                res_4011.PageRecCount = d.PageRecCount.Value;
                res_4011.JournalNo = d.JournalNo.Value;
                res_4011.LogCount = d.LogCount.Value;
                Action<dynamic> act = item =>
                {
                    var result_4011 = new Result_4011();
                    res_4011.list.Add(result_4011);

                    result_4011.TranTime1 = item.TranTime1.Value;
                    result_4011.SummonNo = item.SummonNo.Value;
                    result_4011.SendBank = item.SendBank.Value;
                    result_4011.SendAccount = item.SendAccount.Value;
                    result_4011.SendName = item.SendName.Value;
                    result_4011.TxAmount = item.TxAmount.Value;
                    result_4011.AcctBank = item.AcctBank.Value;
                    result_4011.AcctAccount = item.AcctAccount.Value;
                    result_4011.AcctName = item.AcctName.Value;
                    result_4011.TxType = item.TxType.Value;
                    result_4011.AbstractStr = item.AbstractStr.Value;
                    result_4011.Notes = item.Notes.Value;
                    result_4011.Fee1 = item.Fee1.Value;
                    result_4011.Fee2 = item.Fee2.Value;
                    result_4011.AbstractStr_Desc = item.AbstractStr_Desc.Value;
                    result_4011.CVoucherNo = item.CVoucherNo.Value;
                    result_4011.CstInnerFlowNo = item.CstInnerFlowNo.Value;
                    result_4011.ProxyPayName = item.ProxyPayName.Value;
                    result_4011.ProxyPayAcc = item.ProxyPayAcc.Value;
                    result_4011.ProxyPayBankName = item.ProxyPayBankName.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4011;
        }

        /// <summary>
        /// 转化为交易码为4016的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4016 To_4016(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4016 = new Res_4016();
            if (dynamicXml != null)
            {
                res_4016.Count = d.Count.Value;
                res_4016.EndFlag = d.EndFlag.Value;
                res_4016.LastSeqNo = d.LastSeqNo.Value;
                Action<dynamic> act = item =>
                {
                    //所有的"-"替换为"_"取值
                    var result_4016 = new Result_4016();
                    res_4016.list.Add(result_4016);

                    result_4016.LOAN_NO = item.LOAN_NO.Value;
                    result_4016.LOAN_DATE = item.LOAN_DATE.Value;
                    result_4016.LOAN_DUE_DATE = item.LOAN_DUE_DATE.Value;
                    result_4016.LOAN_RATE = item.LOAN_RATE.Value;
                    result_4016.DEB_PED = item.DEB_PED.Value;
                    result_4016.DEB_UNIT = item.DEB_UNIT.Value;
                    result_4016.LOAN_AMT = item.LOAN_AMT.Value;
                    result_4016.LOAN_BAL = item.LOAN_BAL.Value;
                    result_4016.INT_RECV = item.INT_RECV.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4016;
        }
        /// <summary>
        /// 转化为交易码为4017的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4017 To_4017(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4017 = new Res_4017();
            if (dynamicXml != null)
            {
                res_4017.BankNo = d.BankNo.Value;
                res_4017.BankName = d.BankName.Value;
                res_4017.size = d.size.Value;
                Action<dynamic> act = item =>
                {
                    var result_4017 = new Result_4017();
                    res_4017.list.Add(result_4017);

                    result_4017.NodeName = item.NodeName.Value;
                    result_4017.NodeCode = item.NodeCode.Value;
                };
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4017;
        }
        /// <summary>
        /// 转化为交易码为4020的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4020 To_4020(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4020 = new Res_4020();
            if (dynamicXml != null)
            {
                res_4020.ThirdVoucher = d.ThirdVoucher.Value;
                res_4020.FrontLogNo = d.FrontLogNo.Value;
            }
            return res_4020;
        }
        /// <summary>
        /// 转化为交易码为4019的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4019 To_4019(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4019 = new Res_4019();
            if (dynamicXml != null)
            {
                res_4019.TotalCts = d.TotalCts.Value;
                res_4019.IsEnd = d.IsEnd.Value;
                res_4019.PageNo = d.PageNo.Value;
                res_4019.PageCts = d.PageCts.Value;
                Action<dynamic> act = item =>
                {
                    var result_4019 = new Result_4019();
                    res_4019.list.Add(result_4019);

                    result_4019.ThirdVoucher = item.ThirdVoucher.Value;
                    result_4019.SThirdVoucher = item.SThirdVoucher.Value;
                    result_4019.CstInnerFlowNo = item.CstInnerFlowNo.Value;
                    result_4019.TransDate = item.TransDate.Value;
                    result_4019.PayAccNo = item.PayAccNo.Value;
                    result_4019.OppAccNo = item.OppAccNo.Value;
                    result_4019.OppAccName = item.OppAccName.Value;
                    result_4019.OppBankName = item.OppBankName.Value;
                    result_4019.Amount = item.Amount.Value;
                    result_4019.CcyCode = item.CcyCode.Value;
                    result_4019.RejectDate = item.RejectDate.Value;
                    result_4019.RejectRemark = item.RejectRemark.Value;
                    result_4019.FrontLogNo = item.FrontLogNo.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4019;
        }
        /// <summary>
        /// 转化为交易码为4047的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4047 To_4047(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4047 = new Res_4047();
            if (dynamicXml != null)
            {
                res_4047.ThirdVoucher = d.ThirdVoucher.Value;
                res_4047.PayType = d.PayType.Value;
                res_4047.SrcAccNo = d.SrcAccNo.Value;
                res_4047.TotalNum = d.TotalNum.Value;
                res_4047.TotalAmount = d.TotalAmount.Value;
                Action<dynamic> act = item =>
                {
                    var result_4047 = new Result_4047();
                    res_4047.list.Add(result_4047);

                    result_4047.SThirdVoucher = item.SThirdVoucher.Value;
                    result_4047.OppAccNo = item.OppAccNo.Value;
                    result_4047.OppAccName = item.OppAccName.Value;
                    result_4047.Amount = item.Amount.Value;
                    result_4047.PostScript = item.PostScript.Value;
                    result_4047.Fee = item.Fee.Value;
                    result_4047.stt = item.stt.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4047;
        }
        /// <summary>
        /// 转化为交易码为4048的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4048 To_4048(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4048 = new Res_4048();
            if (dynamicXml != null)
            {
                res_4048.ThirdVoucher = d.ThirdVoucher.Value;
                res_4048.BStt = d.BStt.Value;
                res_4048.BusiType = d.BusiType.Value;
                res_4048.PayType = d.PayType.Value;
                res_4048.Currency = d.Currency.Value;
                res_4048.OthBankFlag = d.OthBankFlag.Value;
                res_4048.SrcAccNo = d.SrcAccNo.Value;
                res_4048.TotalNum = d.TotalNum.Value;
                res_4048.TotalAmount = d.TotalAmount.Value;
                res_4048.SettleType = d.SettleType.Value;
                Action<dynamic> act = item =>
                {
                    var result_4048 = new Result_4048();
                    res_4048.list.Add(result_4048);

                    result_4048.SThirdVoucher = item.SThirdVoucher.Value;
                    result_4048.CstInnerFlowNo = item.CstInnerFlowNo.Value;
                    result_4048.IdType = item.IdType.Value;
                    result_4048.IdNo = item.IdNo.Value;
                    result_4048.OppAccNo = item.OppAccNo.Value;
                    result_4048.OppAccName = item.OppAccName.Value;
                    result_4048.Amount = item.Amount.Value;
                    result_4048.PostScript = item.PostScript.Value;
                    result_4048.Fee = item.Fee.Value;
                    result_4048.stt = item.stt.Value;
                    result_4048.sttInfo = item.sttInfo.Value;
                    result_4048.RemarkFCR = item.RemarkFCR.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4048;
        }

        /// <summary>
        /// 转化为交易码为4009的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4009 To_4009(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4009 = new Res_4009();
            if (dynamicXml != null)
            {
                res_4009.ThirdVoucher = d.ThirdVoucher.Value;
                res_4009.FrontLogNo = d.FrontLogNo.Value;
                res_4009.CstInnerFlowNo = d.CstInnerFlowNo.Value;
                res_4009.CcyCode = d.CcyCode.Value;
                res_4009.OpFlag = d.OpFlag.Value;
                res_4009.AcctNo = d.AcctNo.Value;
                res_4009.StockNo = d.StockNo.Value;
                res_4009.TranAmount = d.TranAmount.Value;
            }
            return res_4009;
        }
        /// <summary>
        /// 转化为交易码为4010的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4010 To_4010(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4010 = new Res_4010();
            if (dynamicXml != null)
            {
                res_4010.InvName = d.InvName.Value;
                res_4010.CapAcct = d.CapAcct.Value;
                res_4010.RMBCurBal = d.RMBCurBal.Value;
                res_4010.RMBAvailBal = d.RMBAvailBal.Value;
                res_4010.RMBTruBal = d.RMBTruBal.Value;
                res_4010.USDCurBal = d.USDCurBal.Value;
                res_4010.USDAvailBal = d.USDAvailBal.Value;
                res_4010.USDTruBal = d.USDTruBal.Value;
                res_4010.HKDCurBal = d.HKDCurBal.Value;
                res_4010.HKDAvailBal = d.HKDAvailBal.Value;
                res_4010.HKDTruBal = d.HKDTruBal.Value;
            }
            return res_4010;
        }
        /// <summary>
        /// 转化为交易码为401802的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_401802 To_401802(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_401802 = new Res_401802();
            if (dynamicXml != null)
            {
                res_401802.ThirdVoucher = d.ThirdVoucher.Value;
                res_401802.SThirdVoucher = d.SThirdVoucher.Value;
                res_401802.OutAcctNo = d.OutAcctNo.Value;
                res_401802.InAcctNo = d.InAcctNo.Value;
                res_401802.InAcctName = d.InAcctName.Value;
                res_401802.TranAmount = d.TranAmount.Value;
                res_401802.CheckNo = d.CheckNo.Value;
                res_401802.CheckCode = d.CheckCode.Value;
            }
            return res_401802;
        }
        /// <summary>
        /// 转化为交易码为4027的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4027 To_4027(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4027 = new Res_4027();
            if (dynamicXml != null)
            {
                res_4027.ThirdVoucher = d.ThirdVoucher.Value;
            }
            return res_4027;
        }


        /// <summary>
        /// 转化为交易码为F001的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_F001 To_F001(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_F001 = new Res_F001();
            if (dynamicXml != null)
            {
                res_F001.FileName = d.FileName.Value;
                res_F001.FilePath = d.FilePath.Value;
                res_F001.RandomPwd = d.RandomPwd.Value;
                res_F001.SignData = d.SignData.Value;
                res_F001.HashData = d.HashData.Value;
            }
            return res_F001;
        }
        /// <summary>
        /// 转化为交易码为F002的请求
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Req_F002 To_F002(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var req_F002 = new Req_F002();
            if (dynamicXml != null)
            {
                req_F002.FileName = d.FileName.Value;
                req_F002.FilePath = d.FilePath.Value;
                req_F002.RandomPwd = d.RandomPwd.Value;
                req_F002.SignData = d.SignData.Value;
                req_F002.HashData = d.HashData.Value;
            }
            return req_F002;
        }
        /// <summary>
        /// 转化为交易码为4021的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4021 To_4021(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4021 = new Res_4021();
            if (dynamicXml != null)
            {
                res_4021.AcctNo = d.AcctNo.Value;
                res_4021.TotalCount = d.TotalCount.Value;
                res_4021.PageRecCount = d.PageRecCount.Value;
                Action<dynamic> act = item =>
                {
                    var result_4021 = new Result_4021();
                    res_4021.list.Add(result_4021);

                    result_4021.SeqNo = item.SeqNo.Value;
                    result_4021.DepositType = item.DepositType.Value;
                    result_4021.DepositTypeDesc = item.DepositTypeDesc.Value;
                    result_4021.CcyCode = item.CcyCode.Value;
                    result_4021.CcyType = item.CcyType.Value;
                    result_4021.Amount = item.Amount.Value;
                    result_4021.Rate = item.Rate.Value;
                    result_4021.ValueDate = item.ValueDate.Value;
                    result_4021.Period = item.Period.Value;
                    result_4021.PeriodDesc = item.PeriodDesc.Value;
                    result_4021.DueDate = item.DueDate.Value;
                    result_4021.Inst = item.Inst.Value;
                    result_4021.InstDesc = item.InstDesc.Value;
                    result_4021.Status = item.Status.Value;
                    result_4021.StatusDesc = item.StatusDesc.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4021;
        }
        /// <summary>
        /// 转化为交易码为4025的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4025 To_4025(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4025 = new Res_4025();
            if (dynamicXml != null)
            {
                res_4025.OUT_LEN = d.OUT_LEN.Value;
                res_4025.OUT_FMT_CODE = d.OUT_FMT_CODE.Value;
                res_4025.OUT_FRONT_CODE = d.OUT_FRONT_CODE.Value;
                res_4025.OUT_FRONT_JRN_NO = d.OUT_FRONT_JRN_NO.Value;
                res_4025.OUT_IBS_JRN_NO = d.OUT_IBS_JRN_NO.Value;
                res_4025.OUT_IBS_DATE = d.OUT_IBS_DATE.Value;
                res_4025.OUT_IBS_TXN_CODE = d.OUT_IBS_TXN_CODE.Value;
                res_4025.Q10_AC_NO = d.Q10_AC_NO.Value;
                res_4025.Q10_TOT_DEP = d.Q10_TOT_DEP.Value;
                res_4025.Q10_CONF_CNT = d.Q10_CONF_CNT.Value;
                res_4025.Q10_END_FLG = d.Q10_END_FLG.Value;
                res_4025.Q10_STR_SEQNO = d.Q10_STR_SEQNO.Value;
                Action<dynamic> act = item =>
                {
                    var result_4025 = new Result_4025();
                    res_4025.list.Add(result_4025);

                    result_4025.Q10_SEQ_NO = item.Q10_SEQ_NO.Value;
                    result_4025.Q10_DEP_TYPE = item.Q10_DEP_TYPE.Value;
                    result_4025.Q10_DEP_TYPE_DESC = item.Q10_DEP_TYPE_DESC.Value;
                    result_4025.Q10_CCY = item.Q10_CCY.Value;
                    result_4025.Q10_RECP_TYPE = item.Q10_RECP_TYPE.Value;
                    result_4025.Q10_BAL = item.Q10_BAL.Value;
                    result_4025.Q10_INT_RATE = item.Q10_INT_RATE.Value;
                    result_4025.Q10_VAL_DATE = item.Q10_VAL_DATE.Value;
                    result_4025.Q10_PERD = item.Q10_PERD.Value;
                    result_4025.Q10_PERD_DESC = item.Q10_PERD_DESC.Value;
                    result_4025.Q10_DUE_DATE = item.Q10_DUE_DATE.Value;
                    result_4025.Q10_RECP_NO = item.Q10_RECP_NO.Value;
                    result_4025.Q10_INST = item.Q10_INST.Value;
                    result_4025.Q10_INST_DESC = item.Q10_INST_DESC.Value;
                    result_4025.Q10_STAS_WORD = item.Q10_STAS_WORD.Value;
                    result_4025.Q10_STAS_WORD_DESC = item.Q10_STAS_WORD_DESC.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4025;
        }
        /// <summary>
        /// 转化为交易码为4054的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4054 To_4054(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4054 = new Res_4054();
            if (dynamicXml != null)
            {
                res_4054.headAccountNo = d.headAccountNo.Value;
                res_4054.headAccountName = d.headAccountName.Value;
                res_4054.AcctNo = d.AcctNo.Value;
                res_4054.supAccountName = d.supAccountName.Value;
                res_4054.subAccountNo = d.subAccountNo.Value;
                res_4054.subAccountName = d.subAccountName.Value;
                res_4054.CheckRate = d.CheckRate.Value;
                res_4054.upScore = d.upScore.Value;
                res_4054.downScore = d.downScore.Value;
                res_4054.upRate = d.upRate.Value;
                res_4054.downRate = d.downRate.Value;
                res_4054.upBookRateAmt = d.upBookRateAmt.Value;
                res_4054.downBookRateAmt = d.downBookRateAmt.Value;
                res_4054.upScoreBalance = d.upScoreBalance.Value;
                res_4054.downScoreBalance = d.downScoreBalance.Value;
                res_4054.upRateAmt = d.upRateAmt.Value;
                res_4054.downRateAmt = d.downRateAmt.Value;
                res_4054.lastRateDate = d.lastRateDate.Value;
                res_4054.endDate = d.endDate.Value;
                res_4054.payRateAcc = d.payRateAcc.Value;
                res_4054.payRateAccName = d.payRateAccName.Value;
                res_4054.recvRateAcc = d.recvRateAcc.Value;
                res_4054.bookRateAmt = d.bookRateAmt.Value;
                res_4054.RateAmt = d.RateAmt.Value;
            }
            return res_4054;
        }
        /// <summary>
        /// 转化为交易码为4058的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4058 To_4058(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4058 = new Res_4058();
            if (dynamicXml != null)
            {
                res_4058.AcctNo = d.AcctNo.Value;
                res_4058.subAccountNo = d.subAccountNo.Value;
                res_4058.opType = d.opType.Value;
                res_4058.subAccountName = d.subAccountName.Value;
                res_4058.feeFlag = d.feeFlag.Value;
                res_4058.feeType = d.feeType.Value;
                res_4058.upFee = d.upFee.Value;
                res_4058.dwFee = d.dwFee.Value;
                res_4058.mFlag = d.mFlag.Value;
            }
            return res_4058;
        }
        /// <summary>
        /// 转化为交易码为4052的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4052 To_4052(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4052 = new Res_4052();
            if (dynamicXml != null)
            {
                res_4052.ThirdVoucher = d.ThirdVoucher.Value;
                res_4052.flowNo = d.flowNo.Value;
                res_4052.AcctNo = d.AcctNo.Value;
                res_4052.supAccountName = d.supAccountName.Value;
                res_4052.supAccountOpenNode = d.supAccountOpenNode.Value;
                res_4052.guiJiAreaOption = d.guiJiAreaOption.Value;
                res_4052.subAccountNo = d.subAccountNo.Value;
                res_4052.subAccountName = d.subAccountName.Value;
                res_4052.guiJiType = d.guiJiType.Value;
                res_4052.Amount = d.Amount.Value;
            }
            return res_4052;
        }
        /// <summary>
        /// 转化为交易码为4057的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4057 To_4057(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4057 = new Res_4057();
            if (dynamicXml != null)
            {
                res_4057.ThirdVoucher = d.ThirdVoucher.Value;
                res_4057.FrontLogNo = d.FrontLogNo.Value;
                res_4057.CstInnerFlowNo = d.CstInnerFlowNo.Value;
                res_4057.AcctNo = d.AcctNo.Value;
                res_4057.AcctName = d.AcctName.Value;
                res_4057.TranOutVirAcc = d.TranOutVirAcc.Value;
                res_4057.TranOutVirAccName = d.TranOutVirAccName.Value;
                res_4057.TranInVirAcc = d.TranInVirAcc.Value;
                res_4057.TranInVirAccName = d.TranInVirAccName.Value;
                res_4057.HostFlowNo = d.HostFlowNo.Value;
                res_4057.TranAmount = d.TranAmount.Value;
                res_4057.UseEx = d.UseEx.Value;
            }
            return res_4057;
        }
        /// <summary>
        /// 转化为交易码为4022的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4022 To_4022(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4022 = new Res_4022();
            if (dynamicXml != null)
            {
                res_4022.AC = d.AC.Value;
                res_4022.CCY = d.CCY.Value;
                res_4022.ACNAME = d.ACNAME.Value;
                res_4022.GTYPE = d.GTYPE.Value;
                res_4022.headAgreementState = d.headAgreementState.Value;
                res_4022.headAuthCirculateFlag = d.headAuthCirculateFlag.Value;
                res_4022.headAuthinnerCirculateType = d.headAuthinnerCirculateType.Value;
                res_4022.headHandCirculateFlag = d.headHandCirculateFlag.Value;
                res_4022.WRDATE = d.WRDATE.Value;
                res_4022.DUEDATE = d.DUEDATE.Value;
                res_4022.CONCURNO = d.CONCURNO.Value;
                res_4022.UNITNO = d.UNITNO.Value;
                res_4022.OVRT_BAL = d.OVRT_BAL.Value;
                res_4022.CURRBAL = d.CURRBAL.Value;
            }
            return res_4022;
        }
        /// <summary>
        /// 转化为交易码为4023的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4023 To_4023(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4023 = new Res_4023();
            if (dynamicXml != null)
            {
                res_4023.PAGE = d.PAGE.Value;
                res_4023.ALLCOUNT = d.ALLCOUNT.Value;
                Action<dynamic> act = item =>
                {
                    var result_4023 = new ResultChildAccount_4023();
                    res_4023.list.Add(result_4023);

                    result_4023.SUBAC = item.SUBAC.Value;
                    result_4023.SUBNAME = item.SUBNAME.Value;
                    result_4023.CORSCONBR = item.CORSCONBR.Value;
                    result_4023.UPBALANCE = item.UPBALANCE.Value;
                    result_4023.DOWNBALANCE = item.DOWNBALANCE.Value;
                    result_4023.payRateComputeDown = item.payRateComputeDown.Value;
                    result_4023.CURRBAL = item.CURRBAL.Value;
                    result_4023.dayOverBalance = item.dayOverBalance.Value;
                    result_4023.dayOverLimit = item.dayOverLimit.Value;
                    result_4023.upScore = item.upScore.Value;
                    result_4023.downScore = item.downScore.Value;
                    result_4023.subAccCount = item.subAccCount.Value;
                    result_4023.accountGroupTypeFlag = item.accountGroupTypeFlag.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4023;
        }

        /// <summary>
        /// 转化为交易码为4055的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4055 To_4055(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4055 = new Res_4055();
            if (dynamicXml != null)
            {
                res_4055.headAccountNo = d.headAccountNo.Value;
                res_4055.headAccountName = d.headAccountName.Value;
                res_4055.headOpenBranch = d.headOpenBranch.Value;
                res_4055.headCurCode = d.headCurCode.Value;
                res_4055.supAccountNo = d.supAccountNo.Value;
                res_4055.supAccountName = d.supAccountName.Value;
                res_4055.supOpenBranch = d.supOpenBranch.Value;
                res_4055.supCurCode = d.supCurCode.Value;
                res_4055.subAccountNo = d.subAccountNo.Value;
                res_4055.subAccountName = d.subAccountName.Value;
                res_4055.BranchNo = d.BranchNo.Value;
                res_4055.currency = d.currency.Value;
                res_4055.accountGroupTypeFlag = d.accountGroupTypeFlag.Value;
                res_4055.subAccountLeve = d.subAccountLeve.Value;
                res_4055.agreementType = d.agreementType.Value;
                res_4055.authCirculateFlag = d.authCirculateFlag.Value;
                res_4055.handGuijiFlag = d.handGuijiFlag.Value;
                res_4055.handXiaboFlag = d.handXiaboFlag.Value;
                res_4055.guiJiType = d.guiJiType.Value;
                res_4055.xiaboType = d.xiaboType.Value;
                res_4055.guiJiCycle = d.guiJiCycle.Value;
                res_4055.guiJiDate = d.guiJiDate.Value;

                res_4055.guiJiTime = d.guiJiTime.Value;
                res_4055.guiJiMode = d.guiJiMode.Value;
                res_4055.guiJiIntegerUnity = d.guiJiIntegerUnity.Value;
                res_4055.guiJiBalance = d.guiJiBalance.Value;
                res_4055.controlMode = d.controlMode.Value;
                res_4055.bigLimit = d.bigLimit.Value;
                res_4055.bookLimit = d.bookLimit.Value;
                res_4055.dayOverdraftFlag = d.dayOverdraftFlag.Value;

                res_4055.dayOverLimit = d.dayOverLimit.Value;
                res_4055.xiaboCycle = d.xiaboCycle.Value;
                res_4055.xiaboDate = d.xiaboDate.Value;
                res_4055.xiaboTime = d.xiaboTime.Value;
                res_4055.xiaboMode = d.xiaboMode.Value;
                res_4055.xiaboKeepAmt = d.xiaboKeepAmt.Value;
                res_4055.xiaboBalance = d.xiaboBalance.Value;
                res_4055.entrustLoanFlag = d.entrustLoanFlag.Value;
                res_4055.RateFlag = d.RateFlag.Value;
                res_4055.rateRemitInFlag = d.rateRemitInFlag.Value;
                res_4055.upRate = d.upRate.Value;

                res_4055.downRate = d.downRate.Value;
                res_4055.agreementState = d.agreementState.Value;
                res_4055.effectDate = d.effectDate.Value;
                res_4055.settleInterestsCycle = d.settleInterestsCycle.Value;
                res_4055.virAccBalance = d.virAccBalance.Value;
            }
            return res_4055;
        }

        /// <summary>
        /// 转化为交易码为4024的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4024 To_4024(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4024 = new Res_4024();
            if (dynamicXml != null)
            {
                res_4024.subAccountNo = d.subAccountNo.Value;
                res_4024.subAccountName = d.subAccountName.Value;
                res_4024.subAccountOpenBank = d.subAccountOpenBank.Value;

                res_4024.currency = d.currency.Value;
                res_4024.headAccountNo = d.headAccountNo.Value;
                res_4024.headAccountName = d.headAccountName.Value;
                res_4024.headOpenBranch = d.headOpenBranch.Value;
                res_4024.headCurCode = d.headCurCode.Value;
                res_4024.AcctNo = d.AcctNo.Value;
                res_4024.AccountName = d.AccountName.Value;
                res_4024.AcctOpenBank = d.AcctOpenBank.Value;
                res_4024.supCurCode = d.supCurCode.Value;
                res_4024.turnPageFlag = d.turnPageFlag.Value;
                res_4024.turnPageShowNum = d.turnPageShowNum.Value;
                res_4024.serialNo = d.serialNo.Value;
                Action<dynamic> act = item =>
                {
                    var result_4024 = new Result_4024();
                    res_4024.list.Add(result_4024);

                    result_4024.tranDate = item.tranDate.Value;
                    result_4024.tranAmount = item.tranAmount.Value;
                    result_4024.virAccBalance = item.virAccBalance.Value;
                    result_4024.loanFlag = item.loanFlag.Value;
                    result_4024.entrustLoanFlag = item.entrustLoanFlag.Value;
                    result_4024.remark = item.remark.Value;
                    result_4024.tranTime = item.tranTime.Value;
                    result_4024.otherAccountNo = item.otherAccountNo.Value;
                    result_4024.otherAccountName = item.otherAccountName.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4024;
        }

        /// <summary>
        /// 转化为交易码为4056的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4056 To_4056(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4056 = new Res_4056();
            if (dynamicXml != null)
            {
                res_4056.supAccountNo = d.supAccountNo.Value;
                res_4056.subAccountNo = d.subAccountNo.Value;
                res_4056.RecordNum = d.RecordNum.Value;
                Action<dynamic> act = item =>
                {
                    var result_4056 = new Result_4056();
                    res_4056.list.Add(result_4056);

                    result_4056.TxDate = item.TxDate.Value;
                    result_4056.HostSeqNo = item.HostSeqNo.Value;
                    result_4056.dFlag = item.dFlag.Value;
                    result_4056.Amount = item.Amount.Value;
                    result_4056.StartDate = item.StartDate.Value;
                    result_4056.EndDate = item.EndDate.Value;
                    result_4056.upRate = item.upRate.Value;
                    result_4056.upScore = item.upScore.Value;
                    result_4056.upBookRateAmt = item.upBookRateAmt.Value;
                    result_4056.downScore = item.downScore.Value;
                    result_4056.downBookRateAmt = item.downBookRateAmt.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4056;
        }

        /// <summary>
        /// 转化为交易码为4059的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4059 To_4059(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4059 = new Res_4059();
            if (dynamicXml != null)
            {
                res_4059.Account = d.Account.Value;
                res_4059.CcyCode = d.CcyCode.Value;
                res_4059.CcyType = d.CcyType.Value;
                res_4059.AccountName = d.AccountName.Value;
                res_4059.Balance = d.Balance.Value;
                res_4059.TotalAmount = d.TotalAmount.Value;
                res_4059.LastBalance = d.LastBalance.Value;
                res_4059.HoldBalance = d.HoldBalance.Value;
            }
            return res_4059;
        }
        /// <summary>
        /// 转化为交易码为4002的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4002 To_4002(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4002 = new Res_4002();
            if (dynamicXml != null)
            {
                res_4002.Account = d.Account.Value;
                res_4002.CcyCode = d.CcyCode.Value;
                res_4002.RecordNum = d.RecordNum.Value;
                Action<dynamic> act = item =>
                {
                    var result_4002 = new Result_4002();
                    res_4002.list.Add(result_4002);

                    result_4002.TxCode = item.TxCode.Value;
                    result_4002.Correct = item.Correct.Value;
                    result_4002.HostSeqNo = item.HostSeqNo.Value;
                    result_4002.CurrencyNo = item.CurrencyNo.Value;
                    result_4002.TxType = item.TxType.Value;
                    result_4002.TxAmount = item.TxAmount.Value;
                    result_4002.Note = item.Note.Value;
                    result_4002.TxAcctNo = item.TxAcctNo.Value;
                    result_4002.UnitNo = item.UnitNo.Value;
                    result_4002.Teller = item.Teller.Value;
                    result_4002.FMCode = item.FMCode.Value;
                    result_4002.FMJournalNo = item.FMJournalNo.Value;
                    result_4002.FMTranType = item.FMTranType.Value;
                    result_4002.JJCode = item.JJCode.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4002;
        }

        /// <summary>
        /// 转化为交易码为4008的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4008 To_4008(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4008 = new Res_4008();
            if (dynamicXml != null)
            {
                res_4008.AcctNo = d.AcctNo.Value;
                res_4008.CcyCode = d.CcyCode.Value;
                res_4008.PageNo = d.PageNo.Value;
                res_4008.PageSize = d.PageSize.Value;
                res_4008.TranDate = d.TranDate.Value;
                res_4008.EndFlag = d.EndFlag.Value;
                res_4008.PageRecCount = d.PageRecCount.Value;
                res_4008.JournalNo = d.JournalNo.Value;
                res_4008.LogCount = d.LogCount.Value;
                Action<dynamic> act = item =>
                {
                    var result_4008 = new Result_4008();
                    res_4008.list.Add(result_4008);

                    result_4008.TranTime1 = item.TranTime1.Value;
                    result_4008.HostSeqNo = item.HostSeqNo.Value;
                    result_4008.SummonNo = item.SummonNo.Value;
                    result_4008.SendBank = item.SendBank.Value;
                    result_4008.SendAccount = item.SendAccount.Value;
                    result_4008.SendName = item.SendName.Value;
                    result_4008.TxAmount = item.TxAmount.Value;
                    result_4008.AcctBank = item.AcctBank.Value;
                    result_4008.AcctAccount = item.AcctAccount.Value;
                    result_4008.AcctName = item.AcctName.Value;
                    result_4008.TxType = item.TxType.Value;
                    result_4008.AbstractStr = item.AbstractStr.Value;
                    result_4008.Notes = item.Notes.Value;
                    result_4008.Fee1 = item.Fee1.Value;
                    result_4008.Fee2 = item.Fee2.Value;
                    result_4008.AbstractStr_Desc = item.AbstractStr_Desc.Value;
                    result_4008.CVoucherNo = item.CVoucherNo.Value;
                    result_4008.CstInnerFlowNo = item.CstInnerFlowNo.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_4008;
        }
        /// <summary>
        ///  转化为交易码为4034的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_4034 To_4034(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_4034 = new Res_4034();
            if (dynamicXml != null)
            {
                res_4034.BThirdVoucher = d.BThirdVoucher.Value;
            }
            return res_4034;
        }
        /// <summary>
        /// 转化为交易码为FILE02的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_FILE02 To_FILE02(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_FILE02 = new Res_FILE02();
            if (dynamicXml != null)
            {
                res_FILE02.Desc = d.Desc.Value;
                res_FILE02.Code = d.Code.Value;
                res_FILE02.FileName = d.FileName.Value;
                res_FILE02.RandomPwd = d.RandomPwd.Value;
                res_FILE02.SignData = d.SignData.Value;
                res_FILE02.HashData = d.HashData.Value;
                res_FILE02.Action = d.Action.Value;
            }
            return res_FILE02;
        }

        /// <summary>
        /// 转化为交易码为FILE03的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_FILE03 To_FILE03(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_FILE03 = new Res_FILE03();
            if (dynamicXml != null)
            {
                res_FILE03.Desc = d.Desc.Value;
                res_FILE03.Code = d.Code.Value;
            }
            return res_FILE03;
        }

        /// <summary>
        /// 转化为交易码为FILE04的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Req_FILE04 To_FILE04(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var req_FILE04 = new Req_FILE04();
            if (dynamicXml != null)
            {
                req_FILE04.TradeSn = d.TradeSn.Value;
                req_FILE04.FileName = d.FileName.Value;
                //req_FILE04.FileSize = d.FileSize.Value;
                req_FILE04.FilePath = d.FilePath.Value;
                req_FILE04.Action = d.Action.Value;
                req_FILE04.RandomPwd = d.RandomPwd.Value;
                req_FILE04.SignData = d.SignData.Value;
                req_FILE04.HashData = d.HashData.Value;
            }
            return req_FILE04;
        }
        /// <summary>
        ///  转化为交易码为KHKF01的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_KHKF01 To_KHKF01(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_KHKF01 = new Res_KHKF01();
            if (dynamicXml != null)
            {
                res_KHKF01.BatchNo = d.BatchNo.Value;
                res_KHKF01.BusiType = d.BusiType.Value;
                res_KHKF01.CorpId = d.CorpId.Value;
                int _TotalNum = 0;
                int.TryParse(d.TotalNum.Value, out _TotalNum);
                res_KHKF01.TotalNum = _TotalNum;

                decimal _TotalAmount = 0m;
                decimal.TryParse(d.TotalAmount.Value, out _TotalAmount);
                res_KHKF01.TotalAmount = _TotalAmount;
            }
            return res_KHKF01;
        }
        /// <summary>
        ///  转化为交易码为KHKF02的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_KHKF02 To_KHKF02(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_KHKF02 = new Res_KHKF02();
            if (dynamicXml != null)
            {
                res_KHKF02.BatchNo = d.BatchNo.Value;
                res_KHKF02.BatchStt = d.BatchStt.Value;
                res_KHKF02.BatchInfo = d.BatchInfo.Value;
                res_KHKF02.FileName = d.FileName.Value;
                res_KHKF02.RandomPwd = d.RandomPwd.Value;
                res_KHKF02.HashData = d.HashData.Value;
                res_KHKF02.SignData = d.SignData.Value;
            }
            return res_KHKF02;
        }
        /// <summary>
        ///  转化为交易码为KHKF03的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_KHKF03 To_KHKF03(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_KHKF03 = new Res_KHKF03();
            if (dynamicXml != null)
            {
                res_KHKF03.OrderNumber = d.OrderNumber.Value;
                res_KHKF03.BussFlowNo = d.BussFlowNo.Value;
            }
            return res_KHKF03;
        }
        /// <summary>
        ///  转化为交易码为KHKF04的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_KHKF04 To_KHKF04(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_KHKF04 = new Res_KHKF04();
            if (dynamicXml != null)
            {
                res_KHKF04.OrderNumber = d.OrderNumber.Value;
                res_KHKF04.BussFlowNo = d.BussFlowNo.Value;
                res_KHKF04.TranFlowNo = d.TranFlowNo.Value;
                res_KHKF04.Status = d.Status.Value;
                res_KHKF04.RetCode = d.RetCode.Value;
                res_KHKF04.RetMsg = d.RetMsg.Value;
                res_KHKF04.SettleDate = d.SettleDate.Value;
                res_KHKF04.InAcctNo = d.InAcctNo.Value;
                res_KHKF04.InAcctName = d.InAcctName.Value;
                res_KHKF04.CcyCode = d.CcyCode.Value;
                res_KHKF04.TranAmount = d.TranAmount.Value;
                res_KHKF04.Mobile = d.Mobile.Value;
                res_KHKF04.Remark = d.Remark.Value;
            }
            return res_KHKF04;
        }
        /// <summary>
        ///  转化为交易码为KHKF04的结果
        /// </summary>
        /// <param name="dynamicXml"></param>
        /// <returns></returns>
        public static Res_KHKF05 To_KHKF05(this DynamicXml dynamicXml)
        {
            dynamic d = dynamicXml;
            var res_KHKF05 = new Res_KHKF05();
            if (dynamicXml != null)
            {
                res_KHKF05.Stt = d.Stt.Value;
                Action<dynamic> act = item =>
                {
                    var result_KHKF05 = new Result_KHKF05();
                    res_KHKF05.list.Add(result_KHKF05);
                    result_KHKF05.FileName = item.FileName.Value;
                    result_KHKF05.FileType = item.FileType.Value;
                    result_KHKF05.BatchNo = item.BatchNo.Value;
                    result_KHKF05.FilePath = item.FilePath.Value;
                    result_KHKF05.RandomPwd = item.RandomPwd.Value;
                    result_KHKF05.SignData = item.SignData.Value;
                    result_KHKF05.HashData = item.HashData.Value;
                };
                //单条
                if (typeof(DynamicXml) == d.list.GetType())
                {
                    act(d.list);
                }
                else
                {
                    //集合
                    foreach (dynamic item in d.list)
                    {
                        act(item);
                    }
                }
            }
            return res_KHKF05;
        }
        #endregion

        #region  特殊的现货交易接口转换
        public static Res_1010 To_1010(this string[] strArr)
        {
            var res_1010 = new Res_1010();
            if (strArr.Length >= 4)
            {
                string Reserve = string.Empty;
                var list = new List<AccountItem>();
                //属性的长度               
                int propertyLen = new AccountItem().GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Count();
                var array = strArr.Skip(4);
                while (true)
                {
                    if (array.Count() >= propertyLen)
                    {
                        var item = array.Take(propertyLen).ToArray();
                        AccountItem accountItem = new AccountItem();
                        list.Add(accountItem);
                        accountItem.CustAcctId = item[0];
                        accountItem.CustFlag = item[1];
                        accountItem.CustType = item[2];
                        accountItem.CustStatus = item[3];
                        accountItem.ThirdCustId = item[4];
                        accountItem.MainAcctId = item[5];
                        accountItem.CustName = item[6];
                        accountItem.TotalAmount = item[7];
                        accountItem.TotalBalance = item[8];
                        accountItem.TotalFreezeAmount = item[9];
                        accountItem.TranDate = item[10];
                        array = array.Skip(propertyLen);
                    }
                    else
                    {
                        if (array.Count() > 0) Reserve = array.ToArray()[0];
                        break;
                    }
                }
                res_1010.TotalCount = strArr[0];
                res_1010.BeginNum = strArr[1];
                res_1010.LastPage = strArr[2];
                res_1010.RecordNum = strArr[3];
                res_1010.AccountList = list;
                res_1010.Reserve = Reserve;
            }
            return res_1010;
        }
        public static Res_1016 To_1016(this string[] strArr)
        {
            var res_1016 = new Res_1016();
            if (strArr.Length >= 4)
            {
                //总记录数
                string TotalCount = strArr[0];
                //起始记录号
                string BeginNum = strArr[1];
                //是否结束包 0：否  1：是
                string LastPage = strArr[2];
                //本次返回流水笔数 重复次数（一次最多返回20条记录）
                string RecordNum = strArr[3];
                string Reserve = string.Empty;
                var list = new List<OpenAccountInfo>();
                //属性的长度               
                int propertyLen = new OpenAccountInfo().GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Count();
                var array = strArr.Skip(4);
                while (true)
                {
                    if (array.Count() >= propertyLen)
                    {
                        var item = array.Take(propertyLen).ToArray();
                        OpenAccountInfo accountItem = new OpenAccountInfo();
                        list.Add(accountItem);
                        accountItem.FrontLogNo = item[0];
                        accountItem.UserStatus = item[1];
                        accountItem.CustAcctId = item[2];
                        accountItem.CustFlag = item[3];
                        accountItem.CustName = item[4];
                        accountItem.ThirdCustId = item[5];
                        accountItem.TranDate = item[6];
                        accountItem.CounterId = item[7];
                        array = array.Skip(propertyLen);
                    }
                    else
                    {
                        if (array.Count() > 0) Reserve = array.ToArray()[0];
                        break;
                    }
                }
                res_1016.TotalCount = strArr[0];
                res_1016.BeginNum = strArr[1];
                res_1016.LastPage = strArr[2];
                res_1016.RecordNum = strArr[3];
                res_1016.OpenAccountInfoList = list;
                res_1016.Reserve = Reserve;
            }
            return res_1016;
        }

        public static Res_1324 To_1324(this string[] strArr)
        {
            var res_1324 = new Res_1324();
            if (strArr.Length >= 4)
            {
                string Reserve = string.Empty;
                var list = new List<TradeFlowiInfo>();
                //属性的长度               
                int propertyLen = new TradeFlowiInfo().GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Count();
                var array = strArr.Skip(4);
                while (true)
                {
                    if (array.Count() >= propertyLen)
                    {
                        var item = array.Take(propertyLen).ToArray();
                        TradeFlowiInfo tradeFlowiInfo = new TradeFlowiInfo();
                        list.Add(tradeFlowiInfo);

                        tradeFlowiInfo.ThirdLogNo = item[0];
                        tradeFlowiInfo.FrontLogNo = item[1];
                        tradeFlowiInfo.TranFlag = item[2];
                        tradeFlowiInfo.TranStatus = item[3];
                        tradeFlowiInfo.TranAmount = item[4];
                        tradeFlowiInfo.OutCustAcctId = item[5];
                        tradeFlowiInfo.OutThirdCustId = item[6];
                        tradeFlowiInfo.InCustAcctId = item[7];
                        tradeFlowiInfo.InThirdCustId = item[8];
                        tradeFlowiInfo.TranDate = item[9];

                        array = array.Skip(propertyLen);
                    }
                    else
                    {
                        if (array.Count() > 0) Reserve = array.ToArray()[0];
                        break;
                    }
                }
                //总记录数
                res_1324.TotalCount = strArr[0];
                //起始记录号
                res_1324.BeginNum = strArr[1];
                //是否结束包 0：否  1：是
                res_1324.LastPage = strArr[2];

                //本次返回流水笔数
                res_1324.RecordNum = strArr[3];

                //信息数组
                res_1324.TradeFlowiInfoList = list;
                //保留域
                res_1324.Reserve = Reserve;
            }
            return res_1324;
        }
        public static Res_1325 To_1325(this string[] strArr)
        {
            var res_1325 = new Res_1325();
            if (strArr.Length >= 4)
            {
                string Reserve = string.Empty;
                var list = new List<AccessToGoldTradeInfo>();
                //属性的长度               
                int propertyLen = new AccessToGoldTradeInfo().GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Count();
                var array = strArr.Skip(4);
                while (true)
                {
                    if (array.Count() >= propertyLen)
                    {
                        var item = array.Take(propertyLen).ToArray();
                        AccessToGoldTradeInfo accessToGoldTradeInfo = new AccessToGoldTradeInfo();
                        list.Add(accessToGoldTradeInfo);

                        accessToGoldTradeInfo.ThirdLogNo = item[0];
                        accessToGoldTradeInfo.FrontLogNo = item[1];
                        accessToGoldTradeInfo.TranFlag = item[2];
                        accessToGoldTradeInfo.TranStatus = item[3];
                        accessToGoldTradeInfo.TranAmount = item[4];
                        accessToGoldTradeInfo.CustAcctId = item[5];
                        accessToGoldTradeInfo.ThirdCustId = item[6];
                        accessToGoldTradeInfo.TranDate = item[7];
                        accessToGoldTradeInfo.AcctDate = item[8];
                        array = array.Skip(propertyLen);
                    }
                    else
                    {
                        if (array.Count() > 0) Reserve = array.ToArray()[0];
                        break;
                    }
                }
                //总记录数
                res_1325.TotalCount = strArr[0];
                //起始记录号
                res_1325.BeginNum = strArr[1];
                //是否结束包 0：否  1：是
                res_1325.LastPage = strArr[2];
                //本次返回流水笔数
                res_1325.RecordNum = strArr[3];
                //信息数组
                res_1325.AccessToGoldTradeInfoList = list;
                //保留域
                res_1325.Reserve = Reserve;
            }
            return res_1325;
        }
        #endregion

    }
}
