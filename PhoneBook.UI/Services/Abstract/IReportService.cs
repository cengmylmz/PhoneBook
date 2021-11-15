using PhoneBook.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.UI.Services.Abstract
{
    public interface IReportService
    {
        Task<List<ReportViewModel>> GetAllAsync();
        Task GenerateReportAync();
        Task<byte[]> DownloadFileAsync(string fileName);
    }
}
