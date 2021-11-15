using System.Collections.Generic;

namespace PhoneBook.UI.Models
{
    public class ContactInfoListViewModel
    {
        public int ContactId { get; set; }
        public string ContactFullName { get; set; }
        public ContactInfoViewModel ContactInfo { get; set; }
        public List<ContactInfoListItemViewModel> ContactInfoList { get; set; }

    }
}
