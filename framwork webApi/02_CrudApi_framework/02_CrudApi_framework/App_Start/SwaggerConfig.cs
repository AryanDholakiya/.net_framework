using System.Web.Http;
using WebActivatorEx;
using _02_CrudApi_framework;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace _02_CrudApi_framework
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "_02_CrudApi_framework");
                    })
                .EnableSwaggerUi(c =>
                    {

                    });
        }
    }
}
