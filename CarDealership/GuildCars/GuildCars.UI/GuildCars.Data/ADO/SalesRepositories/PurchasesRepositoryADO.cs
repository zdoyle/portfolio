using GuildCars.Data.Interfaces.SalesRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables.SalesTables;
using System.Data.SqlClient;
using System.Data;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables.CustomerTables;
using GuildCars.Data.ADO.CustomerRepositories;
using GuildCars.Data.Factories.CustomerRepositories;

namespace GuildCars.Data.ADO.SalesRepositories
{
    public class PurchasesRepositoryADO : IPurchasesRepository
    {
        public IEnumerable<Purchase> GetAll()
        {
            List<Purchase> purchases = new List<Purchase>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchasesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Purchase currentRow = new Purchase();
                        currentRow.PurchaseId = (int)dr["PurchaseId"];
                        currentRow.CustomerId = (int)dr["CustomerId"];
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.PurchaseDate = (DateTime)dr["PurchaseDate"];
                        currentRow.PurchasePrice = (decimal)dr["PurchasePrice"];
                        currentRow.PurchaseTypeId = (byte)dr["PurchaseTypeId"];
                        currentRow.EmployeeId = (int)dr["EmployeeId"];

                        purchases.Add(currentRow);
                    }
                }
            }

            return purchases;
        }

        public IEnumerable<SalesReportRequestItem> GetAllTotalSales()
        {
            List<SalesReportRequestItem> request = new List<SalesReportRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesReportSelectAllDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeFirstName", DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeLastName", DBNull.Value);
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReportRequestItem currentRow = new SalesReportRequestItem();
                        currentRow.EmployeeId = (int)dr["EmployeeId"];
                        currentRow.EmployeeName = dr["EmployeeName"].ToString();
                        currentRow.TotalSales = (decimal)dr["TotalSales"];
                        currentRow.TotalVehicles = (int)dr["TotalVehicles"];

                        request.Add(currentRow);
                    }
                }
            }

            return request;
        }

        public IEnumerable<SalesReportRequestItem> GetAllTotalSales(SalesQuery query)
        {
            List<SalesReportRequestItem> request = new List<SalesReportRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesReportSelectAllDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                if (String.IsNullOrWhiteSpace(query.EmployeeName))
                {
                    cmd.Parameters.AddWithValue("@EmployeeFirstName", DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmployeeLastName", DBNull.Value);
                }
                else
                {
                    string[] names = query.EmployeeName.Split(' ');

                    cmd.Parameters.AddWithValue("@EmployeeFirstName", names[0]);
                    cmd.Parameters.AddWithValue("@EmployeeLastName", names[1]);
                }


                if(!query.FromDate.HasValue)
                {
                    cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FromDate", query.FromDate);
                }

                if (!query.ToDate.HasValue)
                {
                    cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ToDate", query.ToDate);
                }

                

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReportRequestItem currentRow = new SalesReportRequestItem();
                        currentRow.EmployeeId = (int)dr["EmployeeId"];
                        currentRow.EmployeeName = dr["EmployeeName"].ToString();
                        currentRow.TotalSales = (decimal)dr["TotalSales"];
                        currentRow.TotalVehicles = (int)dr["TotalVehicles"];

                        request.Add(currentRow);
                    }
                }
            }

            return request;
        }

        public Purchase GetById(int purchaseId)
        {
            Purchase purchase = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchasesSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PurchaseId", purchaseId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        purchase = new Purchase();
                        purchase.PurchaseId = (int)dr["PurchaseId"];
                        purchase.CustomerId = (int)dr["CustomerId"];
                        purchase.VehicleId = (int)dr["VehicleId"];
                        purchase.PurchaseDate = (DateTime)dr["PurchaseDate"];
                        purchase.PurchasePrice = (decimal)dr["PurchasePrice"];
                        purchase.PurchaseTypeId = (byte)dr["PurchaseTypeId"];
                        purchase.EmployeeId = (int)dr["EmployeeId"];
                    }
                }
            }

            return purchase;
        }

        public void Insert(Customer customer, Purchase purchase, Address address)
        {
            var customerRepo = new CustomersRepositoryADO();
            var addressRepo = new AddressesRepositoryADO();

            var purchaseCustomer = customerRepo.GetAll().Where(c => c.FirstName.ToLower() == customer.FirstName.ToLower() &&
                                                      c.LastName.ToLower() == customer.LastName.ToLower()).ToList();

            var customerAddress = addressRepo.GetAll().Where(a => a.StreetAddress1 == address.StreetAddress1 &&
                                                                      a.StreetAddress2 == address.StreetAddress2 &&
                                                                      a.City == address.City &&
                                                                      a.StateId == address.StateId &&
                                                                      a.ZipCode == address.ZipCode).ToList();

            if (purchaseCustomer.Count() == 0)
            {
                if (customerAddress.Count() > 0)
                {
                    address = customerAddress.FirstOrDefault();
                }

                customerRepo.Insert(customer, address);

                customer = customerRepo.GetAll().Where(c => c.FirstName.ToLower() == customer.FirstName.ToLower() &&
                                               c.LastName.ToLower() == customer.LastName.ToLower()).FirstOrDefault();
            }

            else
            {
                if (customerAddress.Count() == 0)
                {
                    addressRepo.Insert(address);

                    customer.AddressId = addressRepo.GetAll().Where(a => a.StreetAddress1 == address.StreetAddress1 &&
                                                                    a.StreetAddress2 == address.StreetAddress2 &&
                                                                    a.City == address.City &&
                                                                    a.StateId == address.StateId &&
                                                                    a.ZipCode == address.ZipCode).FirstOrDefault().AddressId;
                }

                customer.CustomerId = purchaseCustomer.FirstOrDefault().CustomerId;

                customerRepo.Update(customer);

                customer = customerRepo.GetAll().Where(c => c.FirstName.ToLower() == customer.FirstName.ToLower() &&
                                               c.LastName.ToLower() == customer.LastName.ToLower()).FirstOrDefault();
            }


            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchasesInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@PurchaseId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@VehicleId", purchase.VehicleId);
                cmd.Parameters.AddWithValue("@PurchaseDate", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@PurchasePrice", purchase.PurchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseTypeId", purchase.PurchaseTypeId);
                cmd.Parameters.AddWithValue("@EmployeeId", purchase.EmployeeId);

                cn.Open();

                cmd.ExecuteNonQuery();

                purchase.PurchaseId = (int)param.Value;
            }
        }
    }
}
