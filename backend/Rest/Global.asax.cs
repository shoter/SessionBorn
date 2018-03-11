using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Entities.Repositories;
using Ninject.Web.Common;
using Services;
using Ninject.Web.Mvc;
using Entities;
using Common.Transactions;

namespace Rest
{
    public class WebApiApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            registerServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private void registerServices(IKernel kernel)
        {
            kernel.Bind<SessionBornEntities>().ToSelf().InRequestScope();
            kernel.Bind<IUserInfoRepository>().To<UserInfoRepository>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            kernel.Bind<IScenarioRepository>().To<ScenarioRepository>().InRequestScope();
            kernel.Bind<IScenarioService>().To<ScenarioServices>().InRequestScope();
            kernel.Bind<IQuestRepository>().To<QuestRepository>().InRequestScope();
            kernel.Bind<IQuestService>().To<QuestService>().InRequestScope();
            kernel.Bind<IQuizRepository>().To<QuizRepository>().InRequestScope();
            kernel.Bind<IQuizQuestionRepository>().To<QuizQuestionRepository>().InRequestScope();
            kernel.Bind<IRewardRepository>().To<RewardRepository>().InRequestScope();
            kernel.Bind<IRewardService>().To<RewardService>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<ITransactionScopeProvider>().To<StandardTransactionScopeProvider>().InRequestScope();
            kernel.Bind<IQuizService>().To<QuizService>().InRequestScope();
        }
    }
}
