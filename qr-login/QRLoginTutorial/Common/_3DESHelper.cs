using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace QRLoginTutorial.Common
{
    public class _3DESHelper
    {
        #region------- 3DES加密CBC模式字符窜加密.----------
        /// <summary>
        /// 3DES加密CBC模式字符窜加密.
        /// </summary>
        /// <param name="str">需加密的字符窜</param>
        /// <param name="skey">秘钥</param>
        /// <returns></returns>
        public static string EncodeCBCstr(string str, string skey)
        {
            try
            {
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                byte[] key = Convert.FromBase64String(skey);
                byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                byte[] data = utf8.GetBytes(str);
                //字符串加密
                byte[] ret = Des3EncodeCBC(key, iv, data);
                return Convert.ToBase64String(ret);
            }
            catch (Exception)
            {
                return str;
            }
        }
        /// <summary>
        /// DES CBC模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        public static byte[] Des3EncodeCBC(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;             //默认值
                tdsp.Padding = PaddingMode.PKCS7;       //默认值

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region --------3DES加密CBC模式字符窜解密---------
        /// <summary>
        /// 3DES加密CBC模式字符窜解密.
        /// </summary>
        /// <param name="str">需解密的字符窜</param>
        /// <param name="skey">秘钥</param>
        /// <returns></returns>
        public static string DecodeCBCstr(string str, string skey)
        {
            try
            {
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                byte[] key = Convert.FromBase64String(skey);
                byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                byte[] data = Convert.FromBase64String(str);
                byte[] ret = Des3DecodeCBC(key, iv, data);
                return utf8.GetString(ret).Replace("\0", "");

            }
            catch (Exception)
            {
                return str;
            }
        }

        /// <summary>
        /// DES CBC模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        public static byte[] Des3DecodeCBC(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return fromEncrypt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}