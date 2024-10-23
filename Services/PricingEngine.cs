using FlexiPrice.Models;

namespace FlexiPrice.Services
{
    public class PricingEngine
    {
        private readonly List<IDiscountService> _discountServices;

        public PricingEngine()
        {
            _discountServices = new List<IDiscountService>();
        }

        public void AddDiscountService(IDiscountService discountService)
        {
            _discountServices.Add(discountService);
        }

        public decimal CalculateFinalPrice(Customer customer, Product product)
        {
            decimal finalPrice = product.BasePrice;
            decimal totalDiscount = 0;

            foreach (var service in _discountServices)
            {
                var discount = service.CalculateDiscount(customer, product);
                totalDiscount += discount.Percentage;
            }

            totalDiscount = Math.Min(totalDiscount, 50);
            return finalPrice - (finalPrice * totalDiscount / 100);
        }
    }
}
