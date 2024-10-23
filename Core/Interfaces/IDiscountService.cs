using FlexiPrice.Core.Models;

namespace FlexiPrice.Core.Interfaces
{
    public interface IDiscountService
    {
        Discount CalculateDiscount(Customer customer, Product product);
    }
}
