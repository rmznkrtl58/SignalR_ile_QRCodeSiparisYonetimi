using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.ProductDTOs
{
    public class ResultProductsWithCategoryDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
        //Include uyguladığımız sınıftır categoryName ihtiyacım olduğundan
        //burada çağırıyorum
        public string CategoryName { get; set; }
     
    }
}
