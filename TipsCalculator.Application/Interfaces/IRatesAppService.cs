using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.Application.Dtos;

namespace TipsCalculator.Application.Interfaces
{
    public interface IRatesAppService
    {
        Task<IList<RateDto>> GetRatesAdapter();
    }
}
