using Entities;
using Entities.Repositories;
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
        private readonly IUserRepository userRepository;
        public BaseController()
        {
            userRepository = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUserRepository)) as IUserRepository;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected AspNetUser GetCurrentUser()
        {
            return userRepository.GetUser(User.Identity.Name);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected void ThrowHttpException(HttpStatusCode code, string message)
        {
            var response = new HttpResponseMessage(code)
            {
                Content = new StringContent(message)
            };
            throw new HttpResponseException(response);
        }
    }
}