using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.Entities;

namespace TipsCalculator.Domain.Interfaces
{
    public interface IRatesService
    {
        Task<IList<RateEntity>> GetRates();
    }
}
