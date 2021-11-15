namespace PhoneBook.UI.Models
{
    public class ServiceApiSettings
    {
        public string GatewayBaseUri { get; set; }
        public ServiceApi Contact { get; set; }
        public ServiceApi Report { get; set; }
        
    }
    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
