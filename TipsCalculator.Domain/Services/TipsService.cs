using System;
using System.Linq;
using System.Threading.Tasks;
using TipsCalculator.CrossCutting.Enums;
using TipsCalculator.Domain.Interfaces;
using TipsCalculator.Entities;
using TipsCalculator.Infrastructure.Interfaces;

namespace TipsCalculator.Domain.Services
{
    public class TipsService : ITipsService
    {
        private readonly ICurrencyService currencyService;
        private readonly ITransactionsRepository transactionsRepository;
        private readonly IRatesRepository ratesRepository;
        private const decimal TIP_PORCENTAGE = (decimal) 0.05;

        public TipsService(
            ICurrencyService currencyService,
            ITransactionsRepository transactionsRepository,
            IRatesRepository ratesRepository)
        {
            this.currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
            this.transactionsRepository = transactionsRepository ?? throw new ArgumentNullException(nameof(transactionsRepository));
            this.ratesRepository = ratesRepository ?? throw new ArgumentNullException(nameof(ratesRepository));
        }

        public async Task<TipsOrderEntity> GetTipsOrder(string sku, string currency)
        {
            var transactions = await transactionsRepository.GetTransactionsBySku(sku).ConfigureAwait(false);
            if (!transactions.Any())
            {
                return null;
            }

            var rates = await ratesRepository.GetRates().ConfigureAwait(false);
            var transactionsResult = currencyService.Convert(currency, transactions, rates);

            var tipsTransactions = transactionsResult.Select(transactionEntity => new TipsTransactionEntity
                {
                    Sku = transactionEntity.Sku,
                    Amount = Math.Round(transactionEntity.Amount, 2),
                    Currency = transactionEntity.Currency,
                    Tip = Math.Round(transactionEntity.Amount * TIP_PORCENTAGE, 2)
            }).ToList();

            var result = new TipsOrderEntity
            {
                Currency = Currencies.Euro,
                TotalTipAmount = Math.Round(transactionsResult.Sum(t => t.Amount) * TIP_PORCENTAGE, 2),
                Transactions = tipsTransactions
            };

            return result;
        }
    }
}
