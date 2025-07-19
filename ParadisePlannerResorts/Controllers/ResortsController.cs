using Microsoft.AspNetCore.Mvc;
using ParadisePlanner.Application.Common.Interfaces;
using ParadisePlanner.Domain.Entities;
using ParadisePlanner.Infrastructure.Data;

namespace ParadisePlannerResorts.Controllers
{
    public class ResortsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ResortsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var resort = _unitOfWork.Resort.GetAll();
            return View(resort);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Resort obj)
        {
            // Custom validation
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("", "Name and Description should be different");
            }

            if (ModelState.IsValid)
            {
                // Handle image upload if an image is provided
                if (obj.Image != null && obj.Image.Length > 0)
                {
                    string extension = Path.GetExtension(obj.Image.FileName).ToLower();

                    // Allowed extensions
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    if (!allowedExtensions.Contains(extension))
                    {
                        TempData["Error"] = "Image file type not supported! Allowed: JPG, JPEG, PNG.";
                        return View(obj);
                    }

                    try
                    {
                        // Generate unique filename
                        string fileName = Guid.NewGuid().ToString() + extension;

                        // Build full upload path (wwwroot/images/ResortImages)
                        string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "ResortImages");

                        // Ensure the folder exists
                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        // Save the file
                        string fullPath = Path.Combine(uploadPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            obj.Image.CopyTo(stream);
                        }

                        // Store relative path to DB
                        obj.ImageUrl = "/images/ResortImages/" + fileName;
                    }
                    catch (Exception ex)
                    {
                        TempData["Error"] = "Image upload failed: " + ex.Message;
                        return View(obj);
                    }
                }
                else
                {
                    // Use placeholder image if none uploaded
                    obj.ImageUrl = "https://placehold.co/600x400";
                }

                // Save to database
                _unitOfWork.Resort.Add(obj);
                _unitOfWork.Save();

                TempData["Success"] = "Resort has been added successfully!";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Resort could not be added!";
            return View(obj);
        }

        public IActionResult Update(int id)
        {
            var resort = _unitOfWork.Resort.GetId(x => x.Id == id);
            if (resort == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(resort);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Resort obj)
        {
            ModelState.Remove("ImageUrl");

            if (ModelState.IsValid && obj.Id > 0)
            {
                var existingResort = _unitOfWork.Resort.GetId(x => x.Id == obj.Id);
                if (existingResort == null)
                {
                    TempData["Error"] = "Resort not found.";
                    return RedirectToAction("Index");
                }

                // Update fields
                existingResort.Name = obj.Name;
                existingResort.Description = obj.Description;
                existingResort.Price = obj.Price;
                existingResort.Sqft = obj.Sqft;
                existingResort.Occupancy = obj.Occupancy;

                // Handle image
                if (obj.Image != null && obj.Image.Length > 0)
                {
                    string extension = Path.GetExtension(obj.Image.FileName).ToLower();
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

                    if (!allowedExtensions.Contains(extension))
                    {
                        TempData["Error"] = "Image file type not supported!";
                        return View(existingResort); // Return existing resort to show current data
                    }

                    try
                    {
                        string fileName = Guid.NewGuid().ToString() + extension;
                        string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "ResortImages");

                        if (!Directory.Exists(uploadPath))
                            Directory.CreateDirectory(uploadPath);

                        string fullPath = Path.Combine(uploadPath, fileName);

                        // Delete old image
                        if (!string.IsNullOrEmpty(existingResort.ImageUrl))
                        {
                            string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, existingResort.ImageUrl.TrimStart('/'));
                            if (System.IO.File.Exists(oldImagePath))
                                System.IO.File.Delete(oldImagePath);
                        }

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            obj.Image.CopyTo(stream);
                        }

                        existingResort.ImageUrl = "/images/ResortImages/" + fileName;
                    }
                    catch (Exception ex)
                    {
                        TempData["Error"] = "Image upload failed: " + ex.Message;
                        return View(existingResort);
                    }
                }

                _unitOfWork.Resort.Update(existingResort);
                _unitOfWork.Save();

                TempData["Success"] = "Resort has been updated successfully!";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Resort could not be updated!";
            return View(obj);
        }



        public IActionResult Delete(int id)
        {
            var resort = _unitOfWork.Resort.GetId(x => x.Id == id);
            if (resort == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(resort);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var resort = _unitOfWork.Resort.GetId(x => x.Id == id);
            if (resort != null)
            {
                if (!string.IsNullOrEmpty(resort.ImageUrl))
                {
                    string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, resort.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                        System.IO.File.Delete(oldImagePath);
                }
                _unitOfWork.Resort.Remove(resort);
                _unitOfWork.Save();
                TempData["Success"] = "Resort deleted successfully!";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Resort not found.";
            return RedirectToAction("Index");
        }

    }
}
