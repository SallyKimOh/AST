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
    [Route("api/FormTemplateAPI")]
    public class FormTemplateAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormTemplateAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/FormTemplateAPI
        public JsonResult Get()
        {
            var resultVal = _context.FormTemplate.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.FormTemplate.FirstOrDefault(t => t.FormTemplateID == id);
            return Json(item);
        }
    }
}