using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using GuildCars.Data.Interfaces.SalesRepositoryInterfaces;
using GuildCars.Data.ADO.SalesRepositories;

namespace GuildCars.Data.Factories.SalesRepositories
{
    public class PurchaseTypesRepositoryFactory
    {
        public static IPurchaseTypesRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new PurchaseTypesRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
