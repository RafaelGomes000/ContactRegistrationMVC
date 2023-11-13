using System.Security.Cryptography;
using System.Text;

namespace ContactRegistrationMVC.Helper
{
    public static class cryptography
    {
        public static string GenerateHash(this string value)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(value);

            array = hash.ComputeHash(array);

            var strHex = new StringBuilder();

            foreach ( var item in array )
            {
                strHex.Append(item.ToString("x2"));
            }

            return strHex.ToString();
        }
    }
}
