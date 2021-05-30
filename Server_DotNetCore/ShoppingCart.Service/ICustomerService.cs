using ShoppingCart.Model;
using ShoppingCart.Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Service
{
    public interface ICustomerService
    {
        CustomerDto Login(LoginDto loginDto);
        CustomerDto GetCustomer(int id);
        CustomerDto Discount(CustomerDto customerDto);
    }
}
