using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParadisePlanner.Domain.Entities;

namespace ParadisePlannerResorts.Models.ViewModel
{
    public class AmenityVm
    {
        public Amenity? Amenity { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> list { get; set; }
    }
}
