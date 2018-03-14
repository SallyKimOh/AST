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
    [Route("api/FormTemplateFieldAPI")]
    public class FormTemplateFieldAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormTemplateFieldAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/FormTemplateFieldAPI
        public JsonResult Get()
        {
            var resultVal = _context.FormTemplateField.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.FormTemplateField.FirstOrDefault(t => t.FormTemplateFieldID == id);
            return Json(item);
        }
    }
}