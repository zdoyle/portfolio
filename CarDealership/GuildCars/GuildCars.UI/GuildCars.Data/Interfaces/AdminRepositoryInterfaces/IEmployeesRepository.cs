using GuildCars.Models.Queries;
using GuildCars.Models.Tables.AdminTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.AdminRepositoryInterfaces
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int employeeId);
        void Insert(Employee employee);
        void Update(Employee employee, string emailAddress, bool isDisabled);
        IEnumerable<UserRequestItem> GetUserDetailsAll();
    }
}
