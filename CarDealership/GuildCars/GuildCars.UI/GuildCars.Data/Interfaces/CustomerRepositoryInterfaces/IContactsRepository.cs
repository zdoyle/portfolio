using GuildCars.Models.Tables.CustomerTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.CustomerRepositoryInterfaces
{
    public interface IContactsRepository
    {
        IEnumerable<Contact> GetAll();
        Contact GetById(int contactId);
        void Insert(Customer customer, Contact contact);
    }
}
