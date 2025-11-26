using System.Web.Http;
using WebActivatorEx;
using _01_first_WebApi_Framework;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace _01_first_WebApi_Framework
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var config = GlobalConfiguration.Configuration;

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "MyAPI");
            })
            .EnableSwaggerUi();
        }
    }
}
