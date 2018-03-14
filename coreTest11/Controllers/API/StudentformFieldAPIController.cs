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
    [Route("api/StudentformFieldAPI")]
    public class StudentformFieldAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentformFieldAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/StudentformFieldAPI
        public JsonResult Get()
        {
            var resultVal = _context.StudentformField.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.StudentformField.FirstOrDefault(t => t.StudentformFieldID == id);
            return Json(item);
        }
    }
}