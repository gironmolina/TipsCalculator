using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.Entities;

namespace TipsCalculator.Infrastructure.Interfaces
{
    public interface IRatesRepository
    {
        Task<IEnumerable<RateEntity>> GetRates();
    }
}
