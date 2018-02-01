using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables.VehicleTables
{
    
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VIN { get; set; }
        public int ModelId { get; set; }
        public short ModelYear { get; set; }
        public int Mileage { get; set; }
        public byte TransmissionTypeId { get; set; }
        public byte BodyStyleId { get; set; }
        public byte ColorId { get; set; }
        public byte InteriorColorId { get; set; }
        public byte VehicleTypeId { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSold { get; set; }
    }
}
