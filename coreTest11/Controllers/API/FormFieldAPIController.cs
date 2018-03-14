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
    [Route("api/FormFieldAPI")]
    public class FormFieldAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormFieldAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/FormFieldAPI
        public JsonResult Get()
        {
            var resultVal = _context.FormField.ToList();
            return Json(resultVal);
        }
        public JsonResult GetInfo(int id)
        {
            var item = _context.FormField.FirstOrDefault(t => t.FormFieldID == id);
            return Json(item);
        }


    }
}