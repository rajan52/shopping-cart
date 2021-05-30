using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Model.Dal
{
    public interface IDal
    {
        ICustomer AddCustomer(ICustomer cust);
        ICustomer GetCustomer(string userName,string password);
        ICustomer GetCustomer(int id);
    }
}
