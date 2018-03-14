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
    [Route("api/FormPageAPI")]
    public class FormPageAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public FormPageAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/FormPageAPI
        public JsonResult Get()
        {
            var resultVal = _context.FormPage.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.FormPage.FirstOrDefault(t => t.FormPageID == id);
            return Json(item);
        }
    }
}