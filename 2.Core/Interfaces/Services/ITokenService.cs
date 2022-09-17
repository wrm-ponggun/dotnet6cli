namespace Core;

public interface ITokenService
{
    Task<string> SendEmailTokenAsync();
}
