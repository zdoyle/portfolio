using GuildCars.Models.Tables.SalesTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.SalesRepositoryInterfaces
{
    public interface IPurchaseTypesRepository
    {
        IEnumerable<PurchaseType> GetAll();
        PurchaseType GetById(byte purchaseTypeId);
    }
}
