using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities.Concrete
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        [StringLength(200)]
        public string ImageUrl { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
    }
}
