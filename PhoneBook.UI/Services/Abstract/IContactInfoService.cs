using PhoneBook.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.UI.Services.Abstract
{
    public interface IContactInfoService
    {
        Task<List<ContactInfoListItemViewModel>> GetAllByContactIdAsync(int contactId);
        Task<ContactInfoListViewModel> GetAllWithContactAsync(int contactId);
        Task AddASync(ContactInfoViewModel model);
        Task DeleteASync(ContactInfoViewModel model);
    }
}
