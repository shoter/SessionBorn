using Common.Http;
using Common.Results;
using Entities.Repositories;
using ProjectSpecific.Users;
using Rest.Models.Users;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;


namespace Rest.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

       
        public void Put([FromBody] CreateUserViewModel vm)
        {
            var result = userService.CanCreateUser(vm.Username, vm.Password);
            if (result.IsError)
                result.ThrowHttpException(HttpStatusCode.PreconditionFailed);

            userService.CreateUser(vm.Username, vm.Password);
        }




        [HttpPost]
        [Route("Api/User/Login")]
        public UserToken Login([FromBody] LoginViewModel vm)
        {
            var result = userService.CanLogin(vm.Username, vm.Password);
            if (result.IsError)
                result.ThrowHttpException(HttpStatusCode.PreconditionFailed);

            return userService.Login(vm.Username, vm.Password, vm.RememberMe ?? false);
        }
    }

}