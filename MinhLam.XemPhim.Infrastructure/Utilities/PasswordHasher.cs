using MinhLam.Framework;
using System;

namespace MinhLam.XemPhim.Infrastructure.Utilities
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string purePassword, string key)
        {
            return Cryptography.Encrypt(purePassword, key);
        }
    }
}
