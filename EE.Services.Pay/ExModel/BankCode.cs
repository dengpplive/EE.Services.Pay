using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class BankCode
    {
        public List<KeyCode> BankCodeList = new List<KeyCode>();
    }
}
