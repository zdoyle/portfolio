using FlooringProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI
{
    public class ConsoleIO
    {
        public const string starBorder = "****************************************************************";
        public const string anyKey = "Press any key to continue...";

        public static void DisplayDetailsForEachOrderInList(List<Order> orders, string orderDate)
        {
            Console.WriteLine();
            Console.WriteLine(starBorder);

            foreach (var order in orders)
            {
                Console.WriteLine($"{order.OrderNumber} | {orderDate.Substring(0,2)}/{orderDate.Substring(2, 2)}/{orderDate.Substring(4, 4)}");
                Console.WriteLine($"{order.CustomerName}");
                Console.WriteLine($"{order.State}");
                Console.WriteLine($"Product: {order.ProductType}");
                Console.WriteLine($"Materials: {order.MaterialCost}");
                Console.WriteLine($"Labor: {order.LaborCost}");
                Console.WriteLine($"Tax {order.Tax}");
                Console.WriteLine($"Total: {order.Total}");
                Console.WriteLine(starBorder);
            }
        }

        public static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine("\nOrder Number: {0}", order.OrderNumber);
            Console.WriteLine("Customer Name: {0}", order.CustomerName);
            Console.WriteLine("State: {0} ({1:P} tax rate)", order.State, order.TaxRate / 100);
            Console.WriteLine("Product Type: {0}", order.ProductType);
            Console.WriteLine("Area: {0}", order.Area);
            Console.WriteLine("Cost per Sq. Ft.: {0:C}", order.CostPerSquareFoot);
            Console.WriteLine("Labor Cost per Sq. Ft.: {0:C}", order.LaborCostPerSquareFoot);
            Console.WriteLine("Material Cost: {0:C}", order.MaterialCost);
            Console.WriteLine("Labor Cost: {0:C}", order.LaborCost);
            Console.WriteLine("Tax: {0:C}", order.Tax);
            Console.WriteLine("Total: {0:C}", order.Total);
        }
    }
}
