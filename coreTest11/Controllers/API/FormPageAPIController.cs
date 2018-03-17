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
    [Route("api/FormPageAPI")]
    public class FormPageAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormPageAPIController(SchoolDbContext context)
        {
            _context = context;

        }


        [Route("FormPageList")]
        // GET: api/FormPageAPI
        public JsonResult Get()
        {
            FormPageModule module = new FormPageModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("FormPageInfo")]
        public JsonResult GetInfo(int id)
        {
            FormPageModule module = new FormPageModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }
    }
}