﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models.Rewards
{
    public class BasicRewardViewModel
    {
        public long RewardID { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
    }
}