using PhoneBook.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.UI.Services.Abstract
{
    public interface IContactService
    {
        Task<List<ContactListItemViewModel>> GetAllAsync();
        Task<ContactViewModel> GetByIdAsync(int id);
        Task AddAsync(ContactViewModel model);
        Task UpdateAsync(ContactViewModel model);
        Task DeleteAsync(ContactViewModel model);
    }
}
