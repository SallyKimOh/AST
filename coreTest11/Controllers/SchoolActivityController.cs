using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using Microsoft.EntityFrameworkCore;
using coreTest11.Models;
using coreTest11.Module.API;

namespace coreTest11.Controllers
{
    [Route("SchoolActivity")]
    public class SchoolActivityController : Controller
    {
        private readonly SchoolDbContext _context;
//        private readonly SchoolActivityModule _actModule;

        public SchoolActivityController(SchoolDbContext context)
        {
            _context = context;
        }
        // GET: SchoolActivity
/*        public async Task<ActionResult> Index()
        {
            return View(await _context.SchoolActivity.ToListAsync());
        }
*/
        public ActionResult Index()
        {
            SchoolActivityModule module = new SchoolActivityModule(_context);
            return View(module.GetList());
        }

        [Route("ActivityListAPI")]
        public JsonResult ActivityListAPI()
        {
            SchoolActivityModule module = new SchoolActivityModule(_context);
            return Json(module.GetList());
        }


        [Route("ApplicationList")]
        public ActionResult ApplicationList()
        {
            ActivityConfirmModule module = new ActivityConfirmModule(_context);
            return View(module.GetApplicationList());
        }

        [Route("ApplicationListAPI")]
        public JsonResult ApplicationListAPI()
        {
            ActivityConfirmModule module = new ActivityConfirmModule(_context);
            return Json(module.GetApplicationList());
        }

        [Route("ActivitySelectType")]
        public ActionResult ActivitySelectType(long id, bool flag)
        {
            var viewModel = new ApplicationRequirement();
               viewModel.ActivityID = id;
            viewModel.ApplicationYN = flag;

            return View("ActivitySelect", viewModel);
        }


        [Route("SaveApplicationTemp")]
        public ActionResult SaveApplicationTemp(ApplicationRequirement model)
        {
            SchoolActivityModule module = new SchoolActivityModule(_context);
            long id = module.CreateRequirement(model);
            
            if (id != 0)
            {
                module.UpdateActivity(model.ActivityID);
            }
            return RedirectToAction("Index");
        }

        // GET: /SchoolActivity/SaveApplicationTempAPI


        [Route("SaveApplicationTempAPI")]
        public long SaveApplicationTempAPI(ApplicationRequirement model)
        {
            SchoolActivityModule module = new SchoolActivityModule(_context);
            long id = module.CreateRequirement(model);

            if (id != 0)
            {
                module.UpdateActivity(model.ActivityID);
            }
            return id;
        }


        [Route("ApplicationForm")]
        public ActionResult ApplicationForm(long id)
        {
            SchoolActivityModule module = new SchoolActivityModule(_context);
            ApplicationRequirement model = module.GetRequirement(id);

            var viewModel = model;

            return View("ApplicationForm", viewModel);
        }

        [Route("ApplicationFormAPI")]
        public JsonResult ApplicationFormAPI(long id)
        {
            SchoolActivityModule module = new SchoolActivityModule(_context);
            ApplicationRequirement model = module.GetRequirement(id);

            return Json(model);
        }

        [Route("CreateApplication")]
        public ActionResult CreateApplication(Application item)
        {
            SchoolActivityModule module = new SchoolActivityModule(_context);
            long id = module.CreateApplication(item);

            ActivityConfirmModule module1 = new ActivityConfirmModule(_context);
            return View(module1.GetApplicationList());
        }

        [Route("CreateApplicationAPI")]
        public JsonResult CreateApplicationAPI(Application item)
        {
            SchoolActivityModule module = new SchoolActivityModule(_context);
            long id = module.CreateApplication(item);
//            item.ActivityConfirm.ApplicationID = id;
 //           int activityConfirmID = module.CreateActivityConfirm(item.ActivityConfirm);
            return Json(id);
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