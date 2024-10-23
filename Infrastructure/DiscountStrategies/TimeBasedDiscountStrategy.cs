using FlexiPrice.Core.Interfaces;
using FlexiPrice.Core.Models;

public class TimeBasedDiscountStrategy : IDiscountService
{
    public Discount CalculateDiscount(Customer customer, Product product)
    {
        var discount = new Discount { Percentage = 0 };
        var currentHour = DateTime.Now.Hour;
        var currentDay = DateTime.Now.DayOfWeek;

        // Off-peak hours discount (e.g., between 2 AM and 6 AM)
        if (currentHour >= 2 && currentHour <= 6)
        {
            discount.Percentage = 10;
            discount.Description = "Off-Peak Hours Discount";
        }
        // Weekend discount (e.g., Saturday and Sunday)
        else if (currentDay == DayOfWeek.Saturday || currentDay == DayOfWeek.Sunday)
        {
            discount.Percentage = 15;
            discount.Description = "Weekend Discount";
        }

        return discount;
    }
}
