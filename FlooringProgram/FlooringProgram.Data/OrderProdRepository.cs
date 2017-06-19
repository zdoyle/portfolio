using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.Responses;

namespace FlooringProgram.Data
{
    public class OrderProdRepository : IOrderRepository
    {
        private string _filePath;
        private string _date;

        

        public OrderProdRepository(string baseFilePath, string date)
        {
            _date = date;
            _filePath = baseFilePath + "Orders\\" + "Orders_" + _date + ".txt";
        }

        public List<Order> GetListOfOrders()
        {
            List<Order> orders = CreateOrderListFromFile();

            return orders;
        }

        public Order GetSingleOrder(int orderNumber)
        {
            List<Order> orders = CreateOrderListFromFile();

            foreach (var order in orders)
            {
                if (orderNumber == order.OrderNumber)
                {
                    return order;
                }
            }

            return null;
        }

        public void AddOrder(Order newOrder)
        {
            List<Order> orders = CreateOrderListFromFile();

            orders.Add(newOrder);

            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            WriteNewOrderSheet(orders);
        }

        public void EditOrder(Order updatedOrder)
        {
            List<Order> orders = CreateOrderListFromFile();

            int index = -1;

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderNumber == updatedOrder.OrderNumber)
                {
                    index = i;
                    break;
                }
            }

            orders.RemoveAt(index);
            orders.Add(updatedOrder);

            var newOrders = from o in orders
                            orderby o.OrderNumber
                            select o;

            orders = newOrders.ToList();

            WriteNewOrderSheet(orders);
        }

        public void RemoveOrder(int orderNumber)
        {
            List<Order> orders = CreateOrderListFromFile();

            int index = -1;

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderNumber == orderNumber)
                {
                    index = i;
                    break;
                }
            }

            orders.RemoveAt(index);

            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            if (orders.Count() != 0)
            {
                WriteNewOrderSheet(orders);
            }
        }

        private List<Order> CreateOrderListFromFile()
        {
            List<Order> orders = new List<Order>();

            if (File.Exists(_filePath))
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Order singleOrder = new Order();

                        string[] columns = line.Split(',');

                        singleOrder.OrderNumber = int.Parse(columns[0]);
                        singleOrder.CustomerName = columns[1];
                        singleOrder.State = columns[2];
                        singleOrder.TaxRate = decimal.Parse(columns[3]);
                        singleOrder.ProductType = columns[4];
                        singleOrder.Area = decimal.Parse(columns[5]);
                        singleOrder.CostPerSquareFoot = decimal.Parse(columns[6]);
                        singleOrder.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                        singleOrder.MaterialCost = decimal.Parse(columns[8]);
                        singleOrder.LaborCost = decimal.Parse(columns[9]);
                        singleOrder.Tax = decimal.Parse(columns[10]);
                        singleOrder.Total = decimal.Parse(columns[11]);

                        orders.Add(singleOrder);
                    }
                }
            }

            return orders;
        }

        private void WriteNewOrderSheet(List<Order> orders)
        {
            using (StreamWriter sr = new StreamWriter(_filePath))
            {
                sr.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (var order in orders)
                {
                    sr.WriteLine($"{order.OrderNumber},{order.CustomerName},{order.State},{order.TaxRate},{order.ProductType},{order.Area},{order.CostPerSquareFoot},{order.LaborCostPerSquareFoot},{order.MaterialCost},{order.LaborCost},{order.Tax},{order.Total}");
                }
            }
        }
    }
}
