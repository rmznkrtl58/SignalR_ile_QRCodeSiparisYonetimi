using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.TestimonialDTOs
{
   public class GetTestimonialDTO
    {
       
        public int TestimonialId { get; set; }
    
        public string NameSurname { get; set; }
      
        public string Title { get; set; }
   
        public string Comment { get; set; }
      
        public string ImageUrl { get; set; }

    }
}
