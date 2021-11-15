using PhoneBook.Shared.Dtos;
using PhoneBook.Shared.ResultTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Contacts.Host.Services
{
    public interface IContactInfoManager
    {
        Task<DataResult<List<ContactInfoDto>>> GetAllByContactIdAsync(int contactId);
        Task<Result> AddAsync(ContactInfoDto contactInfo);
        Task<Result> DeleteAsync(ContactInfoDto contactInfo);
        Task<Result> UpdateAsync(ContactInfoDto contactInfo);
    }
}
