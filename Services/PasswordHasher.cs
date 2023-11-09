using System;
using System.Security.Cryptography;
using System.Text;

namespace Lesson67Tests.Services
{
    public class PasswordHasher
    {
        /// <summary>
        /// Метод принимает в себя пароль, после чего производит его хеширование в MD5
        /// </summary>
        /// <param name="password"></param>
        public byte[] Md5HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return hashBytes;
            }
        }
        /// <summary>
        /// Метод принимает в себя MD5 hash (массив байт)
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>Возвращается значение хэша в hexCode</returns>
        public string ToHex(byte[] bytes)
        {
            StringBuilder hex = new(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }
}