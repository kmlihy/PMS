using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace PMS.BLL
{
    public class Security
    {
        /// <summary>
        /// 数据Hash加密处理
        /// </summary>
        /// <param name="source">要Hash处理的数据</param>
        /// <returns></returns>
        public static string SHA256Hash(string source)
        {
            //把数据编码为字节数组
            //byte[] dataBytes = Encoding.UTF8.GetBytes(source);
            //创建哈希类实例
            //SHA256Managed sha = new SHA256Managed();
            //byte[] hashBytes = sha.ComputeHash(dataBytes);

            //创建哈希类实例
            SHA256 sha = new SHA256CryptoServiceProvider();
            //把数据编码为字节数组
            byte[] dataBytes = System.Text.Encoding.ASCII.GetBytes(source);
            byte[] hashBytes = sha.ComputeHash(dataBytes);
            //返回哈希后的字符串
            return Convert.ToBase64String(hashBytes);
        }

        public static string BytesToHexString(byte[] input)
        {
            StringBuilder hexString = new StringBuilder(64);

            for (int i = 0; i < input.Length; i++)
            {
                hexString.Append(String.Format("{0:X2}", input[i]));
            }
            return hexString.ToString();
        }
        public static byte[] HexStringToBytes(string hex)
        {
            if (hex.Length == 0)
            {
                return new byte[] { 0 };
            }

            if (hex.Length % 2 == 1)
            {
                hex = "0" + hex;
            }

            byte[] result = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length / 2; i++)
            {
                result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            return result;
        }


        //DES默认密钥向量
        private static byte[] Keys = { 0x32, 0x94, 0x65, 0x43, 0xDB, 0xAB, 0xCD, 0xEF };
        private static string cryptKey = "dbwhmlgd";
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string Encrypt(string encryptString)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(cryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string Decrypt(string decryptString)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(cryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

    }
}
