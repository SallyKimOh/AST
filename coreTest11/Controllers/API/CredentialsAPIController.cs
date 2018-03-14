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
    [Route("api/CredentialsAPI")]
    public class CredentialsAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public CredentialsAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/CredentialsAPI
        public JsonResult Get()
        {
            var resultVal = _context.Credentials.ToList();
            return Json(resultVal);
        }

        public JsonResult GetInfo(int id)
        {
            var item = _context.Credentials.FirstOrDefault(t => t.CredentialsID == id);
            return Json(item);
        }
    }
}