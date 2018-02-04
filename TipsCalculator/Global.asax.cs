using System.Web.Http;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
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
