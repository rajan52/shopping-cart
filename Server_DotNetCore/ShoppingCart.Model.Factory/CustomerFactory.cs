using ShoppingCart.Discount;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Model.Factory
{
   public class CustomerFactory : ICustomerFactory
    {
        private Dictionary<string, ICustomer> customerList=null;
        public CustomerFactory()
        {

            customerList = new Dictionary<string, ICustomer>();

            NormaluserDiscount normaluserDiscount = new NormaluserDiscount();
            PrivilegedUserDiscount privilegedUserDiscount = new PrivilegedUserDiscount(normaluserDiscount);

            ICustomer normalCustomer = new NormalCustomer(normaluserDiscount);
            ICustomer priviagedCustomer = new PriviagedCustomer(privilegedUserDiscount);

            customerList.Add("normal", normalCustomer);
            customerList.Add("privileged", priviagedCustomer);
        }
        /// <summary>
        /// idealy this should be injected via depenedency injection.
        /// but.net core does not have support to inject depenedency in decortor pattern style
        /// hence using factory pattern
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        //
        public ICustomer GetCustomer(string type)
        {
           return customerList.ContainsKey(type)? customerList[type] : throw new Exception("Invalid Customer Type");
        }
    }
}
