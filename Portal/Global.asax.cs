#region Using

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using Vendor.Portal;
using Vendor.Portal.Code;
using Web;
using Web.Code;
#endregion

namespace Web
{
    public class MvcApplication : HttpApplication
    {
        //string con = ConfigurationManager.ConnectionStrings["sqlConString"].ConnectionString;
        protected void Application_Start()
        {
            try
            {
                if (HostingEnvironment.IsDevelopmentEnvironment)
                {
                    var appLocation = Server.MapPath("/");
                    Process _npmProcess = new Process
                    {
                        StartInfo= new ProcessStartInfo { 
                        FileName="cmd.exe",
                        Arguments=@"/c npm start --prefix" + appLocation + "/ClientApp",
                        UseShellExecute=true
                        }
                    };
                    _npmProcess.Start();
                }
            }
            catch (Exception)
            {

            }
            
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RSACryptoServiceProvider.UseMachineKeyStore = true;
            DSACryptoServiceProvider.UseMachineKeyStore = true;

            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //SqlDependency.Start(con);
            //GlobalConfiguration.Configuration.Filters.Add(new ExceptionHandling());
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath == "content/SmartAdmin/js/config.js")
            {
                HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            }
			Response.AddHeader("Referrer-Policy", "no-referrer");
			Response.AddHeader("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
			Response.AddHeader("X-Frame-Options", "DENY");
			Response.AddHeader("X-Xss-Protection", "1; mode=block");
			Response.AddHeader("X-Content-Type-Options", "nosniff");
			Response.AddHeader("X-Permitted-Cross-Domain-Policies", "none");
		}

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
			string cookieName = "MBRAdmin-" + FormsAuthentication.FormsCookieName;
			HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];
            if (authCookie == null) return;
            if (authCookie.Value != "")
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                UserPrincipalSerializeModel serializeModel = serializer.Deserialize<UserPrincipalSerializeModel>(authTicket.UserData);
                UserPrincipal newUser = new UserPrincipal(serializeModel);
                HttpContext.Current.User = newUser;
            }
        }

    }
}