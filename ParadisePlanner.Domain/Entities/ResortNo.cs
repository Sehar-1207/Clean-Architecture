using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParadisePlanner.Domain.Entities
{
    //[Table("ResortNos")]
    public class ResortNo
    {
        [Key]
        public int Id { get; set; }

        public int Resort_No { get; set; }

        [ForeignKey("Resorts")]
        public int ResortId { get; set; }

        [ValidateNever]
        public Resort Resorts { get; set; }

        public string? SpecialDetail { get; set; }
    }
}
