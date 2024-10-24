using FlexiPrice.Core.Interfaces;
using FlexiPrice.Core.Models;

namespace FlexiPrice.Infrastructure.DiscountStrategies
{
    public class StockLevelDiscountStrategy : IDiscountService
    {
        public Discount CalculateDiscount(Customer customer, Product product)
        {
            var discount = new Discount { Percentage = 0 };

            if (product.StockLevel > 100)
            {
                discount.Percentage = 20;
            }
            else if (product.StockLevel < 10)
            {
                discount.Percentage = 5;
            }

            discount.Description = "Stock Level Discount";
            return discount;
        }
    }
}
