using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class FeaturedVehicleRequestItem
    {
        public int VehicleId { get; set; }
        public int ModelId { get; set; }
        public int MakeId { get; set; }
        public short ModelYear { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string ImageFileName { get; set; }
        public decimal SalePrice { get; set; }
    }
}
