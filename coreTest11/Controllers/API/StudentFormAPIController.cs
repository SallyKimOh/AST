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
    [Route("api/StudentFormAPI")]
    public class StudentFormAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentFormAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/StudentFormAPI
        [Route("StudentFormList")]
        public JsonResult Get()
        {
            StudentFormModule module = new StudentFormModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("StudentFormInfo")]
        public JsonResult GetInfo(int id)
        {
            StudentFormModule module = new StudentFormModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }
    }
}