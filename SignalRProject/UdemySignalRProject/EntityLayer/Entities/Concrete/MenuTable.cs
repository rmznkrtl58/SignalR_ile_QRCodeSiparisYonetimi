using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
	public class MenuTable
	{
        [Key]
        public int TableId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool Status { get; set; }//dolumu? boşmu?
        //sepet tablosuyla bire-cok ilişki
        public List<Basket> Baskets { get; set; }
    }
}
