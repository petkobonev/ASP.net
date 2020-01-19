using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PasswordManager
    {
        public string GeneratePasswordHash(string password)
        {
            string hash = GetStringHash(password);
            return hash;
        }

        public bool IsPasswordMatch(string password, string hash)
        {
            string newPassHash = GetStringHash(password);

            bool areSame = newPassHash == hash;
            return areSame;
        }

        private string GetStringHash(string text)
        {

            SHA256 sha256 = SHA256CryptoServiceProvider.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(text);
            byte[] hash = sha256.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
