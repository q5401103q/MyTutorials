using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Tutorial.model
{
    public class AesEncryptor : IEncrypt
    {
        public string Encrypt(string content)
        {
            return string.Format("AesEncryptor Encrypt your '{0}'", content);
        }
    }
}
