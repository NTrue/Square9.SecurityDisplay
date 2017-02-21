using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Square9.SecurityDisplay.Controllers
{
    [RoutePrefix("authentication")]
    public class AuthenticationController : ApiController
    {
        [HttpGet]
        [ActionName("license")]
        public Models.License getLicense()
        {
            var license = new Models.License();

            return license;
        }
    }
}
