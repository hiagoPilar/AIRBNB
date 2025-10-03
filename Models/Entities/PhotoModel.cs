using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace AIRBNB.Models.Entities
{
    public class PhotoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }
        public PropertyModel? Property { get; set; }

        [Required]
        [MaxLength(500)]
        [Url]
        public string Url { get; set; } = string.Empty;


        [Required, MaxLength(200)]
        public string Description { get; set; } 

        public bool IsCover { get; set; } //select if the first photo
    }
}
