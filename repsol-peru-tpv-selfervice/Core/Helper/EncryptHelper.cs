using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selferviceSIGC.Core.Helper
{
    internal static class EncryptHelper
    {

        internal static string EncriptarBase64Encode(string cadena)
        {
           
            string resultEncrypt = string.Empty;

            byte[] byt = System.Text.Encoding.UTF8.GetBytes(cadena);
            resultEncrypt = Convert.ToBase64String(byt);


            return resultEncrypt;

        }
        internal static string DesencriptarBase64Decode(string cadena)
        {
            
            string resultEncrypt = string.Empty;
           
            byte[] b = Convert.FromBase64String(cadena);
            resultEncrypt = System.Text.Encoding.UTF8.GetString(b);
           
            return resultEncrypt;
        }
    }
}
