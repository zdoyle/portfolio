using GuildCars.Models.Queries;
using GuildCars.Models.Tables.VehicleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.VehicleRepositoryInterfaces
{
    public interface ICarMakesRepository
    {
        IEnumerable<CarMake> GetAll();
        IEnumerable<MakeRequestItem> GetDetailsAllInStock();
        CarMake GetById(short makeId);
        void Insert(CarMake make);
    }
}
