using FlooringProgram.BLL.Rules;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.BLL
{
    public class OperationsManager
    {
        private IOrderRepository _orderRepository;

        public OperationsManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderListLookupResponse LoadListOfOrders(string orderDate)
        {
            OrderListLookupResponse response = new OrderListLookupResponse();

            response.Orders = _orderRepository.GetListOfOrders();

            if (response.Orders == null)
            {
                response.Success = false;
                response.Message = $"There are no orders recorded for {orderDate.Substring(0, 2)}/{orderDate.Substring(2, 2)}/{orderDate.Substring(4, 4)}";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public bool CheckDateFormat(string date)
        {
            if (date.Length == 8 && date.All(char.IsDigit))
            {
                return true;
            }

            return false;
        }

        public AddOrderResponse CheckAddDate(string date)
        {
            AddOrderRules dateRule = new AddOrderRules();

            AddOrderResponse response = dateRule.CheckDate(date);

            return response;
        }

        public AddOrderResponse CheckAddName(string name)
        {
            AddOrderRules nameRule = new AddOrderRules();

            AddOrderResponse response = nameRule.CheckName(name);

            return response;
        }

        public AddOrderResponse CheckAddState(string stateAbbreviation)
        {
            AddOrderRules stateRule = new AddOrderRules();

            AddOrderResponse response = stateRule.CheckState(stateAbbreviation);

            return response;
        }

        public AddOrderResponse CheckAddArea(string area)
        {
            AddOrderRules areaRule = new AddOrderRules();

            AddOrderResponse response = areaRule.CheckArea(area);

            return response;
        }

        public AddOrderResponse CheckEditArea(string area)
        {
            AddOrderRules areaRule = new AddOrderRules();

            AddOrderResponse response = areaRule.CheckEditArea(area);

            return response;
        }

        public AddOrderResponse CheckEditProduct(string productType)
        {
            AddOrderRules productTypeRule = new AddOrderRules();

            AddOrderResponse response = productTypeRule.CheckProduct(productType);

            return response;
        }

        public State GetSingleState(string stateAbbreviation)
        {
            IStateRepository stateRepo = RepoFactory.CreateStateRepo();

            State state = stateRepo.GetSingleState(stateAbbreviation);

            return state;
        }

        public Product GetSingleProduct(string productType)
        {
            IProductRepository productRepo = RepoFactory.CreateProductRepo();

            Product product = productRepo.GetSingleProduct(productType);

            return product;
        }

        public void AddOrder(Order newOrder)
        {
            _orderRepository.AddOrder(newOrder);
        }

        public OrderLookupResponse LookupOrder(int orderNumber)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Order = _orderRepository.GetSingleOrder(orderNumber);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"{orderNumber} is not a valid order number for given date.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public void RemoveOrder(int orderNumber)
        {
            _orderRepository.RemoveOrder(orderNumber);
        }

        public void EditOrder(Order updatedOrder)
        {
            _orderRepository.EditOrder(updatedOrder);
        }
    }
}
