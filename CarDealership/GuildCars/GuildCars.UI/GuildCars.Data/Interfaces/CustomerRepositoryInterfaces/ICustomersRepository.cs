using GuildCars.Models.Tables.CustomerTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.CustomerRepositoryInterfaces
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int customerId);
        void Insert(Customer customer, Address address);
        void Update(Customer customer);
    }
}
