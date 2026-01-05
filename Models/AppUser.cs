
using System.Security.Cryptography;
using System.Text;

namespace ElearningPlatform.Models
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";

        public static string ComputeHash(string password)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(
                sha.ComputeHash(Encoding.UTF8.GetBytes(password))
            );
        }
    }
}
