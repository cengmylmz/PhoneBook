using System.ComponentModel;

namespace PhoneBook.Shared.Enums
{
    public enum ReportState
    {
        [Description("Hazırlanıyor")]
        Preparing,
        [Description("Tamamlandı")]
        Completed
    }
}
