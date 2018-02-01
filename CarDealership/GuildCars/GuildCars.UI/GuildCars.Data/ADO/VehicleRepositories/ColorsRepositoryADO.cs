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
    public class ColorsRepositoryADO : IColorsRepository
    {
        public IEnumerable<Color> GetAll()
        {
            List<Color> colors = new List<Color>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ColorsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Color currentRow = new Color();
                        currentRow.ColorId = (byte)dr["ColorId"];
                        currentRow.Name = dr["Name"].ToString();
                        currentRow.ColorCode = dr["ColorCode"].ToString();

                        colors.Add(currentRow);
                    }
                }
            }

            return colors;
        }

        public Color GetById(byte colorId)
        {
            Color color = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ColorsSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ColorId", colorId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        color = new Color();
                        color.ColorId = (byte)dr["ColorId"];
                        color.Name = dr["Name"].ToString();
                        color.ColorCode = dr["ColorCode"].ToString();
                    }
                }
            }

            return color;
        }
    }
}
