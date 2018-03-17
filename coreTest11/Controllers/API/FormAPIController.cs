using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using coreTest11.Module.API;

namespace coreTest11.Controllers.API
{
    [Produces("application/json")]
    [Route("api/FormAPI")]
    public class FormAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/FormAPI
        public JsonResult Get()
        {
            FormModule module = new FormModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            FormModule module = new FormModule(_context);
            var item =module.GetInfo(id);
            return Json(item);
        }
    }
}