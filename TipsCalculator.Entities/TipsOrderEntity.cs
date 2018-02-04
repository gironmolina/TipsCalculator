using System.Collections.Generic;

namespace TipsCalculator.Entities
{
    public class TipsOrderEntity
    {
        public string Currency { get; set; }

        public decimal TotalTipAmount { get; set; }

        public IEnumerable<TipsTransactionEntity> Transactions { get; set; } = new List<TipsTransactionEntity>();
    }
}
