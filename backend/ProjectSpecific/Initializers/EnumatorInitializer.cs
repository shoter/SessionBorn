using Common.EntityFramework.Enums.Common.EntityFramework.Enums;
using Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSpecific.Initializers
{
    public class EnumatorInitializer
    {

        public static void Init()
        {
            new Enumator<QuestType, QuestTypeEnum, SessionBornEntities>().CreateNewIfAble();
        }
    }
}
