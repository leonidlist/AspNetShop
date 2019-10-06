using DAL;
using DAL.Abstractions;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ShopContext _context = new ShopContext();
        private readonly IRepository<Category> _categoryRepository;
        public CategoriesController(IRepository<Category> repo)
        {
            _categoryRepository = repo;
        }
        public ActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(_categoryRepository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            _categoryRepository.AddOrUpdate(category);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_categoryRepository.Get(id));
        }

        public ActionResult Create()
        {
            return View(new Category { CategoryName = "Name" });
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            _categoryRepository.AddOrUpdate(category);
            return RedirectToAction("Index");
        }
    }
}