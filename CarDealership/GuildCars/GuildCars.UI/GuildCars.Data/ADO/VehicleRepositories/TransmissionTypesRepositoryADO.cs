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
    public class TransmissionTypesRepositoryADO : ITransmissionTypesRepository
    {
        public IEnumerable<TransmissionType> GetAll()
        {
            List<TransmissionType> transmissionTypes = new List<TransmissionType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionTypesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TransmissionType currentRow = new TransmissionType();
                        currentRow.TransmissionTypeId = (byte)dr["TransmissionTypeId"];
                        currentRow.Name = dr["Name"].ToString();

                        transmissionTypes.Add(currentRow);
                    }
                }
            }

            return transmissionTypes;
        }

        public TransmissionType GetById(byte transmissionTypeId)
        {
            TransmissionType transmissionType = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionTypesSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TransmissionTypeId", transmissionTypeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        transmissionType = new TransmissionType();
                        transmissionType.TransmissionTypeId = (byte)dr["TransmissionTypeId"];
                        transmissionType.Name = dr["Name"].ToString();
                    }
                }
            }

            return transmissionType;
        }
    }
}
