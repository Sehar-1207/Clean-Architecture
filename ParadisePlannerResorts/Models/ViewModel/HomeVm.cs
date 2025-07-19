using ParadisePlanner.Domain.Entities;

namespace ParadisePlannerResorts.Models.ViewModel
{
    public class HomeVm
    {
        public IEnumerable<Resort> ResortList { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly? CheckOutDate { get; set; }
        public int Nights { get; set; }
    }
}
