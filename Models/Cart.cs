using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team3B_ShoppingCart.Models
{
    public class Cart
    {
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		//[MaxLength(10)]
		//public string CartID { get; set; }

		[MaxLength(50)]
		[Required]
		public string SessionID { get; set; }

		[MaxLength(40)]
		[Required]
		public string ProductID { get; set; }

		[MaxLength(40)]
		public int CartQuantity { get; set; }

		[MaxLength(40)]
		public string CustomerID { get; set; }
	}
}
