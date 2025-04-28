namespace SignalRWebUI.DTOs.ReservationDTOs
{
    public class ConfirmReservationDTO
    {
        public int ReservationId { get; set; }
        public string NameSurname { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
