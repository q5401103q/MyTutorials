using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.security
{
    public class AESHelper
    {
        #region CBC加密模式，NoPadding偏移
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="returnNull">加密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>密文</returns>
        public static string EncryptByCBC(string plainStr, string key, string iv = "abcdefgh12345678", bool returnNull = false)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(key);
            byte[] bIV = Encoding.UTF8.GetBytes(iv);
            byte[] byteArray = Encoding.UTF8.GetBytes(plainStr);

            string encrypt = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.Zeros;
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();
            
            return returnNull ? encrypt : (encrypt == null ? string.Empty : encrypt);
        }

        /// <summary>
        /// AES解密，CBC模式
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>明文</returns>
        public static string DecryptByCBC(string encryptStr, string key, string iv = "abcdefgh12345678", bool returnNull = false)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(key);
            byte[] bIV = Encoding.UTF8.GetBytes(iv);
            byte[] byteArray = Convert.FromBase64String(encryptStr);

            string decrypt = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.Zeros;
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray()).TrimEnd(new char[] { '\0' });
                    }
                }
            }
            catch { }
            aes.Clear();
            
            return returnNull ? decrypt : (decrypt == null ? string.Empty : decrypt);
        }
        #endregion

        #region EBC加密模式，PKCS7Padding偏移
        /// <summary>
        /// AES加密，EBC模式
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>密文</returns>
        public static string EncryptByEBC(string plainStr, string key, string iv = "abcdefgh12345678", bool returnNull = false)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(key);
            byte[] bIV = Encoding.UTF8.GetBytes(iv);
            byte[] byteArray = Encoding.UTF8.GetBytes(plainStr);

            string encrypt = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();

            return returnNull ? encrypt : (encrypt == null ? string.Empty : encrypt);
        }

        /// <summary>
        /// AES解密，EBC模式
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>明文</returns>
        public static string DecryptByEBC(string encryptStr, string key, string iv = "abcdefgh12345678", bool returnNull = false)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(key);
            byte[] bIV = Encoding.UTF8.GetBytes(iv);
            byte[] byteArray = Convert.FromBase64String(encryptStr);

            string decrypt = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray()).TrimEnd(new char[] { '\0' });
                    }
                }
            }
            catch { }
            aes.Clear();

            return returnNull ? decrypt : (decrypt == null ? string.Empty : decrypt);
        }
        #endregion
    }
}
