using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Web
{
    public class General
    {

      
        public static int GetUserId()
        {
            UserPrincipal User = GetCurrentUser();
            if (User == null)
                return 0;
            else
                return User.UserId;
        }
        
        public static UserPrincipal GetCurrentUser()
        {
			string CookieName = "Template-" + FormsAuthentication.FormsCookieName;
			if (HttpContext.Current.Request.Cookies[CookieName] != null)
			{
				var value = HttpContext.Current.Request.Cookies[CookieName].Value;
				if (value != "" && value!=null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(value);  
                    string UserData = authTicket.UserData;
                    UserPrincipalSerializeModel serializeModel = (new JavaScriptSerializer()).Deserialize<UserPrincipalSerializeModel>(UserData);
                    UserPrincipal User = new UserPrincipal(serializeModel);

                    return User;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public static void LogAction( String Description = "")
        {
            var IP = getIPAddress();
            int? userId = null;
            if (GetCurrentUser() != null)
                userId = GetCurrentUser().UserId;
            String PCNAme = DetermineCompName(IP);
            //Common.LogAction(action, userId, Description, IP, PCNAme, Enumerations.Portal.Administrator);
        }

        public static void LogException(Exception ex)
        {

            var IP = getIPAddress();
            int? userId = null;
            if (GetCurrentUser() != null)
                userId = GetCurrentUser().UserId;
            String HostName = DetermineCompName(IP);
            //ErrorUtility.LogException(ex, userId, IP, HostName);
        }

        public static string DetermineCompName(string IP)
        {
            try
            {
                IPAddress myIP = IPAddress.Parse(IP);
                IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
                return compName.First();
            }
            catch (Exception ex)
            {
                return string.Empty; 
            }
            
        }

        public static string getIPAddress()
        {
            string szRemoteAddr = HttpContext.Current.Request.UserHostAddress;
            string szXForwardedFor = HttpContext.Current.Request.ServerVariables["X_FORWARDED_FOR"];
            string szIP = "";

            if (szXForwardedFor == null)
            {
                szIP = szRemoteAddr;
            }
            else
            {
                szIP = szXForwardedFor;
                if (szIP.IndexOf(",") > 0)
                {
                    string[] arIPs = szIP.Split(',');

                    foreach (string item in arIPs)
                    {
                        return item;
                    }
                }
            }
            return szIP;
        }

    }

    public class User 
    {
        public string Username{get;set;}
        public string Password{get;set;}

        public override string ToString()
        {
            return Username + "-" + Password; 
        }
    }


}