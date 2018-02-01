using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables.VehicleTables
{
    public class CarMake
    {
        public short MakeId { get; set; }
        public string Name { get; set; }
    }
}
