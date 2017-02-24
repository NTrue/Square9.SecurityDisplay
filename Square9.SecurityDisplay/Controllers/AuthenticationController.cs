﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Text;

namespace Square9.SecurityDisplay.Controllers
{
    [RoutePrefix("authentication")]
    public class AuthenticationController : ApiController
    {
        [HttpGet]
        [ActionName("license")]
        public Models.License getLicense()
        {

            IEnumerable<string> headerValues;
            var authHeader = string.Empty;

            if (Request.Headers.TryGetValues("Authorization", out headerValues))
            {
               authHeader = headerValues.FirstOrDefault();
            }

            var license = new Models.License();
            var logic = new Logic.UsersLogic();
            var authData = logic.GetAuthValues(authHeader);

            license = logic.GetLicense(authData.Username, authData.Password, authData.Domain);

            return license;
        }
    }
}
