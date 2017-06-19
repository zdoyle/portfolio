using FlooringProgram.Data;
using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.BLL
{
    public static class RepoFactory
    {
        public static OperationsManager CreateOrderRepo(string date)
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OperationsManager(new OrderTestRepository(date));
                case "Prod":
                    return new OperationsManager(new OrderProdRepository(Settings.baseFilePath, date));
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }

        public static IStateRepository CreateStateRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new StateTestRepository();
                case "Prod":
                    return new StateProdRepository(Settings.baseFilePath);
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }

        public static IProductRepository CreateProductRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new ProductTestRepository();
                case "Prod":
                    return new ProductProdRepository(Settings.baseFilePath);
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
