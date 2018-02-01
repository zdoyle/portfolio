using GuildCars.Data.Interfaces.SalesRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables.SalesTables;
using System.Data.SqlClient;
using System.Data;

namespace GuildCars.Data.ADO.SalesRepositories
{
    public class PurchaseTypesRepositoryADO : IPurchaseTypesRepository
    {
        public IEnumerable<PurchaseType> GetAll()
        {
            List<PurchaseType> purchaseTypes = new List<PurchaseType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseType currentRow = new PurchaseType();
                        currentRow.PurchaseTypeId = (byte)dr["PurchaseTypeId"];
                        currentRow.Name = dr["Name"].ToString();

                        purchaseTypes.Add(currentRow);
                    }
                }
            }

            return purchaseTypes;
        }

        public PurchaseType GetById(byte purchaseTypeId)
        {
            PurchaseType purchaseType = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypesSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PurchaseTypeId", purchaseTypeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        purchaseType = new PurchaseType();
                        purchaseType.PurchaseTypeId = (byte)dr["PurchaseTypeId"];
                        purchaseType.Name = dr["Name"].ToString();
                    }
                }
            }

            return purchaseType;
        }
    }
}
