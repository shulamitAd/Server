using EFModel.CustomEntities;
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
        private ILogger _Logger;

        public JobController(IJobBL jobBl, ILogger logger)
        {
            this._JobBl = jobBl;
            this._Logger = logger;
        }

        [HttpPost]
        public HttpResponseMessage GetChartData(FromToModel fromTo)
        {
            try
            {
                var response = _JobBl.GetChartData(fromTo);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                //TODO add logs
                _Logger.WriteLog(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}