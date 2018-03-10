﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Rest
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
= Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
