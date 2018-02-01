using GuildCars.Models.Tables.CustomerTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.CustomerRepositoryInterfaces
{
    public interface IAddressesRepository
    {
        IEnumerable<Address> GetAll();
        Address GetById(int addressId);
        void Insert(Address address);
    }
}
