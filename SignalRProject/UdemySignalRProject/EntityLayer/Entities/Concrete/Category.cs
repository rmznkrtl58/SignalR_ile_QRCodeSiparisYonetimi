using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        public bool DeleteStatus { get; set; }
        //bire çok ilişki bir kategoride birden fazla ürün olabilir
        public List<Product> Categories{ get; set; }
    }
}
