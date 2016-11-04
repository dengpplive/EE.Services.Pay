using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EE.Services.Pay.Common
{
    /// <summary>
    /// 常用的文件操作类
    /// </summary>
    public class FileHelper
    {
        public static string AppPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        /// <summary>
        /// 读取二进制数据
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] ReadBinaryFile(string path, bool IsCurrent = true, Encoding encoding = null)
        {
            byte[] data = null;
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                if (IsCurrent)
                {
                    path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
                }
                path = System.IO.Path.GetFullPath(path);
                if (File.Exists(path))
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs, (encoding == null ? Encoding.Default : encoding));
                    data = new byte[fs.Length];
                    br.Read(data, 0, data.Length);
                }
            }
            catch (Exception)
            {
                data = null;
            }
            finally
            {
                if (br != null)
                {
                    br.Close();
                    br = null;
                }
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }
            }
            return data;
        }
        /// <summary>
        /// 读取文本文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadTextFile(string path, bool IsCurrent = true, Encoding encoding = null)
        {
            string strData = "";
            try
            {
                if (IsCurrent)
                {
                    path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
                }
                path = System.IO.Path.GetFullPath(path);
                StreamReader sr = new StreamReader(path, (encoding == null ? Encoding.Default : null));
                strData = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception)
            {
                strData = "";
            }
            return strData;
        }

        /// <summary>
        /// 保存文本数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool SaveFile(string path, List<string> list, bool IsCurrent = true, Encoding encoding = null)
        {
            bool strData = false;
            try
            {
                if (IsCurrent)
                {
                    path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
                }
                path = System.IO.Path.GetFullPath(path);
                StreamWriter sw = new StreamWriter(path, true, (encoding == null ? Encoding.Default : encoding));
                foreach (string item in list)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
                sw.Dispose();
                strData = true;
            }
            catch (Exception)
            {
                strData = false;
            }
            return strData;
        }
        /// <summary>
        /// 保存文本数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static bool SaveFile(string path, string Data, bool IsCurrent = true, Encoding encoding = null)
        {
            bool strData = false;
            try
            {
                if (IsCurrent)
                {
                    path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
                }
                path = System.IO.Path.GetFullPath(path);
                string tempDir = System.IO.Path.GetDirectoryName(path);
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }
                StreamWriter sw = new StreamWriter(path, true, (encoding == null ? Encoding.Default : encoding));
                sw.Write(Data);
                sw.Close();
                sw.Dispose();
                strData = true;
            }
            catch (Exception)
            {
                strData = false;
            }
            return strData;
        }
        /// <summary>
        /// 保存二进制数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static bool SaveFile(string path, byte[] Data, bool IsCurrent = true, Encoding encoding = null)
        {
            bool strData = false;
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                if (IsCurrent)
                {
                    path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
                }
                path = System.IO.Path.GetFullPath(path);
                string tempDir = System.IO.Path.GetDirectoryName(path);
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }
                fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite); //初始化FileStream对象
                bw = new BinaryWriter(fs, (encoding == null ? Encoding.Default : encoding));
                bw.Write(Data);

                strData = true;
            }
            catch (Exception)
            {
                strData = false;
            }
            finally
            {
                if (bw != null)
                {
                    bw.Flush();
                    bw.Close();
                    bw = null;
                }
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }
            }
            return strData;
        }

        /// <summary>
        /// 过滤文件名关键字
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string FilterFileName(string filename)
        {
            filename = filename.Replace("/", "");
            filename = filename.Replace("\\", "");
            filename = filename.Replace("|", "");
            filename = filename.Replace(":", "");
            filename = filename.Replace("*", "");
            filename = filename.Replace("?", "");
            filename = filename.Replace("\"", "");
            filename = filename.Replace(">", "");
            filename = filename.Replace(">", "");
            return filename;
        }

        /// <summary>
        /// 对象序列化到xml文件
        /// </summary>
        /// <param name="serializeObject"></param>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static bool SerializeToFile(object serializeObject, string filePath, Encoding encoding)
        {
            if (serializeObject == null || string.IsNullOrEmpty(filePath)) return false;
            if (File.Exists(filePath) == true)
            {
                File.Delete(filePath);
            }
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                XmlTextWriter writer = new XmlTextWriter(fileStream, encoding);
                writer.Formatting = Formatting.Indented;
                XmlSerializer xmlSerializer = new XmlSerializer(serializeObject.GetType());
                xmlSerializer.Serialize(writer, serializeObject);
                fileStream.Flush();
                fileStream.Close();
                return true;
            }
        }

        public static bool SerializeToFile(object serializeObject, string filePath)
        {
            return SerializeToFile(serializeObject, filePath, Encoding.Default);
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object DeSerializeFromFile(string filePath, Type targetType)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                fileStream.Position = 0;
                XmlSerializer xmlSerializer = new XmlSerializer(targetType);
                object result = xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return result;
            }
        }
        /// <summary>
        /// 检测文件是否被占用
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsInUsing(string fileName)
        {
            bool result = false;
            try
            {
                FileStream fs = File.OpenWrite(fileName);
                fs.Close();
            }
            catch
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 扫描指定目录下面的所有文件 ，返回相对原始目录的路径列表
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static List<string> ScanDirFile(string dir)
        {
            var list = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo item in files)
            {
                list.Add(dirInfo.Name + "/" + item.Name);
            }
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            foreach (DirectoryInfo item in dirs)
            {
                list.AddRange(ScanDirFile(item.FullName).Select(p => dirInfo.Name + "/" + p).ToArray());
            }
            return list;
        }

    }
}
