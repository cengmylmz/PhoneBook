using AutoMapper;
using PhoneBook.Shared.Dtos;
using PhoneBook.UI.Models;
using PhoneBook.UI.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PhoneBook.UI.Services.Concrete
{
    public class ReportService:IReportService
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _client;
        public ReportService(HttpClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        
        public async Task<List<ReportViewModel>> GetAllAsync()
        {
            var response = await _client.GetAsync("reports");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = await response.Content.ReadFromJsonAsync<List<ReportDto>>();
            var data = _mapper.Map<List<ReportViewModel>>(result);

            return data;
        }
        public async Task GenerateReportAync()
        {
            var response = await _client.GetAsync("reports/generatereport");

            if (!response.IsSuccessStatusCode)
            {
                return;
            }
        }

        public async Task<byte[]> DownloadFileAsync(string fileName)
        {
            var response = await _client.GetAsync($"files/downloadfile/{fileName}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = await response.Content.ReadAsByteArrayAsync();
            return result;
        }

    }
}
