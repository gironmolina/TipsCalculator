using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.Entities;

namespace TipsCalculator.Infrastructure.Interfaces
{
    public interface ITransactionsRepository
    {
        Task<IList<TransactionEntity>> GetTransactions();

        Task<IList<TransactionEntity>> GetTransactionsBySku(string sku);
    }
}
