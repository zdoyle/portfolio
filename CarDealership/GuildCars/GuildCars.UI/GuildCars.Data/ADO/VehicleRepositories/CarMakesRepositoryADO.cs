using GuildCars.Data.Interfaces.VehicleRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables.VehicleTables;
using System.Data.SqlClient;
using System.Data;
using GuildCars.Models.Queries;

namespace GuildCars.Data.ADO.VehicleRepositories
{
    public class CarMakesRepositoryADO : ICarMakesRepository
    {
        public IEnumerable<CarMake> GetAll()
        {
            List<CarMake> makes = new List<CarMake>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarMakesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CarMake currentRow = new CarMake();
                        currentRow.MakeId = (short)dr["MakeId"];
                        currentRow.Name = dr["Name"].ToString();

                        makes.Add(currentRow);
                    }
                }
            }

            return makes;
        }

        public CarMake GetById(short makeId)
        {
            CarMake make = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarMakesSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeId", makeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        make = new CarMake();
                        make.MakeId = (short)dr["MakeId"];
                        make.Name = dr["Name"].ToString();
                    }
                }
            }

            return make;
        }

        public IEnumerable<MakeRequestItem> GetDetailsAllInStock()
        {
            List<MakeRequestItem> models = new List<MakeRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarMakesInStockSelectAllDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MakeRequestItem currentRow = new MakeRequestItem();
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.Employee = dr["Employee"].ToString();

                        models.Add(currentRow);
                    }
                }
            }

            return models;
        }

        public void Insert(CarMake make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarMakesInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MakeId", SqlDbType.SmallInt);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Name", make.Name);

                cn.Open();

                cmd.ExecuteNonQuery();

                make.MakeId = (short)param.Value;
            }
        }
    }
}
