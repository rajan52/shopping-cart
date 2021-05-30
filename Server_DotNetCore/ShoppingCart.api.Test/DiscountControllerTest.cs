using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.api.Controllers;
using ShoppingCart.Model.Dto;
using ShoppingCart.Service;

namespace ShoppingCart.api.test
{
    [TestClass]
    public class DiscountControllerTest
    {
        DiscountController discountController;
        Mock<ICustomerService> _mockCustomerService;
        CustomerDto normalcustdto;
        CustomerDto privilegedcustdto;
        [TestInitialize]
        public void Setup()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            
            privilegedcustdto = new CustomerDto { Id = 2, TotalPrce = 100, Type = "privileged" };

            discountController = new DiscountController(_mockCustomerService.Object);
           

        }

        [TestMethod]
        public void Check_DiscountController_validCustomer()
        {
            _mockCustomerService.Setup(x => x.Discount(It.IsAny<CustomerDto>())).Returns(privilegedcustdto);
            CustomerDto customerDto = new CustomerDto { Id = 2, DiscountPercentage = 2, TotalPrce = 100 };
            ObjectResult result = discountController.Post(customerDto) as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public void Check_DiscountController_invalidCustomer()
        {
            CustomerDto customerDto = new CustomerDto { Id = 3, DiscountPercentage = 2, TotalPrce = 100 };
            ObjectResult result = discountController.Post(customerDto) as ObjectResult;
            Assert.AreEqual(404, result.StatusCode);

        }
    }
}
