using System.Threading.Tasks;
using TipsCalculator.CrossCutting.Enums;

namespace TipsCalculator.Domain.Interfaces
{
    public interface ITipsService
    {
        Task<dynamic> GetTipsOrder(string sku, string currency);
    }
}
