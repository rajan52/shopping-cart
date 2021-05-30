using ShoppingCart.Discount;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Model
{
    public class NormalCustomer : Customer
    {
        public NormalCustomer(IDiscount _discount) : base(_discount)
        {

        }

        public override decimal DiscountedPrice
        {
            get
            {
                return this.discount.apply(this.TotalPrce);
            }
        }
    }
}
