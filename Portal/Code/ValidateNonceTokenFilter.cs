using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace Web.Code
{
    public sealed class ValidateNonceTokenFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        private const string NonceHeader = "RequestNonceToken";

        public bool verifyNonce(string nonceToken,string api,string apiData)
        {
            try
            {
                //var upUser = General.GetCurrentUser();
                //int? userId = null;
                //if (upUser != null)
                //{
                //    userId = upUser.UserId;
                //}
                //ObjectParameter isValid = new ObjectParameter("IsValid", typeof(bool));
                //using (var db = new DatabaseContext())
                //{
                //    db.SEC_Nonce_Validate(nonceToken, userId, api, apiData, isValid);
                //    return (bool)isValid.Value;
                //}
                return true; 
            }
            catch (Exception ex)
            {
                General.LogException(ex);
                return false;
            }
        }

       

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            HttpRequestHeaders headers = actionContext.Request.Headers;

            string apiData = "";
            var apiURL = actionContext.Request.RequestUri.ToString();
            if (actionContext.ActionArguments.Any())
            {
                if (actionContext.ActionArguments.First().Value !=null)
                {
                    apiData = actionContext.ActionArguments.First().Value.ToString();
                }
                
            }
            
            IEnumerable<string> nonceTokenList;

            if (!headers.TryGetValues(NonceHeader, out nonceTokenList))
            {
               // actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
               // return;
            }

            string tokenHeaderValue = "";
            if (nonceTokenList!=null)
            {
                 tokenHeaderValue = nonceTokenList.First();
            }


            try
            {
                bool VerifiedNonce = verifyNonce(tokenHeaderValue,apiURL,apiData);
                if (!VerifiedNonce)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                    return;
                }
            }
            catch (HttpAntiForgeryException)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}