using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.ReservationDTOs
{
    public class GetReservationDTO
    {
        
        public int ReservationId { get; set; }

        public string NameSurname { get; set; }
    
        public string Phone { get; set; }

        public string Mail { get; set; }
        public int PersonCount { get; set; }

    }
}
