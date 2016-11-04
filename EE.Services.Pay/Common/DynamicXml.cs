using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace EE.Services.Pay.Common
{
    /// <summary>
    /// XElement动态解析 获取的元素如果是集合 
    /// 使用索引 "集合[0]" 获取单个元素， 元素的值使用"集合[0].元素名.Value"取值,"元素.InnerXml"获取子元素xml,"元素[属性名]"获取属性值
    /// </summary>
    public class DynamicXml : DynamicObject, IEnumerable
    {
        private XElement Root;


        public DynamicXml(string xml)
        {
            Root = XElement.Parse(xml);
        }
        public DynamicXml(XElement xe)
        {
            Root = xe;
        }

        #region  属性索引器
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetPropValue(string name)
        {
            if (Root == null)
            {
                return String.Empty;
            }
            var attr = Root.Attribute(name);
            if (attr != null)
            {
                return attr.Value;
            }
            else
            {
                return String.Empty;
            }
        }
        /// <summary>
        /// 获取元素值
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="result"></param>
        private void GetElementValue(string Name, out object result)
        {
            result = string.Empty;
            //获取子列表
            var xList = Root.Elements(Name);
            //异常
            if (xList == null || !xList.Any())
            {
                //所有不已"-"开头替换为"_"取值
                if (!Name.StartsWith("_"))
                {
                    xList = Root.Elements(Name.Replace("_", "-"));
                }
                if (xList == null) return;
            }
            //子列表不为空
            if (xList.Any())
            {
                if (xList.Count() > 1)
                {
                    var list = new List<DynamicXml>();
                    foreach (var item in xList)
                    {
                        list.Add(new DynamicXml(item));
                    }
                    result = list;
                }
                else
                {
                    result = new DynamicXml(xList.FirstOrDefault());
                }
            }
            else
            {
                //获取属性值
                result = GetPropValue(Name);
            }
        }
        #endregion

        #region ///Load 加载xml文件
        public DynamicXml()
        {
        }
        public void Load(string uri)
        {
            Root = XElement.Load(uri);
        }
        #endregion

        #region ///Parse 序列化xml字符串
        public void Parse(string xml)
        {
            Root = XElement.Parse(xml);
        }
        #endregion

        #region ///Parse 序列化xml字符串
        public void Parse(XElement xe)
        {
            Root = xe;
        }
        //    protected DynamicXml(IEnumerable<XElement> elements)
        //{
        //    _elements = new List<XElement>(elements);
        //}

        #endregion

        #region ///ToString
        /// <summary>
        /// 返回此节点的缩进 XML或者文本数据
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Root == null)
            {
                return String.Empty;
            }
            return Root.ToString();
        }
        #endregion

        #region ///TryGetMember
        /// <summary>
        /// 当获取非静态声明代码调用
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = String.Empty;
            //还没有匹配xml，返回空字符串
            if (Root == null)
            {
                result = String.Empty;
            }
            //-------处理自定义的2个属性-----------
            if (binder.Name.ToLower() == "value")
            {
                result = Root.Value;
                return true;
            }
            if (binder.Name.ToLower() == "innerxml")
            {
                var doc = new XmlDocument();
                var xmlElement = doc.ReadNode(Root.CreateReader()) as XmlElement;
                result = xmlElement.InnerXml;
                return true;
            }
            GetElementValue(binder.Name, out result);
            Console.WriteLine("TryGetMember被调用了,Name:{0}", binder.Name);
            //return base.TryGetMember(binder, out result);
            return true;
        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return base.GetDynamicMemberNames();
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            Console.WriteLine("TrySetMember被调用了,Name:{0}", binder.Name);
            return base.TrySetMember(binder, value);
        }
        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            Console.WriteLine("TryInvoke被调用了");
            return base.TryInvoke(binder, args, out result);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.WriteLine("TryInvokeMember被调用了,Name:{0}", binder.Name);
            return base.TryInvokeMember(binder, args, out result);
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            result = String.Empty;
            if (indexes.Length > 0)
            {
                string name = indexes[0].ToString();
                if (name.StartsWith("@"))
                {
                    result = GetPropValue(name.Substring(1));
                }
                else
                {
                    GetElementValue(name, out result);
                }
            }
            return true;
        }
        #endregion

        //public override DynamicMetaObject GetMetaObject(Expression parameter)
        //{
        //    return base.GetMetaObject(parameter);
        //}
        //public override bool TryCreateInstance(CreateInstanceBinder binder, object[] args, out object result)
        //{
        //    return base.TryCreateInstance(binder, args, out result);
        //}
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            return base.TryConvert(binder, out result);
        }
        //public override bool TryUnaryOperation(UnaryOperationBinder binder, out object result)
        //{
        //    return base.TryUnaryOperation(binder, out result);
        //}

        public IEnumerator GetEnumerator()
        {
            foreach (var element in Root.Elements())
            {
                yield return new DynamicXml(element);
            }
        }
    }
}
