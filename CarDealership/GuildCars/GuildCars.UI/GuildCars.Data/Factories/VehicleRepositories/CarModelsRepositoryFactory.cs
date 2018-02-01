using GuildCars.Data.Interfaces.VehicleRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using GuildCars.Data.ADO.VehicleRepositories;

namespace GuildCars.Data.Factories.VehicleRepositories
{
    public class CarModelsRepositoryFactory
    {
        public static ICarModelsRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new CarModelsRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
