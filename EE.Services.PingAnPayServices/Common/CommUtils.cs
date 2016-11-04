using EE.Services.Pay.Model;
using EE.Services.PingAnPayServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EE.Services.PingAnPayServices.Common
{
    public class CommUtils
    {
        public static Result ToResult(DataResult result)
        {
            return new Result()
            {
                CounterId = result.CounterId,
                FuncCode = result.FuncCode,
                Version = result.Version,
                Model = result.Model,
                RspCode = result.RspCode,
                RspContent = result.RspContent,
                RspMsg = result.RspMsg,
                SerialNumber = result.SerialNumber,
                TrandateTime = result.TrandateTime
            };
        }
    }
}