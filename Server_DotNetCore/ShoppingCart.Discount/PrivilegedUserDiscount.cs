using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Discount
{
    public class PrivilegedUserDiscount : DiscountDecorator
    {
        const decimal DISCOUNT_PERCENTAGE = 2;// this value can be read from config also
        public PrivilegedUserDiscount(IDiscount _discount) : base(_discount)
        {
        }
        public override decimal apply(decimal originalPrice)
        {
            decimal discountpricce = base.apply(originalPrice);
            return discountpricce - ((discountpricce * DISCOUNT_PERCENTAGE) / 100);
        }
    }
}
