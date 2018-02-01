using GuildCars.Models.Tables.AdminTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.AdminRepositoryInterfaces
{
    public interface ISpecialsRepository
    {
        IEnumerable<Special> GetAll();
        Special GetById(int specialId);
        void Insert(Special special);
        void Delete(int specialId);
    }
}
