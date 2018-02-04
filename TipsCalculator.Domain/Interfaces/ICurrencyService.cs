using System.Collections.Generic;
using TipsCalculator.CrossCutting.Enums;
using TipsCalculator.Entities;

namespace TipsCalculator.Domain.Interfaces
{
    public interface ICurrencyService
    {
        TransactionEntity Convert(string currency, TransactionEntity transaction, IList<RateEntity> rates);

        IList<TransactionEntity> Convert(string currency, IEnumerable<TransactionEntity> transactions, IList<RateEntity> rates);
    }
}
