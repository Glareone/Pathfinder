using System;
using System.Security.Cryptography;
using System.Text;

namespace Pathfinder.Security
{
    public class HashComputer
    {
        /// <summary>
        /// Computes hash
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string ComputeHash(string input, string salt)
        {
            return ComputeHash(input, salt, new SHA1CryptoServiceProvider());
        }

        /// <summary>
        /// Computes hash
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        protected string ComputeHash(string input, string salt, HashAlgorithm algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            // Combine salt and input bytes
            byte[] saltedInput = new byte[salt.Length + inputBytes.Length];

            saltBytes.CopyTo(saltedInput, 0);
            inputBytes.CopyTo(saltedInput, salt.Length);

            byte[] hashedBytes = algorithm.ComputeHash(saltedInput);

            return BitConverter.ToString(hashedBytes);
        }


    }
}
