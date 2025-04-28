using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public class Slider
    {
        public int SliderId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Title2 { get; set; }
        [StringLength(50)]
        public string Title3 { get; set; }
        [StringLength(50)]
        public string Title4 { get; set; }
        [StringLength(350)]
        public string SubDescription { get; set; }
        [StringLength(350)]
        public string SubDescription2 { get; set; }
        [StringLength(350)]
        public string SubDescription3 { get; set; }
        [StringLength(350)]
        public string SubDescription4 { get; set; }
    }
}
