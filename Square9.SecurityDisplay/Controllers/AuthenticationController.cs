using System;
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
            var nameFilter = string.Empty;
            var authHeader = string.Empty;
            if (Request.Headers.TryGetValues("Authorization", out headerValues))
            {
               authHeader = headerValues.FirstOrDefault();
            }
            var domain = "";
            var username = "";
            var password = "";
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
                int seperatorIndex = usernamePassword.IndexOf(':');
                int domainSeperatorIndex = (usernamePassword.IndexOf('\\') + 1);
                domain = usernamePassword.Substring(0, domainSeperatorIndex - 1);
                username = usernamePassword.Substring(domainSeperatorIndex, seperatorIndex - domainSeperatorIndex);
                password = usernamePassword.Substring(seperatorIndex + 1);
            }
            else {
                //Handle what happens if that isn't the case
                throw new Exception("The authorization header is either empty or isn't Basic.");
            }
            var license = new Models.License();
            var logic = new Logic.UsersLogic();
            license = logic.GetLicense(username, password, domain);
            return license;
        }
    }
}
