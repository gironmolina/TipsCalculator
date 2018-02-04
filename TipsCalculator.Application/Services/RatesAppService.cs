using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TipsCalculator.Application.Dtos;
using TipsCalculator.Application.Interfaces;
using TipsCalculator.Domain.Interfaces;

namespace TipsCalculator.Application.Services
{
    public class RatesAppService : IRatesAppService
    {
        private readonly IRatesService ratesService;

        public RatesAppService(IRatesService ratesService)
        {
            this.ratesService = ratesService ?? throw new ArgumentNullException(nameof(ratesService));
        }

        public async Task<IList<RateDto>> GetRatesAdapter()
        {
            var result = await this.ratesService.GetRates().ConfigureAwait(false);
            return Mapper.Map<List<RateDto>>(result);
        }
    }
}
