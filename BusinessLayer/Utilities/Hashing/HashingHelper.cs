using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities.Hashing
{
    public class HashingHelper
    {
        public static void AdminCreatePasswordHash(string adminMail, string password, out byte[] adminMailHash, out byte[] adminPasswordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                adminPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                adminMailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminMail));
            }
        }

        public static bool AdminVerifyPasswordHash(string adminMail, string password, byte[] adminMailHash, byte[] adminPasswordHash, byte[] passwordSalt)
        {
            using ( var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedPasswordHash.Length; i++)
                {
                    if (computedPasswordHash[i] != adminPasswordHash[i])
                    {
                        return false;
                    }
                }
                var computedAdminMailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminMail));
                for (int i = 0; i < computedAdminMailHash.Length; i++)
                {
                    if (computedAdminMailHash[i] != adminMailHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static bool AdminVerifyPasswordHash(string userName, byte[] userNameHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var computedAdminMailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userName));
                for (int i = 0; i < computedAdminMailHash.Length; i++)
                {
                    if (computedAdminMailHash[i] != userNameHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static string AdminPasswordDecode(string password)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA512Managed sha512Hasher = new SHA512Managed();
            byte[] hashedDataBytes = sha512Hasher.ComputeHash(encoder.GetBytes(password));
            return Convert.ToBase64String(hashedDataBytes);
        }
    }
}
