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
    public class VehiclesRepositoryADO : IVehiclesRepository
    {
        public void Delete(int vehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Vehicle> GetAll()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.ModelYear = (short)dr["ModelYear"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.TransmissionTypeId = (byte)dr["TransmissionTypeId"];
                        currentRow.BodyStyleId = (byte)dr["BodyStyleId"];
                        currentRow.ColorId = (byte)dr["ColorId"];
                        currentRow.InteriorColorId = (byte)dr["InteriorColorId"];
                        currentRow.VehicleTypeId = (byte)dr["VehicleTypeId"];
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.EmployeeId = (int)dr["EmployeeId"];
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsSold = (bool)dr["IsSold"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public IEnumerable<VehicleRequestItem> GetDetailsAllByIsSold(bool isSold)
        {
            List<VehicleRequestItem> vehicles = new List<VehicleRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAllDetailsByIsSold", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IsSold", isSold);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleRequestItem currentRow = new VehicleRequestItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.ModelYear = (short)dr["ModelYear"];
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.VehicleType = dr["VehicleType"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.ColorCode = dr["ColorCode"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.InteriorColorCode = dr["InteriorColorCode"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.IsSold = (bool)dr["IsSold"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public IEnumerable<VehicleRequestItem> GetDetailsAllByVehicleTypeId(byte vehicleTypeId, VehicleQuery query)
        {
            List<VehicleRequestItem> vehicles = new List<VehicleRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAllDetailsByVehicleTypeId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleTypeId);

                if (String.IsNullOrWhiteSpace(query.SearchQuery))
                {
                    cmd.Parameters.AddWithValue("@SearchQuery", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SearchQuery", query.SearchQuery);
                }

                if (!query.MinPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinPrice", query.MinPrice);
                }

                if (!query.MaxPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", query.MaxPrice);
                }

                if (!query.MinYear.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinYear", query.MinYear);
                }

                if (!query.MaxYear.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MaxYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaxYear", query.MaxYear);
                }

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleRequestItem currentRow = new VehicleRequestItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.ModelYear = (short)dr["ModelYear"];
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.VehicleType = dr["VehicleType"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.ColorCode = dr["ColorCode"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.InteriorColorCode = dr["InteriorColorCode"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.IsSold = (bool)dr["IsSold"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public Vehicle GetById(int vehicleId)
        {
            Vehicle vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicle();
                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.ModelYear = (short)dr["ModelYear"];
                        vehicle.ModelId = (int)dr["ModelId"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.TransmissionTypeId = (byte)dr["TransmissionTypeId"];
                        vehicle.BodyStyleId = (byte)dr["BodyStyleId"];
                        vehicle.ColorId = (byte)dr["ColorId"];
                        vehicle.InteriorColorId = (byte)dr["InteriorColorId"];
                        vehicle.VehicleTypeId = (byte)dr["VehicleTypeId"];
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.ImageFileName = dr["ImageFileName"].ToString();
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.EmployeeId = (int)dr["EmployeeId"];
                        vehicle.DateAdded = (DateTime)dr["DateAdded"];
                        vehicle.IsFeatured = (bool)dr["IsFeatured"];
                        vehicle.IsSold = (bool)dr["IsSold"];
                    }
                }
            }

            return vehicle;
        }

        public IEnumerable<VehicleRequestItem> GetDetailsAll()
        {
            List<VehicleRequestItem> vehicles = new List<VehicleRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAllDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SearchQuery", DBNull.Value);
                cmd.Parameters.AddWithValue("@MinPrice", DBNull.Value);
                cmd.Parameters.AddWithValue("@MaxPrice", DBNull.Value);
                cmd.Parameters.AddWithValue("@MinYear", DBNull.Value);
                cmd.Parameters.AddWithValue("@MaxYear", DBNull.Value);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleRequestItem currentRow = new VehicleRequestItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.ModelYear = (short)dr["ModelYear"];
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.VehicleType = dr["VehicleType"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.ColorCode = dr["ColorCode"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.InteriorColorCode = dr["InteriorColorCode"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.IsSold = (bool)dr["IsSold"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public VehicleRequestItem GetDetailsById(int vehicleId)
        {
            VehicleRequestItem vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAllDetailsById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new VehicleRequestItem();
                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.ModelYear = (short)dr["ModelYear"];
                        vehicle.Model = dr["Model"].ToString();
                        vehicle.Make = dr["Make"].ToString();
                        vehicle.VehicleType = dr["VehicleType"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.TransmissionType = dr["TransmissionType"].ToString();
                        vehicle.BodyStyle = dr["BodyStyle"].ToString();
                        vehicle.Color = dr["Color"].ToString();
                        vehicle.ColorCode = dr["ColorCode"].ToString();
                        vehicle.InteriorColor = dr["InteriorColor"].ToString();
                        vehicle.InteriorColorCode = dr["InteriorColorCode"].ToString();
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.ImageFileName = dr["ImageFileName"].ToString();
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.IsSold = (bool)dr["IsSold"];
                    }
                }
            }

            return vehicle;
        }

        public void Insert(Vehicle vehicle, CarModel model, CarMake make)
        {
            var vehicleRepo = new VehiclesRepositoryADO();
            var modelRepo = new CarModelsRepositoryADO();
            var makeRepo = new CarMakesRepositoryADO();

            var submittedModel = modelRepo.GetAll().Where(m => m.Name.ToLower() == model.Name.ToLower()).ToList();

            var submittedMake = makeRepo.GetAll().Where(m => m.Name.ToLower() == make.Name.ToLower()).ToList();

            if (submittedModel.Count() == 0)
            {
                if (submittedMake.Count() == 0)
                {
                    makeRepo.Insert(make);

                    make = makeRepo.GetAll().Where(m => m.Name.ToLower() == make.Name.ToLower()).ToList().FirstOrDefault();
                }

                else
                {
                    model.MakeId = submittedMake.FirstOrDefault().MakeId;
                }

                modelRepo.Insert(model, make);

                model = modelRepo.GetAll().Where(m => m.Name.ToLower() == model.Name.ToLower()).ToList().FirstOrDefault();
            }

            else
            {
                
                    model = submittedModel.FirstOrDefault();
            }

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@ModelId", model.ModelId);
                cmd.Parameters.AddWithValue("@ModelYear", vehicle.ModelYear);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@TransmissionTypeId", vehicle.TransmissionTypeId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@ColorId", vehicle.ColorId);
                cmd.Parameters.AddWithValue("@InteriorColorId", vehicle.InteriorColorId);
                cmd.Parameters.AddWithValue("@VehicleTypeId", vehicle.VehicleTypeId);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@EmployeeId", vehicle.EmployeeId);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleId = (int)param.Value;
            }
        }

        public IEnumerable<FeaturedVehicleRequestItem> GetFeaturedDetailsAll()
        {
            List<FeaturedVehicleRequestItem> vehicles = new List<FeaturedVehicleRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("FeaturedVehicleSelectAllDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedVehicleRequestItem currentRow = new FeaturedVehicleRequestItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.ModelYear = (short)dr["ModelYear"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.MakeId = (short)dr["MakeId"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.SalePrice = (decimal)dr["SalePrice"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public IEnumerable<InventoryReportRequestItem> GetTotalInventoryDetailsAll()
        {
            List<InventoryReportRequestItem> vehicles = new List<InventoryReportRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InventoryReportSelectAllDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReportRequestItem currentRow = new InventoryReportRequestItem();
                        currentRow.ModelYear = (short)dr["ModelYear"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.MakeId = (short)dr["MakeId"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.VehicleTypeId = (byte)dr["VehicleTypeId"];
                        currentRow.VehiclesInStock = (int)dr["VehiclesInStock"];
                        currentRow.StockValue = (decimal)dr["StockValue"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public IEnumerable<VehicleRequestItem> GetDetailsAllByVehicleTypeId(byte vehicleTypeId)
        {
            List<VehicleRequestItem> vehicles = new List<VehicleRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAllDetailsByVehicleTypeId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleTypeId);
                cmd.Parameters.AddWithValue("@SearchQuery", DBNull.Value);
                cmd.Parameters.AddWithValue("@MinPrice", DBNull.Value);
                cmd.Parameters.AddWithValue("@MaxPrice", DBNull.Value);
                cmd.Parameters.AddWithValue("@MinYear", DBNull.Value);
                cmd.Parameters.AddWithValue("@MaxYear", DBNull.Value);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleRequestItem currentRow = new VehicleRequestItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.ModelYear = (short)dr["ModelYear"];
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.VehicleType = dr["VehicleType"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.ColorCode = dr["ColorCode"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.InteriorColorCode = dr["InteriorColorCode"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.IsSold = (bool)dr["IsSold"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public IEnumerable<VehicleRequestItem> GetDetailsAll(VehicleQuery query)
        {
            List<VehicleRequestItem> vehicles = new List<VehicleRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAllDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (String.IsNullOrWhiteSpace(query.SearchQuery))
                {
                    cmd.Parameters.AddWithValue("@SearchQuery", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SearchQuery", query.SearchQuery);
                }

                if (!query.MinPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinPrice", query.MinPrice);
                }

                if (!query.MaxPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", query.MaxPrice);
                }

                if (!query.MinYear.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinYear", query.MinYear);
                }

                if (!query.MaxYear.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MaxYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaxYear", query.MaxYear);
                }

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleRequestItem currentRow = new VehicleRequestItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.ModelYear = (short)dr["ModelYear"];
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.VehicleType = dr["VehicleType"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.ColorCode = dr["ColorCode"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.InteriorColorCode = dr["InteriorColorCode"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.IsSold = (bool)dr["IsSold"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public void Update(Vehicle vehicle, CarModel model, CarMake make)
        {
            var vehicleRepo = new VehiclesRepositoryADO();
            var modelRepo = new CarModelsRepositoryADO();
            var makeRepo = new CarMakesRepositoryADO();

            var submittedModel = modelRepo.GetAll().Where(m => m.Name.ToLower() == model.Name.ToLower()).ToList();

            var submittedMake = makeRepo.GetAll().Where(m => m.Name.ToLower() == make.Name.ToLower()).ToList();

            if (submittedModel.Count() == 0)
            {
                if (submittedMake.Count() == 0)
                {
                    makeRepo.Insert(make);

                    make = makeRepo.GetAll().Where(m => m.Name.ToLower() == make.Name.ToLower()).ToList().FirstOrDefault();
                }

                else
                {
                    model.MakeId = submittedMake.FirstOrDefault().MakeId;
                }

                modelRepo.Insert(model, make);

                model = modelRepo.GetAll().Where(m => m.Name.ToLower() == model.Name.ToLower()).ToList().FirstOrDefault();
            }

            else
            {

                model = submittedModel.FirstOrDefault();
            }

            if (vehicle.ImageFileName == null)
            {
                vehicle.ImageFileName = vehicleRepo.GetById(vehicle.VehicleId).ImageFileName;
            }

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@ModelId", model.ModelId);
                cmd.Parameters.AddWithValue("@ModelYear", vehicle.ModelYear);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@TransmissionTypeId", vehicle.TransmissionTypeId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@ColorId", vehicle.ColorId);
                cmd.Parameters.AddWithValue("@InteriorColorId", vehicle.InteriorColorId);
                cmd.Parameters.AddWithValue("@VehicleTypeId", vehicle.VehicleTypeId);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@EmployeeId", vehicle.EmployeeId);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
