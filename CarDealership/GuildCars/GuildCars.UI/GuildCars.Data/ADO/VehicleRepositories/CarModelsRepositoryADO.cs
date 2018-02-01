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
using GuildCars.Data.Factories.VehicleRepositories;

namespace GuildCars.Data.ADO.VehicleRepositories
{
    public class CarModelsRepositoryADO : ICarModelsRepository
    {
        public IEnumerable<CarModel> GetAll()
        {
            List<CarModel> models = new List<CarModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarModelsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CarModel currentRow = new CarModel();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.MakeId = (short)dr["MakeId"];
                        currentRow.Name = dr["Name"].ToString();

                        models.Add(currentRow);
                    }
                }
            }

            return models;
        }

        public CarModel GetById(int modelId)
        {
            CarModel model = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarModelsSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ModelId", modelId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        model = new CarModel();
                        model.ModelId = (int)dr["ModelId"];
                        model.MakeId = (short)dr["MakeId"];
                        model.Name = dr["Name"].ToString();
                    }
                }
            }

            return model;
        }

        public IEnumerable<ModelRequestItem> GetDetailsAll()
        {
            List<ModelRequestItem> models = new List<ModelRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarModelsSelectAllDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ModelRequestItem currentRow = new ModelRequestItem();
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.DateAdded = DateTime.Parse("1/1/1900");
                        currentRow.Employee = "n/a";

                        models.Add(currentRow);
                    }
                }
            }

            return models;
        }

        public IEnumerable<ModelRequestItem> GetDetailsAllInStock()
        {
            List<ModelRequestItem> models = new List<ModelRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarModelsInStockSelectAllDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ModelRequestItem currentRow = new ModelRequestItem();
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.Employee = dr["Employee"].ToString();

                        models.Add(currentRow);
                    }
                }
            }

            return models;
        }

        public void Insert(CarModel model, CarMake make)
        {
            var makesRepo = new CarMakesRepositoryADO();

            var makeModel = makesRepo.GetById(make.MakeId);

            if (makeModel == null)
            {
                makesRepo.Insert(make);

                make = makesRepo.GetAll().Where(m => m.Name == make.Name).FirstOrDefault();
            }

            else
            {
                make = makeModel;
            }

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarModelsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeId", make.MakeId);
                cmd.Parameters.AddWithValue("@Name", model.Name);

                cn.Open();

                cmd.ExecuteNonQuery();

                model.ModelId = (int)param.Value;
            }
        }
    }
}
