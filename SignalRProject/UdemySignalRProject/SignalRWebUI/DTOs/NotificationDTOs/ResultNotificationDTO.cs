using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.DTOs.NotificationDTOs
{
    public class ResultNotificationDTO
    {
        public int NotificationId { get; set; }
   
        public string Type { get; set; }
        
        public string Icon { get; set; }
   
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
