namespace Common.Security.Hashing.Contracts;

public interface IPasswordHasherFacade
{
    string HashPassword(string password);

    bool VerifyHashedPassword(string hashedPassword, string enteredPassword);
}