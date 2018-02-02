using System;
using System.Collections.Generic;
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

        public TipsService(
            ICurrencyService currencyService,
            ITransactionsRepository transactionsRepository,
            IRatesRepository ratesRepository)
        {
            this.currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));

            this.transactionsRepository = transactionsRepository ?? throw new ArgumentNullException(nameof(transactionsRepository));
            this.ratesRepository = ratesRepository ?? throw new ArgumentNullException(nameof(ratesRepository));
        }

        public async Task<dynamic> GetTipsOrder(string sku, string currency)
        {
            var transactions = await transactionsRepository.GetTransactionsBySku(sku);
            if (!transactions.Any())
            {
                return null;
            }

            var rates = await ratesRepository.GetRates();
            var transactionsResult = currencyService.Convert(currency, transactions, rates);

            var tipsTransactions = transactionsResult.Select(transactionEntity => new TipsTransaction
                {
                    Sku = transactionEntity.Sku,
                    Amount = transactionEntity.Amount,
                    Currency = transactionEntity.Currency,
                    Tip = transactionEntity.Amount * (decimal) 0.05
                })
                .ToList();


            var result = new TipsOrder
            {
                Currency = Currencies.Euro,
                TotalTipAmount = transactionsResult.Sum(t => t.Amount),
                Transactions = tipsTransactions
            };

            return result;
        }
    }
}
