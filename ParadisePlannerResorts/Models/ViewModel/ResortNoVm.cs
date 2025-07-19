using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParadisePlanner.Domain.Entities;

namespace ParadisePlannerResorts.Models.ViewModel
{
    public class ResortNoVm
    {
        public ResortNo? ResortNo { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> list { get; set; }
    }
}
