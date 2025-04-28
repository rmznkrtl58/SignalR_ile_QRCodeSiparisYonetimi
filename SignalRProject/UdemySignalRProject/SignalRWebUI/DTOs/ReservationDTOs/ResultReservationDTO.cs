namespace SignalRWebUI.DTOs.ReservationDTOs
{
    public class ResultReservationDTO
    {
        public int ReservationId { get; set; }
        public string NameSurname { get; set; }
        public int PersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool ReservationStatus { get; set; }
        public string Phone { get; set; }
    }
}
