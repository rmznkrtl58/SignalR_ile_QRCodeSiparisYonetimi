using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.ProductDTOs
{
    public class CreateProductDTO
    {
       
        public string ProductName { get; set; }
      
        public string Description { get; set; }
        public decimal Price { get; set; }
     
        public string ImageUrl { get; set; }
		public int CategoryId { get; set; }

	}
}
