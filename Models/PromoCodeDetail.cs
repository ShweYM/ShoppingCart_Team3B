using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team3B_ShoppingCart.Models
{
    public class PromoCodeDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(40)]
        public string PromoCodeDetailID { get; set; }

        public DateTime PromoStartDate { get; set; }
        public DateTime PromoEndDate { get; set; }
        public int PromoDiscountRate { get; set; }
        public double PromoPrice { get; set; }
    }
}
