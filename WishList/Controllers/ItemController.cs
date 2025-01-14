﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;
using System.Linq;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Item> items = _context.Items.ToList(); return View("Index", _context.Items.ToList());        }

[HttpGet]
        public IActionResult Create() {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
           var item =  _context.Items.FirstOrDefault(a => a.Id == id);

            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index", "Item");
        }
    }
}
