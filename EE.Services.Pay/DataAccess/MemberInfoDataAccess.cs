using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using EE.Services.Pay.Model.Req;
using EE.Services.Pay.Model;
using EE.Services.Pay.Model.Res;

namespace EE.Services.Pay.DataAccess
{
    /// <summary>
    /// 处理会员
    /// </summary>
    public class MemberInfoDataAccess
    {
        static string strConnection = DbHelper.GetDbConnString("TestDb");
        /// <summary>
        /// 处理1301的请求
        /// </summary>
        /// <param name="req_1301"></param>
        /// <returns></returns>
        public static int AddOrUpdateMemberInfo(Req_1301 req_1301)
        {
            string sql = "select count(1) from MemberInfo where CustAcctId=@CustAcctId and ThirdCustId=@ThirdCustId";
            var obj = MySqlHelper.ExecuteScalar(strConnection, sql, new MySqlParameter[] {
                new MySqlParameter("@CustAcctId",req_1301.CustAcctId) ,
                new MySqlParameter("@ThirdCustId",req_1301.ThirdCustId)
            });
            int retValue = -1;
            if (obj != null)
            {
                var param = new MySqlParameter[] {
                        new MySqlParameter("@SupAcctId",req_1301.SupAcctId),
                        new MySqlParameter("@CustAcctId",req_1301.CustAcctId),
                        new MySqlParameter("@CustName",req_1301.CustName),
                        new MySqlParameter("@ThirdCustId",req_1301.ThirdCustId),
                        new MySqlParameter("@IdType",req_1301.IdType),
                        new MySqlParameter("@IdCode",req_1301.IdCode),
                        new MySqlParameter("@CustFlag",req_1301.CustFlag),
                        new MySqlParameter("@TotalAmount",req_1301.TotalAmount),
                        new MySqlParameter("@TotalBalance",req_1301.TotalBalance),
                        new MySqlParameter("@TotalFreezeAmount",req_1301.TotalFreezeAmount)
                };
                if (int.TryParse(obj.ToString(), out retValue) && retValue == 0)
                {
                    //添加
                    sql = "insert into MemberInfo(`SupAcctId`,`CustAcctId`,`CustName`,`ThirdCustId`,`IdType`,`IdCode`,`CustFlag`,`TotalAmount`,`TotalBalance`,`TotalFreezeAmount`,`LastOption`) values(";
                    sql += "  @SupAcctId,@CustAcctId,@CustName,@ThirdCustId,@IdType,@IdCode,@CustFlag,@TotalAmount,@TotalBalance,@TotalFreezeAmount ,'add_1301') ";
                    obj = MySqlHelper.ExecuteScalar(strConnection, sql + ";select @@IDENTITY;", param);
                    int.TryParse(obj.ToString(), out retValue);
                }
                else
                {
                    //修改
                    sql = " update MemberInfo set Status=@Status, SupAcctId=@SupAcctId,CustName=@CustName,IdType=@IdType,IdCode=@IdCode,CustFlag=@CustFlag,TotalAmount=@TotalAmount,TotalBalance=@TotalBalance,TotalFreezeAmount=@TotalFreezeAmount,LastOption='update_1301' where CustAcctId=@CustAcctId and ThirdCustId=@ThirdCustId";
                    var list = new List<MySqlParameter>();
                    list.AddRange(param);
                    list.Add(new MySqlParameter("@Status", req_1301.FuncFlag == 1));
                    obj = MySqlHelper.ExecuteNonQuery(strConnection, sql, param);
                    int.TryParse(obj.ToString(), out retValue);
                }
            }
            return retValue;
        }
        /// <summary>
        /// 处理1315的请求
        /// </summary>
        /// <param name="req_1315"></param>
        /// <returns></returns>
        public static int AddOrUpdateMemberInfo(Req_1315 req_1315)
        {
            string sql = "select count(1) from MemberInfo where CustAcctId=@CustAcctId";
            var obj = MySqlHelper.ExecuteScalar(strConnection, sql, new MySqlParameter[] {
                new MySqlParameter("@CustAcctId",req_1315.CustAcctId)
            });
            int retValue = -1;
            if (obj != null)
            {
                var param = new MySqlParameter[] {
                        new MySqlParameter("@Status", 1),
                        new MySqlParameter("@DealStatus", 0),
                        new MySqlParameter("@CustAcctId",req_1315.CustAcctId),
                        new MySqlParameter("@RelatedAcctId",req_1315.RelatedAcctId),
                        new MySqlParameter("@AcctFlag",req_1315.AcctFlag),
                        new MySqlParameter("@TranType",req_1315.TranType),
                        new MySqlParameter("@AcctName",req_1315.AcctName),
                        new MySqlParameter("@BankCode",req_1315.BankCode),
                        new MySqlParameter("@BankName",req_1315.BankName),
                        new MySqlParameter("@Address",req_1315.Address),
                        new MySqlParameter("@OldRelatedAcctId",req_1315.OldRelatedAcctId),
                        new MySqlParameter("@Reserve",req_1315.Reserve)
                    };
                if (int.TryParse(obj.ToString(), out retValue) && retValue == 0)
                {
                    //添加
                    sql = "insert into MemberInfo(`Status`,`DealStatus`,`CustAcctId`,`RelatedAcctId`,`AcctFlag`,`TranType`,`AcctName`,`BankCode`,`BankName`,`Address`,`OldRelatedAcctId`,`Reserve`,`LastOption`) values(";
                    sql += " @Status,@DealStatus, @CustAcctId,@RelatedAcctId,@AcctFlag,@TranType,@AcctName,@BankCode,@BankName,@Address,@OldRelatedAcctId,@Reserve ,'add_1315') ";
                    obj = MySqlHelper.ExecuteScalar(strConnection, sql + ";select @@IDENTITY;", param);
                    int.TryParse(obj.ToString(), out retValue);
                }
                else
                {
                    //修改
                    sql = " update MemberInfo set Status=@Status,DealStatus=@DealStatus, RelatedAcctId=@RelatedAcctId,AcctFlag=@AcctFlag,TranType=@TranType,AcctName=@AcctName,BankCode=@BankCode,BankName=@BankName,Address=@Address,OldRelatedAcctId=@OldRelatedAcctId,Reserve=@Reserve,LastOption='update_1315' where CustAcctId=@CustAcctId";
                    obj = MySqlHelper.ExecuteNonQuery(strConnection, sql, param);
                    int.TryParse(obj.ToString(), out retValue);
                }
            }
            return retValue;
        }
        /// <summary>
        /// 处理1303的请求
        /// </summary>
        /// <param name="req_1303"></param>
        /// <returns></returns>
        public static int AddOrUpdateMemberInfo(Req_1303 req_1303)
        {
            string sql = "select count(1) from MemberInfo where CustAcctId=@CustAcctId";
            var obj = MySqlHelper.ExecuteScalar(strConnection, sql, new MySqlParameter[] {
                new MySqlParameter("@CustAcctId",req_1303.CustAcctId)
            });
            int retValue = -1;
            if (obj != null)
            {
                var param = new MySqlParameter[] {
                        new MySqlParameter("@SupAcctId",req_1303.SupAcctId),
                        new MySqlParameter("@CustAcctId",req_1303.CustAcctId),
                        new MySqlParameter("@CustName",req_1303.CustName),
                        new MySqlParameter("@ThirdCustId",req_1303.ThirdCustId),
                        new MySqlParameter("@IdType",req_1303.IdType),
                        new MySqlParameter("@IdCode",req_1303.IdCode),
                        new MySqlParameter("@RelatedAcctId",req_1303.RelatedAcctId),
                        new MySqlParameter("@AcctFlag",req_1303.AcctFlag),
                        new MySqlParameter("@TranType",req_1303.TranType),
                        new MySqlParameter("@AcctName",req_1303.AcctName),
                        new MySqlParameter("@BankCode",req_1303.BankCode),
                        new MySqlParameter("@BankName",req_1303.BankName),
                        new MySqlParameter("@OldRelatedAcctId",req_1303.OldRelatedAcctId),
                        new MySqlParameter("@Reserve",req_1303.Reserve)
                    };
                if (int.TryParse(obj.ToString(), out retValue)
                    && retValue == 0)
                {
                    if (req_1303.FuncFlag == 1)
                    {
                        var list = new List<MySqlParameter>();
                        list.AddRange(param);
                        list.Add(new MySqlParameter("@Status", 1));
                        list.Add(new MySqlParameter("@DealStatus", 0));
                        //添加
                        sql = "insert into MemberInfo(`Status`,`DealStatus`,`SupAcctId`,`CustAcctId`,`CustName`,`ThirdCustId`,`IdType`,`IdCode`,`RelatedAcctId`,`AcctFlag`,`TranType`,`AcctName`,`BankCode`,`BankName`,`OldRelatedAcctId`,`Reserve`,`LastOption`) values(";
                        sql += " @Status,@DealStatus,@CustAcctId,@RelatedAcctId,@AcctFlag,@TranType,@AcctName,@BankCode,@BankName,@Address,@OldRelatedAcctId,@Reserve,'add_1303' ) ";
                        obj = MySqlHelper.ExecuteScalar(strConnection, sql + ";select @@IDENTITY;", list.ToArray());
                        int.TryParse(obj.ToString(), out retValue);
                    }
                }
                else
                {
                    var list = new List<MySqlParameter>();
                    list.AddRange(param);
                    list.Add(new MySqlParameter("@Status", req_1303.FuncFlag == 2));
                    //修改
                    sql = " update MemberInfo set Status=@Status," + (req_1303.FuncFlag == 2 ? " DealStatus=0, " : "") + " SupAcctId=@SupAcctId,CustAcctId=@CustAcctId,CustName=@CustName,ThirdCustId=@ThirdCustId,IdType=@IdType,IdCode=@IdCode,RelatedAcctId=@RelatedAcctId,AcctFlag=@AcctFlag,TranType=@TranType,AcctName=@AcctName,BankCode=@BankCode,BankName=@BankName,OldRelatedAcctId=@OldRelatedAcctId, Reserve=@Reserve,LastOption='update_1303' where CustAcctId=@CustAcctId";
                    obj = MySqlHelper.ExecuteNonQuery(strConnection, sql, param);
                    int.TryParse(obj.ToString(), out retValue);
                }
            }
            return retValue;
        }
        /// <summary>
        /// 处理1343的请求
        /// </summary>
        /// <param name="req_1343"></param>
        /// <returns></returns>
        public static int AddOrUpdateMemberInfo(Req_1343 req_1343, string serialNo)
        {
            string sql = "select count(1) from MemberInfo where SupAcctId=@SupAcctId and ThirdCustId=@ThirdCustId and MobilePhone=@MobilePhone and Status=0 and DealStatus=-1";
            var obj = MySqlHelper.ExecuteScalar(strConnection, sql, new MySqlParameter[] {
                new MySqlParameter("@SupAcctId",req_1343.SupAcctId),
                new MySqlParameter("@ThirdCustId",req_1343.ThirdCustId),
                new MySqlParameter("@MobilePhone",req_1343.MobilePhone),
                new MySqlParameter("@AcctId",req_1343.AcctId),
            });
            int retValue = -1;
            if (obj != null)
            {
                var param = new MySqlParameter[] {
                        new MySqlParameter("@SupAcctId",req_1343.SupAcctId),
                        new MySqlParameter("@ThirdCustId",req_1343.ThirdCustId),
                        new MySqlParameter("@CustName",req_1343.CustName),
                        new MySqlParameter("@IdType",req_1343.IdType),
                        new MySqlParameter("@IdCode",req_1343.IdCode),
                        new MySqlParameter("@CpFlag",req_1343.CpFlag),
                        new MySqlParameter("@AcctId",req_1343.AcctId),
                        new MySqlParameter("@BankType",req_1343.BankType),
                        new MySqlParameter("@BankName",req_1343.BankName),
                        new MySqlParameter("@BankCode",req_1343.BankCode),
                        new MySqlParameter("@SBankCode",req_1343.SBankCode),
                        new MySqlParameter("@MobilePhone",req_1343.MobilePhone),
                        new MySqlParameter("@EmailAddr",req_1343.EmailAddr),
                        new MySqlParameter("@RegAddress",req_1343.RegAddress),
                        new MySqlParameter("@Zip",req_1343.Zip),
                        new MySqlParameter("@ErpAddress",req_1343.Address),
                        new MySqlParameter("@ContactUser",req_1343.ContactUser),
                        new MySqlParameter("@Reserve",req_1343.Reserve),
                        new MySqlParameter("@SerialNo",serialNo)
                    };
                if (int.TryParse(obj.ToString(), out retValue)
                    && retValue == 0
                    && !string.IsNullOrEmpty(serialNo)
                    )
                {
                    //添加
                    sql = "insert into MemberInfo(`SupAcctId`,`ThirdCustId`,`CustName`,`IdType`,`IdCode`,`CpFlag`,`AcctId`,`BankType`,`BankName`,`BankCode`,`SBankCode`,`MobilePhone`,`EmailAddr`,`RegAddress`,`Zip`,`ErpAddress`,`ContactUser`,`Reserve`,`SerialNo`,`DealStatus`,`LastOption`) values(";
                    sql += " @SupAcctId,@ThirdCustId,@CustName,@IdType,@IdCode,@CpFlag,@AcctId,@BankType,@BankName,@BankCode,@SBankCode,@MobilePhone,@EmailAddr,@RegAddress,@Zip,@ErpAddress,@ContactUser,@Reserve,@SerialNo,-1,'add_1303' ) ";
                    obj = MySqlHelper.ExecuteScalar(strConnection, sql + ";select @@IDENTITY;", param);
                    int.TryParse(obj.ToString(), out retValue);
                }
            }
            return retValue;
        }
        /// <summary>
        /// 处理1344响应
        /// </summary>
        /// <param name="req_1344"></param>       
        /// <returns></returns>
        public static int AddOrUpdateMemberInfo(Res_1344 res_1344)
        {
            string sql = "select Id from MemberInfo where SerialNo=@SerialNo";
            var obj = MySqlHelper.ExecuteScalar(strConnection, sql, new MySqlParameter[] {
                new MySqlParameter("@SerialNo",res_1344.SerialNo)
            });
            int retValue = -1;
            if (obj != null
                && int.TryParse(obj.ToString(), out retValue)
                && retValue > 0
                && !string.IsNullOrEmpty(res_1344.SerialNo)
                )
            {
                var param = new MySqlParameter[] {
                        new MySqlParameter("@Id",retValue),
                        new MySqlParameter("@Status",res_1344.DealStatus==0),
                        new MySqlParameter("@DealStatus",res_1344.DealStatus),
                        new MySqlParameter("@CustAcctId",res_1344.CustAcctId),
                        new MySqlParameter("@RelatedAcctId",res_1344.RelatedAcctId)
                        //,new MySqlParameter("@Reserve",res_1344.Reserve)
                    };
                //修改
                sql = " update MemberInfo set Status=@Status,DealStatus=@DealStatus,CustAcctId=@CustAcctId,RelatedAcctId=@RelatedAcctId,Reserve=@Reserve,LastOption='update_1344' where Id=@Id";
                obj = MySqlHelper.ExecuteNonQuery(strConnection, sql, param);
                int.TryParse(obj.ToString(), out retValue);
            }
            return retValue;
        }

        /// <summary>
        /// 获取通过审核的会员开户信息
        /// </summary>
        /// <param name="mobile">会员手机号</param>
        /// <returns></returns>
        public static MemberInfo GetMemberInfo(string mobile)
        {
            MemberInfo memberinfo = null;
            string sql = "select * from MemberInfo where MobilePhone=@MobilePhone and Status=1 and DealStatus=0";
            using (var reader = MySqlHelper.ExecuteReader(strConnection, sql, new MySqlParameter[] {
                new MySqlParameter("@MobilePhone",mobile)
            }))
            {
                if (reader.Read())
                {
                    memberinfo = new MemberInfo();
                    memberinfo.Id = reader["Id"] == DBNull.Value ? 0 : int.Parse(reader["Id"].ToString());

                    memberinfo.Status = reader["Status"] == DBNull.Value ? false : reader["Status"].ToString() == "1";
                    memberinfo.DealStatus = reader["DealStatus"] == DBNull.Value ? -1 : int.Parse(reader["DealStatus"].ToString());
                    memberinfo.CpFlag = reader["CpFlag"] == DBNull.Value ? 1 : int.Parse(reader["CpFlag"].ToString());
                    memberinfo.AcctId = reader["AcctId"] == DBNull.Value ? "" : reader["AcctId"].ToString();
                    memberinfo.BankType = reader["BankType"] == DBNull.Value ? 1 : int.Parse(reader["BankType"].ToString());
                    memberinfo.SBankCode = reader["SBankCode"] == DBNull.Value ? "" : reader["SBankCode"].ToString();
                    memberinfo.MobilePhone = reader["MobilePhone"] == DBNull.Value ? "" : reader["MobilePhone"].ToString();
                    memberinfo.EmailAddr = reader["EmailAddr"] == DBNull.Value ? "" : reader["EmailAddr"].ToString();
                    memberinfo.RegAddress = reader["RegAddress"] == DBNull.Value ? "" : reader["RegAddress"].ToString();
                    memberinfo.Zip = reader["Zip"] == DBNull.Value ? "" : reader["Zip"].ToString();
                    memberinfo.ErpAddress = reader["ErpAddress"] == DBNull.Value ? "" : reader["ErpAddress"].ToString();
                    memberinfo.ContactUser = reader["ContactUser"] == DBNull.Value ? "" : reader["ContactUser"].ToString();
                    memberinfo.SerialNo = reader["SerialNo"] == DBNull.Value ? "" : reader["SerialNo"].ToString();

                    memberinfo.SupAcctId = reader["SupAcctId"] == DBNull.Value ? "" : reader["SupAcctId"].ToString();
                    memberinfo.CustAcctId = reader["CustAcctId"] == DBNull.Value ? "" : reader["CustAcctId"].ToString();
                    memberinfo.CustName = reader["CustName"] == DBNull.Value ? "" : reader["CustName"].ToString();
                    memberinfo.ThirdCustId = reader["ThirdCustId"] == DBNull.Value ? "" : reader["ThirdCustId"].ToString();
                    memberinfo.IdType = reader["IdType"] == DBNull.Value ? "" : reader["IdType"].ToString();
                    memberinfo.IdCode = reader["IdCode"] == DBNull.Value ? "" : reader["IdCode"].ToString();
                    memberinfo.CustFlag = reader["CustFlag"] == DBNull.Value ? "" : reader["CustFlag"].ToString();
                    memberinfo.TotalAmount = reader["TotalAmount"] == DBNull.Value ? 0 : decimal.Parse(reader["TotalAmount"].ToString());
                    memberinfo.TotalBalance = reader["TotalBalance"] == DBNull.Value ? 0 : decimal.Parse(reader["TotalBalance"].ToString());
                    memberinfo.TotalFreezeAmount = reader["TotalFreezeAmount"] == DBNull.Value ? 0 : decimal.Parse(reader["TotalFreezeAmount"].ToString());
                    memberinfo.RelatedAcctId = reader["RelatedAcctId"] == DBNull.Value ? "" : reader["RelatedAcctId"].ToString();
                    memberinfo.AcctFlag = reader["AcctFlag"] == DBNull.Value ? "" : reader["AcctFlag"].ToString();
                    memberinfo.TranType = reader["TranType"] == DBNull.Value ? "" : reader["TranType"].ToString();
                    memberinfo.AcctName = reader["AcctName"] == DBNull.Value ? "" : reader["AcctName"].ToString();
                    memberinfo.BankCode = reader["BankCode"] == DBNull.Value ? "" : reader["BankCode"].ToString();
                    memberinfo.BankName = reader["BankName"] == DBNull.Value ? "" : reader["BankName"].ToString();
                    memberinfo.Address = reader["Address"] == DBNull.Value ? "" : reader["Address"].ToString();
                    memberinfo.OldRelatedAcctId = reader["OldRelatedAcctId"] == DBNull.Value ? "" : reader["OldRelatedAcctId"].ToString();
                    memberinfo.Reserve = reader["Reserve"] == DBNull.Value ? "" : reader["Reserve"].ToString();
                    memberinfo.LastOption = reader["LastOption"] == DBNull.Value ? "" : reader["LastOption"].ToString();
                }
            }
            return memberinfo;
        }
    }
}
