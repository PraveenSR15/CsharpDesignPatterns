namespace Bridge
{
    public abstract class Menu
    {
        public readonly ICoupon _coupon;
        protected Menu(ICoupon coupon)
        {
            _coupon = coupon;
        }
        public abstract double CalculateBill();
    }
    public class VegMenu : Menu
    {
        public VegMenu(ICoupon coupon) : base(coupon)
        {
        }
        public override double CalculateBill()
        {
            return 300 - _coupon.CouponValue;
        }
    }
    public class NonVegMenu : Menu
    {
        public NonVegMenu(ICoupon coupon) : base(coupon)
        {
        }
        public override double CalculateBill()
        {
            return 500 - _coupon.CouponValue;
        }
    }
    public interface ICoupon
    {
        int CouponValue { get; }
    }

    public class NoCoupon : ICoupon
    {
        public int CouponValue => 0;
    }
    public class FiftyRupeeCoupon : ICoupon
    {
        public int CouponValue => 50;
    }
    public class HundredRupeeCoupon : ICoupon
    {
        public int CouponValue => 100;
    }
}
