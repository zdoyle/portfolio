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
using System.Web.Mvc;

namespace GuildCars.UI.Models.ViewModels
{
    public class ModelsVM
    {
        public IEnumerable<ModelRequestItem> Models { get; set; }
        public IEnumerable<ModelRequestItem> ModelItemsInStock { get; set; }
        [Required]
        [DisplayName("New Model Name")]
        public string ModelName { get; set; }
        [Required]
        [DisplayName("New Make")]
        public short MakeId { get; set; }
        public List<SelectListItem> MakeItems { get; set; }

        public ModelsVM()
        {
            Models = CarModelsRepositoryFactory.GetRepository().GetDetailsAll();
            ModelItemsInStock = CarModelsRepositoryFactory.GetRepository().GetDetailsAllInStock();
            MakeItems = new List<SelectListItem>();
        }

        public void SetMakeItems(IEnumerable<CarMake> makes)
        {
            foreach (var make in makes)
            {
                MakeItems.Add(new SelectListItem()
                {
                    Value = make.MakeId.ToString(),
                    Text = make.Name
                });
            }
        }
    }
}