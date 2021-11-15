using AutoMapper;
using PhoneBook.Shared.Dtos;
using PhoneBook.Shared.ResultTypes;
using PhoneBook.UI.Models;
using PhoneBook.UI.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PhoneBook.UI.Services.Concrete
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _client;
        public ContactInfoService(HttpClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }
        public async Task AddASync(ContactInfoViewModel model)
        {
            var data = _mapper.Map<ContactInfoDto>(model);
            var response = await _client.PostAsJsonAsync("contactinfo", data);

            if (!response.IsSuccessStatusCode)
            {
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<SuccessResult>();
        }

        public async Task DeleteASync(ContactInfoViewModel model)
        {
            var data = _mapper.Map<ContactInfoDto>(model);
            var response = await _client.DeleteAsync($"contactinfo/{model.Id}");

            if (!response.IsSuccessStatusCode)
            {
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<SuccessResult>();
        }

        public async Task<List<ContactInfoListItemViewModel>> GetAllByContactIdAsync(int contactId)
        {
            var response = await _client.GetAsync($"contactinfo/{contactId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<List<ContactInfoDto>>();
            var data = _mapper.Map<List<ContactInfoListItemViewModel>>(result);

            return data;
        }

        public async Task<ContactInfoListViewModel> GetAllWithContactAsync(int contactId)
        {
            var response = await _client.GetAsync($"contacts/getwithinfo/{contactId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<ContactInfoListDto>();
            var contact = _mapper.Map<ContactViewModel>(result.Contact);
            var contactInfoList = result.ContactInfoList==null? new List<ContactInfoListItemViewModel>():_mapper.Map<List<ContactInfoListItemViewModel>>(result.ContactInfoList);
            var data = new ContactInfoListViewModel
            {
                ContactFullName = $"{contact.FirstName} {contact.LastName}",
                ContactId = contact.Id,
                ContactInfoList = contactInfoList
            };
            return data;
        }
    }
}
