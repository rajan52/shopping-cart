using ShoppingCart.Discount;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Model
{
    public abstract class Customer : ICustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal TotalPrce { get; set; }
        public abstract decimal DiscountedPrice { get; }

        protected IDiscount discount;
        public Customer(IDiscount _discount)
        {
            this.discount = _discount;
        }
    }
}
