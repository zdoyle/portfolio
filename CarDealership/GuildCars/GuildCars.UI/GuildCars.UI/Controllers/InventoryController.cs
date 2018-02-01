using GuildCars.Data.ADO.VehicleRepositories;
using GuildCars.Data.Factories.VehicleRepositories;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = VehiclesRepositoryFactory.GetRepository().GetDetailsById(id);

            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = VehiclesRepositoryFactory.GetRepository().GetDetailsAllByVehicleTypeId(1);

            return View(model);
        }

        [HttpGet]
        public ActionResult Used()
        {
            var model = VehiclesRepositoryFactory.GetRepository().GetDetailsAllByVehicleTypeId(2);

            return View(model);
        }
    }
}