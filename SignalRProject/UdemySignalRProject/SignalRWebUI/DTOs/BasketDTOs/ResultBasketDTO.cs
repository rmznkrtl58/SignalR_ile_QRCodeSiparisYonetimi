using EntityLayer.Entities.Concrete;

namespace SignalRWebUI.DTOs.BasketDTOs
{
    public class ResultBasketDTO
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        //ürün tablosuyla ilişki
        public int ProductId { get; set; }
        public int MenuTableId { get; set; }
        public string ProductName { get; set; }
    }
}

