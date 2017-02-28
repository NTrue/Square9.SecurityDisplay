using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;

namespace Square9.SecurityDisplay.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        //(api/users/groupusers?DomainOrServerName={computer name/domain}&GroupName={group name}&Domain=false)
        [HttpGet]
        [ActionName("groupusers")]
        public HttpResponseMessage Get(string DomainOrServerName, string GroupName, bool Domain = true)
        {
            List<string> Users = new List<string>();

            try
            {
                var logic = new Square9.SecurityDisplay.Logic.UsersLogic();
                Users = logic.GetUsersOfGroup(DomainOrServerName, GroupName, Domain);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Unable to return the Secured Users Tree Results: " + ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Users);
        }

        //(api/users/tree?DomainOrServerName={computer name/domain}&UserName={username}&Password={password})
        [HttpGet]
        [ActionName("tree")]
        public HttpResponseMessage GetUserTree(string DomainOrServerName, string UserName, string Password)
        {
            List<Models.SecurityNode> Users = new List<Models.SecurityNode>();

            try
            {
                var logic = new Square9.SecurityDisplay.Logic.UsersLogic();
                Users = logic.GetSecuredUsersTree(DomainOrServerName, UserName, Password);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Unable to return the Secured Users Tree Results: " + ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Users);
        }

        //(api/users/tree?DomainOrServerName={computer name/domain}&UserName={username}&Password={password})
        [HttpGet]
        [ActionName("secured")]
        public HttpResponseMessage GetSecuredUserList(string DomainOrServerName, string UserName, string Password, string Secured = "secured")
        {
            List<Models.SecuredGroup> Users = new List<Models.SecuredGroup>();

            try
            {
                var logic = new Square9.SecurityDisplay.Logic.UsersLogic();
                Users = logic.GetSecuredUsers(DomainOrServerName, UserName, Password);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.Forbidden, "Unable to return the Secured Users List: " + ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.Forbidden, Users);
        }

        //(api/users/tree?DomainOrServerName={computer name/domain}&UserName={username}&Password={password})
        [HttpGet]
        [ActionName("permissions")]
        public HttpResponseMessage GetAllDatabasePermissions(int DatabaseID, bool isDomain = true)
        {
            List<Models.Permissions> permissions = new List<Models.Permissions>();
            IEnumerable<string> headerValues;
            var authHeader = string.Empty;
            if (Request.Headers.TryGetValues("Authorization", out headerValues))
            {
                authHeader = headerValues.FirstOrDefault();
            }

            try
            {
                var logic = new Square9.SecurityDisplay.Logic.UsersLogic();
                var authData = logic.GetAuthValues(authHeader);
                permissions = logic.GetAllDatabasePermissions(authData.Domain, authData.Username, authData.Password, DatabaseID, isDomain);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Unable to return permissions: " + ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, permissions);
        }
    }
}
