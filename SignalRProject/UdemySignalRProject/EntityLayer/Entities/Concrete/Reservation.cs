using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities.Concrete
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool ReservationStatus { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
