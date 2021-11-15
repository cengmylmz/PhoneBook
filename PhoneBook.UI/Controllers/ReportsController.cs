using Microsoft.AspNetCore.Mvc;
using PhoneBook.UI.Models;
using PhoneBook.UI.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.UI.Controllers
{

    public class ReportsController : Controller
    {
        private IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _reportService.GetAllAsync();
            return View((result ?? new List<ReportViewModel>()));
        }

        public async Task<FileContentResult> DownloadFile(string fileName)
        {
            var result = await _reportService.DownloadFileAsync(fileName);
            return File(result, "application/vnd.ms-excel",fileName);
        }

        public async Task<IActionResult> GenerateReport()
        {
            await _reportService.GenerateReportAync();
            return RedirectToAction("Index");
        }
    }
}
