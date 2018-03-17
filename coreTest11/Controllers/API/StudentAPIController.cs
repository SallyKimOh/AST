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
    [Route("api/StudentAPI")]
    public class StudentAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentAPIController(SchoolDbContext context)
        {
            _context = context;

        }
        // GET: api/StudentAPI
        [HttpGet]
        [Route("StudentList")]
        public JsonResult Get()
        {
            StudentModule module = new StudentModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("StudentInfo")]
        public JsonResult GetInfo(int id)
        {
            StudentModule module = new StudentModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }

    }
}
