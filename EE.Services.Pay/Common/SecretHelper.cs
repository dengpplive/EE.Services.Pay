using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace EE.Services.Pay.Common
{
    /// <summary>
    /// 加密解密工具类
    /// </summary>
    public class SecretHelper
    {
        public SecretHelper()
        {
        }

        public static string DesEncrypt(string strText, string strEncrKey)
        {
            if (string.IsNullOrEmpty(strText) || string.IsNullOrEmpty(strEncrKey)) return strText;
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, strEncrKey.Length));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string DesDecrypt(string strText, string sDecrKey)
        {
            if (string.IsNullOrEmpty(strText) || string.IsNullOrEmpty(sDecrKey)) return strText;
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] inputByteArray = new Byte[strText.Length];
            byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(ms.ToArray());
        }

        public void DesEncrypt(string m_InFilePath, string m_OutFilePath, string strEncrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
            FileStream fin = new FileStream(m_InFilePath, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(m_OutFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            byte[] bin = new byte[100];
            long rdlen = 0;
            long totlen = fin.Length;
            int len;
            var des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            encStream.Close();
            fout.Close();
            fin.Close();
        }

        public void DesDecrypt(string m_InFilePath, string m_OutFilePath, string sDecrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            FileStream fin = new FileStream(m_InFilePath, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(m_OutFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);

            byte[] bin = new byte[100];
            long rdlen = 0;
            long totlen = fin.Length;
            int len;

            var des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);

            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }

            encStream.Close();
            fout.Close();
            fin.Close();
        }

        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return System.Text.Encoding.UTF8.GetString(result);
        }

        public static string MD5Decrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.TransformFinalBlock(System.Text.Encoding.Default.GetBytes(strText), 0, strText.Length);
            return System.Text.Encoding.UTF8.GetString(result);
        }


        #region 计算文件hash值和md5值
        /// <summary>
        /// 计算文件的 MD5 值
        /// </summary>
        /// <param name="fileName">要计算 MD5 值的文件名和路径</param>
        /// <returns>MD5 值16进制字符串</returns>
        public static string MD5File(string fileName)
        {
            return HashFile(fileName, "md5");
        }

        /// <summary>
        /// 计算文件的 sha1 值
        /// </summary>
        /// <param name="fileName">要计算 sha1 值的文件名和路径</param>
        /// <returns>sha1 值16进制字符串</returns>
        public static string SHA1File(string fileName)
        {
            return HashFile(fileName, "sha1");
        }

        /// <summary>
        /// 计算文件的哈希值
        /// </summary>
        /// <param name="fileName">要计算哈希值的文件名和路径</param>
        /// <param name="algName">算法:sha1,md5</param>
        /// <returns>哈希值16进制字符串</returns>
        private static string HashFile(string fileName, string algName)
        {
            if (!System.IO.File.Exists(fileName))
                return string.Empty;

            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            byte[] hashBytes = HashData(fs, algName);
            fs.Close();
            return ByteArrayToHexString(hashBytes);
        }

        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="stream">要计算哈希值的 Stream</param>
        /// <param name="algName">算法:sha1,md5</param>
        /// <returns>哈希值字节数组</returns>
        private static byte[] HashData(System.IO.Stream stream, string algName)
        {
            System.Security.Cryptography.HashAlgorithm algorithm;
            if (algName == null)
            {
                throw new ArgumentNullException("algName 不能为 null");
            }
            if (string.Compare(algName, "sha1", true) == 0)
            {
                algorithm = System.Security.Cryptography.SHA1.Create();
            }
            else
            {
                if (string.Compare(algName, "md5", true) != 0)
                {
                    throw new Exception("algName 只能使用 sha1 或 md5");
                }
                algorithm = System.Security.Cryptography.MD5.Create();
            }
            return algorithm.ComputeHash(stream);
        }

        /// <summary>
        /// 字节数组转换为16进制表示的字符串
        /// </summary>
        private static string ByteArrayToHexString(byte[] buf)
        {
            return BitConverter.ToString(buf).Replace("-", "");
        }
        #endregion
    }
}
