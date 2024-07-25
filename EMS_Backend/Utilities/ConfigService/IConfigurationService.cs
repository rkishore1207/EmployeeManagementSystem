namespace Utilities.ConfigService
{
    public interface IConfigurationService
    {
        string? SqlConnectionString { get; }
    }
}