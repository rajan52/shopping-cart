using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Model.Dal
{
   public static class EmployeeDataInitilizer
    {
        public static void initizlize()
        {
            IDal dal = new CustomerDal();
            dal.AddCustomer(new NormalCustomer(null)
                            { Id=1, Name="normal", Password="12345", UserName="normalcust" });
            dal.AddCustomer(new PriviagedCustomer(null)
            { Id = 2, Name = "privileged", Password = "12345", UserName = "privilegedcust" });
        }
    }
}
