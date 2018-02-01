using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using GuildCars.Data.Interfaces.AdminRepositoryInterfaces;
using GuildCars.Data.ADO.AdminRepositories;

namespace GuildCars.Data.Factories.AdminRepositories
{
    public class EmployeesRepositoryFactory
    {
        public static IEmployeesRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new EmployeesRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
