using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Model
{
    public interface ICustomer
    {
        int Id { get; set; }
        string Name { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        decimal TotalPrce { get; set; }
        decimal DiscountedPrice { get; }
    }
}
