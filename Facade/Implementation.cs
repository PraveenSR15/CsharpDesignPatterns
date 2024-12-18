namespace Facade
{
    public class OrderDetails
    {
        public bool HasEnoughOrders(int customerId)
        {
            return customerId > 5;
        }
    }

    public class DiscountBase
    {
        public int CalculateDiscountBase(int customerId)
        {
            return customerId > 8 ? 10 : 20; 
        }
    }

    public class DayOfWeekDiscount
    {
        public double CalculateDiscountOnDayOfWeek()
        {
            switch(DateTime.UtcNow.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return 0.8;
                default:
                    return 1.0;
            }
        }
    }

    public class DiscountFacade
    {
        OrderDetails orderDetails = new();
        DiscountBase discountBase = new();
        DayOfWeekDiscount dayOfWeekDiscount = new();

        public double CalculateDiscount(int customerId)
        {
            if(orderDetails.HasEnoughOrders(customerId))
                return discountBase.CalculateDiscountBase(customerId)*dayOfWeekDiscount.CalculateDiscountOnDayOfWeek();
            
            return 0;
        }
    }
}
