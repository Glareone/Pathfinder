using System;
using System.Security.Cryptography;
using System.Text;

namespace Pathfinder.Security
{
    public class HashComputer : IHashComputer
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HashComputer"/> class
        /// </summary>
        public HashComputer(string salt)
        {
            Salt = salt;
        }

        /// <summary>
        /// Salt
        /// </summary>
        protected string Salt { get; private set; }

        /// <summary>
        /// Computes hash
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ComputeHash(string input)
        {
            return ComputeHash(input, new SHA1CryptoServiceProvider());
        }

        /// <summary>
        /// Computes hash
        /// </summary>
        /// <param name="input"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        protected string ComputeHash(string input, HashAlgorithm algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] saltBytes = Encoding.UTF8.GetBytes(Salt);

            // Combine salt and input bytes
            byte[] saltedInput = new byte[Salt.Length + inputBytes.Length];

            saltBytes.CopyTo(saltedInput, 0);
            inputBytes.CopyTo(saltedInput, Salt.Length);

            byte[] hashedBytes = algorithm.ComputeHash(saltedInput);

            return BitConverter.ToString(hashedBytes);
        }


    }
}
