namespace SignalRWebUI.DTOs.ContactDTOs
{
	public class UpdateContactDTO
	{
		public int ContactId { get; set; }
		public string LocationUrl { get; set; }
		public string Phone { get; set; }
		public string Mail { get; set; }
		public string FooterDescription { get; set; }
		public string OpenHours { get; set; }
	}
}
