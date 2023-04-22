namespace Common.Models.Db.Abstractions;

public abstract class DatabaseConnectionOptionsBase
{
    public string? ConnectionString { get; set; }

    public string? DatabaseName { get; set; }
}