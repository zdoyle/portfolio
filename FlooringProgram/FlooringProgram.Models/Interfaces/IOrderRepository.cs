using FlooringProgram.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models.Interfaces
{
    public interface IOrderRepository
    {
        //list, add, edit, delete
        List<Order> GetListOfOrders();
        Order GetSingleOrder(int orderNumber);
        void AddOrder(Order newOrder);
        void EditOrder(Order updatedOrder);
        void RemoveOrder(int orderNumber);
    }
}
