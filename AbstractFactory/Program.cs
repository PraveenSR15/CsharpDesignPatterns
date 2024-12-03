using AbstractFactory;

var cbePurchaseFactory = new CoimbatoreShoppingCartPurchaseFactory();
var cbeCart = new ShoppingCart(cbePurchaseFactory);
cbeCart.CalculateCost();

var chennaiPurchaseFactory = new ChennaiShoppingCartPurchaseFactory();
var chennaiCart = new ShoppingCart(chennaiPurchaseFactory);
chennaiCart.CalculateCost();

Console.ReadKey();