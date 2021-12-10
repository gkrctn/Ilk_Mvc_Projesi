using Ilk_Mvc_Projesi.Models;
using Ilk_Mvc_Projesi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_Mvc_Projesi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NorthwindContext _context;


        public CategoryController(NorthwindContext context)
        {
            _context = context;
        }
        // [HttpGet]
        public IActionResult Index()
        {

            var data = _context.Categories
                .Include(x => x.Products)
                .OrderBy(x => x.CategoryName)
                .ToList();
            //resharper
            return View(data);
        }
        public IActionResult Detail(int? id)
        {
            var category = _context.Categories
                .Include(x => x.Products)
                .ThenInclude(x => x.OrderDetails) // tenınclude eklediğimiz verinin bağlantısını eklemek için kullanılır.
                .ThenInclude(x => x.Order)
                .FirstOrDefault(x => x.CategoryId == id);

            var category2 = from cat2 in _context.Categories
                            join prod in _context.Products on cat2.CategoryId equals prod.CategoryId
                            join odetail in _context.OrderDetails on prod.ProductId equals odetail.ProductId
                            where cat2.CategoryId == id
                            select cat2;

            if (category == null)
                return RedirectToAction(nameof(Index));
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var caregory = new Category()
            {
                //CategoryId = 1,// hata verwsin diye yazdık
                CategoryName = model.CategoryName,
                Description = model.Description
            };
            _context.Categories.Add(caregory);
            try
            {
                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = caregory.CategoryId });

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CategoryName}eklenirken bir hata oluştu. tekrar deneyiniz");
                return View(model);

            }
        }
        public IActionResult Delete(int? categoryId)
        {
            try
            {
                _context.Categories.Remove(silinecek);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Detail), new { id = categoryId });
            }
            TempData["Silinen_Kategori"] = silinecek.CategoryName;
            return RedirectToAction(nameof(Index));
        }

    }
}













