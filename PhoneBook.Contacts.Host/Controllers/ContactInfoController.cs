using Microsoft.AspNetCore.Mvc;
using PhoneBook.Contacts.Host.Services;
using PhoneBook.Shared.Dtos;
using PhoneBook.Shared.ResultTypes;
using System.Threading.Tasks;

namespace PhoneBook.Contacts.Host.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoManager _contactInfoManager;

        public ContactInfoController(IContactInfoManager contactInfoManager)
        {
            _contactInfoManager = contactInfoManager;
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetAll(int contactId)
        {
            var result = await _contactInfoManager.GetAllByContactIdAsync(contactId);
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactInfoDto model)
        {
            await _contactInfoManager.AddAsync(model);
            return Ok(new SuccessResult());
        }

        [HttpPut]
        public async Task<IActionResult> Update(ContactInfoDto model)
        {
            await _contactInfoManager.UpdateAsync(model);
            return Ok(new SuccessResult());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactInfoManager.DeleteAsync(new ContactInfoDto { Id=id });
            return Ok(new SuccessResult());
        }
    }
}
