using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Web
{
    public class Hash
    {
        public class Password
        {
            /// <summary>
            /// Create a new unique password
            /// </summary>
            public Password()
                : this(CreateSalt(), GetUniqueKey())
            {
            }

            /// <summary>
            /// Create hash from user submitted password
            /// </summary>
            public Password(string userPassword)
                : this(CreateSalt(), userPassword)
            {
            }

            /// <summary>
            /// Create hash from user submitted password and salt from db, useful for comparing hashes
            /// </summary>
            public Password(byte[] userSalt, string userPassword)
            {
                byte[] saltBytes = userSalt;
                Salt = Convert.ToBase64String(saltBytes);
                ClearPassword = userPassword;
                byte[] hashBytes = GenerateSaltedHash(Encoding.UTF8.GetBytes(userPassword), saltBytes);
                HashPassword = Convert.ToBase64String(hashBytes);
            }

            public string Salt { get; set; }
            public string ClearPassword { get; set; }

            public string HashPassword { get; set; }
        }

        public static string GetUniqueKey()
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[8];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(8);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static byte[] CreateSalt()
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[16];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return buff;
        }

        public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}