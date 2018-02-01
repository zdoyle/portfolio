using GuildCars.Models.Queries;
using GuildCars.Models.Tables.VehicleTables;
using GuildCars.UI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models.ViewModels
{

    public class UpdateVehicleVM : IValidatableObject
    {
        public List<SelectListItem> MakeItems { get; set; }
        public List<SelectListItem> VehicleTypeItems { get; set; }
        public List<SelectListItem> BodyStyleItems { get; set; }
        public List<SelectListItem> TransmissionTypeItems { get; set; }
        public List<Color> ColorItems { get; set; }
        public List<InteriorColor> InteriorColorItems { get; set; }
        public int VehicleId { get; set; }
        [Required]
        [RegularExpression("[A-HJ-NPR-Z0-9]{13}[0-9]{4}", ErrorMessage = "Invalid Vehicle Identification Number Format.")]
        [DisplayName("VIN")]
        public string VIN { get; set; }
        [Required]
        [DisplayName("Make Name")]
        public string MakeName { get; set; }
        [Required]
        [DisplayName("Model Name")]
        public string ModelName { get; set; }
        [Required]
        [DisplayName("Model Year")]
        public short ModelYear { get; set; }
        [Required]
        [DisplayName("Mileage")]
        public int Mileage { get; set; }
        [Required]
        [DisplayName("Transmission Type")]
        public byte TransmissionTypeId { get; set; }
        [Required]
        [DisplayName("Body Style")]
        public byte BodyStyleId { get; set; }
        [Required]
        [DisplayName("Color")]
        public byte ColorId { get; set; }
        [Required]
        [DisplayName("Interior Color")]
        public byte InteriorColorId { get; set; }
        [Required]
        [DisplayName("Vehicle Type")]
        public byte VehicleTypeId { get; set; }
        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required]
        [DisplayName("MSRP")]
        public decimal MSRP { get; set; }
        [Required]
        [DisplayName("Sale Price")]
        public decimal SalePrice { get; set; }
        [DisplayName("Featured Vehicle?")]
        public bool IsFeatured { get; set; }
        [DisplayName("Vehicle Image")]
        public HttpPostedFileBase File { get; set; }
        public List<ModelRequestItem> MakeModels { get; set; }

        public UpdateVehicleVM()
        {
            MakeItems = new List<SelectListItem>();
            VehicleTypeItems = new List<SelectListItem>();
            BodyStyleItems = new List<SelectListItem>();
            TransmissionTypeItems = new List<SelectListItem>();
            ColorItems = new List<Color>();
            InteriorColorItems = new List<InteriorColor>();
            MakeModels = new List<ModelRequestItem>();
        }

        public void SetMakeItems(IEnumerable<CarMake> makes)
        {
            foreach (var make in makes)
            {
                MakeItems.Add(new SelectListItem()
                {
                    Value = make.Name,
                    Text = make.Name
                });
            }
        }

        public void SetVehicleTypeItems(IEnumerable<VehicleType> vehicleTypes)
        {
            foreach (var type in vehicleTypes)
            {
                VehicleTypeItems.Add(new SelectListItem()
                {
                    Value = type.VehicleTypeId.ToString(),
                    Text = type.Name
                });
            }
        }

        public void SetBodyStyleItems(IEnumerable<BodyStyle> bodyStyles)
        {
            foreach (var bodyStyle in bodyStyles)
            {
                BodyStyleItems.Add(new SelectListItem()
                {
                    Value = bodyStyle.BodyStyleId.ToString(),
                    Text = bodyStyle.Name
                });
            }
        }

        public void SetTransmissionTypeItems(IEnumerable<TransmissionType> transmissionTypes)
        {
            foreach (var transmissionType in transmissionTypes)
            {
                TransmissionTypeItems.Add(new SelectListItem()
                {
                    Value = transmissionType.TransmissionTypeId.ToString(),
                    Text = transmissionType.Name
                });
            }
        }

        public void SetColorItems(IEnumerable<Color> colors)
        {
            foreach (var color in colors)
            {
                ColorItems.Add(color);
            }
        }

        public void SetInteriorColorItems(IEnumerable<InteriorColor> interiorColors)
        {
            foreach (var interiorColor in interiorColors)
            {
                InteriorColorItems.Add(interiorColor);
            }
        }

        public void SetMakeModelItems(IEnumerable<ModelRequestItem> makeModels)
        {
            foreach (var mm in makeModels)
            {
                MakeModels.Add(new ModelRequestItem
                {
                    Make = mm.Make,
                    Model = mm.Model
                });
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (SalePrice >= MSRP)
            {
                errors.Add(new ValidationResult("Sale Price must be less than MSRP",
                    new[] { "SalePrice" }));
            }

            return errors;
        }

    }
}