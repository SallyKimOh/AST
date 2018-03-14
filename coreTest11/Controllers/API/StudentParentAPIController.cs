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
    [Route("api/StudentParentAPI")]
    public class StudentParentAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentParentAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/StudentParentAPI
        public JsonResult Get()
        {
            var resultVal = _context.StudentParent.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.StudentParent.FirstOrDefault(t => t.StudentID == id);
            return Json(item);
        }
    }
}