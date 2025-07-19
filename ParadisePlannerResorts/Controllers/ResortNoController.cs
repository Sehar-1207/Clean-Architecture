using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParadisePlanner.Application.Common.Interfaces;
using ParadisePlanner.Domain.Entities;
using ParadisePlanner.Infrastructure.Data;
using ParadisePlannerResorts.Models.ViewModel;

public class ResortNoController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ResortNoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var resortNoList = _unitOfWork.ResortNo.GetAll(includeProperties: "Resorts");
        return View(resortNoList);
    }

    public IActionResult Create()
    {
        var vm = new ResortNoVm
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
    public IActionResult Create(ResortNoVm obj)
    {
        bool exists = _unitOfWork.ResortNo.Any(u => u.Resort_No == obj.ResortNo.Resort_No);

        if (exists)
        {
            ModelState.AddModelError("", "This resort number already exists.");
        }

        if (ModelState.IsValid && !exists)
        {
            _unitOfWork.ResortNo.Add(obj.ResortNo);
            _unitOfWork.Save();
            TempData["Success"] = "Resort number has been added successfully!";
            return RedirectToAction("Index");
        }

        TempData["Error"] = "Resort number already exists or data is invalid.";

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
        var resort = _unitOfWork.ResortNo.GetId(x => x.Id == id);
        if (resort == null)
        {
            return NotFound();
        }

        var vm = new ResortNoVm
        {
            ResortNo = resort,
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
    public IActionResult Update(ResortNoVm obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.ResortNo.Update(obj.ResortNo);
            _unitOfWork.Save();
            TempData["Success"] = "Resort number has been updated successfully!";
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
    // GET: Delete ResortNo
    public IActionResult Delete(int id)
    {
        var resort = _unitOfWork.ResortNo.GetId(x => x.Id == id);
        if (resort == null)
        {
            return NotFound();
        }

        var vm = new ResortNoVm
        {
            ResortNo = resort,
            list = _unitOfWork.Resort.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }).ToList()
        };

        return View(vm);
    }

    // POST: Delete ResortNo
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int id)
    {
        var resort = _unitOfWork.ResortNo.GetId(x => x.Id == id);
        if (resort == null)
        {
            return NotFound();
        }

        _unitOfWork.ResortNo.Remove(resort);
        _unitOfWork.Save();
        TempData["Success"] = "Resort number deleted successfully!";
        return RedirectToAction("Index");
    }

}
