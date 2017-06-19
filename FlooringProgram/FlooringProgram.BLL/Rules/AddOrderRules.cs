using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Responses;
using System.Text.RegularExpressions;
using System.Globalization;

namespace FlooringProgram.BLL.Rules
{
    public class AddOrderRules
    {
        public AddOrderResponse CheckDate(string date)
        {
            AddOrderResponse response = new AddOrderResponse();

            // date format
            if (date.Length != 8 || !date.All(char.IsDigit))
            {
                response.Success = false;
                response.Message = "Please use correct order date format (MMDDYYYY)";
                return response;
            }


            // date in future?

            CultureInfo provider = CultureInfo.InvariantCulture;

            if (DateTime.ParseExact(date, "MMddyyyy", provider) <= DateTime.Today)
            {
                response.Success = false;
                response.Message = "Specific order date must be in the future.";
                return response;
            }

            response.Success = true;
            return response;

        }

        public AddOrderResponse CheckName(string name)
        {
            AddOrderResponse response = new AddOrderResponse();

            // name format
            Regex charCheck = new Regex("^[a-zA-Z0-9., ]+$");

            if (!charCheck.IsMatch(name) && name != "")
            {
                response.Success = false;
                response.Message = "You have entered an invalid name format (only letters, numbers, spaces, commas, and periods are acceptable).";
                return response;
            }

            response.Success = true;
            return response;
        }

        public AddOrderResponse CheckState(string stateAbbreviation)
        {
            AddOrderResponse response = new AddOrderResponse();

            IStateRepository stateRepo = RepoFactory.CreateStateRepo();

            List<State> states = stateRepo.GetListOfStates();

            if (stateAbbreviation.Length != 2 || !stateAbbreviation.All(char.IsLetter))
            {
                response.Success = false;
                response.Message = "You have entered an invalid State format (must be 2-letter abbreviation).";
                return response;
            }

            foreach (var state in states)
            {
                if (state.StateAbbreviation == stateAbbreviation)
                {
                    response.Success = true;
                    return response;
                }
            }

            response.Success = false;
            response.Message = $"We do not sell products in the state of {stateAbbreviation}.";
            return response;
        }

        public AddOrderResponse CheckProduct(string productType)
        {
            AddOrderResponse response = new AddOrderResponse();

            IProductRepository stateRepo = RepoFactory.CreateProductRepo();

            List<Product> products = stateRepo.GetListOfProducts();

            foreach (var product in products)
            {
                if (product.ProductType == productType)
                {
                    response.Success = true;
                    return response;
                }
            }

            response.Success = false;
            response.Message = $"We do not sell product type \"{productType}\".";
            return response;
        }

        public AddOrderResponse CheckArea(string area)
        {
            AddOrderResponse response = new AddOrderResponse();

            int j;

            if (!int.TryParse(area, out j))
            {
                response.Success = false;
                response.Message = "Input may can only contain digits.";
                return response;
            }

            if (j < 100)
            {

                response.Success = false;
                response.Message = "Minimum order is 100 sq. ft.";
                return response;
            }

            response.Success = true;
            return response;
        }

        public AddOrderResponse CheckEditArea(string area)
        {
            AddOrderResponse response = new AddOrderResponse();

            int j;

            if (!int.TryParse(area, out j) && area != "")
            {
                response.Success = false;
                response.Message = "Input may can only contain digits.";
                return response;
            }

            if (j < 100)
            {

                response.Success = false;
                response.Message = "Minimum order is 100 sq. ft.";
                return response;
            }

            response.Success = true;
            return response;
        }

    }

}
       