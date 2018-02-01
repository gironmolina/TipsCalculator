using System.Threading.Tasks;

namespace TipsCalculator.Domain.Interfaces
{
    public interface ITipsService
    {
        Task<dynamic> GetTipsOrder(string sku, string currency);
    }
}
