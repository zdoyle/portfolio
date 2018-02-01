using GuildCars.Models.Queries;
using GuildCars.Models.Tables.AdminTables;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Data.ADO.VehicleRepositories;
using GuildCars.Data.ADO.AdminRepositories;
using GuildCars.Data.Factories.AdminRepositories;
using GuildCars.Data.Factories.VehicleRepositories;

namespace GuildCars.UI.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<FeaturedVehicleRequestItem> FeaturedVehicleItems { get; set; }
        public IEnumerable<Special> SpecialItems { get; set; }

        public HomeVM()
        {
            FeaturedVehicleItems = VehiclesRepositoryFactory.GetRepository().GetFeaturedDetailsAll();
            SpecialItems = SpecialsRepositoryFactory.GetRepository().GetAll();
        }
    }
}
