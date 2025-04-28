using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities.Concrete
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(20)]
        public string Amount { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        [StringLength(200)]
        public string ImageUrl { get; set; }
    }
}
