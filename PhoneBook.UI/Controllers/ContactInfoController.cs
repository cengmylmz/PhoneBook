using Microsoft.AspNetCore.Mvc;
using PhoneBook.Shared.ResultTypes;
using PhoneBook.UI.Models;
using PhoneBook.UI.Services.Abstract;
using System.Threading.Tasks;

namespace PhoneBook.UI.Controllers
{
    public class ContactInfoController : Controller
    {
        private IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> List(int id)
        {
            var model = await _contactInfoService.GetAllWithContactAsync(id);
            return PartialView("List", model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            var model = await _contactInfoService.GetAllByContactIdAsync(id);
            return Json(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactInfoService.DeleteASync(new ContactInfoViewModel { Id=id });
            return Json(new SuccessResult());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactInfoViewModel model)
        {
            await _contactInfoService.AddASync(model);
            return Json(new { isSuccessful=true });
        }

        [HttpPut]
        public IActionResult Update(ContactInfoListViewModel model)
        {

            return RedirectToAction("Index");
        }
    }
}
