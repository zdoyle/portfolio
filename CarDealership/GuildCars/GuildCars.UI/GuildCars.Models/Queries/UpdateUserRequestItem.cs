using GuildCars.Models.Tables.AdminTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class UpdateUserRequestItem
    {
        public Employee Employee { get; set; }
        [Required]
        [DisplayName("Email")]
        public string EmailAddress { get; set; }
        [Required]
        [DisplayName("Disable User?")]
        public bool IsDisabled { get; set; }
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
        [DisplayName("Confirm New Password")]
        public string ConfirmNewPassword { get; set; }
        

        public UpdateUserRequestItem()
        {
            Employee = new Employee();
        }
    }
}
