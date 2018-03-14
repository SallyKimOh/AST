using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;

namespace coreTest11.API.Controllers
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
        public JsonResult Get()
        {
            var resultVal = _context.BankAccount.ToList();
            return Json(resultVal);
        }

        public JsonResult GetBankAccountInfo(string id)
        {
            var item = _context.BankAccount.FirstOrDefault(t => t.UserId == id);
            return Json(item);
        }


    }
}