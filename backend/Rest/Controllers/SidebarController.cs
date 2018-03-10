﻿using Entities.Repositories;
using ProjectSpecific.Users;
using Rest.Models.Sidebars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Rest.Controllers
{

    public class SidebarController : BaseController
    {
        private readonly IUserRepository userRepository;
        public SidebarController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Authorize]
        public SidebarViewModel Get()
        {
            var user = userRepository.GetUser(User.Identity.Name);
            var level = new Level(user.UserInfo.Experience);
            return new SidebarViewModel()
            {
                Name = user.UserName,
                Exp = level.Experience,
                Lvl = level.CurrentLevel,
                NextLevelExperience = level.ExperienceForNextLevel
            };
        }
    }
}