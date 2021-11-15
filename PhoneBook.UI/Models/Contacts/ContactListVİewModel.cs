using System.Collections.Generic;

namespace PhoneBook.UI.Models
{
    public class ContactListViewModel
    {
        public ContactListViewModel()
        {
            List<ContactListItemViewModel> ContactList = new();
        }
        public List<ContactListItemViewModel> ContactList { get; set; }
        public ContactViewModel Contact { get; set; }

    }
}
