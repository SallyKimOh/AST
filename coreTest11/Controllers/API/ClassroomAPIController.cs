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
    [Route("api/ClassroomAPI")]
    public class ClassroomAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public ClassroomAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        [Route("ClassroomList")]
        // GET: api/ClassroomAPI
        public JsonResult Get()
        {
            ClassroomModule module = new ClassroomModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("ClassroomInfo")]
        public JsonResult GetInfo(int id)
        {
            ClassroomModule module = new ClassroomModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }

    }
}