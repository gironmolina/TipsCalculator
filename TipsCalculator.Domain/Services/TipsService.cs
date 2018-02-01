using System;
using System.Threading.Tasks;
using TipsCalculator.Domain.Interfaces;
using TipsCalculator.Infrastructure.Interfaces;

namespace TipsCalculator.Domain.Services
{
    public class TipsService : ITipsService
    {
        private readonly ITransactionsRepository transactionsRepository;
        private readonly IRatesRepository ratesRepository;

        public TipsService(
            ITransactionsRepository transactionsRepository,
            IRatesRepository ratesRepository)
        {
            this.transactionsRepository = transactionsRepository ?? throw new ArgumentNullException(nameof(transactionsRepository));
            this.ratesRepository = ratesRepository ?? throw new ArgumentNullException(nameof(ratesRepository));
        }

        public async Task<dynamic> GetTipsOrder(string sku, string currency)
        {
            var transactions = await transactionsRepository.GetTransactionsBySku(sku);
            var rates = await ratesRepository.GetRates();
            return transactions;
        }
    }
}
