using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Discount
{
    public class NormaluserDiscount : IDiscount
    {
        const decimal DISCOUNT_PERCENTAGE = 0;// this value can be read from config also
        public decimal apply(decimal originalPrice)
        {
            return originalPrice - ((originalPrice * DISCOUNT_PERCENTAGE) / 100);
        }
    }
}
