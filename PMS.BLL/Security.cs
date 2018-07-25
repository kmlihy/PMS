using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

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

        
    }
}
