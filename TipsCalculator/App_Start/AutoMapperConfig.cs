using AutoMapper;
using TipsCalculator.Application.Dtos;
using TipsCalculator.Entities;

namespace TipsCalculator.API
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<TipsOrderEntity, TipsOrderDto>();
                cfg.CreateMap<RateEntity, RateDto>();
                cfg.CreateMap<TransactionEntity, TransactionDto>();
            });
        }
    }
}