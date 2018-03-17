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
    [Route("api/FormFieldTypeAPI")]
    public class FormFieldTypeAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormFieldTypeAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        [Route("FormFieldTypeList")]
        // GET: api/FormFieldTypeAPI
        public JsonResult Get()
        {
            FormFieldTypeModule module = new FormFieldTypeModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("FormFieldTypeInfo")]
        public JsonResult GetInfo(int id)
        {
            FormFieldTypeModule module = new FormFieldTypeModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }
    }
}