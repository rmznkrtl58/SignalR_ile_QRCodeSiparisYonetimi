using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public class SocialMedia
    {
        [Key]
        public int SocialMediaId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Url { get; set; }
        [StringLength(50)]
        public string Icon { get; set; }
    }
}
