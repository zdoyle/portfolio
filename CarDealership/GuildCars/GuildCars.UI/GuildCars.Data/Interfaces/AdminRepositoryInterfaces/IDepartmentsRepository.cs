using GuildCars.Models.Tables.AdminTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.AdminRepositoryInterfaces
{
    public interface IDepartmentsRepository
    {
        IEnumerable<Department> GetAll();
        Department GetById(byte departmentId);
    }
}
