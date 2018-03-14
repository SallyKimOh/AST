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
    [Route("api/FormFieldTypeAPI")]
    public class FormFieldTypeAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormFieldTypeAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/FormFieldTypeAPI
        public JsonResult Get()
        {
            var resultVal = _context.FormFieldType.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.FormFieldType.FirstOrDefault(t => t.FormFieldTypeID == id);
            return Json(item);
        }
    }
}