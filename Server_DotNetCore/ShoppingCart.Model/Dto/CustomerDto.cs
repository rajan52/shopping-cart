using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Model.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal TotalPrce { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int DiscountPercentage { get; set; }
        public string Type { get; set; }
    }
}
