using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipsCalculator.CrossCutting.Helpers;
using TipsCalculator.CrossCutting.Interfaces;
using TipsCalculator.Entities;
using TipsCalculator.Infrastructure.Interfaces;

namespace TipsCalculator.Infrastructure.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly IAppConfigSettings appConfigSettings;

        public TransactionsRepository(IAppConfigSettings appConfigSettings)
        {
            this.appConfigSettings = appConfigSettings ?? throw new ArgumentNullException(nameof(appConfigSettings));
        }


        public async Task<IEnumerable<TransactionEntity>> GetTransactions()
        {
            var transactions = await HttpClientHelpers.GetAsync<IEnumerable<TransactionEntity>>(appConfigSettings.TransactionApiUrl)
                .ConfigureAwait(false);
            return transactions;
        }

        public async Task<IEnumerable<TransactionEntity>> GetTransactionsBySku(string sku)
        {
            var transactions = await GetTransactions();
            var transactionsBySku = transactions.Where(t => t.Sku == sku);
            return transactionsBySku;
        }
    }
}
