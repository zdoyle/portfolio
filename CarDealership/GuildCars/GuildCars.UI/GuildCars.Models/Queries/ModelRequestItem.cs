using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class ModelRequestItem
    {
        public string Model { get; set; }
        public string Make { get; set; }
        public DateTime DateAdded { get; set; }
        public string Employee { get; set; }
    }
}
