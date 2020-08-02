using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team3B_ShoppingCart.Models
{
    public class Session
    {
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[MaxLength(40)]
		[Required]
		public string SessionID { get; set; }

		[MaxLength(10)]
		public string CustomerID { get; set; }

		public DateTime SessionDateTime { get; set; }
		public DateTime SessionDuration { get; set; }
	}
}
