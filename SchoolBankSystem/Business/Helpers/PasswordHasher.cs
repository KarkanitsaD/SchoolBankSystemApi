using System.Security.Cryptography;
using System.Text;

namespace Business.Helpers;

public static class PasswordHasher
{
    public static string GeneratePasswordHash(string password)
    {
        byte[] passwordBytes = Encoding.Default.GetBytes(password);
        var hashBytes = SHA256.Create().ComputeHash(passwordBytes);
        var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

        return hash;
    }
}