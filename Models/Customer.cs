namespace FlexiPrice.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoyaltyTier { get; set; }
        public decimal LifetimeValue { get; set; }
        public int PurchaseFrequency { get; set; }
        public string Region { get; set; }
    }
}
