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
    [Route("api/FormTemplatePageAPI")]
    public class FormTemplatePageAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormTemplatePageAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/FormTemplatePageAPI
        [Route("FormTemplatePageList")]
        public JsonResult Get()
        {
            FormTemplatePageModule module = new FormTemplatePageModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("FormTemplatePageInfo")]
        public JsonResult GetInfo(int id)
        {
            FormTemplatePageModule module = new FormTemplatePageModule(_context);
            var item =module.GetInfo(id);
            return Json(item);
        }
    }
}