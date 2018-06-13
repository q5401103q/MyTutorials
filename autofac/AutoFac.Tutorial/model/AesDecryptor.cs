using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Tutorial.model
{
    public class AesDecryptor : IDecrypt
    {
        public string Decrypt(string content)
        {
            return string.Format("AesDecryptor Decrypt your '{0}'", content);
        }
    }
}
