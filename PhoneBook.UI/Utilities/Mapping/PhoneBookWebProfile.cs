using AutoMapper;
using PhoneBook.Shared.Dtos;
using PhoneBook.UI.Models;

namespace PhoneBook.UI.Utilities.Mapping
{
    public class PhoneBookWebProfile:Profile
    {
        public PhoneBookWebProfile()
        {
            CreateMap<ContactDto, ContactListItemViewModel>()
                .ForMember(vm=>vm.FullName , opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}"));
            CreateMap<ContactDto, ContactViewModel>().ReverseMap();
            CreateMap<ContactInfoDto, ContactInfoViewModel>().ReverseMap();
            CreateMap<ContactInfoDto, ContactInfoListItemViewModel>();
            CreateMap<ReportDto, ReportViewModel>();
        }
    }
}
