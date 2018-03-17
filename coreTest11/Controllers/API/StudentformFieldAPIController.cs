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
    [Route("api/StudentformFieldAPI")]
    public class StudentformFieldAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentformFieldAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/StudentformFieldAPI
        [Route("StudentformFieldList")]
        public JsonResult Get()
        {
            StudentformFieldModule module = new StudentformFieldModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("StudentformFieldInfo")]
        public JsonResult GetInfo(int id)
        {
            StudentformFieldModule module = new StudentformFieldModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }
    }
}