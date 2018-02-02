namespace TipsCalculator.Entities
{
    public class TipsTransaction
    {
            
        public string Sku { get; set; }

        public decimal Amount { get; set; }

        public decimal Tip { get; set; }

        public string Currency { get; set; }
    }
}
