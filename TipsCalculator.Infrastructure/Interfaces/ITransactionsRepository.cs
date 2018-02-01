using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.Entities;

namespace TipsCalculator.Infrastructure.Interfaces
{
    public interface ITransactionsRepository
    {
        Task<IEnumerable<TransactionEntity>> GetTransactions();

        Task<IEnumerable<TransactionEntity>> GetTransactionsBySku(string sku);
    }
}
