using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EE.Services.PingAnPayServices.Model
{
    /// <summary>
    /// 证件类型
    /// </summary>
    [Serializable]
    public class CardType
    {

        public List<IdType> list { get; set; } = new List<IdType>();
        public class IdType
        {
            /// <summary>
            /// 证件类型id
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// 证件名称
            /// </summary>
            public string Desc { get; set; }
        }
    }
}