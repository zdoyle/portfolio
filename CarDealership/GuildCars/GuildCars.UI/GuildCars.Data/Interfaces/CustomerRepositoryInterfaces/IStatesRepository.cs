using GuildCars.Models.Tables.CustomerTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.CustomerRepositoryInterfaces
{
    public interface IStatesRepository
    {
        IEnumerable<State> GetAll();
        State GetById(byte stateId);
    }
}
