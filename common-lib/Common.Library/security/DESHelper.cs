using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.security
{
    public class DESHelper
    {
        #region------- 3DES加密CBC模式字符窜加密.----------
        /// <summary>
        /// 3DES加密CBC模式字符串加密
        /// </summary>
        /// <param name="plainString">需加密的字符窜</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string EncodeCBCstr(string plainString, string key)
        {
            try
            {
                byte[] byteKey = Convert.FromBase64String(key);
                byte[] byteIV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                byte[] byteArray = Encoding.UTF8.GetBytes(plainString);

                //字符串加密
                byte[] byteResult = Des3EncodeCBC(byteKey, byteIV, byteArray);
                return Convert.ToBase64String(byteResult);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// DES CBC模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        private static byte[] Des3EncodeCBC(byte[] key, byte[] iv, byte[] data)
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
                CryptoStream cStream = new CryptoStream(mStream, tdsp.CreateEncryptor(key, iv), CryptoStreamMode.Write);

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
        /// 3DES加密CBC模式字符串解密
        /// </summary>
        /// <param name="plainString">需解密的字符窜</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string DecodeCBCstr(string plainString, string key)
        {
            try
            {
                byte[] byteKey = Convert.FromBase64String(key);
                byte[] byteIV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                byte[] byteArray = Convert.FromBase64String(plainString);

                //字符串解密
                byte[] byteResult = Des3DecodeCBC(byteKey, byteIV, byteArray);
                return Encoding.UTF8.GetString(byteResult).TrimEnd(new char[] { '\0' });

            }
            catch (Exception)
            {
                return plainString;
            }
        }

        /// <summary>
        /// DES CBC模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        private static byte[] Des3DecodeCBC(byte[] key, byte[] iv, byte[] data)
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
                CryptoStream csDecrypt = new CryptoStream(msDecrypt, tdsp.CreateDecryptor(key, iv), CryptoStreamMode.Read);

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
