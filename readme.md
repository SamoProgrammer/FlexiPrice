# FlexiPrice

**FlexiPrice** is a flexible and dynamic pricing Asp.net core project template designed for e-commerce platforms. It allows for calculating product prices based on various factors such as customer loyalty, stock levels, time-limited promotions, and other customizable strategies. This project is open-source and can be used and expanded as needed.it has some different example strategies that you can modify them or build your strategies on top of them.so:
## Any contribution would be welcomed for adding more strategies to project.

## Features
- **Dynamic Pricing**: Calculate product prices dynamically based on multiple discount strategies.
- **Customizable**: Easily add or modify discount strategies according to your business logic.
- **Modular Design**: The engine is designed as a reusable .NET library that can be integrated into any e-commerce system.

---

## Table of Contents

1. [Getting Started](#getting-started)
2. [Usage](#usage)
3. [Adding Custom Discount Strategies](#adding-custom-discount-strategies)
4. [Expanding the Project](#expanding-the-project)
5. [Contributing](#contributing)

---

## 1. Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:
- [.NET SDK](https://dotnet.microsoft.com/download)
- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
- An IDE (such as [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/))

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/FlexiPrice.git
   cd FlexiPrice
   ```

2. **Build the project**:
   Run the following command in the project root directory to restore the dependencies and build the solution:
   ```bash
   dotnet build
   ```

3. **Run the project**:
   ```bash
   dotnet run
   ```

The **FlexiPrice** is now up and running!

---

## 2. Usage

### Basic Example

Here’s an example of how to use the **FlexiPrice** in your project:

```csharp
using FlexiPrice.Models;
using FlexiPrice.Services;
using FlexiPrice.Services.DiscountStrategies;

class Program
{
    static void Main(string[] args)
    {
        var customer = new Customer { Id = 1, Name = "John", LoyaltyTier = "Gold", Region = "US" };
        var product = new Product { Id = 1, Name = "Laptop", BasePrice = 1000, StockLevel = 120 };

        var pricingEngine = new PricingEngine();
        pricingEngine.AddDiscountService(new LoyaltyDiscountStrategy());
        pricingEngine.AddDiscountService(new StockLevelDiscountStrategy());
        pricingEngine.AddDiscountService(new TimeLimitedPromotionStrategy(DateTime.Now.AddHours(1)));

        var finalPrice = pricingEngine.CalculateFinalPrice(customer, product);
        Console.WriteLine($"Final price for {customer.Name}: ${finalPrice}");
    }
}
```

### Adding to an ASP.NET Core Project

You can add **FlexiPrice** to an ASP.NET Core application by referencing it as a library. Once you integrate it, you can handle pricing calculations in your controllers or services.

Example in a controller:

```csharp
using FlexiPrice.Services;
using FlexiPrice.Models;
using FlexiPrice.Services.DiscountStrategies;

public class PricingController : ControllerBase
{
    private readonly PricingEngine _pricingEngine;

    public PricingController()
    {
        _pricingEngine = new PricingEngine();
        _pricingEngine.AddDiscountService(new LoyaltyDiscountStrategy());
        _pricingEngine.AddDiscountService(new StockLevelDiscountStrategy());
        _pricingEngine.AddDiscountService(new TimeLimitedPromotionStrategy(DateTime.Now.AddHours(2)));
    }

    [HttpGet("calculate-price")]
    public ActionResult<decimal> CalculatePrice([FromQuery] int customerId, [FromQuery] int productId)
    {
        // Logic to retrieve customer and product details
        var customer = GetCustomerById(customerId);
        var product = GetProductById(productId);

        var finalPrice = _pricingEngine.CalculateFinalPrice(customer, product);
        return Ok(finalPrice);
    }
}
```

---

## 3. Adding Custom Discount Strategies

To extend **FlexiPrice**, you can create custom discount strategies that plug into the engine’s modular architecture.

### Step-by-Step Guide to Creating a Custom Discount Strategy

1. **Create a new class** that implements `IDiscountService`.

2. **Implement the `CalculateDiscount` method**, defining the logic for your discount.

3. **Add the strategy** to the `PricingEngine` to use it.

Here’s an example of a custom **SeasonalDiscountStrategy**:

```csharp
public class SeasonalDiscountStrategy : IDiscountService
{
    public Discount CalculateDiscount(Customer customer, Product product)
    {
        var discount = new Discount { Percentage = 0 };

        var currentMonth = DateTime.Now.Month;
        if (currentMonth == 12) // Christmas season
        {
            discount.Percentage = 25;
        }

        discount.Description = "Seasonal Discount";
        return discount;
    }
}
```

### Registering the New Strategy

In your pricing engine configuration:

```csharp
var pricingEngine = new PricingEngine();
pricingEngine.AddDiscountService(new LoyaltyDiscountStrategy());
pricingEngine.AddDiscountService(new StockLevelDiscountStrategy());
pricingEngine.AddDiscountService(new SeasonalDiscountStrategy());
```

---

## 4. Expanding the Project

### Additional Features You Can Add

1. **Advanced Caching**:
   - Improve performance by caching customer or product data, avoiding unnecessary recalculations.

2. **Support for Multiple Currencies**:
   - Add currency conversion rates to handle international pricing.

3. **Regional Pricing**:
   - Create region-based pricing models (e.g., different prices for customers in different countries).

4. **Volume-Based Discounts**:
   - Add strategies for offering discounts based on the quantity purchased (e.g., buy 3, get 10% off).

5. **Real-Time Stock Updates**:
   - Integrate stock level checks with a real-time database or API to adjust discounts based on availability.

## 5. Contributing

If you would like to contribute to **FlexiPrice**, feel free to submit a pull request or open an issue. I would welcome contributions that improve functionality, add new discount strategies, or enhance documentation.

Before contributing, please review our [Contributing Guidelines](CONTRIBUTING.md).

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.