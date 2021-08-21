using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Data.Cryptography
{
    public class MD5Cryptography
    {
        public static string Encrypt(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            var result = string.Empty;
            foreach (var item in hash)
            {
                result += item.ToString("x2"); //hexadecimal
            }

            return result;
        }
    }
}


