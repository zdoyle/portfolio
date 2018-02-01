using GuildCars.Data.ADO.AdminRepositories;
using GuildCars.Data.ADO.CustomerRepositories;
using GuildCars.Data.ADO.SalesRepositories;
using GuildCars.Data.ADO.VehicleRepositories;
using GuildCars.Data.Factories.AdminRepositories;
using GuildCars.Data.Factories.CustomerRepositories;
using GuildCars.Data.Factories.SalesRepositories;
using GuildCars.Data.Factories.VehicleRepositories;
using GuildCars.Models.Tables.CustomerTables;
using GuildCars.Models.Tables.SalesTables;
using GuildCars.UI.Models.Extensions;
using GuildCars.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [Authorize(Roles = "Admin, Sales")]
    public class SalesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = VehiclesRepositoryFactory.GetRepository().GetDetailsAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Purchase(int id)
        {
            var viewModel = new PurchaseVM();

            viewModel.VehicleId = id;
            viewModel.Vehicle = VehiclesRepositoryFactory.GetRepository().GetDetailsById(id);
            viewModel.MSRP = viewModel.Vehicle.MSRP;
            viewModel.SalePrice = viewModel.Vehicle.SalePrice;
            viewModel.SetStateItems(StatesRepositoryFactory.GetRepository().GetAll());
            viewModel.SetPurchaseTypeItems(PurchaseTypesRepositoryFactory.GetRepository().GetAll());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseVM purchaseVM)
        {
            if (String.IsNullOrWhiteSpace(purchaseVM.Email) && String.IsNullOrWhiteSpace(purchaseVM.Phone))
            {
                ModelState.AddModelError("m.Email", "Must Provide Either Email or Phone");
            }

            if (ModelState.IsValid)
            {
                Customer customer = new Customer();
                Purchase purchase = new Purchase();
                Address address = new Address();

                customer.FirstName = purchaseVM.FirstName;
                customer.LastName = purchaseVM.LastName;
                if (!String.IsNullOrWhiteSpace(purchaseVM.Email))
                {
                    customer.Email = purchaseVM.Email;
                }
                if (!String.IsNullOrWhiteSpace(purchaseVM.Phone))
                {
                    customer.Phone = purchaseVM.Phone;
                }

                var employeeId = int.Parse(User.Identity.GetEmployeeId());

                purchase.VehicleId = purchaseVM.VehicleId;
                purchase.EmployeeId = employeeId;
                purchase.PurchasePrice = purchaseVM.PurchasePrice;
                purchase.PurchaseTypeId = purchaseVM.PurchaseTypeId;

                address.StreetAddress1 = purchaseVM.StreetAddress1;
                if (!String.IsNullOrWhiteSpace(purchaseVM.StreetAddress2))
                {
                    address.StreetAddress2 = purchaseVM.StreetAddress2;
                }
                address.City = purchaseVM.City;
                address.StateId = purchaseVM.StateId;
                address.ZipCode = purchaseVM.ZipCode;

                var repo = PurchasesRepositoryFactory.GetRepository();

                repo.Insert(customer, purchase, address);

                return RedirectToAction("Index"); 
            }

            purchaseVM.Vehicle = VehiclesRepositoryFactory.GetRepository().GetDetailsById(purchaseVM.VehicleId);
            purchaseVM.SetStateItems(StatesRepositoryFactory.GetRepository().GetAll());
            purchaseVM.SetPurchaseTypeItems(PurchaseTypesRepositoryFactory.GetRepository().GetAll());

            return View("Purchase", purchaseVM);
        }
    }
}