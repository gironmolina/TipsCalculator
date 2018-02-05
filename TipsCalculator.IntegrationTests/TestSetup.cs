using NUnit.Framework;
using TipsCalculator.Application.Interfaces;
using TipsCalculator.Application.Services;
using TipsCalculator.API;
using TipsCalculator.CrossCutting.Helpers;
using TipsCalculator.CrossCutting.Interfaces;
using TipsCalculator.Domain.Interfaces;
using TipsCalculator.Domain.Services;
using TipsCalculator.Infrastructure.Interfaces;
using TipsCalculator.Infrastructure.Repositories;
using Unity;

namespace TipsCalculator.IntegrationTests
{
    [SetUpFixture]
    public class TestSetup
    {
        public static IUnityContainer Container { get; private set; }

        [OneTimeSetUp]
        public static void ConfigureDependecies()
        {
            AutoMapperConfig.RegisterMappings();
            Container = new UnityContainer();

            // Application Services
            Container.RegisterType<ITipsAppService, TipsAppService>();
            Container.RegisterType<IRatesAppService, RatesAppService>();
            Container.RegisterType<ITransactionsAppService, TransactionsAppService>();

            // Domain Services
            Container.RegisterType<ITipsService, TipsService>();
            Container.RegisterType<IRatesService, RatesService>();
            Container.RegisterType<ITransactionsService, TransactionsService>();
            Container.RegisterType<ICurrencyService, CurrencyService>();

            // Repositories
            Container.RegisterType<ITransactionsRepository, TransactionsRepository>();
            Container.RegisterType<IRatesRepository, RatesRepository>();

            // Cross-cutting
            Container.RegisterType<IAppConfigSettings, AppConfigSettings>();
        }
    }
}