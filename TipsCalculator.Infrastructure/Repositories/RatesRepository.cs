using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.CrossCutting.Helpers;
using TipsCalculator.CrossCutting.Interfaces;
using TipsCalculator.Entities;
using TipsCalculator.Infrastructure.Interfaces;

namespace TipsCalculator.Infrastructure.Repositories
{
    public class RatesRepository : IRatesRepository
    {
        private readonly IAppConfigSettings appConfigSettings;

        public RatesRepository(IAppConfigSettings appConfigSettings)
        {
            this.appConfigSettings = appConfigSettings ?? throw new ArgumentNullException(nameof(appConfigSettings));
        }

        public async Task<IList<RateEntity>> GetRates()
        {
            var rates = await HttpClientHelpers.GetAsync<IList<RateEntity>>(appConfigSettings.RatesApiUrl)
                .ConfigureAwait(false);
            return rates;
        }
    }
}
