using System.Collections.Generic;

namespace TipsCalculator.Application.Dtos
{
    public class TipsOrderDto
    {
        public string Currency { get; set; }

        public decimal TotalTipAmount { get; set; }

        public IEnumerable<TipsTransactionDto> Transactions { get; set; } = new List<TipsTransactionDto>();
    }
}
