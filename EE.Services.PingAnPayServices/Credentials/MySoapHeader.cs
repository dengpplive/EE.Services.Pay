using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace EE.Services.PingAnPayServices.Credentials
{
    public class MySoapHeader : SoapHeader
    {
        public CredentialParam Param = new CredentialParam();
        public MySoapHeader()
        {
        }

        public bool IsValid()
        {
            if (this.Param.UserName == "djy")
            {
                return true;
            }
            else
            {
            }
            return false;
        }

    }
}