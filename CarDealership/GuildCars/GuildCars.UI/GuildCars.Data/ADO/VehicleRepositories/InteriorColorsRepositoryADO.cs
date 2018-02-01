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
    public class InteriorColorsRepositoryADO : IInteriorColorsRepository
    {
        public IEnumerable<InteriorColor> GetAll()
        {
            List<InteriorColor> interiorColors = new List<InteriorColor>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InteriorColor currentRow = new InteriorColor();
                        currentRow.InteriorColorId = (byte)dr["InteriorColorId"];
                        currentRow.Name = dr["Name"].ToString();
                        currentRow.ColorCode = dr["ColorCode"].ToString();

                        interiorColors.Add(currentRow);
                    }
                }
            }

            return interiorColors;
        }

        public InteriorColor GetById(byte interiorColorId)
        {
            InteriorColor interiorColor = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorsSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@InteriorColorId", interiorColorId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        interiorColor = new InteriorColor();
                        interiorColor.InteriorColorId = (byte)dr["InteriorColorId"];
                        interiorColor.Name = dr["Name"].ToString();
                        interiorColor.ColorCode = dr["ColorCode"].ToString();
                    }
                }
            }

            return interiorColor;
        }
    }
}
