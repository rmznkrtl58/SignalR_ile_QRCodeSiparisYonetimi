using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
   public class communication
    {
        [Key]
        public int MessageId { get; set; }
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(30)]
        public string Subject { get; set; }
        [StringLength(600)]
        public string MessageContent { get; set; }
        public DateTime SendDate { get; set; }
        public bool Status { get; set; }
    }
}
