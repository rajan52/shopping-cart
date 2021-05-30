using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingCart.Model.Dal
{
    public class CustomerDal: IDal
    {
        private static List<ICustomer> customers = new List<ICustomer>();

        public ICustomer AddCustomer(ICustomer cust)
        {
            customers.Add(cust);
            return cust;
        }
        public virtual ICustomer GetCustomer(string userName, string password)
        {
            return customers.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }
        public ICustomer GetCustomer(int id)
        {
            return customers.FirstOrDefault(x => x.Id == id);
        }
    }      
}
