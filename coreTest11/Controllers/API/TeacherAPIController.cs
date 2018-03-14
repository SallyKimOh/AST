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
    [Route("api/TeacherAPI")]
    public class TeacherAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/TeacherAPI
        public JsonResult Get()
        {
            var resultVal = _context.Teacher.ToList();
            return Json(resultVal);
        }

        public JsonResult GetBankAccountInfo(int id)
        {
            var item = _context.Teacher.FirstOrDefault(t => t.TeacherID == id);
            return Json(item);
        }
    }
}