using System.Threading.Tasks;
using TipsCalculator.Entities;

namespace TipsCalculator.Domain.Interfaces
{
    public interface ITipsService
    {
        Task<TipsOrderEntity> GetTipsOrder(string sku, string currency);
    }
}
