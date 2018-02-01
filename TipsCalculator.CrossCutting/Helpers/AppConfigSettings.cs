using System.Configuration;
using TipsCalculator.CrossCutting.Interfaces;

namespace TipsCalculator.CrossCutting.Helpers
{
    public class AppConfigSettings : IAppConfigSettings
    {
        public string RatesApiUrl { get; }

        public string TransactionApiUrl { get; }

        public AppConfigSettings()
        {
            this.RatesApiUrl = ConfigurationManager.AppSettings["RatesAPIUrl"];
            this.TransactionApiUrl = ConfigurationManager.AppSettings["TransactionsAPIUrl"];
        }
    }
}
