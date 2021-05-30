using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Discount
{
    public abstract class DiscountDecorator : IDiscount
    {
        protected IDiscount discount;
        public DiscountDecorator(IDiscount _discount)
        {
            this.discount = _discount;
        }

        public virtual decimal apply(decimal originalPrice)
        {
            return discount.apply(originalPrice);
        }
    }
}
