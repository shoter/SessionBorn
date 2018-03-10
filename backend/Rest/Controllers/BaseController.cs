using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Rest.Controllers
{
    public class BaseController : ApiController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public void ThrowHttpException(HttpStatusCode code, string message)
        {
            var response = new HttpResponseMessage(code)
            {
                Content = new StringContent(message)
            };
            throw new HttpResponseException(response);
        }
    }
}