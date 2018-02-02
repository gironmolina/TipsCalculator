using System.Collections.Generic;

namespace TipsCalculator.Entities
{
    public class TipsOrder
    {
        public string Currency { get; set; }

        public decimal TotalTipAmount { get; set; }

        public IEnumerable<TipsTransaction> Transactions { get; set; } = new List<TipsTransaction>();
    }
}
