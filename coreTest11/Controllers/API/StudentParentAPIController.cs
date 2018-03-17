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
    [Route("api/StudentParentAPI")]
    public class StudentParentAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentParentAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/StudentParentAPI
        [Route("StudentParentList")]
        public JsonResult Get()
        {
            StudentParentModule module = new StudentParentModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("StudentParentInfo")]
        public JsonResult GetInfo(int id)
        {
            StudentParentModule module = new StudentParentModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }
    }
}