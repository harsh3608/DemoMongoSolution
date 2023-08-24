using System.Security.Cryptography;
using System.Text;

namespace GoByBus.API.Helpers
{
    public static class EncryptDecryptHelper
    {
        private static readonly string SecretKey = "harsh-patel-24"; // Replace with a secure secret key

        public static string HashData(string data)
        {
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(SecretKey)))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyHash(string data, string hash)
        {
            string computedHash = HashData(data);
            return hash == computedHash;
        }
    }
}
