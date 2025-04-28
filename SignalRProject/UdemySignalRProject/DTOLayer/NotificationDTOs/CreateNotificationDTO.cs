using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.NotificationDTOs
{
    public class CreateNotificationDTO
    {
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
