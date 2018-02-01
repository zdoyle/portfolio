using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleRequestItem
    {
        public int VehicleId { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public short ModelYear { get; set; }
        public string VehicleType { get; set; }
        public int Mileage { get; set; }
        public string TransmissionType { get; set; }
        public string BodyStyle { get; set; }
        public string Color { get; set; }
        public string ColorCode { get; set; }
        public string InteriorColor { get; set; }
        public string InteriorColorCode { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsSold { get; set; }
    }
}
