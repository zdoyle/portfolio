using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Tests
{
    [TestFixture]
    public class TestRepoTests
    {
        [Test]
        public void CanLoadOrderList()
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            OrderListLookupResponse response = manager.LoadListOfOrders("");

            Assert.IsNotEmpty(response.Orders);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("North Oldham High School", response.Orders[0].CustomerName);
        }

        [Test]
        public void CanLookupSingleOrder()
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            OrderLookupResponse response = manager.LookupOrder(1);

            Assert.IsNotNull(response.Order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("North Oldham High School", response.Order.CustomerName);
        }

        [TestCase("My Company", "KY", "Carpet", 100)]
        public void CanAddOrder(string customerName, string stateAbbreviation, string productType, decimal area)
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            Order order = new Order();

            order.OrderNumber = manager.LoadListOfOrders("").Orders.Count() + 1;
            order.CustomerName = customerName;
            order.State = stateAbbreviation;
            order.TaxRate = manager.GetSingleState(stateAbbreviation).TaxRate;
            order.ProductType = productType;
            order.Area = area;
            order.CostPerSquareFoot = manager.GetSingleProduct(productType).CostPerSquareFoot;
            order.LaborCostPerSquareFoot = manager.GetSingleProduct(productType).LaborCostPerSquareFoot;
            order.MaterialCost = order.Area * order.CostPerSquareFoot;
            order.LaborCost = order.Area * order.LaborCostPerSquareFoot;
            order.Tax = (order.MaterialCost + order.LaborCost) * (order.TaxRate / 100);
            order.Total = order.MaterialCost + order.LaborCost + order.Tax;

            manager.AddOrder(order);

            Assert.AreEqual(3, manager.LoadListOfOrders("").Orders.Count());
            Assert.AreEqual("My Company", manager.LoadListOfOrders("").Orders[2].CustomerName);
        }

        [Test]
        public void CanRemoveOrder()
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            manager.RemoveOrder(2);

            Assert.AreEqual(1, manager.LoadListOfOrders("").Orders.Count());
        }

        [Test]
        public void CanEditOrder()
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            Order order = new Order();
            int orderNumber = 1;

            order.OrderNumber = orderNumber;
            order.CustomerName = "Glencliff High School";
            order.State = manager.LookupOrder(orderNumber).Order.State;
            order.TaxRate = manager.LookupOrder(orderNumber).Order.TaxRate;
            order.ProductType = manager.LookupOrder(orderNumber).Order.ProductType;
            order.Area = manager.LookupOrder(orderNumber).Order.Area;
            order.CostPerSquareFoot = manager.GetSingleProduct(order.ProductType).CostPerSquareFoot;
            order.LaborCostPerSquareFoot = manager.GetSingleProduct(order.ProductType).LaborCostPerSquareFoot;
            order.MaterialCost = order.Area * order.CostPerSquareFoot;
            order.LaborCost = order.Area * order.LaborCostPerSquareFoot;
            order.Tax = (order.MaterialCost + order.LaborCost) * (order.TaxRate / 100);
            order.Total = order.MaterialCost + order.LaborCost + order.Tax;

            manager.EditOrder(order);

            Assert.AreNotEqual("North Oldham High School", manager.LoadListOfOrders("").Orders[1].CustomerName);
            Assert.AreEqual("Glencliff High School", manager.LoadListOfOrders("").Orders[1].CustomerName);
        }

        [TestCase("150", true)]
        [TestCase("50", false)]
        [TestCase("banana", false)]
        public void CanCheckAddArea(string area, bool expectedResult)
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            AddOrderResponse response = manager.CheckAddArea(area);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("Art Factory, Inc.", true)]
        [TestCase("H&M Store", false)]
        public void CanCheckAddName(string name, bool expectedResult)
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            AddOrderResponse response = manager.CheckAddName(name);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("09099999", true)]
        [TestCase("01012017", false)]
        [TestCase("10 Mar 9999", false)]
        [TestCase("1/1/2019", false)]
        public void CanCheckAddDate(string date, bool expectedResult)
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            AddOrderResponse response = manager.CheckAddDate(date);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("KY", true)]
        [TestCase("IN", false)]
        [TestCase("Indiana", false)]
        [TestCase("23", false)]
        public void CanCheckAddState(string stateAbbreviation, bool expectedResult)
        {
            OperationsManager manager = RepoFactory.CreateOrderRepo("");

            AddOrderResponse response = manager.CheckAddState(stateAbbreviation);

            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
