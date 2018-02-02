using System.Collections.Generic;
using System.Linq;
using TipsCalculator.Domain.Interfaces;
using TipsCalculator.Entities;

namespace TipsCalculator.Domain.Services
{
    public class CurrencyService : ICurrencyService
    {
        public IEnumerable<TransactionEntity> Convert(string currency, IEnumerable<TransactionEntity> transactions, IList<RateEntity> rates)
        {
            var transactionEntities = new List<TransactionEntity>();
            foreach (var transaction in transactions)
            {
                var convertion = Convert(currency, transaction, rates);
                transactionEntities.Add(convertion);
            }
            return transactionEntities;
        }

        public TransactionEntity Convert(string currency, TransactionEntity transaction, IList<RateEntity> rates)
        {
            if (transaction.Currency.Equals(currency))
            {
                return transaction;
            }

            var rate = GetCurrencyConversionRate(transaction.Currency, currency, rates);

            //TODO: Throw bussines exception ?? what to do when there is no rate?
            if (rate == null)
            {
                return null;
            }

            return new TransactionEntity
            {
                Sku = transaction.Sku,
                Currency = currency,
                Amount = transaction.Amount * rate.Rate
            };
        }

        private RateEntity GetCurrencyConversionRate(string fromCurrency, string toCurrency, IList<RateEntity> rates)
        {
            var rate = rates.FirstOrDefault(r => r.From == fromCurrency && 
                                                 r.To == toCurrency);

            if (rate != null)
            {
                return rate;
            }

            var fromRates = rates.Where(r => r.From == fromCurrency);

            foreach (var f in fromRates)
            {
                rate = rates.FirstOrDefault(r => r.From.Equals(f.To) && r.To.Equals(toCurrency));
                if (rate == null)
                {
                    continue;
                }

                return new RateEntity
                {
                    From = $"{fromCurrency}-{rate.From}-{toCurrency}",
                    To = toCurrency,
                    Rate = f.Rate * rate.Rate
                };
            }

            return rate;
        }
    }
}
