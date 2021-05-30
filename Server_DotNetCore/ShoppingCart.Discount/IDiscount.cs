using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Discount
{
    public interface IDiscount
    {
        decimal apply(decimal originalPrice);
    }
}
