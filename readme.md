# FlexiPrice

**FlexiPrice** is a flexible and dynamic pricing Asp.net core project template designed for e-commerce platforms. It allows for calculating product prices based on various factors such as customer loyalty, stock levels, time-limited promotions, and other customizable strategies. This project is open-source and can be used and expanded as needed.it has some different example strategies that you can modify them or build your strategies on top of them.so:
## Any contribution would be welcomed for adding more strategies to project.

## Features
- **Dynamic Pricing**: Calculate product prices dynamically based on multiple discount strategies.
- **Customizable**: Easily add or modify discount strategies according to your business logic.
- **Modular Design**: The engine is designed as a reusable .NET library that can be integrated into any e-commerce system.

Table of Contents
Installation
Usage
Advanced Factors
Extending FlexiPriceEngine
Discount Strategies
Contributing
License
Installation
Follow these steps to install and use FlexiPriceEngine in your project:

Clone the repository:

bash
Copy code
git clone https://github.com/yourusername/FlexiPriceEngine.git
Build the project:

bash
Copy code
dotnet build
Add reference: Add a reference to the FlexiPriceEngine.Core and FlexiPriceEngine.Application projects in your .NET solution.

Install dependencies: You may need to install any necessary NuGet packages based on your setup.

Usage
To get started with FlexiPriceEngine, follow these steps to set up the pricing engine and apply various discount strategies:

Step 1: Create the Pricing Engine
Initialize the pricing engine and add the discount strategies you want to apply.

csharp
Copy code
var pricingEngine = new PricingEngine();
pricingEngine.AddDiscountService(new LoyaltyDiscountStrategy());
pricingEngine.AddDiscountService(new StockLevelDiscountStrategy());
pricingEngine.AddDiscountService(new PurchaseHistoryDiscountStrategy(orderService));
Step 2: Calculate the Final Price
Use the CalculateFinalPrice method to compute the final price of a product for a customer.

csharp
Copy code
var customer = new Customer { LoyaltyTier = "Gold", Region = "US" };
var product = new Product { BasePrice = 1000 };

var finalPrice = pricingEngine.CalculateFinalPrice(customer, product);

Console.WriteLine($"Final Price: {finalPrice}");
Advanced Factors
FlexiPriceEngine includes advanced factors to handle complex pricing scenarios:

1. Customer Purchase History Analysis
Analyze a customer's purchase history to offer personalized discounts.

csharp
Copy code
pricingEngine.AddDiscountService(new PurchaseHistoryDiscountStrategy(orderService));
Example: Customers who frequently buy complementary products receive additional discounts.
2. Geographic Location-Based Pricing
Offer region-specific discounts based on the customer's geographic location.

csharp
Copy code
pricingEngine.AddDiscountService(new RegionalPricingStrategy());
Example: Customers in APAC regions get a higher discount due to market demand.
3. Time of Day/Week-Based Pricing
Apply dynamic pricing based on the time of day or week.

csharp
Copy code
pricingEngine.AddDiscountService(new TimeBasedDiscountStrategy());
Example: Apply a 10% discount during off-peak hours (2 AM - 6 AM) and special weekend promotions.
Extending FlexiPriceEngine
FlexiPriceEngine is designed to be modular and extensible. You can add new services, discount strategies, or custom logic by implementing the IDiscountService interface.

Step 1: Create a Custom Discount Strategy
To add a custom discount strategy, implement the IDiscountService interface.

csharp
Copy code
public class SeasonalDiscountStrategy : IDiscountService
{
    public Discount CalculateDiscount(Customer customer, Product product)
    {
        var discount = new Discount { Percentage = 0 };

        if (DateTime.Now.Month == 12) // Apply discount during December
        {
            discount.Percentage = 15;
            discount.Description = "Holiday Discount";
        }

        return discount;
    }
}
Step 2: Register the Custom Strategy
After creating a custom strategy, register it in the pricing engine.

csharp
Copy code
pricingEngine.AddDiscountService(new SeasonalDiscountStrategy());
Discount Strategies
Here are some of the discount strategies supported by FlexiPriceEngine:

Loyalty Discount:

Offers a discount based on the customer's loyalty tier.
Stock Level Discount:

Adjusts the discount based on the stock level of the product.
Purchase History Discount:

Offers a discount based on a customer's purchase history.
Regional Pricing Discount:

Provides region-specific discounts based on the customer’s location.
Time-Based Discount:

Applies discounts depending on the time of day or week.
Contributing
Contributions are welcome! If you'd like to contribute, please follow these steps:

Fork the repository.
Create a new branch for your feature or bug fix.
Make your changes and ensure tests are passing.
Submit a pull request.
For major changes, please open an issue first to discuss your idea.

License
This project is licensed under the MIT License. See the LICENSE file for details.