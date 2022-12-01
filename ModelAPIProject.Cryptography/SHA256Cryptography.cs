using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace ModelAPIProject.Cryptography
{
    public class SHA256Cryptography
    {
        public static string Encrypt(string value)
        {
            var hash = SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value));

            var result = string.Empty;
            foreach (var item in hash)
            {
                result += item.ToString("X2");
            }

            return result;
        }
    }
}