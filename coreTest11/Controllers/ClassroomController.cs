using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using Microsoft.EntityFrameworkCore;

namespace coreTest11.Controllers
{
    [Route("Classroom")]
    public class ClassroomController : Controller
    {
        private readonly SchoolDbContext _context;

        public ClassroomController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: Classroom
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classroom.ToListAsync());
//            return View();
        }
/*
        // GET: Classroom/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Classroom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classroom/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Classroom/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Classroom/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Classroom/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Classroom/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}