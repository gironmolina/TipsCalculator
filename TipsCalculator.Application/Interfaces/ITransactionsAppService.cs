using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.Application.Dtos;

namespace TipsCalculator.Application.Interfaces
{
    public interface ITransactionsAppService
    {
        Task<IList<TransactionDto>> GetTransactionAdapter();
    }
}
