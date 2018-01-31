using System;
using TipsCalculator.Application.Interfaces;
using TipsCalculator.Application.Services;
using TipsCalculator.Domain.Interfaces;
using TipsCalculator.Domain.Services;
using Unity;

namespace TipsCalculator
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        
        public static void RegisterTypes(IUnityContainer container)
        {
            // Application Services
            container.RegisterType<ITipsAppService, TipsAppService>();

            // Domain Services
            container.RegisterType<ITipsService, TipsService>();
        }
    }
}