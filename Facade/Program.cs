using Facade;

var discountFacade = new DiscountFacade();
Console.WriteLine($"Discount for customer #10 is {discountFacade.CalculateDiscount(10)}");
Console.WriteLine($"Discount for customer #1 is {discountFacade.CalculateDiscount(1)}");
Console.WriteLine($"Discount for customer #6 is {discountFacade.CalculateDiscount(6)}");

Console.ReadKey();