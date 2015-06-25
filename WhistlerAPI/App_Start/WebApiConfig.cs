using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WhizzleAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ImageHandler",
                routeTemplate: "api/{controller}/{type}/{id}"
            );

            //config.Routes.MapHttpRoute(
            //    name: "UserHandler",
            //    routeTemplate: "api/{controller}/{method}"
            //);

            //          team/id/member
            //          team/id/pin
            //          team/id/chat
            config.Routes.MapHttpRoute(
                name: "TeamHandler",
                routeTemplate: "api/{controller}/{id}/{module}/{moduleId}",
                defaults: new {
                    module = RouteParameter.Optional,
                    moduleId = RouteParameter.Optional
                }
            );
            

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

        }
    }
}
