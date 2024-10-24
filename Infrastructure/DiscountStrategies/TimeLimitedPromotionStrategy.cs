using FlexiPrice.Core.Interfaces;
using FlexiPrice.Core.Models;

namespace FlexiPrice.Infrastructure.DiscountStrategies
{
    public class TimeLimitedPromotionStrategy : IDiscountService
    {
        private readonly DateTime _promotionEndTime;

        public TimeLimitedPromotionStrategy(DateTime promotionEndTime)
        {
            _promotionEndTime = promotionEndTime;
        }

        public Discount CalculateDiscount(Customer customer, Product product)
        {
            var discount = new Discount { Percentage = 0 };

            if (DateTime.Now <= _promotionEndTime)
            {
                discount.Percentage = 30;
            }

            discount.Description = "Time-Limited Promotion";
            return discount;
        }
    }
}
