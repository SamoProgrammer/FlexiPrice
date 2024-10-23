
using FlexiPrice.Core.Interfaces;
using FlexiPrice.Core.Models;

namespace FlexiPrice.Infrastructure.DiscountStrategies
{
    public class LoyaltyDiscountStrategy : IDiscountService
    {
        public Discount CalculateDiscount(Customer customer, Product product)
        {
            var discount = new Discount { Percentage = 0 };

            switch (customer.LoyaltyTier)
            {
                case "Bronze":
                    discount.Percentage = 5;
                    break;
                case "Silver":
                    discount.Percentage = 10;
                    break;
                case "Gold":
                    discount.Percentage = 15;
                    break;
            }

            discount.Description = "Loyalty Discount";
            return discount;
        }
    }
}
