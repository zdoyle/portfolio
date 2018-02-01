using GuildCars.Data.ADO.VehicleRepositories;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables.AdminTables;
using GuildCars.Models.Tables.CustomerTables;
using GuildCars.Models.Tables.SalesTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models.ViewModels
{
    public class PurchaseVM : IValidatableObject
    {
        public VehicleRequestItem Vehicle { get; set; }
        public int VehicleId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Phone Number must be 10 digits")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Street Address 1")]
        public string StreetAddress1 { get; set; }
        [DisplayName("Street Address 2")]
        public string StreetAddress2 { get; set; }
        [Required]
        [DisplayName("City")]
        public string City { get; set; }
        [Required]
        [DisplayName("State")]
        public byte StateId { get; set; }
        [Required]
        [DisplayName("Zip Code")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zip Code must be 5 digits")]
        public int ZipCode { get; set; }
        [Required]
        [DisplayName("Purchase Price")]
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        [Required]
        [DisplayName("Purchase Type")]
        public byte PurchaseTypeId { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<SelectListItem> PurchaseTypeItems { get; set; }

        public PurchaseVM()
        {
            Vehicle = new VehicleRequestItem();
            StateItems = new List<SelectListItem>();
            PurchaseTypeItems = new List<SelectListItem>();
        }

        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem()
                {
                    Value = state.StateId.ToString(),
                    Text = state.Abbreviation
                });
            }
        }

        public void SetPurchaseTypeItems(IEnumerable<PurchaseType> purchaseTypes)
        {
            foreach (var purchaseType in purchaseTypes)
            {
                PurchaseTypeItems.Add(new SelectListItem()
                {
                    Value = purchaseType.PurchaseTypeId.ToString(),
                    Text = purchaseType.Name
                });
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (PurchasePrice < Decimal.Multiply(SalePrice, 0.95M))
            {
                errors.Add(new ValidationResult("Vehicle may not be purchased for less than 95% of the Sale Price.",
                    new[] { "Purchase Price" }));
            }

            if (PurchasePrice > MSRP)
            {
                errors.Add(new ValidationResult("Vehicle may not be purchased for more than MSRP.",
                    new[] { "Purchase Price" }));
            }

            return errors;
        }
    }
}