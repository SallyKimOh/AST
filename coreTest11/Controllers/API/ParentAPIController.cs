using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using Microsoft.AspNetCore.Identity;
using coreTest11.Models;
using coreTest11.Module.API;

namespace coreTest11.Controllers.API
{
    public class ParentAPIController : Controller
    {

        private readonly SchoolDbContext _context;

        public ParentAPIController(SchoolDbContext context)
        {
            _context = context;

        }

        // GET: api/ParentAPI
        [HttpGet]
        [Route("ParentList")]
        public JsonResult Get()
        {
            ParentModule module = new ParentModule(_context);
            var resultVal = module.GetList();
            return Json(resultVal);
        }

        // GET: api/ParentAPI/5
        [HttpGet("{id}", Name = "Get")]
        [Route("ParentInfo")]
        public JsonResult Get(string id)
        {
            ParentModule module = new ParentModule(_context);
            var item = module.Get(id);
            return Json(item);
        }


        [Route("CreateParent")]
        public JsonResult CreateParent(Parent item)
        {
            ParentModule module = new ParentModule(_context);
            int parentID = module.CreateParent(item);
            return Json(new { Succeeded = true, statusCode = 200, parentID = parentID });
        }

    }
}
