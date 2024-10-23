using FlexiPrice.Core.Interfaces;
using FlexiPrice.Core.Models;

namespace FlexiPrice.Application.Services
{
    public class PricingEngine : IPricingEngine
    {
        private readonly List<IDiscountService> _discountServices = new List<IDiscountService>();

        public void AddDiscountService(IDiscountService discountService)
        {
            _discountServices.Add(discountService);
        }

        public decimal CalculateFinalPrice(Customer customer, Product product)
        {
            decimal finalPrice = product.BasePrice;

            foreach (var discountService in _discountServices)
            {
                var discount = discountService.CalculateDiscount(customer, product);
                finalPrice -= finalPrice * (discount.Percentage / 100);
            }

            return finalPrice;
        }
    }
}
