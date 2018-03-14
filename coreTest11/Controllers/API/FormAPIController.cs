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
    [Route("api/FormAPI")]
    public class FormAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/FormAPI
        public JsonResult Get()
        {
            var resultVal = _context.Form.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.Form.FirstOrDefault(t => t.FormID == id);
            return Json(item);
        }
    }
}