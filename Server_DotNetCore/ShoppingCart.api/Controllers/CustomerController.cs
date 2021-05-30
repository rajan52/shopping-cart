using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Service;

namespace ShoppingCart.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        ICustomerService customerService;
        public CustomerController(ICustomerService _customerService)
        {
            this.customerService = _customerService;
        }


        // GET: api/Customer/5
        [HttpGet]
        public ActionResult Get()
        {
            
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    int UserId = Convert.ToInt32(identity.FindFirst("UserId").Value);
                    var custdto = this.customerService.GetCustomer(UserId);
                    return Ok(custdto);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.Forbidden);
                }

                
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
