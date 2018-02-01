using GuildCars.Models.Tables.VehicleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.VehicleRepositoryInterfaces
{
    public interface IBodyStylesRepository
    {
        IEnumerable<BodyStyle> GetAll();
        BodyStyle GetById(byte bodyStyleId);
    }
}
