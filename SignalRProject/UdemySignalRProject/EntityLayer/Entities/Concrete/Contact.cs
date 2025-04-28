using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
   public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [StringLength(400)]
        public string LocationUrl { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(400)]
        public string FooterDescription { get; set; }
        [StringLength(50)]
        public string OpenHours { get; set; }
    }
}
