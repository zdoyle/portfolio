using GuildCars.Models.Queries;
using GuildCars.Models.Tables.VehicleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.VehicleRepositoryInterfaces
{
    public interface IVehiclesRepository
    {
        IEnumerable<Vehicle> GetAll();
        Vehicle GetById(int vehicleId);
        IEnumerable<VehicleRequestItem> GetDetailsAllByVehicleTypeId(byte vehicleTypeId, VehicleQuery query);
        IEnumerable<VehicleRequestItem> GetDetailsAllByVehicleTypeId(byte vehicleTypeId);
        IEnumerable<VehicleRequestItem> GetDetailsAllByIsSold(bool isSold);
        IEnumerable<VehicleRequestItem> GetDetailsAll();
        IEnumerable<VehicleRequestItem> GetDetailsAll(VehicleQuery query);
        IEnumerable<FeaturedVehicleRequestItem> GetFeaturedDetailsAll();
        IEnumerable<InventoryReportRequestItem> GetTotalInventoryDetailsAll();
        VehicleRequestItem GetDetailsById(int vehicleId);
        void Insert(Vehicle vehicle, CarModel model, CarMake make);
        void Update(Vehicle vehicle, CarModel model, CarMake make);
        void Delete(int vehicleId);
    }
}
