using FlexiPrice.Core.Interfaces;
using FlexiPrice.Core.Models;

public class RegionalPricingStrategy : IDiscountService
{
    public Discount CalculateDiscount(Customer customer, Product product)
    {
        var discount = new Discount { Percentage = 0 };

        switch (customer.Region)
        {
            case "US":
                discount.Percentage = 5; // Lower discount in a competitive region
                break;
            case "EU":
                discount.Percentage = 10;
                break;
            case "APAC":
                discount.Percentage = 15;
                break;
        }

        discount.Description = "Regional Pricing Discount";
        return discount;
    }
}
