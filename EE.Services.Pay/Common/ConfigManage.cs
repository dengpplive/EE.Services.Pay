using EE.Services.Pay.Model;
using System.IO;
using System.Text;
namespace EE.Services.Pay.Common
{
    public class ConfigManage
    {
        /// <summary>
        /// 获取平安的支付设置的参数信息
        /// </summary>
        /// <returns></returns>
        public static PinganPayConfig GetPinganPayConfig()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"XmlConfig\PinganPayConfig.xml");
            PinganPayConfig answerCode = ConfigHelper.XmlDeserializeFromFile<PinganPayConfig>(path, Encoding.Default);
            return answerCode;
        }
        public static void SetPinganPayConfig(PinganPayConfig pinganPayConfig)
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"XmlConfig\PinganPayConfig.xml");
            ConfigHelper.XmlSerializeToFile(pinganPayConfig, path, Encoding.Default);
        }

        /// <summary>
        /// 获取应答码列表
        /// </summary>
        /// <returns></returns>
        public static AnswerCode GetAnswerList()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"XmlConfig\AnswerList.xml");
            AnswerCode answerCode = ConfigHelper.XmlDeserializeFromFile<AnswerCode>(path, Encoding.Default);
            return answerCode;
        }
        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        public static ProviceCode GetProviceList()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"XmlConfig\Province.xml");
            ProviceCode proviceCode = ConfigHelper.XmlDeserializeFromFile<ProviceCode>(path, Encoding.Default);
            return proviceCode;
        }
        /// <summary>
        /// 获取银行列表
        /// </summary>
        /// <returns></returns>
        public static BankCode GetBankCodeList()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"XmlConfig\BankCode.xml");
            BankCode bankCode = ConfigHelper.XmlDeserializeFromFile<BankCode>(path, Encoding.Default);
            return bankCode;
        }
    }
}
