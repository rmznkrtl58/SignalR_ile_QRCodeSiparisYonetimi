using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
	public class MoneyCase
	{
        [Key]
        public int CaseId { get; set; }
        public decimal TotalAmount { get; set; }//toplam miktar
    }
}
