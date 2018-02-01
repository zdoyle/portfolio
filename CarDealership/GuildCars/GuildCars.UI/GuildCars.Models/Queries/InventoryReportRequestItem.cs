using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class InventoryReportRequestItem
    {
        public short ModelYear { get; set; }
        public int ModelId { get; set; }
        public int MakeId { get; set; }
        public string ModelName { get; set; }
        public string MakeName { get; set; }
        public byte VehicleTypeId { get; set; }
        public int VehiclesInStock { get; set; }
        public decimal StockValue { get; set; }
    }
}
