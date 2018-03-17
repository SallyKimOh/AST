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
    [Route("api/FormTemplateFieldAPI")]
    public class FormTemplateFieldAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormTemplateFieldAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/FormTemplateFieldAPI
        [Route("FormTemplateFieldList")]
        public JsonResult Get()
        {
            FormTemplateFieldModule module = new FormTemplateFieldModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("FormTemplateFieldInfo")]
        public JsonResult GetInfo(int id)
        {
            FormTemplateFieldModule module = new FormTemplateFieldModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }
    }
}