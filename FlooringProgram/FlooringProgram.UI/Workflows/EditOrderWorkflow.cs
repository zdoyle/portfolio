using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Models.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlooringProgram.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public const string pageHeader = "**Edit Order From a Given Date's Order Sheet*";
        static int _orderNumber = -1;
        string _orderDate = "";
        string nameInput = "";
        string stateInput = "";
        string productInput = "";
        decimal areaInput = -1;

        public void Execute()
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            //get date
            _orderDate = GetEditOrderDate(manager);

            //reload manager with order date
            manager = RepoFactory.CreateOrderRepo(_orderDate);

            //get order list
            OrderListLookupResponse _orders = manager.LoadListOfOrders(_orderDate);
            
            //get order number
            _orderNumber = GetEditOrderNumber(_orderDate);

            //confirm and execute/abort edit order
            OrderLookupResponse response = new OrderLookupResponse();
            EditOrder(manager, _orders, response);
        }

        private string GetEditOrderDate(OperationsManager manager)
        {
            string dateInput;
            bool isCorrectDateFormat = false;

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.Write("\nEnter a date (MMDDYYYY): ");

                dateInput = Console.ReadLine();

                if (manager.CheckDateFormat(dateInput))
                {
                    isCorrectDateFormat = true;
                }
                else
                {
                    isCorrectDateFormat = false;
                    Console.Write("Please use correct order date format (MMDDYYYY). " + ConsoleIO.anyKey);
                    Console.ReadKey();
                }
            } while (isCorrectDateFormat == false);

            return dateInput;
        }

        private static int GetEditOrderNumber(string _orderDate)
        {
            int _orderNumber;
            bool isNumber = false;

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.WriteLine();
                Console.Write($"Enter an order number for {_orderDate.Substring(0, 2)}/{_orderDate.Substring(2, 2)}/{_orderDate.Substring(4, 4)}: ");
                string orderNumberInput = Console.ReadLine();

                if (!int.TryParse(orderNumberInput, out _orderNumber))
                {
                    isNumber = false;
                    Console.WriteLine("Order number may not contain letters or special characters. " + ConsoleIO.anyKey);
                    Console.ReadKey();

                }
                else
                {
                    isNumber = true;
                }
            } while (!isNumber);
            return _orderNumber;
        }

        private void EditOrder(OperationsManager manager, OrderListLookupResponse _orders, OrderLookupResponse response)
        {
            var selectedOrder = from o in _orders.Orders
                                where o.OrderNumber == _orderNumber
                                select o;

            if (selectedOrder == null)
            {
                Console.WriteLine();
                Console.WriteLine($"There is no order that matches given order number for {_orderDate.Substring(0, 2)}/{_orderDate.Substring(2, 2)}/{_orderDate.Substring(4, 4)}. " + ConsoleIO.anyKey);
                Console.ReadKey();
            }

            else
            {
                response.Order = selectedOrder.ElementAt(0);
                TakeInOrderEdits(manager, response);

                if (response.Success)
                {
                    manager.EditOrder(response.Order);

                    Console.WriteLine("\n" + response.Message + "\n");
                    Console.WriteLine($"Order number {_orderNumber} for {_orderDate.Substring(0, 2)}/{_orderDate.Substring(2, 2)}/{_orderDate.Substring(4, 4)} has been updated to the following: ");
                    ConsoleIO.DisplayOrderDetails(response.Order);
                    Console.Write("\n" + ConsoleIO.anyKey);
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("\n" + response.Message + " " + ConsoleIO.anyKey);
                    Console.ReadKey();
                }

            }
        }

        private void TakeInOrderEdits(OperationsManager manager, OrderLookupResponse response)
        {
            bool finishEditProcess = false;

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.WriteLine();
                Console.WriteLine("***Order to Remove***");
                ConsoleIO.DisplayOrderDetails(response.Order);

                Console.WriteLine("\nYou may edit the following information of this order:");
                Console.WriteLine("\n\tCustomer Name");
                Console.WriteLine("\tState");
                Console.WriteLine("\tProduct Type");
                Console.WriteLine("\tArea");
                Console.Write("\nDo you want to edit this order ? (Y or N): ");
                string userInput = Console.ReadLine().ToUpper();

                if (userInput == "Y")
                {

                    nameInput = GetEditOrderCustomerName(manager, response);

                    stateInput = GetEditOrderState(manager, response);

                    productInput = GetEditOrderProductType(manager, response);

                    areaInput = GetEditOrderArea(manager, response);

                    Console.Write("\nAre you sure you wish to replace the order information with the new information above? (Y or N): ");
                    string editOrNo = Console.ReadLine().ToUpper();


                    if (editOrNo == "Y")
                    {
                        if (nameInput != "")
                        {
                            response.Order.CustomerName = nameInput;
                        }

                        if (stateInput != "")
                        {
                            response.Order.State = stateInput;
                        }

                        if (productInput != "")
                        {
                            response.Order.ProductType = productInput;
                        }

                        if (areaInput != 0)
                        {
                            response.Order.Area = areaInput;
                        }

                        finishEditProcess = true;
                        response.Success = true;
                        response.Message = "Order has been edited!";
                    }

                    else
                    {
                        finishEditProcess = true;
                        response.Success = false;
                        response.Message = "Edit order process has been cancelled and order will not be edited.";
                    }
                }
                else if (userInput == "N")
                {
                    finishEditProcess = true;
                    response.Success = false;
                    response.Message = "Edit order process has been cancelled and order will not be edited.";
                }
                else
                {
                    finishEditProcess = false;
                }
            } while (!finishEditProcess);
        }

        private string GetEditOrderCustomerName(OperationsManager manager, OrderLookupResponse response)
        {
            bool isCorrectNameFormat = false;
            string userInput = "";

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.WriteLine("\n***Edit Order Number {0} for {1}/{2}/{3}***", response.Order.OrderNumber, _orderDate.Substring(0, 2), _orderDate.Substring(2, 2), _orderDate.Substring(4, 4));
                Console.WriteLine("\nIf you wish to edit a field, type in the new information.  If you wish to leave the field unchanged, simply press enter.");

                Console.Write("\nCustomer Name ({0}): ", response.Order.CustomerName);
                userInput = Console.ReadLine();

                if (manager.CheckAddName(userInput).Success)
                {
                    isCorrectNameFormat = true;
                }
                else
                {
                    isCorrectNameFormat = false;
                    Console.WriteLine();
                    Console.WriteLine(manager.CheckAddName(userInput).Message);
                    Console.Write(ConsoleIO.anyKey);
                    Console.ReadKey();
                }
            } while (!isCorrectNameFormat);

            return userInput;
        }

        private string GetEditOrderState(OperationsManager manager, OrderLookupResponse response)
        {
            bool isCorrectStateFormat = false;
            string userInput = "";

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.WriteLine("\n***Edit Order Number {0} for {1}/{2}/{3}***", response.Order.OrderNumber, _orderDate.Substring(0, 2), _orderDate.Substring(2, 2), _orderDate.Substring(4, 4));
                Console.WriteLine("\nIf you wish to edit a field, type in the new information.  If you wish to leave the field unchanged, simply press enter.");

                Console.WriteLine("\nCustomer Name ({0}): {1}", response.Order.CustomerName, nameInput);
                Console.Write("State ({0}): ", response.Order.State);
                userInput = Console.ReadLine();



                if (manager.CheckAddState(userInput).Success || userInput == "")
                {
                    isCorrectStateFormat = true;
                }
                else
                {
                    isCorrectStateFormat = false;
                    Console.WriteLine();
                    Console.WriteLine(manager.CheckAddState(userInput).Message);
                    Console.Write(ConsoleIO.anyKey);
                    Console.ReadKey();
                }
            } while (!isCorrectStateFormat);

            return userInput;
        }

        private string GetEditOrderProductType(OperationsManager manager, OrderLookupResponse response)
        {
            bool isCorrectProductType = false;
            string productInputString = "";

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.WriteLine("\n***Edit Order Number {0} for {1}/{2}/{3}***", response.Order.OrderNumber, _orderDate.Substring(0, 2), _orderDate.Substring(2, 2), _orderDate.Substring(4, 4));
                Console.WriteLine("\nIf you wish to edit a field, type in the new information.  If you wish to leave the field unchanged, simply press enter.");

                Console.WriteLine("\nCustomer Name ({0}): {1}", response.Order.CustomerName, nameInput);
                Console.WriteLine("State ({0}): {1}", response.Order.State, stateInput);
                Console.WriteLine("ProductType ({0}): ", response.Order.ProductType);
                Console.WriteLine();

                IProductRepository productRepo = RepoFactory.CreateProductRepo();

                List<Product> products = productRepo.GetListOfProducts();

                int listNumber = 1;

                foreach (var product in products)
                {

                    Console.WriteLine("\t" + listNumber + ". " + product.ProductType);

                    listNumber++;
                }

                Console.Write("\nEnter selection: ");
                string userInput = Console.ReadLine();

                int j;

                if (!int.TryParse(userInput, out j) || j < 1 || j > listNumber - 1)
                {
                    Console.Write($"\nPlease enter a valid number (1-{listNumber - 1}). "  + ConsoleIO.anyKey);
                    Console.ReadKey();
                    isCorrectProductType = false;
                }

                else
                {
                    productInputString = products[j - 1].ProductType;
                    isCorrectProductType = true; 
                }

            } while (!isCorrectProductType);

            return productInputString;
        }

        private decimal GetEditOrderArea(OperationsManager manager, OrderLookupResponse response)
        {
            bool isCorrectAreaFormat = false;
            string userInput = "";

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.WriteLine("\n***Edit Order Number {0} for {1}/{2}/{3}***", response.Order.OrderNumber, _orderDate.Substring(0, 2), _orderDate.Substring(2, 2), _orderDate.Substring(4, 4));
                Console.WriteLine("\nIf you wish to edit a field, type in the new information.  If you wish to leave the field unchanged, simply press enter.");

                Console.WriteLine("\nCustomer Name ({0}): {1}", response.Order.CustomerName, nameInput);
                Console.WriteLine("State ({0}): {1}", response.Order.State, stateInput);
                Console.WriteLine("ProductType ({0}): ", response.Order.ProductType);
                Console.Write("Area ({0}): ", response.Order.Area);

                userInput = Console.ReadLine();

                AddOrderResponse areaResponse = new AddOrderResponse();

                areaResponse = manager.CheckEditArea(userInput);

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

            return decimal.Parse(userInput);
        }
    }
}
