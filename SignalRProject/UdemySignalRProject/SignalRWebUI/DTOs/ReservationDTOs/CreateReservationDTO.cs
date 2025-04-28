namespace SignalRWebUI.DTOs.ReservationDTOs
{
	public class CreateReservationDTO
	{
		public string NameSurname { get; set; }
		public string Mail { get; set; }
		public int PersonCount { get; set; }
		public DateTime ReservationDate { get; set; }
		public string Phone { get; set; }
	}
}
