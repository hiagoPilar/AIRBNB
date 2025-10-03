using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models.Entities
{
    public class PoolModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }
        public PropertyModel? Property { get; set; }

        [Range(0, double.MaxValue)]
        public double Lenght { get; set; }

        [Range(0, double.MaxValue)]
        public double Width { get; set; }

        [Range(0, double.MaxValue)]
        public double Depth { get; set; }

        public bool IsHeated { get; set; } 
    }
}
