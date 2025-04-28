using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.DTOs.MenuTableDTOs
{
	public class UpdateMenuTableDTO
	{
	
		public int TableId { get; set; }
		public string Name { get; set; }
	}
}
