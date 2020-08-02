using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team3B_ShoppingCart.Models
{
    public class Sale
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[MaxLength(40)]
		[Required]
		public int SalesID { get; set; }

		[MaxLength(40)]
		[Required]
		public string CustomerID { get; set; }
		public int SalesQuantity { get; set; }
		public DateTime SalesDate { get; set; }
		[MaxLength(40)]
		public string PromoCode { get; set; }
		[MaxLength(20)]
		public string ProductID { get; set; }
		[MaxLength(50)]
		public string SessionID { get; set; }
	}
}
