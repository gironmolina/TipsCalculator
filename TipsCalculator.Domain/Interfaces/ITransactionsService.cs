using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.Entities;

namespace TipsCalculator.Domain.Interfaces
{
    public interface ITransactionsService
    {
        Task<IList<TransactionEntity>> GetTransactions();
    }
}
