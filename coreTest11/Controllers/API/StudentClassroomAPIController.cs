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
    [Route("api/StudentClassroomAPI")]
    public class StudentClassroomAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentClassroomAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/StudentClassroomAPI
        [Route("StudentClassroomList")]
        public JsonResult Get()
        {
            StudentClassroomModule module = new StudentClassroomModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("StudentClassroomInfo")]
        public JsonResult GetInfo(int id)
        {
            StudentClassroomModule module = new StudentClassroomModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }
    }
}