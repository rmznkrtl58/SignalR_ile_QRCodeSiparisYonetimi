﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.DTOs.SocialMediaDTOs
{
    public class UpdateSocialMediaDTO
    {
       
        public int SocialMediaId { get; set; }
      
        public string Title { get; set; }
        
        public string Url { get; set; }
       
        public string Icon { get; set; }
    }
}
