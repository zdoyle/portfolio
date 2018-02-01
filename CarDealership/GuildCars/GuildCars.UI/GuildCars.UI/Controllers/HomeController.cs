using GuildCars.Data.ADO.AdminRepositories;
using GuildCars.Data.ADO.CustomerRepositories;
using GuildCars.Data.ADO.VehicleRepositories;
using GuildCars.Data.Factories.AdminRepositories;
using GuildCars.Data.Factories.CustomerRepositories;
using GuildCars.Models.Tables.AdminTables;
using GuildCars.Models.Tables.CustomerTables;
using GuildCars.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new HomeVM();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            var viewModel = new SpecialVM();

            viewModel.SetSpecials(SpecialsRepositoryFactory.GetRepository().GetAll());

            return View(viewModel);
        }

        //[HttpPost]
        //public ActionResult Specials(Special special)
        //{
        //    var repo = SpecialsRepositoryFactory.GetRepository();

        //    repo.Insert(special);

        //    return RedirectToAction("Specials");
        //}

        [HttpGet]
        public ActionResult Contact(string id)
        {
            var viewModel = new ContactVM();

            if (!String.IsNullOrEmpty(id))
            {
                if (id == "submitted")
                {
                    viewModel.Message = id;
                }

                else
                {
                    viewModel.Message = "Re: Vehicle with VIN#: " + id + "\n\n"; 
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Contact(ContactVM contactVM)
        {
            if (String.IsNullOrWhiteSpace(contactVM.Email) && String.IsNullOrWhiteSpace(contactVM.Phone))
            {
                ModelState.AddModelError("m.Email", "Must Provide Either Email or Phone");
            }

            if (ModelState.IsValid)
            {
                var customer = new Customer();
                var contact = new Contact();

                customer.FirstName = contactVM.FirstName;
                customer.LastName = contactVM.LastName;

                if (!String.IsNullOrWhiteSpace(contactVM.Email))
                {
                    customer.Email = contactVM.Email;
                }

                if (!String.IsNullOrWhiteSpace(contactVM.Phone))
                {
                    customer.Phone = contactVM.Phone;
                }

                contact.Message = contactVM.Message;

                var repo = ContactsRepositoryFactory.GetRepository();

                repo.Insert(customer, contact);

                return RedirectToAction("Contact", new { id = "submitted" });
            }

            return View("Contact", contactVM);
        }
    }
}