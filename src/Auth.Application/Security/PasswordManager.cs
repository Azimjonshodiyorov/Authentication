using System.Text;
using Auth.Application.Security.Interfaces;

namespace Auth.Application.Security;

public class PasswordManager : IPasswordManager
{
    public void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmec = new System.Security.Cryptography.HMACSHA512();
        hash = hmec.ComputeHash(Encoding.UTF8.GetBytes(password));
        salt = hmec.Key;

    }

    public bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
    {
        using var hmec = new System.Security.Cryptography.HMACSHA512(salt);
        var competuedHash = hmec.ComputeHash(Encoding.UTF8.GetBytes(password));
        return competuedHash.SequenceEqual(hash);
    }
}