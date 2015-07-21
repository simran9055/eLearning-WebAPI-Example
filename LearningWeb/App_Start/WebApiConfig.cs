using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LearningWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
            name: "Courses",
            routeTemplate: "api/courses/{id}",
            defaults: new { controller = "courses", id = RouteParameter.Optional }
            );
        }
    }
}
