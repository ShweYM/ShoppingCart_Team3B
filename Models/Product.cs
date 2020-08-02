using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team3B_ShoppingCart.Models
{
	public class Product
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Required]
		[MaxLength(20)]
		public string ProductID { get; set; }

		[MaxLength(40)]
		[Required]
		public string ProductName { get; set; }

		[MaxLength(2000)]
		public string Description { get; set; }
		public double ProductPrice { get; set; }
		[MaxLength(500)]
		public string ImageURL { get; set; }
		public int InventoryQuantity { get; set; }
		
	}
}
