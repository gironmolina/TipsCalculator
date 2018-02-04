using System.Collections.Generic;
using System.Linq;
using TipsCalculator.Domain.Interfaces;
using TipsCalculator.Entities;

namespace TipsCalculator.Domain.Services
{
    public class CurrencyService : ICurrencyService
    {
        public IList<TransactionEntity> Convert(string currency, IEnumerable<TransactionEntity> transactions, IList<RateEntity> rates)
        {
            return transactions.Select(transaction => Convert(currency, transaction, rates)).ToList();
        }

        public TransactionEntity Convert(string currency, TransactionEntity transaction, IList<RateEntity> rates)
        {
            if (transaction.Currency.Equals(currency))
            {
                return transaction;
            }

            var rate = GetRate(transaction.Currency, currency, rates);

            return new TransactionEntity
            {
                Sku = transaction.Sku,
                Currency = currency,
                Amount = transaction.Amount * rate.Rate
            };
        }

        private RateEntity GetRate(string fromCurrency, string toCurrency, IList<RateEntity> rates)
        {
            // Try to find the conversation
            var rateConvertion = rates.FirstOrDefault(rate => rate.From == fromCurrency && 
                                                              rate.To == toCurrency);

            if (rateConvertion != null)
            {
                return rateConvertion;
            }

            var rateConversation = GetRateConversation(fromCurrency, toCurrency, rates);
            var rateDescription = rateConversation.Select(i=> i.From).Aggregate((current, next) => current + " - " + next);
            var rateValue = rateConversation.Select(i => i.Rate).Aggregate((current, next) => current * next);

            var calculatedRate = new RateEntity
            {
                From = rateDescription + " - " + toCurrency,
                To = toCurrency,
                Rate = rateValue
            };

            return calculatedRate;
        }

        private List<RateEntity> GetRateConversation(string fromCurrency, string toCurrency, IList<RateEntity> rates)
        {
            var ratesFrom = rates.Where(rate => rate.From == fromCurrency).ToList();
            var ratesTo = rates.Where(rate => rate.To == toCurrency).ToList();

            var ratesConversation = new List<RateEntity>();
            if (ratesFrom.Any(rateFrom => ratesTo.Any(rateTo => rateFrom.To == rateTo.From)))
            {
                ratesConversation.Add(ratesFrom.First(x => ratesTo.Any(y => x.To == y.From)));
                ratesConversation.Add(ratesTo.First(x => ratesFrom.Any(y => x.From == y.To)));
            }
            else
            {
                var secondRate = rates.First(x => ratesFrom.Any(y => x.From.Equals(y.To)) &&
                                                    ratesTo.Any(y => x.To.Equals(y.From)));

                var firstRate = rates.First(rate => rate.From == fromCurrency && 
                                                    rate.To == secondRate.From);

                var thirdRate = rates.First(rate => rate.From == secondRate.To && 
                                                    rate.To == toCurrency);
                ratesConversation.Add(firstRate);
                ratesConversation.Add(secondRate);
                ratesConversation.Add(thirdRate);
            }

            return ratesConversation;
            
        }
    }
}
