using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public class Testimonial
    {
        [Key]
        public int TestimonialId { get; set; }
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(400)]
        public string Comment { get; set; }
        [StringLength(200)]
        public string ImageUrl { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
