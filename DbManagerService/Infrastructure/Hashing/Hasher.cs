using System.Text;
using System.Security.Cryptography;
using Infrastructure.Interfaces;
using Infrastructure.Enums;

namespace Infrastructure.Hashing
{
    public class Hasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return Hash(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var providedPasswordHashed = Hash(providedPassword);

            if (providedPasswordHashed == hashedPassword)
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }

        private string Hash(string input)
        {
            string output = "";

            using (SHA256 mySHA256 = SHA256.Create())
            {
                var result = mySHA256
                    .ComputeHash(
                    Encoding.ASCII.GetBytes(input));

                output = Encoding.Default.GetString(result);

                mySHA256.Clear();
            }

            return output;
        }
    }
}
