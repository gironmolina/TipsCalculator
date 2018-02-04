using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.Domain.Interfaces;
using TipsCalculator.Entities;
using TipsCalculator.Infrastructure.Interfaces;

namespace TipsCalculator.Domain.Services
{
    public class RatesService : IRatesService
    {
        private readonly IRatesRepository ratesRepository;

        public RatesService(IRatesRepository ratesRepository)
        {
            this.ratesRepository = ratesRepository ?? throw new ArgumentNullException(nameof(ratesRepository));
        }

        public async Task<IList<RateEntity>> GetRates()
        {
            var rates = await ratesRepository.GetRates().ConfigureAwait(false);
            return rates;
        }
    }
}
