using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.ContactDTOs
{
   public class GetContactDTO
    {
      
        public int ContactId { get; set; }

        public string LocationUrl { get; set; }
     
        public string Phone { get; set; }
       
        public string Mail { get; set; }
       
        public string FooterDescription { get; set; }
       
        public string OpenHours { get; set; }
    }
}
