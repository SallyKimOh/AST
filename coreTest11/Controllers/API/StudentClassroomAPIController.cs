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
    [Route("api/StudentClassroomAPI")]
    public class StudentClassroomAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentClassroomAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/StudentClassroomAPI
        public JsonResult Get()
        {
            var resultVal = _context.StudentClassroom.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.StudentClassroom.FirstOrDefault(t => t.StudentID == id);
            return Json(item);
        }
    }
}