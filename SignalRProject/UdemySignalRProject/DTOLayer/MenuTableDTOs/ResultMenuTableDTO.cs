using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.MenuTableDTOs
{
	public class ResultMenuTableDTO
	{
		
		public int TableId { get; set; }
		
		public string Name { get; set; }
		public bool Status { get; set; }//dolumu? boşmu?
										//sepet tablosuyla bire-cok ilişki

	}
}
