using AspNetShop.ViewModels;
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
    public class GoodsController : Controller
    {
        private readonly ShopContext _context = new ShopContext();
        private readonly IRepository<Good> _goodRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Manufacturer> _manufacturerRepo;
        public GoodsController(IRepository<Good> goodRepo, IRepository<Category> categoryRepo, IRepository<Manufacturer> manufacturerRepo)
        {
            _goodRepo = goodRepo;
            _categoryRepo = categoryRepo;
            _manufacturerRepo = manufacturerRepo;
        }
        public ActionResult Index()
        {
            return View(_goodRepo.GetAll());
        }
        public ActionResult Edit(int id)
        {
            var good = _goodRepo.Get(id);
            var gvm = new GoodViewModel
            {
                Categories = new SelectList(_categoryRepo.GetAll(), "CategoryId", "CategoryName"),
                CategoryId = good.CategoryId,
                GoodCount = good.GoodCount,
                GoodId = good.GoodId,
                GoodName = good.GoodName,
                ManufacturerId = good.ManufacturerId,
                Manufacturers = new SelectList(_manufacturerRepo.GetAll(), "ManufacturerId", "ManufacturerName"),
                Price = good.Price
            };
            return View(gvm);
        }

        [HttpPost]
        public ActionResult Edit(GoodViewModel gvm)
        {
            _goodRepo.AddOrUpdate(new DAL.Models.Good
            {
                GoodId = gvm.GoodId,
                CategoryId = gvm.CategoryId,
                GoodCount = gvm.GoodCount,
                GoodName = gvm.GoodName,
                ManufacturerId = gvm.ManufacturerId,
                Price = gvm.Price
            });

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_goodRepo.Get(id));
        }

        public ActionResult Delete(int id)
        {
            _goodRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View(new GoodViewModel {
                Categories = new SelectList(_categoryRepo.GetAll(), "CategoryId", "CategoryName"),
                CategoryId = 1,
                GoodCount = 1,
                GoodName = "Good",
                ManufacturerId = 1,
                Manufacturers = new SelectList(_manufacturerRepo.GetAll(), "ManufacturerId", "ManufacturerName"),
                Price = 0
            });
        }

        [HttpPost]
        public ActionResult Create(GoodViewModel gvm)
        {
            _goodRepo.AddOrUpdate(new DAL.Models.Good
            {
                GoodId = gvm.GoodId,
                CategoryId = gvm.CategoryId,
                GoodCount = gvm.GoodCount,
                GoodName = gvm.GoodName,
                ManufacturerId = gvm.ManufacturerId,
                Price = gvm.Price
            });

            return RedirectToAction("Index");
        }
    }
}