using FlooringProgram.BLL;
using FlooringProgram.BLL.Rules;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlooringProgram.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public const string pageHeader = "**Add Order to a Given Date's Order Sheet*";
        string promptForOrderDetails = "";
        string _orderDate = "";
        string _customerName = "";
        string _stateAbbreviation = "";
        string _productType = "";
        decimal _area = -1;

        public void Execute()
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");
            AddOrderResponse response = new AddOrderResponse();

            // get order date
            _orderDate = GetOrderDate(manager);

            //reload manager with order date passed in
            manager = RepoFactory.CreateOrderRepo(_orderDate);
            promptForOrderDetails = $"Enter new order details for order on {_orderDate.Substring(0, 2)}/{_orderDate.Substring(2, 2)}/{_orderDate.Substring(4, 4)}";

            // get customer name
            _customerName = GetOrderCustomerName(manager);

            // get state
            _stateAbbreviation = GetOrderState(manager);

            // get product type
            _productType = GetOrderProductType(manager);

            //get area
            _area = GetOrderArea(manager);

            //confirm add
            response = ConfirmAddOrder(manager, response);

            //execute/abort add
            ExecuteOrAbortAddOrder(manager, response);
        }

        private string GetOrderDate(OperationsManager manager)
        {

            string dateInput;
            bool isCorrectDateFormat = false;

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.Write("\nEnter a date (MMDDYYYY, must be in future): ");

                dateInput = Console.ReadLine();

                AddOrderResponse dateResponse = new AddOrderResponse();

                dateResponse = manager.CheckAddDate(dateInput);

                if (dateResponse.Success == false)
                {
                    isCorrectDateFormat = false;
                    Console.WriteLine();
                    Console.Write(dateResponse.Message + " " + ConsoleIO.anyKey);
                    Console.ReadKey();
                }
                else
                {
                    isCorrectDateFormat = true;
                }
            } while (isCorrectDateFormat == false);

            return dateInput;
        }

        private string GetOrderCustomerName(OperationsManager manager)
        {
            string nameInput = "";
            bool isCorrectNameFormat = false;

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.WriteLine();
                Console.WriteLine(promptForOrderDetails);
                Console.Write("\nCustomer Name: ");

                nameInput = Console.ReadLine();

                AddOrderResponse nameResponse = new AddOrderResponse();

                nameResponse = manager.CheckAddName(nameInput);

                if (!nameResponse.Success)
                {
                    isCorrectNameFormat = false;
                    Console.WriteLine();
                    Console.WriteLine(nameResponse.Message);
                    Console.Write(ConsoleIO.anyKey);
                    Console.ReadKey();
                }
                else
                {
                    isCorrectNameFormat = true;
                }
            } while (isCorrectNameFormat == false);

            return nameInput;
        }

        private string GetOrderState(OperationsManager manager)
        {
            string stateInput = "";
            bool isStateWeSellTo = false;

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.WriteLine();
                Console.WriteLine(promptForOrderDetails);
                Console.WriteLine("\nCustomer Name: {0}", _customerName);
                Console.Write("State (2-letter abbreviation): ");

                stateInput = Console.ReadLine().ToUpper();

                AddOrderResponse stateResponse = new AddOrderResponse();

                stateResponse = manager.CheckAddState(stateInput);

                if (stateResponse.Success == false)
                {
                    isStateWeSellTo = false;
                    Console.WriteLine();
                    Console.WriteLine(stateResponse.Message);
                    Console.WriteLine();
                    Console.Write(ConsoleIO.anyKey);
                    Console.ReadKey();
                }
                else
                {
                    isStateWeSellTo = true;
                }
            } while (isStateWeSellTo == false);

            return stateInput;
        }

        private string GetOrderProductType(OperationsManager manager)
        {
            bool isValidProductType = false;
            string productInputString = "";

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.WriteLine();
                Console.WriteLine(promptForOrderDetails);
                Console.WriteLine("\nCustomer name: " + _customerName);
                Console.WriteLine("State (2-letter abbreviation): " + _stateAbbreviation);
                Console.WriteLine("\nSelect Product Type:\n");

                IProductRepository productRepo = RepoFactory.CreateProductRepo();

                List<Product> products = productRepo.GetListOfProducts();

                int listNumber = 1;

                foreach (var product in products)
                {

                    Console.WriteLine("\t" + listNumber + ". " + product.ProductType);

                    listNumber++;
                }

                Console.Write("\nEnter selection: ");
                string productInput = Console.ReadLine();

                int j;

                while (!int.TryParse(productInput, out j) || j < 1 || j > listNumber - 1)
                {
                    Console.Write("\nPlease enter a valid number (1-{0}): ", listNumber - 1);

                    productInput = Console.ReadLine();
                }

                productInputString = products[j - 1].ProductType;
                isValidProductType = true;
            } while (!isValidProductType);

            return productInputString;
        }

        private decimal GetOrderArea(OperationsManager manager)
        {
            bool isCorrectAreaFormat = false;
            string areaInput = "";

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.WriteLine();
                Console.WriteLine(promptForOrderDetails);
                Console.WriteLine("\nCustomer Name: {0}", _customerName);
                Console.WriteLine("State (2-letter abbreviation): {0}", _stateAbbreviation);
                Console.WriteLine("Product Type: {0}", _productType);
                Console.Write("Area (100 sq. ft. minimum): ");

                areaInput = Console.ReadLine();

                AddOrderResponse areaResponse = new AddOrderResponse();

                areaResponse = manager.CheckAddArea(areaInput);

                if (areaResponse.Success == false)
                {
                    isCorrectAreaFormat = false;
                    Console.WriteLine();
                    Console.WriteLine(areaResponse.Message);
                    Console.WriteLine();
                    Console.Write(ConsoleIO.anyKey);
                    Console.ReadKey();
                }
                else
                {

                    isCorrectAreaFormat = true;
                }
            } while (isCorrectAreaFormat == false);

            return decimal.Parse(areaInput);
        }

        private AddOrderResponse ConfirmAddOrder(OperationsManager manager, AddOrderResponse response)
        {
            bool finishAddProcess = false;

            do
            {
                Order newOrder = new Order();

                newOrder.OrderNumber = manager.LoadListOfOrders(_orderDate).Orders.Count() + 1;
                newOrder.CustomerName = _customerName;
                newOrder.State = _stateAbbreviation;
                newOrder.TaxRate = manager.GetSingleState(_stateAbbreviation).TaxRate;
                newOrder.ProductType = _productType;
                newOrder.Area = _area;
                newOrder.CostPerSquareFoot = manager.GetSingleProduct(_productType).CostPerSquareFoot;
                newOrder.LaborCostPerSquareFoot = manager.GetSingleProduct(_productType).LaborCostPerSquareFoot;
                newOrder.MaterialCost = newOrder.Area * newOrder.CostPerSquareFoot;
                newOrder.LaborCost = newOrder.Area * newOrder.LaborCostPerSquareFoot;
                newOrder.Tax = (newOrder.MaterialCost + newOrder.LaborCost) * (newOrder.TaxRate / 100);
                newOrder.Total = newOrder.MaterialCost + newOrder.LaborCost + newOrder.Tax;

                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.WriteLine();
                Console.WriteLine("***New Order Details***");
                ConsoleIO.DisplayOrderDetails(newOrder);


                Console.Write("\nDo you want to add this order to file? (Y or N): ");
                string userInput = Console.ReadLine().ToUpper();

                if (userInput == "Y")
                {
                    response.Order = newOrder;

                    finishAddProcess = true;
                    response.Success = true;
                    response.Message = "Order has been saved to file!";
                }
                else if (userInput == "N")
                {
                    finishAddProcess = true;
                    response.Success = false;
                    response.Message = "Add order process has been cancelled and order will not be saved to file.";
                }
                else
                {
                    finishAddProcess = false;
                }
            } while (!finishAddProcess);

            return response;
        }

        private void ExecuteOrAbortAddOrder(OperationsManager manager, AddOrderResponse response)
        {
            if (response.Success)
            {
                manager.AddOrder(response.Order);

                Console.Write("\n" + response.Message + " " + ConsoleIO.anyKey);
                Console.ReadKey();
            }
            else
            {
                Console.Write("\n" + response.Message + " " + ConsoleIO.anyKey);
                Console.ReadKey();
            }
        }
    }
}
