using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
namespace WebApiTraining
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            string angularuri = ConfigurationManager.AppSettings["AngularAppUri"];
            // Web API configuration and services
            config.EnableCors(new EnableCorsAttribute(angularuri, headers: "*", methods: "*"));
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
