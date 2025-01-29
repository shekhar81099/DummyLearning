using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace DI
{
    public static class HashingPassword
    {
        public static byte[] generateSalt(int size = 16)
        {
            byte[] salt = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
        public static void Encrypt()
        {
            string mypassword = "mypassword";

            var salt = generateSalt();
            string hashedPassword = HashPasswordWithSalt(mypassword, salt);

            WriteLine($"Salt: {Convert.ToBase64String(salt)}");
            WriteLine($"Hashed Password: {hashedPassword}");
        }

        private static string HashPasswordWithSalt(string password, byte[] salt)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] passwordWithSalt = new byte[passwordBytes.Length + salt.Length];

                Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, passwordWithSalt, passwordBytes.Length, salt.Length); 

                // for (int i = 0; i < passwordBytes.Length; i++)
                // {
                //     passwordWithSalt[i] = passwordBytes[i];
                // }

                // for (int i = 0; i < salt.Length; i++)
                // {
                //     passwordWithSalt[passwordBytes.Length + i] = salt[i];
                // }
                // Salt: t8ccHr+uRz1vGLfwMgHugA==
                // Hashed Password: ktGnhXpkr1eeqwRj2IbZdU0lDACBh59RufhRAt09yjM=

                byte[] hash = sha.ComputeHash(passwordWithSalt);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
 