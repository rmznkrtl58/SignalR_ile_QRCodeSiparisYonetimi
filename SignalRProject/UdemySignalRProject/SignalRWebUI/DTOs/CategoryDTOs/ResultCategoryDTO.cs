namespace SignalRWebUI.DTOs.CategoryDTOs
{
	public class ResultCategoryDTO
	{
		//UI tarafında dto oluşturma sebebim apilerimin eşleşmesi için
		//DTO katmanım ise apilerimi oluştururken eşleştirmesi için
		//UI tarafındaki dto klasörüm ise consume edeceğim apileri
		//direk çekemem onlarıda eşleştirmem gerek

		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public bool DeleteStatus { get; set; }
	}
}
