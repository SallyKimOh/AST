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
    [Route("api/BankAccountAPI")]
    public class BankAccountAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public BankAccountAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/BankAccountAPI
        [Route("GetBankAccountList")]
        public JsonResult Get()
        {
            BankAccountModule module = new BankAccountModule(_context);

            var resultVal = module.GetList();
            return Json(resultVal);
        }

        [Route("GetBankAccountInfo")]
        public JsonResult GetBankAccountInfo(string id)
        {
            BankAccountModule module = new BankAccountModule(_context);
            var item = module.GetBankAccountInfo(id);
            return Json(item);
        }


    }
}