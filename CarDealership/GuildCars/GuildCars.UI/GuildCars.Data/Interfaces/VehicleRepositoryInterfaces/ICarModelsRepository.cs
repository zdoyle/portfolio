using GuildCars.Models.Queries;
using GuildCars.Models.Tables.VehicleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.VehicleRepositoryInterfaces
{
    public interface ICarModelsRepository
    {
        IEnumerable<CarModel> GetAll();
        IEnumerable<ModelRequestItem> GetDetailsAllInStock();
        IEnumerable<ModelRequestItem> GetDetailsAll();
        CarModel GetById(int modelId);
        void Insert(CarModel model, CarMake make);
    }
}
