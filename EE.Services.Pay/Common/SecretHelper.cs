using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace EE.Services.Pay.Common
{
    /// <summary>
    /// ���ܽ��ܹ�����
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


        #region �����ļ�hashֵ��md5ֵ
        /// <summary>
        /// �����ļ��� MD5 ֵ
        /// </summary>
        /// <param name="fileName">Ҫ���� MD5 ֵ���ļ�����·��</param>
        /// <returns>MD5 ֵ16�����ַ���</returns>
        public static string MD5File(string fileName)
        {
            return HashFile(fileName, "md5");
        }

        /// <summary>
        /// �����ļ��� sha1 ֵ
        /// </summary>
        /// <param name="fileName">Ҫ���� sha1 ֵ���ļ�����·��</param>
        /// <returns>sha1 ֵ16�����ַ���</returns>
        public static string SHA1File(string fileName)
        {
            return HashFile(fileName, "sha1");
        }

        /// <summary>
        /// �����ļ��Ĺ�ϣֵ
        /// </summary>
        /// <param name="fileName">Ҫ�����ϣֵ���ļ�����·��</param>
        /// <param name="algName">�㷨:sha1,md5</param>
        /// <returns>��ϣֵ16�����ַ���</returns>
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
        /// �����ϣֵ
        /// </summary>
        /// <param name="stream">Ҫ�����ϣֵ�� Stream</param>
        /// <param name="algName">�㷨:sha1,md5</param>
        /// <returns>��ϣֵ�ֽ�����</returns>
        private static byte[] HashData(System.IO.Stream stream, string algName)
        {
            System.Security.Cryptography.HashAlgorithm algorithm;
            if (algName == null)
            {
                throw new ArgumentNullException("algName ����Ϊ null");
            }
            if (string.Compare(algName, "sha1", true) == 0)
            {
                algorithm = System.Security.Cryptography.SHA1.Create();
            }
            else
            {
                if (string.Compare(algName, "md5", true) != 0)
                {
                    throw new Exception("algName ֻ��ʹ�� sha1 �� md5");
                }
                algorithm = System.Security.Cryptography.MD5.Create();
            }
            return algorithm.ComputeHash(stream);
        }

        /// <summary>
        /// �ֽ�����ת��Ϊ16���Ʊ�ʾ���ַ���
        /// </summary>
        private static string ByteArrayToHexString(byte[] buf)
        {
            return BitConverter.ToString(buf).Replace("-", "");
        }
        #endregion
    }
}
