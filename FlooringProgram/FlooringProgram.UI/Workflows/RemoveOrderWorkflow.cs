using FlooringProgram.BLL;
using FlooringProgram.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public const string pageHeader = "**Remove Order From a Given Date's Order Sheet*";
        static int _orderNumber = -1;

        public void Execute()
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            //get date
            string _orderDate = GetRemoveOrderDate(manager);

            //reload manager with order date
            manager = RepoFactory.CreateOrderRepo(_orderDate);

            //get order number
            _orderNumber = GetRemoveOrderNumber(_orderDate);

            //lookup order
            OrderLookupResponse response = manager.LookupOrder(_orderNumber);

            //confirm and execute/abort remove order
            ConfirmRemoveOrder(manager, response);
        }

        private string GetRemoveOrderDate(OperationsManager manager)
        {
            string dateInput;
            bool isCorrectDateFormat = false;

            do
            {
                Console.Clear();
                Console.WriteLine(pageHeader);
                Console.Write("\nEnter a date (MMDDYYYY, must be in future): ");

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

        private int GetRemoveOrderNumber(string _orderDate)
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

        private static void ConfirmRemoveOrder(OperationsManager manager, OrderLookupResponse response)
        {
            if (!response.Success)
            {
                Console.WriteLine();
                Console.WriteLine(response.Message + "" + ConsoleIO.anyKey);
                Console.ReadKey();
            }

            else
            {
                bool finishRemoveProcess = false;

                do
                {
                    Console.Clear();
                    Console.WriteLine(pageHeader);
                    Console.WriteLine();
                    Console.WriteLine("***Order to Remove***");
                    ConsoleIO.DisplayOrderDetails(response.Order);

                    Console.Write("\nDo you want to remove this order to file? (Y or N): ");
                    string userInput = Console.ReadLine().ToUpper();

                    if (userInput == "Y")
                    {
                        finishRemoveProcess = true;
                        response.Success = true;
                        response.Message = "Order has been removed from file!";
                    }
                    else if (userInput == "N")
                    {
                        finishRemoveProcess = true;
                        response.Success = false;
                        response.Message = "Remove order process has been cancelled and order will not be removed from file.";
                    }
                    else
                    {
                        finishRemoveProcess = false;
                    }
                } while (!finishRemoveProcess);

                if (response.Success)
                {
                    manager.RemoveOrder(_orderNumber);

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
}
