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
    [Route("api/CredentialsAPI")]
    public class CredentialsAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public CredentialsAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        [Route("CredentialsList")]
        // GET: api/CredentialsAPI
        public JsonResult Get()
        {
            CredentialsModule module = new CredentialsModule(_context);
            var resultVal =module.GetList();
            return Json(resultVal);
        }

        [Route("CredentialsInfo")]
        public JsonResult GetInfo(int id)
        {
            CredentialsModule module = new CredentialsModule(_context);
            var item = module.GetInfo(id);
            return Json(item);
        }
    }
}