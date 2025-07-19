using Microsoft.AspNetCore.Mvc;
using ParadisePlanner.Application.Common.Interfaces;
using ParadisePlannerResorts.Models;
using ParadisePlannerResorts.Models.ViewModel;
using System.Diagnostics;

namespace ParadisePlannerResorts.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeVm vm = new HomeVm()
            {
                ResortList = _unitOfWork.Resort.GetAll(includeProperties : "amenities"),
                Nights = 1,
                CheckInDate = DateOnly.FromDateTime(DateTime.Now)
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
