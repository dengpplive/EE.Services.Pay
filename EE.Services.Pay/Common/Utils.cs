using EE.Services.Pay.Model;
using EE.Services.Pay.Model.Res;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static EE.Services.Pay.Common.CommonEnums;
using EE.Services.Pay.Common.Ext;
using EE.Services.Pay.InertnetVer;
using System.ComponentModel;
using System.Threading;
namespace EE.Services.Pay.Common
{
    public class Utils
    {
        /// <summary>
        /// 对字节数组gbk编码得到的字符串
        /// </summary>
        /// <param name="buf">字节数组</param>
        /// <param name="offset">开始位置偏移</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public static string ToGBK(byte[] buf, int offset, int length)
        {
            return Encoding.GetEncoding("GBK").GetString(buf, offset, length);
        }
        /// <summary>
        /// 返回字符串gbk编码后的字节数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static byte[] ToByte(string str)
        {
            return Encoding.GetEncoding("GBK").GetBytes(str);
        }
        /// <summary>
        /// utf-8的格式序列化字节为字符串
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ToUTF8(byte[] buf, int offset, int length)
        {
            return Encoding.UTF8.GetString(buf, offset, length);
        }
        /// <summary>
        /// 字符串转换以UTF8字符编码的字节
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ToByteUTF8(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
        /// <summary>
        /// 在指定字节长度内填充数据 兼容双字节和汉字
        /// </summary>
        /// <param name="maxLen">最大字节数</param>
        /// <param name="strValue">数据值</param>
        /// <returns></returns>
        public static string ToData(string strValue, int maxLen)
        {
            if (strValue == null) strValue = "";
            if (maxLen <= 0) maxLen = 0;
            byte[] bytes = Enumerable.Repeat<byte>(32, maxLen).ToArray();
            var bData = ToByte(strValue);
            if (bytes.Length >= bData.Length)
                Array.Copy(bData, 0, bytes, 0, bData.Length);
            return ToGBK(bytes, 0, bytes.Length);
        }
        /// <summary>
        /// 将对象映射到hashTable
        /// </summary>
        /// <typeparam name="T">实例对象类型</typeparam>
        /// <param name="model">实例对象</param>
        /// <param name="hashTable">hashTable</param>
        /// <returns></returns>
        public static void ModelToHashTable<T>(T model, ExHashTable hashTable)
        {
            Type type = model.GetType();
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in props)
            {
                var name = property.Name;
                var val = Convert.ChangeType(property.GetValue(model), property.PropertyType);
                if (val == null) val = "";
                if (!hashTable.ContainsKey(name))
                {
                    hashTable.Add(name, val.ToString());
                }
            }
        }
        /// <summary>
        /// 将实例对象的基本属性使用指定的字符串连接起来
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="combineStr"></param>
        /// <returns></returns>
        public static string JoinModelString<T>(T model)
        {
            StringBuilder sbStr = new StringBuilder();
            Type type = model.GetType();
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in props)
            {
                //排序泛型
                if (property.PropertyType.IsGenericType) continue;

                var name = property.Name;
                var val = property.GetValue(model);
                val = Convert.ChangeType(val, property.PropertyType);
                if (val == null) val = "";
                if (property.PropertyType == typeof(decimal)) val = DecimalToString(val);
                sbStr.AppendFormat("{0}{1}", val, GlobalData.CombineStr);
            }
            return sbStr.ToString();
        }
        /// <summary>
        /// 显示实体的数据展示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ToString<T>(T model) where T : class
        {
            StringBuilder sbStr = new StringBuilder();
            var props = model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in props)
            {
                //排序泛型
                if (property.PropertyType.IsGenericType) continue;
                var name = property.Name;
                var val = Convert.ChangeType(property.GetValue(model), property.PropertyType);
                if (val == null) val = "";
                sbStr.AppendFormat("{0}={1}\r\n", property.Name, val);
            }
            return sbStr.ToString();
        }
        /// <summary>
        /// 跨行快付处理
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="model">实例对象</param>
        /// <returns></returns>
        public static string DiskFileToString<T>(T model)
        {
            List<string> list = new List<string>();
            Type type = model.GetType();
            string result = string.Empty;
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in props)
            {
                var name = property.Name;
                dynamic val = property.GetValue(model);

                if (property.PropertyType.IsGenericType
                       && property.PropertyType.Name.Contains("List"))
                {
                    foreach (dynamic item in val)
                    {
                        list.Add(DiskFileToString<dynamic>(item));
                    }
                    return string.Join("", list.ToArray());
                }
                else
                {
                    if (property.PropertyType.IsClass && !property.PropertyType.IsSealed)
                    {
                        list.Add(DiskFileToString<dynamic>(val));
                    }
                    else
                    {
                        val = Convert.ChangeType(val, property.PropertyType);
                        if (val == null) val = "";
                        if (property.PropertyType == typeof(decimal)) val = DecimalToString(val);
                        list.Add(val.ToString());
                    }
                }
            }
            return string.Join(GlobalData.CrossCombineStr, list.ToArray()) + "\r\n";
        }

        /// <summary>
        /// 数字小数位不足2位的补0处理
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string DecimalToString(object d)
        {
            string str = d.ToString();
            if (str.Contains("."))
            {
                string[] strArr = str.Split('.');
                if (strArr.Length == 2)
                {
                    string dex = strArr[0];
                    string point = strArr[1].PadRight(2, '0');
                    str = dex + "." + point;
                }
            }
            else
            {
                str += ".00";
            }
            return str;
        }
        /// <summary>
        /// 将返回的结果装换为DataResult实体
        /// </summary>
        /// <param name="keyDict"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public static DataResult ToDataResult(ExHashTable keyDict, string ver)
        {
            var result = new DataResult();
            if (keyDict.Count < 7) return result;
            if (keyDict.Contains("TargetSystem")) result.TargetSystem = (string)keyDict.Get("TargetSystem");
            if (keyDict.Contains("ThirdLogNo")) result.SerialNumber = (string)keyDict.Get("ThirdLogNo");
            if (keyDict.Contains("TranFunc")) result.FuncCode = (string)keyDict.Get("TranFunc");
            if (keyDict.Contains("RspCode")) result.RspCode = (string)keyDict.Get("RspCode");
            if (keyDict.Contains("RspMsg")) result.RspMsg = (string)keyDict.Get("RspMsg");
            if (keyDict.Contains("TrandateTime")) result.TrandateTime = (string)keyDict.Get("TrandateTime");
            if (keyDict.Contains("BodyMsg")) result.RspContent = (string)keyDict.Get("BodyMsg");
            if (keyDict.Contains("Qydm")) result.PartnerCode = (string)keyDict.Get("Qydm");
            if (keyDict.Contains("CounterId")) result.CounterId = (string)keyDict.Get("CounterId");
            if (keyDict.Contains("Data")) result.RecvData = (string)keyDict.Get("Data");
            result.Version = ver;
            return result;
        }
        /// <summary>
        /// 初始化返回结果的结构
        /// </summary>
        /// <param name="rspMsg">初始化描述</param>
        /// <returns></returns>
        public static ExHashTable InitRetDict(string rspMsg)
        {
            ExHashTable retKeyDict = new ExHashTable();
            retKeyDict.Add("Data", "");//接收到的原始数据
            retKeyDict.Add("TranFunc", "");//交易码
            retKeyDict.Add("TargetSystem", "");//接入系统
            retKeyDict.Add("BodyMsg", "");//响应内容        
            retKeyDict.Add("RspCode", "INT000");//响应码 INT000初始码
            retKeyDict.Add("RspMsg", rspMsg);//响应描述
            retKeyDict.Add("TrandateTime", "");//交易日期                      
            retKeyDict.Add("RspMsgLength", "0");//响应数据长度
            retKeyDict.Add("Qydm", "");//企业标识代码
            retKeyDict.Add("ThirdLogNo", "");//请求流水号    
            retKeyDict.Add("CounterId", "");//操作员
            return retKeyDict;
        }
        /// <summary>
        /// 检测输入数据
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="counterId">操作员号</param>
        public static void PayCheckData(string serialNumber, string counterId)
        {
            if (serialNumber.Length == 0) throw new PayException("请输入请求流水号");
            if (serialNumber.Length > 20) throw new PayException("请求流水号长度超过限制长度,最长为20位");
            if (!string.IsNullOrEmpty(counterId) && counterId.Length > 5) throw new PayException("操作员号字符数超过限制,最长为5位长度");
        }
        /// <summary>
        /// 获取接入的目标系统编号
        /// </summary>
        /// <param name="recvData">接收的报文数据</param>
        /// <returns></returns>
        public static string GetTargetSystem(string recvData)
        {
            string TargetSystem = string.Empty;
            if (recvData.Length > 6) TargetSystem = recvData.Substring(4, 2);
            return TargetSystem;
        }

        /// <summary>
        /// 转换成xml节点字符串
        /// </summary>
        /// <typeparam name="T">实例对象类型</typeparam>
        /// <param name="model">实例对象</param>
        /// <returns></returns>
        public static string ModelToXMLNode<T>(T model)
        {
            StringBuilder sbXML = new StringBuilder();
            Type type = model.GetType();
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in props)
            {
                var name = property.Name;
                dynamic val = Convert.ChangeType(property.GetValue(model), property.PropertyType);
                if (val == null) val = "";
                if (property.PropertyType.IsClass && !property.PropertyType.IsSealed)
                {
                    if (property.PropertyType.IsGenericType
                        && property.PropertyType.Name.Contains("List"))
                    {
                        //处理集合
                        string strItem = string.Empty;
                        foreach (var item in val)
                        {
                            strItem = ModelToXMLNode<dynamic>(item);
                            if (!string.IsNullOrEmpty(strItem))
                            {
                                sbXML.AppendFormat("<{0}>{1}</{0}>", name, strItem);
                            }
                        }
                        val = "";
                    }
                    else
                    {
                        val = ModelToXMLNode<dynamic>(val);
                    }
                }
                if (!string.IsNullOrEmpty(val.ToString()))
                {
                    sbXML.AppendFormat("<{0}>{1}</{0}>", name, val);
                }
            }
            return sbXML.ToString();
        }
        /// <summary>
        /// 解析xml片段
        /// </summary>
        /// <param name="xml">xml字符串</param>
        /// <returns></returns>
        public static dynamic LoadXML(string xml)
        {
            return new DynamicXml(xml);
        }
        /// <summary>
        /// 01：GBK缺省 02：UTF8  03：unicode  04：iso-8859-1
        /// </summary>
        /// <param name="messageBody">内容</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static int GetLengthByEncoding(string messageBody, string encoding)
        {
            int len = 0;
            encoding = encoding.ToLower();
            switch (encoding)
            {
                case "01":
                    len = Encoding.GetEncoding("GBK").GetBytes(messageBody).Length;
                    break;
                case "02":
                    len = Encoding.UTF8.GetBytes(messageBody).Length;
                    break;
                case "03":
                    len = Encoding.Unicode.GetBytes(messageBody).Length;
                    break;
                case "04":
                    len = Encoding.GetEncoding("ISO-8859-1").GetBytes(messageBody).Length;
                    break;
                default:
                    break;
            }
            return len;
        }
        /// <summary>
        /// 获取编码后的内容长度
        /// </summary>
        /// <param name="messageBody">内容</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static int GetLengthByEncoding(string messageBody, MessageEncoding encoding)
        {
            int len = 0;
            switch (encoding)
            {
                case MessageEncoding.GBK:
                    len = Encoding.GetEncoding("GBK").GetBytes(messageBody).Length;
                    break;
                case MessageEncoding.UTF8:
                    len = Encoding.UTF8.GetBytes(messageBody).Length;
                    break;
                case MessageEncoding.Unicode:
                    len = Encoding.Unicode.GetBytes(messageBody).Length;
                    break;
                case MessageEncoding.ISO_8859_1:
                    len = Encoding.GetEncoding("ISO-8859-1").GetBytes(messageBody).Length;
                    break;
                default:
                    break;
            }
            return len;
        }

        /// <summary>
        /// 将返回的数据转换为具体的实例对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="formString">依次按照顺利使用"&"隔开</param>
        /// <param name="funcCode">交易码</param>
        /// <returns></returns>
        public static T ToModelFromString<T>(string funcCode, string formString) where T : class, new()
        {
            T t = new T();
            if (string.IsNullOrEmpty(formString)) return t;
            int lastIndex = formString.LastIndexOf(GlobalData.CombineStr);
            if (lastIndex > 0)
                formString = formString.Substring(0, lastIndex);
            string[] strFormArr = formString.Split(new string[] { GlobalData.CombineStr }, StringSplitOptions.None);
            //处理查询的几个特殊的交易码的数据
            if (funcCode == "1010")
            {
                t = strFormArr.To_1010() as T;
            }
            else if (funcCode == "1016")
            {
                t = strFormArr.To_1016() as T;
            }
            else if (funcCode == "1324")
            {
                t = strFormArr.To_1324() as T;
            }
            else if (funcCode == "1325")
            {
                t = strFormArr.To_1325() as T;
            }
            else
            {
                var props = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                int arrLen = strFormArr.Length;
                int propsLength = props.Length;
                if (propsLength == arrLen)
                {
                    for (int i = 0; i < strFormArr.Length; i++)
                    {
                        PropertyInfo property = props[i];
                        if (!string.IsNullOrEmpty(strFormArr[i]))
                        {
                            dynamic val = Convert.ChangeType(strFormArr[i], property.PropertyType);
                            property.SetValue(t, val);
                        }
                    }
                }
            }
            return t;
        }
        /// <summary>
        /// 将返回的XML数据转换成具体的类
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">实例对象</param>
        /// <param name="d">DynamicXml对象</param>
        /// <returns></returns>
        public static T ToModelFromXML<T>(T t, dynamic d)
        {
            var props = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            for (int i = 0; i < props.Length; i++)
            {
                PropertyInfo property = props[i];
                string pName = property.Name;
                if (property.PropertyType.IsClass && !property.PropertyType.IsSealed)
                {
                    //处理集合
                    if (property.PropertyType.Name.Contains("List"))
                    {
                        var subType = property.PropertyType.GenericTypeArguments[0];                        
                        var mlist = Activator.CreateInstance(property.PropertyType);
                        foreach (dynamic item in d.list)
                        {
                            var m = Activator.CreateInstance(subType);
                            m = ToModelFromXML(m, item);
                            mlist.GetType().GetMethod("Add").Invoke(mlist, new Object[] { m });
                        }
                        //转换
                        dynamic val = Convert.ChangeType(mlist, property.PropertyType);
                        property.SetValue(t, val);
                    }
                }
                else
                {
                    //基本数据
                    if (property.PropertyType.IsClass && property.PropertyType.IsSealed)
                    {
                        //处理
                        string val = d[pName].Value;
                        if (!string.IsNullOrEmpty(val))
                        {
                            property.SetValue(t, val);
                        }
                    }
                }
            }
            return t;
        }
        /// <summary>
        /// 获取List<DynamicXml>内部的XML字符串
        /// </summary>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public static string InnerXml(List<DynamicXml> list)
        {
            return (list as List<DynamicXml>).InnerXml();
        }

        /// <summary>
        /// 解析枚举类型数据
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns></returns>
        public static List<EnumProp> ToEnumProp<T>()
        {
            var list = new List<EnumProp>();
            typeof(T).GetEnumNames().ForEach(prop =>
            {
                T item = (T)Enum.Parse(typeof(T), prop);
                string name = item.ToString();
                int val = (int)Convert.ChangeType(item, typeof(int));
                string desc = string.Empty;
                var type = item.GetType();
                if (Enum.IsDefined(type, item))
                {
                    var field = type.GetField(Enum.GetName(type, item));
                    if (field != null)
                    {
                        if (Attribute.IsDefined(field, typeof(DescriptionAttribute)))
                        {
                            var descriptionAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                            if (descriptionAttribute != null) desc = descriptionAttribute.Description;
                        }
                    }
                }
                list.Add(new EnumProp()
                {
                    Name = name,
                    Value = val,
                    Desc = desc
                });
            });
            return list;
        }

        /// <summary>
        /// 只能运行一个进程
        /// </summary>
        /// <param name="ac"></param>
        public static void RunOne(Action ac)
        {

            bool flag = false;
            string name = "Pay_" + AppDomain.CurrentDomain.Id;
            Mutex mutex = new Mutex(true, name, out flag);
            if (!flag)
            {
                WriteInfo("该控制台程序存在已开启的进程！");
                System.Threading.Thread.Sleep(5000);//线程挂起5秒钟 
                Environment.Exit(1);//退出程序     
            }
            else
            {
                ac?.Invoke();
            }
        }
        /// <summary>
        /// 接收控制台输入命令按照顺序匹配执行
        /// </summary>
        /// <param name="cmd">命令</param>
        /// <param name="ac">执行方法</param>
        public static void ReadAndExecCmd(string cmd, Action ac = null)
        {
            string readLine = string.Empty;
            while ((readLine = Console.ReadLine()).ToLower() != "exit")
            {
                if (cmd.ToLower() == readLine)
                {
                    ac?.Invoke();
                    break;
                }
            }
        }
        #region 输出屏幕信息
        public static void WriteMessage(string msg, params object[] args)
        {
            Console.WriteLine(msg, args);
        }
        public static void WriteInfo(string info, params object[] args)
        {
            WriteTimeStamp();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(info, args);
            Console.ResetColor();
        }
        public static void WriteError(string error, params object[] args)
        {
            WriteTimeStamp();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error, args);
            Console.ResetColor();
        }
        public static void WriteTimeStamp()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(DateTime.Now.ToString("[MM/dd HH:mm:ss:fff]：\t"));
            Console.ResetColor();
        }
        public static void WriteSeparator(char chr, int count = -1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            count = count < 0 ? 80 : count;
            Console.WriteLine(new string(chr, count));
            Console.ResetColor();
        }
        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }
        #endregion

    }
    /// <summary>
    /// 枚举属性
    /// </summary>
    public class EnumProp
    {
        /// <summary>
        /// 枚举名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 枚举索引值
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// 枚举描述和说明 
        /// </summary>
        public string Desc { get; set; }
    }
}
