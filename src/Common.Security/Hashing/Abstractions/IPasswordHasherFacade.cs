namespace Common.Security.Hashing.Abstractions;

public interface IPasswordHasherFacade
{
    string HashPassword(string password);

    bool VerifyHashedPassword(string hashedPassword, string enteredPassword);
}