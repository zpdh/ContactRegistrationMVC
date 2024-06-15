using System.Security.Cryptography;
using System.Text;

namespace ContactRegistrationMVC.Helper
{
    public static class Cryptography
    {
        public static string GenerateHash(this string value)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var hexaStr = new StringBuilder();
            var array = encoding.GetBytes(value);

            array = hash.ComputeHash(array);

            foreach ( var item in array )
            {
                hexaStr.Append(item.ToString("x2"));
            }

            return hexaStr.ToString();
        }
    }
}
