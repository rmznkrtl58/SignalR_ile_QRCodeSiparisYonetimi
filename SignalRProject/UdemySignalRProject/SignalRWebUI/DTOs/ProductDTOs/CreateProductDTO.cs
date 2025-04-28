namespace SignalRWebUI.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Picture { get; set; }
        public int CategoryId { get; set; }
    }
}
