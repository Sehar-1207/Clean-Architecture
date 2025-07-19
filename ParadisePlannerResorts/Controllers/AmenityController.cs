using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParadisePlanner.Application.Common.Interfaces;
using ParadisePlanner.Domain.Entities;
using ParadisePlanner.Infrastructure.Data;
using ParadisePlannerResorts.Models.ViewModel;

public class AmenityController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public AmenityController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var AmenityList = _unitOfWork.Amenity.GetAll(includeProperties: "Resorts");
        return View(AmenityList);
    }

    public IActionResult Create()
    {
        var vm = new AmenityVm
        {
            list = _unitOfWork.Resort.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }).ToList()
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AmenityVm obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Amenity.Add(obj.Amenity);
            _unitOfWork.Save();
            TempData["Success"] = "Amenity has been added successfully!";
            return RedirectToAction("Index");
        }

        TempData["Error"] = "Amenity already exists or data is invalid.";

        // Re-populate dropdown
        obj.list = _unitOfWork.Resort.GetAll().Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        }).ToList();

        return View(obj);
    }

    public IActionResult Update(int id)
    {
        var resort = _unitOfWork.Amenity.GetId(x => x.Id == id);
        if (resort == null)
        {
            return NotFound();
        }

        var vm = new AmenityVm
        {
            Amenity = resort,
            list = _unitOfWork.Resort.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }).ToList()
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(AmenityVm obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Amenity.Update(obj.Amenity);
            _unitOfWork.Save();
            TempData["Success"] = "Amenity has been updated successfully!";
            return RedirectToAction("Index");
        }

        TempData["Error"] = "Update failed!";

        obj.list = _unitOfWork.Resort.GetAll().Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        }).ToList();

        return View(obj);
    }
    // GET: Delete Amenity
    public IActionResult Delete(int id)
    {
        var resort = _unitOfWork.Amenity.GetId(x => x.Id == id);
        if (resort == null)
        {
            return NotFound();
        }

        var vm = new AmenityVm
        {
            Amenity = resort,
            list = _unitOfWork.Resort.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }).ToList()
        };

        return View(vm);
    }

    // POST: Delete Amenity
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int id)
    {
        var resort = _unitOfWork.Amenity.GetId(x => x.Id == id);
        if (resort == null)
        {
            return NotFound();
        }

        _unitOfWork.Amenity.Remove(resort);
        _unitOfWork.Save();
        TempData["Success"] = "Amenity deleted successfully!";
        return RedirectToAction("Index");
    }

}
