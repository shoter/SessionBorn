using Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rest.Controllers
{
    public class DamianTestController : Controller
    {
        private readonly IUserInfoRepository userRepository;
        public DamianTestController(IUserInfoRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public JsonResult Dupa()
        {
            return Json(userRepository.GetAll().ToList());
        }

    }
}