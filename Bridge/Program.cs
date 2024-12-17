using Bridge;

var noCoupon = new NoCoupon();
var fiftyCoupon = new FiftyRupeeCoupon();
var hundredCoupon = new HundredRupeeCoupon();

var vegMenuNoCoupon = new VegMenu(noCoupon);
Console.WriteLine($"Vegetarian menu with no coupon costs {vegMenuNoCoupon.CalculateBill()} Rupees");

var vegMenuFiftyCoupon = new VegMenu(fiftyCoupon);
Console.WriteLine($"Vegetarian menu with fifty rupees coupon costs {vegMenuFiftyCoupon.CalculateBill()} Rupees");

var vegMenuHundredCoupon = new VegMenu(hundredCoupon);
Console.WriteLine($"Vegetarian menu with hundred rupees coupon costs {vegMenuHundredCoupon.CalculateBill()} Rupees");

var nonVegMenuNoCoupon = new NonVegMenu(noCoupon);
Console.WriteLine($"Non vegetarian menu with no coupon costs {nonVegMenuNoCoupon.CalculateBill()} Rupees");

var nonVegMenuFiftyCoupon = new NonVegMenu(fiftyCoupon);
Console.WriteLine($"Non vegetarian menu with fifty rupees coupon costs {nonVegMenuFiftyCoupon.CalculateBill()} Rupees");

var nonVegMenuHundredCoupon = new NonVegMenu(hundredCoupon);
Console.WriteLine($"Non vegetarian menu with hundred rupees coupon costs {nonVegMenuHundredCoupon.CalculateBill()} Rupees");

Console.ReadKey();