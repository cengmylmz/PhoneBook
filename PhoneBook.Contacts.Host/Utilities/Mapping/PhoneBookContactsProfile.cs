using AutoMapper;
using PhoneBook.Contacts.Host.Entities;
using PhoneBook.Shared.Dtos;

namespace PhoneBook.Contacts.Host.Utilities.Mapping
{
    public class PhoneBookContactsProfile:Profile
    {
        public PhoneBookContactsProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
        }
    }
}
