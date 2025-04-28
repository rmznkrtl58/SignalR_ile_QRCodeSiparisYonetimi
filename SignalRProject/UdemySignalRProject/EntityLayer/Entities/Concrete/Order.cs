using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
	public class Order
	{
        public int OrderId { get; set; }
        public string TableNumber { get; set; }=string.Empty;
        [StringLength(30)]
        public string Description { get; set; }
        [Column(TypeName ="Date")]
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
