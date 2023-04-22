using Common.Models.DependencyInjection.Attributes;
using Common.Security.Hashing.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Common.Security.Hashing.Implementations;

[SingletonLifetime]
public class PasswordHasherFacade : IPasswordHasherFacade
{
    private readonly PasswordHasher<string> _passwordHasher;

    public PasswordHasherFacade()
    {
        _passwordHasher = new PasswordHasher<string>();
    }

    public string HashPassword(string password)
    {
        var hashedPassword = _passwordHasher.HashPassword(null!, password);
        return hashedPassword;
    }

    public bool VerifyHashedPassword(string hashedPassword, string enteredPassword)
    {
        var result = _passwordHasher.VerifyHashedPassword(null!, hashedPassword, enteredPassword);
        return result == PasswordVerificationResult.Success;
    }
}