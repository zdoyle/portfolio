using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;
using FlooringProgram.Models.Responses;

namespace FlooringProgram.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        List<Order> orders = new List<Order>();

        private string _date;

        private static Order _order1 = new Order
        {
            OrderNumber = 1,
            CustomerName = "North Oldham High School",
            State = "KY",
            TaxRate = 6.00M,
            ProductType = "Carpet",
            Area = 100.00M,
            CostPerSquareFoot = 2.50M,
            LaborCostPerSquareFoot = 4.00M,
            MaterialCost = 250.00M, //_order.Area * _order.CostPerSquareFoot,
            LaborCost = 400.00M, //_order.Area * _order.LaborCostPerSquareFoot,
            Tax = 39.00M, //(_order.MaterialCost + _order.LaborCost) * (_order.TaxRate/100),
            Total = 689.00M //_order.MaterialCost + _order.LaborCost + _order.Tax
        };

        private static Order _order2 = new Order
        {
            OrderNumber = 2,
            CustomerName = "Seneca High School",
            State = "KY",
            TaxRate = 6.00M,
            ProductType = "Carpet",
            Area = 50.00M,
            CostPerSquareFoot = 2.50M,
            LaborCostPerSquareFoot = 4.00M,
            MaterialCost = 125.00M, //_order.Area * _order.CostPerSquareFoot,
            LaborCost = 200.00M, //_order.Area * _order.LaborCostPerSquareFoot,
            Tax = 19.50M, //(_order.MaterialCost + _order.LaborCost) * (_order.TaxRate/100),
            Total = 344.50M //_order.MaterialCost + _order.LaborCost + _order.Tax
        };

        public OrderTestRepository(string date)
        {
            _date = date;

            orders.Add(_order1);
            orders.Add(_order2);
        }


        public void AddOrder(Order newOrder)
        {
            orders.Add(newOrder);
        }

        public void EditOrder(Order updatedOrder)
        {
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
        }

        public List<Order> GetListOfOrders()
        {
            return orders;
        }

        public Order GetSingleOrder(int orderNumber)
        {
            foreach (var order in orders)
            {
                if (orderNumber == order.OrderNumber)
                {
                    return order;
                }
            }

            return null;
        }

        public void RemoveOrder(int orderNumber)
        {
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
        }
    }
}
