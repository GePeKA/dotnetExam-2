﻿using Main.Infrastructure.Services.Abstractions;
using System.Security.Cryptography;

namespace Main.Infrastructure.Services.Implementations
{
    public class HasherService : IHasherService
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

        private const char SegmentDelimiter = ':';

        public string Hash(string input)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                input,
                salt,
                Iterations,
                Algorithm,
                KeySize
            );
            return string.Join(
                SegmentDelimiter,
                Convert.ToHexString(hash),
                Convert.ToHexString(salt),
                Iterations,
                Algorithm
            );
        }

        public bool Verify(string input, string hashString)
        {
            try
            {
                var segments = hashString.Split(SegmentDelimiter);
                var hash = Convert.FromHexString(segments[0]);
                var salt = Convert.FromHexString(segments[1]);
                var iterations = int.Parse(segments[2]);
                var algorithm = new HashAlgorithmName(segments[3]);
                var inputHash = Rfc2898DeriveBytes.Pbkdf2(
                    input,
                    salt,
                    iterations,
                    algorithm,
                    hash.Length
                );
                return CryptographicOperations.FixedTimeEquals(inputHash, hash);
            }
            catch
            {
                return false;
            }
        }
    }
}
