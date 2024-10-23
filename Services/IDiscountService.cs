using FlexiPrice.Models;

namespace FlexiPrice.Services
{
    public interface IDiscountService
    {
        Discount CalculateDiscount(Customer customer, Product product);
    }
}
