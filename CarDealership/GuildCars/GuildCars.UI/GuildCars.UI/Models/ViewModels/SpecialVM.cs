using GuildCars.Data.ADO.AdminRepositories;
using GuildCars.Data.Factories.AdminRepositories;
using GuildCars.Models.Tables.AdminTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models.ViewModels
{
    public class SpecialVM
    {
        public List<Special> Specials { get; set; }
        [Required]
        [DisplayName("Special Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Special Description")]
        public string Description { get; set; }

        public SpecialVM()
        {
            Specials = new List<Special>();
        }

        public void SetSpecials(IEnumerable<Special> specials)
        {
            foreach (var special in specials)
            {
                Specials.Add(new Special()
                {
                    SpecialId = special.SpecialId,
                    Title = special.Title,
                    Description = special.Description
                });
            }
        }
    }
}