using System.Web.Http;
using System.Web.Routing;
using NSwag.AspNet.Owin;

namespace SampleWebApiWithSwaggerUi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.MapOwinPath("swagger", app =>
            {
                app.UseSwaggerUi(typeof(WebApiApplication).Assembly, new SwaggerUiOwinSettings
                {
                    OwinBasePath = "/swagger",
                    SwaggerUiRoute = "/swagger/foo", 
                    SwaggerRoute = "/swagger/myswag.json"
                });
            });

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
