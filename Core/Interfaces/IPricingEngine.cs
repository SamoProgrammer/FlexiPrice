using FlexiPrice.Core.Models;

namespace FlexiPrice.Core.Interfaces
{
    public interface IPricingEngine
    {
        decimal CalculateFinalPrice(Customer customer, Product product);
        void AddDiscountService(IDiscountService discountService);
    }
}