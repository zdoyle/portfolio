using GuildCars.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.UI.Models.Attributes
{
    public class SalePriceMustBeLessThanMSRPAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is UpdateVehicleVM)
            {
                UpdateVehicleVM checkVM = (UpdateVehicleVM)value;
                if (checkVM.SalePrice >= checkVM.MSRP)
                    return false;
                else
                    return true;
            }

            return false;
        }
    }
}
