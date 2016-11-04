using System;
using System.Collections;
using System.Text;

namespace EE.Services.Pay.Common
{
    /// <summary>
    /// 无排序哈希表
    /// </summary>
    public class ExHashTable : Hashtable
    {
        private ArrayList list = new ArrayList();
        public override void Add(object key, object value)
        {
            if (!base.ContainsKey(key))
            {
                base.Add(key, value);
                list.Add(key);
            }
        }
        public override void Clear()
        {
            base.Clear();
            list.Clear();
        }
        public Object Get(string key)
        {
            return base[key];
        }
        public void Set(string key, object val)
        {
            if (base.ContainsKey(key))
                base[key] = val;
        }
        public override void Remove(object key)
        {
            if (base.ContainsKey(key))
            {
                base.Remove(key);
                list.Remove(key);
            }
        }
        public override ICollection Keys
        {
            get
            {
                return list;
            }
        }

        public override string ToString()
        {
            StringBuilder sbText = new StringBuilder();
            foreach (var key in list)
            {
                sbText.AppendFormat("{0}=[{1}]\r\n", key, base[key]);
            }
            return sbText.ToString();
        }

    }
}
