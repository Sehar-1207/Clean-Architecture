using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ParadisePlanner.Domain.Entities
{
    public class Resort
    {

        public int Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Price per Night")]
        [Range(1,1000000)]
        public double Price { get; set; }
        public int Sqft { get; set; }
        //[Range(1,10)]
        public string Occupancy { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

        [DisplayName("Image Url")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ValidateNever]
        public IEnumerable<Amenity> amenities { get; set; }
    }
}
