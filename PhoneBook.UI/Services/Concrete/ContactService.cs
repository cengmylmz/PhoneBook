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
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _client;
        public ContactService(HttpClient client,IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task AddAsync(ContactViewModel model)
        {
            var data = _mapper.Map<ContactDto>(model);
            var response = await _client.PostAsJsonAsync("contacts",data);

            if (!response.IsSuccessStatusCode)
            {
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<SuccessResult>();
        }

        public async Task DeleteAsync(ContactViewModel model)
        {
            var data = _mapper.Map<ContactDto>(model);
            var response = await _client.DeleteAsync($"contacts/{model.Id}");

            if (!response.IsSuccessStatusCode)
            {
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<SuccessResult>();
        }

        public async Task<List<ContactListItemViewModel>> GetAllAsync()
        {
            var response = await _client.GetAsync("contacts");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<List<ContactDto>>();
            var data = _mapper.Map<List<ContactListItemViewModel>>(result);

            return data;
        }

        public async Task<ContactViewModel> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("contacts");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<ContactDto>();
            var data = _mapper.Map<ContactViewModel>(result);

            return data;
        }

        public async Task UpdateAsync(ContactViewModel model)
        {
            var data = _mapper.Map<ContactDto>(model);
            var response = await _client.PutAsJsonAsync("contacts", data);

            if (!response.IsSuccessStatusCode)
            {
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<SuccessResult>();
        }
    }
}
