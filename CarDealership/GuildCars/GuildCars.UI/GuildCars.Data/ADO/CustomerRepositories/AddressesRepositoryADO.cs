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
    public class AddressesRepositoryADO : IAddressesRepository
    {
        public IEnumerable<Address> GetAll()
        {
            List<Address> addresses = new List<Address>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddressesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Address currentRow = new Address();
                        currentRow.AddressId = (int)dr["AddressId"];
                        currentRow.StreetAddress1 = dr["StreetAddress1"].ToString();

                        if (dr["StreetAddress2"] != DBNull.Value)
                            currentRow.StreetAddress2 = dr["StreetAddress2"].ToString();

                        currentRow.City = dr["City"].ToString();
                        currentRow.StateId = (byte)dr["StateId"];
                        currentRow.ZipCode = (int)dr["ZipCode"];

                        addresses.Add(currentRow);
                    }
                }
            }

            return addresses;
        }

        public Address GetById(int addressId)
        {
            Address address = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddressesSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AddressId", addressId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        address = new Address();
                        address.AddressId = (int)dr["AddressId"];
                        address.StreetAddress1 = dr["StreetAddress1"].ToString();

                        if (dr["StreetAddress2"] != DBNull.Value)
                            address.StreetAddress2 = dr["StreetAddress2"].ToString();

                        address.City = dr["City"].ToString();
                        address.StateId = (byte)dr["StateId"];
                        address.ZipCode = (int)dr["ZipCode"];
                    }
                }
            }

            return address;
        }

        public void Insert(Address address)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddressesInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@AddressId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

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

                cn.Open();

                cmd.ExecuteNonQuery();

                address.AddressId = (int)param.Value;
            }
        }
    }
}
