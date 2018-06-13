using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Tutorial.model
{
    public class TodayWriter : IWriter
    {
        private IEncrypt _encryptor;
        private IDecrypt _decryptor;

        public TodayWriter(IEncrypt encryptor, IDecrypt decryptor)
        {
            this._encryptor = encryptor;
            this._decryptor = decryptor;
        }

        public void Write()
        {
            Console.WriteLine(this._encryptor.Encrypt(DateTime.Now.ToShortDateString()));
            Console.WriteLine(this._decryptor.Decrypt(DateTime.Now.ToShortDateString()));
        }
    }
}
