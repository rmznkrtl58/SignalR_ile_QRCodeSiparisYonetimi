using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.DTOs.FeatureDTOs
{
    public class UpdateFeatureDTO
    {
       
        public int FeatureId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
