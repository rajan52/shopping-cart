using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Model.Dto;
using ShoppingCart.Service;

namespace ShoppingCart.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    [Authorize]
    public class DiscountController : ControllerBase
    {

        ICustomerService customerService;
        public DiscountController(ICustomerService _customerService)
        {
            this.customerService = _customerService;
        }
        public ActionResult Post(CustomerDto customerDto)
        {
            try
            {
                var custdto = this.customerService.Discount(customerDto);
                if (custdto != null)
                {
                    return Ok(custdto);
                }
                else
                {
                    return NotFound("invalid customer");
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}