using System;
using System.Threading.Tasks;
using AutoMapper;
using TipsCalculator.Application.Interfaces;
using TipsCalculator.Domain.Interfaces;

namespace TipsCalculator.Application.Services
{
    public class TipsAppService : ITipsAppService
    {
        private readonly ITipsService tipsService;

        public TipsAppService(ITipsService tipsService)
        {
            this.tipsService = tipsService ?? throw new ArgumentNullException(nameof(tipsService));
        }

        public async Task<dynamic> GetTipsOrderAdapter(string sku, string currency)
        {
            var result = await this.tipsService.GetTipsOrder(sku, currency);
            //return Mapper.Map<SchedulerWeekDto>(schedulerEntity);
            return result;
        }
    }
}
