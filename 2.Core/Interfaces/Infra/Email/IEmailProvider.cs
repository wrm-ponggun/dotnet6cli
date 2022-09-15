namespace Core;

public interface IEmailProvider
{
    Task<string> SendEmailAsync(string subject, string message, List<string> recepients);
}