using System.Collections.Generic;

namespace PhoneBook.Shared.Dtos
{
    public class ContactInfoListDto:IDto
    {
        public ContactDto Contact { get; set; }
        public List<ContactInfoDto> ContactInfoList { get; set; }
    }

}
