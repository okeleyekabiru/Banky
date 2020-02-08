using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Banky.App_Start;
using Newtonsoft.Json.Serialization;

namespace Banky
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
           ContainerConfig.Register();
           config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

//            config.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "api/{controller}/{id}",
//                defaults: new { id = RouteParameter.Optional }
//            );
        }
    }
}
