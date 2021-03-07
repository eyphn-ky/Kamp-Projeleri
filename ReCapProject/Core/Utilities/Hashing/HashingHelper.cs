using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //rastgele bir anahtar oluşturuluyor ve password' ekleniyor
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//eklenen karakterlerle beraber yeni password hashleniyor
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) //password saltı da ekle öyle kontrol et
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
