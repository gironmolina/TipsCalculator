using System.Threading.Tasks;

namespace TipsCalculator.Application.Interfaces
{
    public interface ITipsAppService
    {
        Task<dynamic> GetTipsCalculatorAdapter();
    }
}
