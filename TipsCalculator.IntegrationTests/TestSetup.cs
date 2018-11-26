using NUnit.Framework;
using TipsCalculator.API;
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
            UnityConfig.RegisterTypes(Container);
        }
    }
}