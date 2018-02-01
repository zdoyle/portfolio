using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using GuildCars.Data.Interfaces.CustomerRepositoryInterfaces;
using GuildCars.Data.ADO.CustomerRepositories;

namespace GuildCars.Data.Factories.CustomerRepositories
{
    public class AddressesRepositoryFactory
    {
        public static IAddressesRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new AddressesRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
