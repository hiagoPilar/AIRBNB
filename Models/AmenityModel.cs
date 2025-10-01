using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models
{
    public class AmenityModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null;


        //Relations

    }
}
