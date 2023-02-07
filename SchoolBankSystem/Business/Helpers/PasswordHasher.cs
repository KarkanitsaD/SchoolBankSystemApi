using System.Security.Cryptography;
using System.Text;

namespace Business.Helpers;

public static class PasswordHasher
{
    public static string GeneratePasswordHash(string password)
    {
        byte[] passwordBytes = Encoding.Default.GetBytes(password);
        var hashBytes = new SHA256Managed().ComputeHash(passwordBytes);
        var hash = BitConverter.ToString(hashBytes);

        return hash;
    }
}