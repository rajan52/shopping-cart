using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Model.Factory
{
    public interface ICustomerFactory
    {
        ICustomer GetCustomer(string type);
    }
}
