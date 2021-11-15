using Microsoft.AspNetCore.Mvc;
using PhoneBook.UI.Models;
using PhoneBook.UI.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.UI.Controllers
{
    public class ContactsController : Controller
    {
        private IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        private ContactListViewModel GetContact()
        {
            return new ContactListViewModel { ContactList =new List<ContactListItemViewModel> 
            {
                new ContactListItemViewModel { Id = "cc1" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc2" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc3" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc4" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc5" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc12" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc11" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc112" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1123" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc15123" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1898" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1789" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1098" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1078" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc178" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc176" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1686" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc155" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc15779" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1adsad" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1a12" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "ccxc1" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1bvc" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc112awq" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1zxc" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1vc" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" },
                new ContactListItemViewModel { Id = "cc1zx" ,FullName = "Muhammet Yılmaz",CompanyName ="Kernel Yazılım" }
            } };
        }
        public IActionResult Index2()
        {
            var model = GetContact();
            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            var data = await _contactService.GetAllAsync();
            var model = new ContactListViewModel
            {
                ContactList = data
            };
            return View(nameof(ContactsController.Index), model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactListViewModel model)
        {
            await _contactService.AddAsync(model.Contact);
            return RedirectToAction("Index");
        }

        [HttpPut]
        public IActionResult Update(ContactListViewModel model)
        {
            _contactService.UpdateAsync(model.Contact);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.DeleteAsync(new ContactViewModel { Id=id });
            return Json(new { isSuccessful=true });
        }
    }
}
