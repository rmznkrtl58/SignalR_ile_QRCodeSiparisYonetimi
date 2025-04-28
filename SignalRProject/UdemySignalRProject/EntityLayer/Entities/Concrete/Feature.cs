using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities.Concrete
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
    }
}
