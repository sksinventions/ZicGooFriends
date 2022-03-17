using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Common.Security.Cryptography
{
    public static class SHA256Helper
    {
        public static string Encryt(string str)
        {
            byte[] hash = new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(str));
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }
    }
}
