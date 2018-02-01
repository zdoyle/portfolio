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
    public class VehicleTypesRepositoryADO : IVehicleTypesRepository
    {
        public IEnumerable<VehicleType> GetAll()
        {
            List<VehicleType> vehicleTypes = new List<VehicleType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleTypesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleType currentRow = new VehicleType();
                        currentRow.VehicleTypeId = (byte)dr["VehicleTypeId"];
                        currentRow.Name = dr["Name"].ToString();

                        vehicleTypes.Add(currentRow);
                    }
                }
            }

            return vehicleTypes;
        }

        public VehicleType GetById(byte vehicleTypeId)
        {
            VehicleType vehicleType = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleTypesSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleTypeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicleType = new VehicleType();
                        vehicleType.VehicleTypeId = (byte)dr["VehicleTypeId"];
                        vehicleType.Name = dr["Name"].ToString();
                    }
                }
            }

            return vehicleType;
        }
    }
}
