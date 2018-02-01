using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables.SalesTables
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseTypeId { get; set; }
        public int EmployeeId { get; set; }
    }
}
