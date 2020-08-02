using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team3B_ShoppingCart.Models
{
    public class Customer

    {
        [MaxLength(40)]
        public string CustomerID { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }

        [MaxLength(128)]
        public string EmailAddress { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(128)]
        public string Address { get; set; }

    }
}
