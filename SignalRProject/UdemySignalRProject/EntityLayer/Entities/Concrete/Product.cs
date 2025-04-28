using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        [StringLength(200)]
        public string ImageUrl { get; set; }
        public bool DeleteStatus { get; set; }
        //bire çok ilişki bir ürün sadece bir kategoriye aittir.
        public int CategoryId { get; set; }
        public Category Category { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
        //sepet tablosuyla bire-cok ilişki
        public List<Basket> Baskets { get; set; }
    }
}
