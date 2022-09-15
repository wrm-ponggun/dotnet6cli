namespace Infra;

public class MailGunEmailProviderOptions
{
    public const string ConfigItem = "MailGunEmailProvider";

    public string APIURL { get; set; }
    public string APIKey { get; set; }
}
