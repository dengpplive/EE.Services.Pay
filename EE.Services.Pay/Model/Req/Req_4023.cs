using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 5.4.2 集团子账户列表查询 [4023]
    /// </summary>
    [Serializable]
    public partial class Req_4023
    {
        /// <summary>
        /// 总账号 总账号与子账号二选一必输
        /// </summary>
        public string AC { get; set; }
        /// <summary>
        /// 子账号 重要]第一次查询该项不输入，若有翻页送前一次查询循环体里面最后一条记录的子账户
        /// </summary>
        public string SUBAC { get; set; }       

    }
}
