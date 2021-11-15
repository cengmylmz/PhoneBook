using AutoMapper;
using MongoDB.Driver;
using PhoneBook.Reports.Host.Entities;
using PhoneBook.Reports.Host.Services.Abstract;
using PhoneBook.Reports.Host.Utilities.DbConfigurationSettings;
using PhoneBook.Shared.Dtos;
using PhoneBook.Shared.ResultTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Reports.Host.Services.Concrete
{
    public class ReportManager:IReportManager
    {
        private readonly IMongoCollection<Report> _contactCollection;
        private readonly IMapper _mapper;
        public ReportManager(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _contactCollection = database.GetCollection<Report>(databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task<DataResult<ReportDto>> AddAsync(ReportDto model)
        {
            var data = _mapper.Map<Report>(model);
            await _contactCollection.InsertOneAsync(data);
            return new SuccessDataResult<ReportDto>(_mapper.Map<ReportDto>(data));
        }

        public async Task<DataResult<List<ReportDto>>> GetAllAsync()
        {
            var data = await _contactCollection.Find(contact => true).ToListAsync();
            var reportList = _mapper.Map<List<ReportDto>>(data);
            return new SuccessDataResult<List<ReportDto>>(reportList.OrderByDescending(report=>report.RequestedDate).ToList());
        }

        public async Task<DataResult<ReportDto>> GetByIdAsync(string id)
        {
            var data = await _contactCollection.Find(contact => contact.Id==id).FirstOrDefaultAsync();
            var report = _mapper.Map<ReportDto>(data);
            return new SuccessDataResult<ReportDto>(report);
        }

        public async Task<Result> UpdateAsync(ReportDto model)
        {
            var data = _mapper.Map<Report>(model);
            await _contactCollection.ReplaceOneAsync(book => book.Id == data.Id, data);
            return new SuccessResult();
        }
    }
}
