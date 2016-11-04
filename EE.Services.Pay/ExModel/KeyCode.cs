using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model
{
    [Serializable]
    public class KeyCode
    {
        public string Key { get; set; }
        public string Desc { get; set; }
    }
}
