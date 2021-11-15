namespace PhoneBook.Reports.Host.Utilities.DbConfigurationSettings
{
    public interface IDatabaseSettings
    {
        string ContactCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
