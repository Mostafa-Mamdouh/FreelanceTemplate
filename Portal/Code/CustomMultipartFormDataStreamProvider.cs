using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        private string Name = string.Empty;
        Boolean IsNameFromContent = false;
        public CustomMultipartFormDataStreamProvider(string path)
            : base(path)
        {
        }

        public CustomMultipartFormDataStreamProvider(string path, String Name)
            : base(path)
        {
            this.Name = Name;
        }

        public CustomMultipartFormDataStreamProvider(string path, Boolean IsNameFromContent)
            : base(path)
        {
            this.IsNameFromContent = IsNameFromContent;
            this.Name = string.Empty;
        }

		public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
		{

			var AllowedExtensions = new List<String> { ".pdf", ".docx", ".doc", ".png", ".jpeg", ".jpg", ".xlsx", ".xls", ".xml" };
			if (this.Name != string.Empty && this.Name != null)
				return Name;
			else
			{
				var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
				name = name.Replace("\"", string.Empty);
				var ext = name.Substring(name.LastIndexOf("."), name.Length - name.LastIndexOf("."));
				//if (!AllowedExtensions.Contains(ext))
				//{
				//	throw new HttpResponseException(new HttpResponseMessage
				//	{
				//		StatusCode = HttpStatusCode.NotAcceptable,
				//		ReasonPhrase = "Forbidden Extension"
				//	});
				//}
				var nameNoExt = name.Substring(0, name.LastIndexOf("."));
				if (IsNameFromContent)
					return string.Format("{0}_{1}" + ext, nameNoExt, DateTime.Now.ToString("yyyyMMddhhmmss"));
				else
					return Guid.NewGuid() + ext;
			}
		}
	}
}