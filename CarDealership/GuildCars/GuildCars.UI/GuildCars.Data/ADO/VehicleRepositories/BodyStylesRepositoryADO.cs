using GuildCars.Data.Interfaces.VehicleRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables.VehicleTables;
using System.Data.SqlClient;
using System.Data;

namespace GuildCars.Data.ADO.VehicleRepositories
{
    public class BodyStylesRepositoryADO : IBodyStylesRepository
    {
        public IEnumerable<BodyStyle> GetAll()
        {
            List<BodyStyle> bodyStyles = new List<BodyStyle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStylesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle currentRow = new BodyStyle();
                        currentRow.BodyStyleId = (byte)dr["BodyStyleId"];
                        currentRow.Name = dr["Name"].ToString();

                        bodyStyles.Add(currentRow);
                    }
                }
            }

            return bodyStyles;
        }

        public BodyStyle GetById(byte bodyStyleId)
        {
            BodyStyle bodyStyle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStylesSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BodyStyleId", bodyStyleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        bodyStyle = new BodyStyle();
                        bodyStyle.BodyStyleId = (byte)dr["BodyStyleId"];
                        bodyStyle.Name = dr["Name"].ToString();
                    }
                }
            }

            return bodyStyle;
        }
    }
}
