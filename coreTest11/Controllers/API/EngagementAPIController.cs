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
    [Route("api/EngagementAPI")]
    public class EngagementAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public EngagementAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/EngagementAPI
        public JsonResult Get()
        {
            var resultVal = _context.Engagement.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.Engagement.FirstOrDefault(t => t.EngagementID == id);
            return Json(item);
        }
    }
}