using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.Discount;
using ShoppingCart.Model;
using ShoppingCart.Model.Dal;
using ShoppingCart.Model.Dto;
using ShoppingCart.Model.Factory;
using ShoppingCart.Service;

namespace ShoppingCart.Services.Test
{
    [TestClass]
   public class CustomerServiceTest
    {
        Mock<IDal> _mockDal;
        Mock<ICustomerFactory> _mockCustomerFactory;
        ICustomerService _customerService;

        [TestInitialize]
        public void Setup()
        {

            
            NormaluserDiscount normaluserDiscount = new NormaluserDiscount();
            PrivilegedUserDiscount privilegedUserDiscount = new PrivilegedUserDiscount(normaluserDiscount);


            ICustomer normalCustomer = new NormalCustomer(normaluserDiscount);
            normalCustomer.Id = 1;
            normalCustomer.Name = "User1";
            normalCustomer.TotalPrce = 100;
            


            ICustomer priviagedCustomer = new PriviagedCustomer(privilegedUserDiscount);
            priviagedCustomer.Id = 2;
            priviagedCustomer.Name = "User2";
            priviagedCustomer.TotalPrce = 200;
           

            _mockDal = new Mock<IDal>();
            _mockCustomerFactory = new Mock<ICustomerFactory>();
            _customerService=new CustomerService(_mockDal.Object, _mockCustomerFactory.Object);
            _mockDal.Setup(x => x.GetCustomer(It.Is<int>(custid => custid == 1))).Returns(normalCustomer);

            _mockDal.Setup(x => x.GetCustomer(It.Is<int>(custid => custid == 2))).Returns(priviagedCustomer);

            _mockCustomerFactory.Setup(x => x.GetCustomer("normal")).Returns(normalCustomer);

            _mockCustomerFactory.Setup(x => x.GetCustomer(It.Is<string>(custid => custid == "privileged"))).Returns(priviagedCustomer);

            //privileged

        }
        #region retrieve customer info frm db
        [TestMethod]
        public void Check_customerService_normalCustomer()
        {
            var customer=_customerService.GetCustomer(1);
            Assert.AreEqual("User1", customer.Name);
            
        }

        [TestMethod]
        public void Check_customerService_privilegedCustomer()
        {
            ICustomerService _customerService = new CustomerService(_mockDal.Object, _mockCustomerFactory.Object);
            var customer = _customerService.GetCustomer(2);
            Assert.AreEqual("User2", customer.Name);

        }

        [TestMethod]
        public void Check_customerService_invalidCustomer()
        {
            ICustomerService _customerService = new CustomerService(_mockDal.Object, _mockCustomerFactory.Object);
            var customer = _customerService.GetCustomer(3);
            Assert.AreEqual(null, null);
        }
        #endregion

        #region customer discount check
        [TestMethod]
        public void Check_customerService_normalCustomer_discount()
        {
            CustomerDto customerDto = new CustomerDto { Id = 1, DiscountPercentage = 2, TotalPrce = 100 };
            var customer = _customerService.Discount(customerDto);
            Assert.AreEqual(100, customer.DiscountedPrice);

        }

        [TestMethod]
        public void Check_customerService_normalCustomer_privileged_discount()
        {
            CustomerDto customerDto = new CustomerDto { Id = 2, DiscountPercentage = 2, TotalPrce = 100 };
            var customer = _customerService.Discount(customerDto);
            Assert.AreEqual(98, customer.DiscountedPrice);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Check_customerService_normalCustomer_invalid_discount()
        {
            CustomerDto customerDto = new CustomerDto { Id = 3, DiscountPercentage = 2, TotalPrce = 100 };
            var customer = _customerService.Discount(customerDto);

        }
        #endregion
    }
}
