using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Web.Code
{
    public sealed class ValidateAntiForgeryTokenFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
		private const string XsrfHeader = "RequestVerificationToken";
		private const string XsrfCookie = "xsrf-token";

		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			HttpRequestHeaders headers = actionContext.Request.Headers;
			IEnumerable<string> xsrfTokenList;

			if (!headers.TryGetValues(XsrfHeader, out xsrfTokenList))
			{
				actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
				return;
			}

			string tokenHeaderValue = xsrfTokenList.First();

			CookieState tokenCookie = actionContext.Request.Headers.GetCookies().Select(c => c[XsrfCookie]).FirstOrDefault();

			if (tokenCookie == null)
			{
				actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
				return;
			}

			try
			{
				AntiForgery.Validate(tokenCookie.Value, tokenHeaderValue);
			}
			catch (HttpAntiForgeryException)
			{
				actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
			}
		}
	}
}