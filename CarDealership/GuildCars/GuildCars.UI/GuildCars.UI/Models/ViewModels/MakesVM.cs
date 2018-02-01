using GuildCars.Data.ADO.VehicleRepositories;
using GuildCars.Data.Factories.VehicleRepositories;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables.VehicleTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models.ViewModels
{
    public class MakesVM
    {
        public IEnumerable<CarMake> Makes { get; set; }
        public IEnumerable<MakeRequestItem> MakeItems { get; set; }
        [Required]
        [DisplayName("New Make Name")]
        public string MakeName { get; set; }

        public MakesVM()
        {
            Makes = CarMakesRepositoryFactory.GetRepository().GetAll();
            MakeItems = CarMakesRepositoryFactory.GetRepository().GetDetailsAllInStock();
        }
    }
}