using GuildCars.Data.ADO.VehicleRepositories;
using GuildCars.Data.Factories.VehicleRepositories;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables.VehicleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers.ApiControllers
{
    [RoutePrefix("inventory/vehicles")]
    public class InventoryAPIController : ApiController
    {
        [Route("all/get/{searchQuery}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllVehicles(string searchQuery, short? minPrice, short? maxPrice, short? minYear, short? maxYear)
        {
            VehicleQuery query = new VehicleQuery();

            query.SearchQuery = searchQuery;
            query.MinPrice = minPrice;
            query.MaxPrice = maxPrice;
            query.MinYear = minYear;
            query.MaxYear = maxYear;

            var repo = VehiclesRepositoryFactory.GetRepository();

            var model = repo.GetDetailsAll(query).Take(20);

            return Ok(model);
        }

        [Route("")]
        [Route("new/get/{searchQuery}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult NewVehicles(string searchQuery, short? minPrice, short? maxPrice, short? minYear, short? maxYear)
        {
            VehicleQuery query = new VehicleQuery();

            query.SearchQuery = searchQuery;
            query.MinPrice = minPrice;
            query.MaxPrice = maxPrice;
            query.MinYear = minYear;
            query.MaxYear = maxYear;

            var repo = VehiclesRepositoryFactory.GetRepository();

            var model = repo.GetDetailsAllByVehicleTypeId(1, query).Take(20);

            return Ok(model);
        }

        [Route("")]
        [Route("used/get/{searchQuery}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult UsedVehicles(string searchQuery, short? minPrice, short? maxPrice, short? minYear, short? maxYear)
        {
            VehicleQuery query = new VehicleQuery();

            query.SearchQuery = searchQuery;
            query.MinPrice = minPrice;
            query.MaxPrice = maxPrice;
            query.MinYear = minYear;
            query.MaxYear = maxYear;

            var repo = VehiclesRepositoryFactory.GetRepository();

            var model = repo.GetDetailsAllByVehicleTypeId(2, query).Take(20);

            return Ok(model);
        }

        [Route("")]
        [Route("models/get/{makeName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModelsByMake(string makeName)
        {
            var repo = CarModelsRepositoryFactory.GetRepository();

            var model = repo.GetDetailsAll().Where(m => m.Make.ToLower() == makeName.ToLower());

            return Ok(model);
        }
    }
}
