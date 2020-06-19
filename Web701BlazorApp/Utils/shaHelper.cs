using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Web701BlazorApp.Utils
{

    public static class shaHelper //using this to generate hashes for sessions (hashing user agent and ip to add it to token)
    {
        public static String GetHash(String text)
        {
            string res = "";
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                res = BitConverter.ToString(hashedBytes).Replace("-", "").ToUpper();
            }
            return res;
        }
    }
}
