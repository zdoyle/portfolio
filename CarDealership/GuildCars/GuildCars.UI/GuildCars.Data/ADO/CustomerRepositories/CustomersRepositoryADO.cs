using GuildCars.Data.Interfaces.CustomerRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables.CustomerTables;
using System.Data.SqlClient;
using System.Data;

namespace GuildCars.Data.ADO.CustomerRepositories
{
    public class CustomersRepositoryADO : ICustomersRepository
    {
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CustomersSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Customer currentRow = new Customer();
                        currentRow.CustomerId = (int)dr["CustomerId"];
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();

                        if (dr["Email"] != DBNull.Value)
                            currentRow.Email = dr["Email"].ToString();

                        if (dr["Phone"] != DBNull.Value)
                            currentRow.Phone = dr["Phone"].ToString();

                        if (dr["AddressId"] != DBNull.Value)
                            currentRow.AddressId = (int)dr["AddressId"];

                        customers.Add(currentRow);
                    }
                }
            }

            return customers;
        }

        public Customer GetById(int customerId)
        {
            Customer customer = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CustomersSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        customer = new Customer();
                        customer.CustomerId = (int)dr["CustomerId"];
                        customer.FirstName = dr["FirstName"].ToString();
                        customer.LastName = dr["LastName"].ToString();

                        if (dr["Email"] != DBNull.Value)
                            customer.Email = dr["Email"].ToString();

                        if (dr["Phone"] != DBNull.Value)
                            customer.Phone = dr["Phone"].ToString();

                        if (dr["AddressId"] != DBNull.Value)
                            customer.AddressId = (int)dr["AddressId"];
                    }
                }
            }

            return customer;
        }

        public void Insert(Customer customer, Address address)
        {
            if (address.StreetAddress1 == null)
                address = null;

            

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CustomersInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@CustomerId", SqlDbType.Int);
                param1.Direction = ParameterDirection.Output;

                SqlParameter param2 = new SqlParameter("@AddressId", SqlDbType.Int);
                param2.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param1);

                cmd.Parameters.Add(param2);

                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);


                if (String.IsNullOrWhiteSpace(customer.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                }

                if (String.IsNullOrWhiteSpace(customer.Phone))
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                }

                if (address != null)
                {
                    cmd.Parameters.AddWithValue("@StreetAddress1", address.StreetAddress1);

                    if (String.IsNullOrWhiteSpace(address.StreetAddress2))
                    {
                        cmd.Parameters.AddWithValue("@StreetAddress2", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@StreetAddress2", address.StreetAddress2);
                    }

                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@StateId", address.StateId);
                    cmd.Parameters.AddWithValue("@ZipCode", address.ZipCode); 
                }
                else
                {
                    cmd.Parameters.AddWithValue("@StreetAddress1", DBNull.Value);
                    cmd.Parameters.AddWithValue("@StreetAddress2", DBNull.Value);
                    cmd.Parameters.AddWithValue("@City", DBNull.Value);
                    cmd.Parameters.AddWithValue("@StateId", DBNull.Value);
                    cmd.Parameters.AddWithValue("@ZipCode", DBNull.Value);
                }

                cn.Open();

                cmd.ExecuteNonQuery();

                customer.CustomerId = (int)param1.Value;

                if (param2.Value != DBNull.Value)
                    customer.AddressId = (int)param2.Value;

            }
        }

        public void Update(Customer customer)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CustomersUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);

                if (String.IsNullOrWhiteSpace(customer.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                }

                if (String.IsNullOrWhiteSpace(customer.Phone))
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                }

                if (!customer.AddressId.HasValue)
                {
                    cmd.Parameters.AddWithValue("@AddressId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AddressId", customer.AddressId);
                }

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
