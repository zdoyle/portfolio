using GuildCars.Data.ADO.SalesRepositories;
using GuildCars.Data.ADO.VehicleRepositories;
using GuildCars.Data.Factories.SalesRepositories;
using GuildCars.Data.Factories.VehicleRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Sales()
        {
            var repo = PurchasesRepositoryFactory.GetRepository();

            var model = repo.GetAllTotalSales();

            return View(model);
        }

        [HttpGet]
        public ActionResult Inventory()
        {
            var repo = VehiclesRepositoryFactory.GetRepository();

            var model = repo.GetTotalInventoryDetailsAll();

            return View(model);
        }
    }
}