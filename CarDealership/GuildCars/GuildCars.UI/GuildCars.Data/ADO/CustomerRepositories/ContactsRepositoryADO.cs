using GuildCars.Data.Interfaces.CustomerRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using GuildCars.Models.Tables.CustomerTables;
using GuildCars.Data.Factories.CustomerRepositories;

namespace GuildCars.Data.ADO.CustomerRepositories
{
    public class ContactsRepositoryADO : IContactsRepository
    {
        public IEnumerable<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contact currentRow = new Contact();
                        currentRow.ContactId = (int)dr["ContactId"];
                        currentRow.CustomerId = (int)dr["CustomerId"];
                        currentRow.Message = dr["Message"].ToString();
                        currentRow.ContactDate = (DateTime)dr["ContactDate"];

                        contacts.Add(currentRow);
                    }
                }
            }

            return contacts;
        }

        public Contact GetById(int contactId)
        {
            Contact contact = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContactId", contactId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        contact = new Contact();
                        contact.ContactId = (int)dr["ContactId"];
                        contact.CustomerId = (int)dr["CustomerId"];
                        contact.Message = dr["Message"].ToString();
                        contact.ContactDate = (DateTime)dr["ContactDate"];
                    }
                }
            }

            return contact;
        }

        public void Insert(Customer customer, Contact contact)
        {
            var repo = new CustomersRepositoryADO();

            var contactCustomer = repo.GetAll().Where(c => c.FirstName.ToLower() == customer.FirstName.ToLower() &&
                                                      c.LastName.ToLower() == customer.LastName.ToLower());

            if (contactCustomer.Count() == 0)
            {
                repo.Insert(customer, new Address());

                customer = repo.GetAll().Where(c => c.FirstName.ToLower() == customer.FirstName.ToLower() &&
                                               c.LastName.ToLower() == customer.LastName.ToLower()).FirstOrDefault();
            }

            else
            {
                customer.CustomerId = contactCustomer.FirstOrDefault().CustomerId;

                repo.Update(customer);

                customer = repo.GetAll().Where(c => c.FirstName.ToLower() == customer.FirstName.ToLower() &&
                                               c.LastName.ToLower() == customer.LastName.ToLower()).FirstOrDefault();
            }


            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@Message", contact.Message);

                cn.Open();

                cmd.ExecuteNonQuery();

                contact.ContactId = (int)param.Value;
            }
        }
    }
}
