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
    public class ManufacturersController : Controller
    {
        private readonly ShopContext _context = new ShopContext();
        private readonly IRepository<Manufacturer> _repo;
        public ManufacturersController(IRepository<Manufacturer> manufacturerRepo)
        {
            _repo = manufacturerRepo;
        }
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(_repo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Manufacturer manufacturer)
        {
            _repo.AddOrUpdate(manufacturer);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_repo.Get(id));
        }

        public ActionResult Create()
        {
            return View(new Manufacturer { ManufacturerName = "Name" });
        }

        [HttpPost]
        public ActionResult Create(Manufacturer manufacturer)
        {
            _repo.AddOrUpdate(manufacturer);
            return RedirectToAction("Index");
        }

    }
}