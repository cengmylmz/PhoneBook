using Microsoft.AspNetCore.Mvc;
using PhoneBook.Reports.Host.Services.Abstract;
using PhoneBook.Reports.Host.Services.RabbitMQ;
using PhoneBook.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace PhoneBook.Reports.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportManager _reportManager;

        private readonly RabbitMQPublisher _rabbitMQPublisher;
        public ReportsController(RabbitMQPublisher rabbitMQPublisher, IReportManager reportManager)
        {
            _reportManager = reportManager;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reportManager.GetAllAsync();
            return Ok(result.Data);
        }



        [HttpGet("generatereport")]
        public async Task<IActionResult> GenerateReport()
        {
            var fileName = $"{DateTime.Now.ToString("ddMMyyyyhh:mm:ss")}-{Guid.NewGuid().ToString().Substring(1, 10)}";

            var model = new ReportDto
            {
                RequestedDate = DateTime.Now.ToString(),
                FileName = fileName,
                ReportState = Shared.Enums.ReportState.Preparing
            };

            var result = await _reportManager.AddAsync(model);

            _rabbitMQPublisher.Publish(new GenerateExcelMessageDto() { FileId = result.Data.Id });
            return Ok();
        }
    }
}
