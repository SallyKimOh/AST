using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using Microsoft.EntityFrameworkCore;
using coreTest11.Models;

namespace coreTest11.Controllers
{
    [Route("SchoolActivity")]
    public class SchoolActivityController : Controller
    {
        private readonly SchoolDbContext _context;
        public SchoolActivityController(SchoolDbContext context)
        {
            _context = context;
        }
        // GET: SchoolActivity
        public async Task<ActionResult> Index()
        {
            return View(await _context.SchoolActivity.ToListAsync());
        }

        [Route("ActivitySelectType")]
        public ActionResult ActivitySelectType()
        {
            var viewModel = new ApplicationRequirement();

            return View("ActivitySelect", viewModel);
        }

        /*
                // GET: SchoolActivity/Details/5
                public ActionResult Details(int id)
                {
                    return View();
                }

                // GET: SchoolActivity/Create
                public ActionResult Create()
                {
                    return View();
                }

                // POST: SchoolActivity/Create
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

                // GET: SchoolActivity/Edit/5
                public ActionResult Edit(int id)
                {
                    return View();
                }

                // POST: SchoolActivity/Edit/5
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

                // GET: SchoolActivity/Delete/5
                public ActionResult Delete(int id)
                {
                    return View();
                }

                // POST: SchoolActivity/Delete/5
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