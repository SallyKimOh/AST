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
    [Route("api/StudentFormAPI")]
    public class StudentFormAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentFormAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/StudentFormAPI
        public JsonResult Get()
        {
            var resultVal = _context.StudentForm.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.StudentForm.FirstOrDefault(t => t.StudentID == id);
            return Json(item);
        }
    }
}