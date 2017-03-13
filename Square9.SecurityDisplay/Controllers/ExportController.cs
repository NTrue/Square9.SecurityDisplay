using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Square9.SecurityDisplay.Controllers
{
    [RoutePrefix("export")]
    public class ExportController : ApiController
    {
        [HttpPost]
        [ActionName("exportDocuments")]
        public HttpResponseMessage ExportSecurityData([FromBody]List<Models.Permissions> permissions, String FilePath)
        {
            try
            {
                Logic.ExportLogic export = new Logic.ExportLogic();
                export.exportData(permissions, FilePath);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Data Exported Successfully.");
        }
    }
}
