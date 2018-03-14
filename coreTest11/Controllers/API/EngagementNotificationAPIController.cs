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
    [Route("api/EngagementNotificationAPI")]
    public class EngagementNotificationAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public EngagementNotificationAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/EngagementNotificationAPI
        public JsonResult Get()
        {
            var resultVal = _context.EngagementNotification.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.EngagementNotification.FirstOrDefault(t => t.EngagementNotificationID == id);
            return Json(item);
        }
    }
}