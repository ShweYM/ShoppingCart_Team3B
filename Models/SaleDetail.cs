using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team3B_ShoppingCart.Models
{
    public class SaleDetail
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[MaxLength(40)]
		[Required]
		public int SaleDetailID { get; set; }

		[MaxLength(40)]
		public int SalesID { get; set; }
		[MaxLength(20)]
		public string ProductID { get; set; }
		
		public string ActivationCode { get; set; }
	}
}
