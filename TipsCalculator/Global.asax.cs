﻿using System.Web.Http;
using TipsCalculator.API.Filter;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace TipsCalculator.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMappings();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Filters.Add(new ValidateModelStateAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new CheckModelForNullAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new CacheFilter());
        }
    }
}
