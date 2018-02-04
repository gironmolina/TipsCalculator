using System.Threading.Tasks;
using TipsCalculator.Application.Dtos;

namespace TipsCalculator.Application.Interfaces
{
    public interface ITipsAppService
    {
        Task<TipsOrderDto> GetTipsOrderAdapter(string sku, string currency);
    }
}
