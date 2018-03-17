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
    [Route("api/EngagementNotificationAPI")]
    public class EngagementNotificationAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public EngagementNotificationAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        [Route("EngagementNotificationList")]
        // GET: api/EngagementNotificationAPI
        public JsonResult Get()
        {
            EngagementNotificationModule module = new EngagementNotificationModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("EngagementNotificationInfo")]
        public JsonResult GetInfo(int id)
        {
            EngagementNotificationModule module = new EngagementNotificationModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }
    }
}