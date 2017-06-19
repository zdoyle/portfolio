using FlooringProgram.BLL;
using FlooringProgram.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI.Workflows
{
    public class DisplayOrdersWorkflow
    {
        public const string pageHeader = "**Display Orders for a Given Date**";

        public void Execute()
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            //get date
            string _orderDate = GetDisplayOrdersDate(manager);

            //reload manager with order date
            manager = RepoFactory.CreateOrderRepo(_orderDate);

            //get list of orders
            OrderListLookupResponse response = manager.LoadListOfOrders(_orderDate);

            //show list success
            DisplayList(_orderDate, response);
        }

        private string GetDisplayOrdersDate(OperationsManager manager)
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

        private void DisplayList(string _orderDate, OrderListLookupResponse response)
        {
            if (response.Success)
            {
                ConsoleIO.DisplayDetailsForEachOrderInList(response.Orders, _orderDate);
            }
            else
            {
                Console.WriteLine("\nAn error occured: " + response.Message);
            }

            Console.WriteLine();
            Console.Write(ConsoleIO.anyKey);
            Console.ReadKey();
        }
    }
}
