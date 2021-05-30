using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Model;
using ShoppingCart.Model.Dal;
using ShoppingCart.Model.Dto;
using ShoppingCart.Model.Factory;

namespace ShoppingCart.Service
{
    public class CustomerService : ICustomerService
    {
        IDal dal = null;
        ICustomerFactory customerFactory = null;
        public CustomerService(IDal _dal, ICustomerFactory _customerFactory)
        {
            this.dal = _dal;
            this.customerFactory = _customerFactory;
        }
        public CustomerDto Discount(CustomerDto customerDto)
        {
            var cust = this.dal.GetCustomer(customerDto.Id);
            ICustomer customer = null;
            if(cust!=null)
            {
                if(cust is PriviagedCustomer)
                {
                    customer=customerFactory.GetCustomer("privileged");
                }
                else if (cust is NormalCustomer)
                {
                    customer= customerFactory.GetCustomer("normal");
                }

                customer.TotalPrce = customerDto.TotalPrce;
                customerDto.DiscountedPrice = customer.DiscountedPrice;
                return customerDto;
            }
            else
            {
                throw new Exception("Invalid Customer");//custom execption can be created and thrown
            }
            
        }
        public CustomerDto GetCustomer(int id)
        {
            CustomerDto customerDto = null;
            var cust = this.dal.GetCustomer(id);
            if (cust != null)
            {
                
                customerDto = new CustomerDto { Id = cust.Id, Name = cust.Name, DiscountPercentage=2 };//DiscountedPrice can be load from config or db
                if(cust is NormalCustomer)
                {
                    customerDto.Type = "normal";
                }
                else if (cust is PriviagedCustomer)
                {
                    customerDto.Type = "priviaged";
                }
            }
            return customerDto;
        }
        public CustomerDto Login(LoginDto loginDto)
        {
            CustomerDto customerDto = null;
           var cust= this.dal.GetCustomer(loginDto.UserName, loginDto.Password);
           if(cust!=null)
            {
                customerDto = new CustomerDto { Id = cust.Id, Name = cust.Name };
            }
            return customerDto;
        }
    }
}
