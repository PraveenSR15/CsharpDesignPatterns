using FactoryMethod;

Console.Title = "Factory Method";

var factories = new List<DiscountFactory>
                    {
                        new CountryDiscountFactory("CBE"),
                        new CodeDiscountFactory(Guid.NewGuid()),
                        new CountryDiscountFactory("KL")
                    };

foreach (var factory in factories)
{
    var discountService = factory.CreateDiscountService();
    Console.WriteLine($"Percentage {discountService.DiscountPercentage} is coming from {discountService}");
}

Console.ReadKey();