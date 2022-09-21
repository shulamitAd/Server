using Project.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class JobController : ApiController
    {

        private IJobBL _JobBl;

        public JobController(IJobBL jobBl)
        {
            this._JobBl = jobBl;

        }

        [HttpGet]
        public HttpResponseMessage GetChartData()
        {
            try
            {
                var response = _JobBl.GetChartData();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                //TODO add logs
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}