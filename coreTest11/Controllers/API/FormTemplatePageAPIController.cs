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
    [Route("api/FormTemplatePageAPI")]
    public class FormTemplatePageAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormTemplatePageAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/FormTemplatePageAPI
        public JsonResult Get()
        {
            var resultVal = _context.FormTemplatePage.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.FormTemplatePage.FirstOrDefault(t => t.FormTemplatePageID == id);
            return Json(item);
        }
    }
}