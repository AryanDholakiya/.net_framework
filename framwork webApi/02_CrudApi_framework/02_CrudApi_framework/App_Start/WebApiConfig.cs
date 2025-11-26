using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _02_CrudApi_framework
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
        name: "swagger_root",
        routeTemplate: "",
        defaults: null,
        constraints: null,
        // Assumes your Swashbuckle/Swagger UI endpoint is at "~/swagger/ui/index"
        // The RedirectHandler is part of Swashbuckle.Application.
        handler: new Swashbuckle.Application.RedirectHandler(
            message => message.RequestUri.ToString(), "swagger/ui/index"
        )
    );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
