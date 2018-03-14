using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;

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
        public JsonResult Get()
        {
            var resultVal = _context.Student.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.Student.FirstOrDefault(t => t.StudentID == id);
            return Json(item);
        }

    }
}
