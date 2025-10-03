using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models.Entities
{
    public class AmenityModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;


        //Relations

    }
}
