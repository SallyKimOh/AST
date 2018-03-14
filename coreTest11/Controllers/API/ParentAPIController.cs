using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using Microsoft.AspNetCore.Identity;
using coreTest11.Models;

namespace coreTest11.Controllers.API
{
    public class ParentAPIController : Controller
    {

        private readonly SchoolDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public ParentAPIController(SchoolDbContext context, UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        // GET: api/ParentAPI
        [HttpGet]
        public JsonResult Get()
        {
            var resultVal = _context.Parent.ToList();
            return Json(resultVal);
        }

        // GET: api/ParentAPI/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(string id)
        {
            var item = _context.Parent.FirstOrDefault(t => t.UserId == id);
            return Json(item);
        }


        [Route("CreateParent")]
        public JsonResult CreateParent(Parent item)
        {

            //if (item.UserId == null)
            //{
            //    return Json(BadRequest());
            //}
   //         _context.Parent.Add(item);
   //         _context.SaveChanges();

            return Json(new { Succeeded = true, statusCode = 200 });
        }

        // POST: api/ParentAPI
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/ParentAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
