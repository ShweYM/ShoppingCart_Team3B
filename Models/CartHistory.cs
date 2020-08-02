using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team3B_ShoppingCart.Models
{
    public class CartHistory
    {
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		//[MaxLength(10)]
		//public string CartHistoryID { get; set; }

		[MaxLength(50)]
		[Required]
		public string SessionID { get; set; }

		[Required]
		public int IsDeletedProduct { get; set; }

		[MaxLength(40)]
		public string ProdutID { get; set; }

		[MaxLength(40)]
		public int CartQuantity { get; set; }

		public DateTime IsDeletedDate { get; set; }
	}
}
