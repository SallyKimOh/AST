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
    [Route("api/ClassroomAPI")]
    public class ClassroomAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public ClassroomAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/ClassroomAPI
        public JsonResult Get()
        {
            var resultVal = _context.Classroom.ToList();
            return Json(resultVal);
        }

        [Route("ClassroomInfo")]
        public JsonResult GetInfo(int id)
        {
            var item = _context.Classroom.FirstOrDefault(t => t.ClassroomID == id);
            return Json(item);
        }

    }
}