using GuildCars.Models.Queries;
using GuildCars.Models.Tables.AdminTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models.ViewModels
{
    public class UpdateUserVM : IValidatableObject
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Department Name")]
        public byte DepartmentId { get; set; }
        [DisplayName("New Password?")]
        public string NewPassword { get; set; }
        [DisplayName("Confirm Password")]
        public string ConfirmNewPassword { get; set; }
        [Required]
        [DisplayName("User Disabled?")]
        public bool IsDisabled { get; set; }
        public int EmployeeId { get; set; }
        public List<SelectListItem> DepartmentItems { get; set; }

        public UpdateUserVM()
        {
            DepartmentItems = new List<SelectListItem>();
        }

        public void SetDepartmentItems(IEnumerable<Department> departments)
        {
            foreach (var department in departments)
            {
                DepartmentItems.Add(new SelectListItem()
                {
                    Value = department.DepartmentId.ToString(),
                    Text = department.Name
                });
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (NewPassword != ConfirmNewPassword)
            {
                errors.Add(new ValidationResult("Confirm Password field must match New Password field.",
                    new[] { "ConfirmNewPassword" }));
            }

            return errors;
        }
    }
}