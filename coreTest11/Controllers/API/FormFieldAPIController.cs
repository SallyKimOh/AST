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
    [Route("api/FormFieldAPI")]
    public class FormFieldAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormFieldAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        [Route("FormFieldList")]
        // GET: api/FormFieldAPI
        public JsonResult Get()
        {
            FormFieldModule module = new FormFieldModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }
        [Route("FormFieldInfo")]
        public JsonResult GetInfo(int id)
        {
            FormFieldModule module = new FormFieldModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }


    }
}