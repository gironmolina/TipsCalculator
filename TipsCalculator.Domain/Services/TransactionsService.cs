using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.Domain.Interfaces;
using TipsCalculator.Entities;
using TipsCalculator.Infrastructure.Interfaces;

namespace TipsCalculator.Domain.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository transactionsRepository;

        public TransactionsService(ITransactionsRepository transactionsRepository)
        {
            this.transactionsRepository = transactionsRepository ?? throw new ArgumentNullException(nameof(transactionsRepository));
        }

        public async Task<IList<TransactionEntity>> GetTransactions()
        {
            var rates = await transactionsRepository.GetTransactions().ConfigureAwait(false);
            return rates;
        }
    }
}
