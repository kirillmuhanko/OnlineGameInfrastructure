namespace Common.Models.Database.Options;

public abstract class DatabaseConnectionOptionsBase
{
    public string? ConnectionString { get; set; }

    public string? DatabaseName { get; set; }
}