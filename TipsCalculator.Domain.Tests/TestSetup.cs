using NUnit.Framework;
using TipsCalculator.API;
using TipsCalculator.Domain.Interfaces;
using TipsCalculator.Domain.Services;
using Unity;

namespace TipsCalculator.Domain.Tests
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
            Container.RegisterType<ICurrencyService, CurrencyService>();
        }
    }
}