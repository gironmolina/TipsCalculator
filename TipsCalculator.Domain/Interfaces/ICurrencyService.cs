using System.Collections.Generic;
using TipsCalculator.Entities;

namespace TipsCalculator.Domain.Interfaces
{
    public interface ICurrencyService
    {
        IList<TransactionEntity> Convert(string currency, IEnumerable<TransactionEntity> transactions, IList<RateEntity> rates);
    }
}
