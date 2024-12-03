using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface ITamilnaduShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostService CreateShippingCostService();
    }

    public interface IDiscountService
    {
        int DiscountPercentage {  get; }
    }

    public interface IShippingCostService
    {
        double ShippingCost {  get; }
    }

    public class CoimbatoreDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }
    public class ChennaiDiscountService : IDiscountService
    {
        public int DiscountPercentage => 15;
    }

    public class CoimbatoreShippingCostService : IShippingCostService
    {
        public double ShippingCost => 25;
    }
    public class ChennaiShippingCostService : IShippingCostService
    {
        public double ShippingCost => 10;
    }

    public class CoimbatoreShoppingCartPurchaseFactory : ITamilnaduShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new CoimbatoreDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new CoimbatoreShippingCostService();
        }
    }

    public class ChennaiShoppingCartPurchaseFactory : ITamilnaduShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new ChennaiDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new ChennaiShippingCostService();
        }
    }

    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostService _shippingCostService;
        private int _orderTotal;

        public ShoppingCart(ITamilnaduShoppingCartPurchaseFactory factory)
        {
             _discountService = factory.CreateDiscountService();
            _shippingCostService = factory.CreateShippingCostService();
            _orderTotal = 500;
        }

        public void CalculateCost()
        {
            Console.WriteLine($"Total Cost : {_orderTotal - (_orderTotal / 100 * _discountService.DiscountPercentage) + _shippingCostService.ShippingCost}");
        }
    }
}
