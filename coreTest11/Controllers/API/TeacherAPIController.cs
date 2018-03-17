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
    [Route("api/TeacherAPI")]
    public class TeacherAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/TeacherAPI
        [Route("TeacherList")]
        public JsonResult Get()
        {
            TeacherModule module = new TeacherModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("TeacherInfo")]
        public JsonResult GetBankAccountInfo(int id)
        {
            TeacherModule module = new TeacherModule(_context);
            var item = module.GetTeacherInfo(id);
            return Json(item);
        }
    }
}