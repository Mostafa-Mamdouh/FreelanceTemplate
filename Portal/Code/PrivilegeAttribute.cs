using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Text;
using System.Net;
using System.Configuration;
using System.Web.Routing; 

namespace Web
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CheckPrivilegeAttribute : AuthorizationFilterAttribute 
    {
        Boolean Ismultiple = false ; 
        //Enumerations.Privilege privilege;
        //Enumerations.Privilege[] privileges;

        //public CheckPrivilegeAttribute(Enumerations.Privilege privilege)
        //{
        //    Ismultiple = false; 
        //    this.privilege = privilege;
        //}

        //public CheckPrivilegeAttribute(params Enumerations.Privilege[] privileges)
        //{
        //    Ismultiple = true; 
        //    this.privileges = privileges;
        //}

        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    var request = actionContext.Request;
        //    var IssingleAllowed =  !Ismultiple && PrivilegeHelper.IsPrivilegeExists(this.privilege); 
        //    var IsmutipleAllowed = Ismultiple && PrivilegeHelper.ArePrivilegesExiss(this.privileges);

        //    if (General.GetCurrentUser() == null)
        //    {
        //        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        string accessdeniedlocation = ConfigurationManager.AppSettings["RootURI"] + "#/login";
        //        //actionContext.Response = new RedirectResult(accessdeniedlocation);

                
        //    }
        //    else if ((!IssingleAllowed && !IsmutipleAllowed))
        //    {
        //        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
        //        string accessdeniedlocation = ConfigurationManager.AppSettings["RootURI"] + "#/login"; 
        //    }
        //}

    }
}