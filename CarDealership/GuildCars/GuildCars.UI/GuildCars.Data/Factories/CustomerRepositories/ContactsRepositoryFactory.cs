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
    public class ContactsRepositoryFactory
    {
        public static IContactsRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new ContactsRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
