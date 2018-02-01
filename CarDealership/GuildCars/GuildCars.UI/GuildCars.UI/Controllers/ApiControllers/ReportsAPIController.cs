using GuildCars.Data.ADO.SalesRepositories;
using GuildCars.Data.Factories.SalesRepositories;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers.ApiControllers
{
    [RoutePrefix("reports/get")]
    public class ReportsAPIController : ApiController
    {
        [Route("all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllSales()
        {
            var repo = PurchasesRepositoryFactory.GetRepository();

            var model = repo.GetAllTotalSales();

            return Ok(model);
        }

        [Route("")]
        [Route("all/{employeeName}/{fromDate}/{toDate}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllSalesViaSearch(string employeeName, DateTime? fromDate, DateTime? toDate)
        {
            SalesQuery query = new SalesQuery();

            query.EmployeeName = employeeName;
            query.ToDate = toDate;
            query.FromDate = fromDate;

            var repo = PurchasesRepositoryFactory.GetRepository();

            var model = repo.GetAllTotalSales(query);

            return Ok(model);
        }
    }
}
