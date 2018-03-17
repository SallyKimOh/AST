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
    [Route("api/EngagementAPI")]
    public class EngagementAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public EngagementAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        [Route("EngagementList")]
        // GET: api/EngagementAPI
        public JsonResult Get()
        {
            EngagementModule module = new EngagementModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("EngagementInfo")]
        public JsonResult GetInfo(int id)
        {
            EngagementModule module = new EngagementModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }
    }
}