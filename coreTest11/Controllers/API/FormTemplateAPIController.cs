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
    [Route("api/FormTemplateAPI")]
    public class FormTemplateAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormTemplateAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/FormTemplateAPI
        [Route("FormTemplateList")]
        public JsonResult Get()
        {
            FormTemplateModule module = new FormTemplateModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("FormTemplateInfo")]
        public JsonResult GetInfo(int id)
        {
            FormTemplateModule module = new FormTemplateModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }
    }
}