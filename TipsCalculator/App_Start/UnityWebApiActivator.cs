using System.Web.Http;

using Unity.AspNet.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TipsCalculator.UnityWebApiActivator), nameof(TipsCalculator.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(TipsCalculator.UnityWebApiActivator), nameof(TipsCalculator.UnityWebApiActivator.Shutdown))]

namespace TipsCalculator
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            var resolver = new UnityDependencyResolver(UnityConfig.Container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}