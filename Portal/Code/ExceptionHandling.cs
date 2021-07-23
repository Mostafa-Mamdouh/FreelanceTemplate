using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;


namespace Web
{
	public class ExceptionHandling : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext context)
		{
			short errorCode = Convert.ToInt16(ConfigurationManager.AppSettings["ErrorCode"]);
			if (context.Exception is BusinessException)
			{
				throw new HttpResponseException(new HttpResponseMessage((HttpStatusCode)errorCode)
				{
					Content = new StringContent(context.Exception.Message),
					ReasonPhrase = "Error"
				});
			}
			var exception = context.Exception.InnerException ?? context.Exception;
			//General.LogException(exception);

			int IsDebugMode = int.Parse(ConfigurationManager.AppSettings["IsDebugMode"]);
			throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
			{
				//Content = new StringContent(IsDebugMode == 1 ? ErrorUtility.GetExceptionMessage(exception, true) : exception.Message),
				Content = new StringContent(exception.Message),
				ReasonPhrase = "Server Error",
			});
		}
	}
}