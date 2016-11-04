using System;
namespace EE.Services.Pay.Common
{
    /// <summary>
    /// AssistantHelper 的摘要说明。 随机数生成
    /// </summary>
    public sealed class AssistantHelper
    {
        /// <summary>
        /// 随机种子值（防止速度过快造成的重复）
        /// </summary>
        /// <returns></returns>
        public static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        /// <summary>
        /// 生成带有日期格式的订单号
        /// </summary>
        /// <param name="len">结尾生成几位随机数</param>
        /// <param name="dataFormat">日期的格式</param>
        /// <param name="prxFix">订单号的前缀</param>
        /// <returns></returns>
        public static string GetOrderId(int len, string dataFormat = "yyyyMMddHHmmssfff", string prxFix = "")
        {
            return string.Format("{0}{1}{2}", prxFix, DateTime.Now.ToString(dataFormat), GetRandomNumber(len));
        }
        /// <summary>
        /// 生成订单号
        /// </summary>
        /// <param name="prxFix"></param>
        /// <returns></returns>
        public static string GetOrderId(string prxFix)
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            long l = BitConverter.ToInt64(buffer, 0);
            return prxFix + l.ToString();
        }
        /// <summary>
        /// 获取指定长度的随机数字
        /// </summary>
        /// <param name="NumberLength">生成随机数字的个数</param>
        /// <returns></returns>
        public static string GetRandomNumber(int NumberLength)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9";
            string[] allCharArray = allChar.Split(',');
            string RandomNumber = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < NumberLength; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(allCharArray.Length - 1);
                while (temp == t)
                {
                    t = rand.Next(allCharArray.Length - 1);
                }
                temp = t;
                RandomNumber += allCharArray[t];
            }
            return RandomNumber;
        }
        /// <summary>
        /// 26个字母和数字 生成指定长度的随机代码
        /// </summary>
        /// <param name="lenth">位数长度</param>
        /// <returns></returns>
        public static string GenerateCheckCodeNoncestr(int lenth)
        {
            char[] CharArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 
                                'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 
                                'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
                                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 
                                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 
                                's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 
                                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
                               };
            string sCode = "";
            Random random = new Random();
            for (int i = 0; i < lenth; i++)
            {
                sCode += CharArray[random.Next(CharArray.Length)];
            }
            return sCode.Trim();
        }

        /// <summary>
        /// 从字符串里随机得到，规定个数的字符串.
        /// </summary>
        /// <param name="allChar"></param>
        /// <param name="CodeCount"></param>
        /// <returns></returns>
        private string GetRandomCode(string allChar, int CodeCount)
        {
            //string allChar = "1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z"; 
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(allCharArray.Length - 1);
                while (temp == t)
                {
                    t = rand.Next(allCharArray.Length - 1);
                }
                temp = t;
                RandomCode += allCharArray[t];
            }
            return RandomCode;
        }


        /// <summary>
        /// 产生验证码 
        /// </summary>
        /// <param name="type">产生的验证码类型 1 数字，2 字母和数字 3 字母</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public string CreateCode(int type, int length)
        {
            int number;
            string code = string.Empty;
            Random random = new Random();
            if (length < 1)
            {
                return string.Empty;
            }
            switch (type)
            {
                case 1:
                    for (int i = 0; i < length; i++)
                    {
                        number = random.Next();
                        code += (char)('0' + (char)(number % 10));     //生成数字
                    }
                    break;
                case 2:
                    for (int i = 0; i < length; i++)
                    {
                        number = random.Next();
                        if (number % 2 == 0)
                        {
                            code += (char)('0' + (char)(number % 10));     //生成数字
                        }
                        else
                        {
                            code += (char)('A' + (char)(number % 26));     //生成字母
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < length; i++)
                    {
                        number = random.Next();
                        code += (char)('A' + (char)(number % 26));     //生成字母
                    }
                    break;
            }
            return code;
        }
    }
}
