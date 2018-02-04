namespace TipsCalculator.Entities
{
    public class TipsTransactionEntity
    {
        public string Sku { get; set; }

        public decimal Amount { get; set; }

        public decimal Tip { get; set; }

        public string Currency { get; set; }
    }
}
