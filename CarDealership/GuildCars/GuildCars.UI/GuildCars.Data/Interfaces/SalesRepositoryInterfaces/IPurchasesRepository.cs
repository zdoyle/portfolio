using GuildCars.Models.Queries;
using GuildCars.Models.Tables.CustomerTables;
using GuildCars.Models.Tables.SalesTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces.SalesRepositoryInterfaces
{
    public interface IPurchasesRepository
    {
        IEnumerable<Purchase> GetAll();
        IEnumerable<SalesReportRequestItem> GetAllTotalSales();
        IEnumerable<SalesReportRequestItem> GetAllTotalSales(SalesQuery query);
        Purchase GetById(int purchaseId);
        void Insert(Customer customer, Purchase purchase, Address address);
    }
}
