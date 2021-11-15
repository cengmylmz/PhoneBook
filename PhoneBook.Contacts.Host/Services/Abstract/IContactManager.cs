using PhoneBook.Shared.Dtos;
using PhoneBook.Shared.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Contacts.Host.Services
{
    public interface IContactManager
    {
        Task<DataResult<List<ContactDto>>> GetAllAsync();
        Task<DataResult<ContactDto>> GetByIdAsync(int id);
        Task<Result> AddAsync(ContactDto contact);
        Task<Result> UpdateAsync(ContactDto contact);
        Task<Result> DeleteAsync(ContactDto contact);
    }
}
