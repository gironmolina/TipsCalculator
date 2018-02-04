using System.Web.Http;

namespace TipsCalculator.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMappings();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
