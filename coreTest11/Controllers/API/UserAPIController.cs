using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using coreTest11.Models;
using coreTest11.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace coreTest11.Controllers.API
{
    [Produces("application/json")]
    [Route("api/UserAPI")]
    public class UserAPIController : Controller
    {

        private readonly SchoolDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public UserAPIController(SchoolDbContext context, UserManager<Users> userManager,SignInManager<Users> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public JsonResult GetAll()
        {
            var returnVal = _context.Users.ToList();
            return Json(returnVal);
        }


        [Route("UserList")]
        public JsonResult GetUserList()
        {
            var returnVal = _context.Users.ToList();
            return Json(returnVal);
        }


        /*******************************************************************************************************
          * GET: /api/UserAPI/CreateUser
          * user/{email}/{password}/Register
          * MPX Your account creates.
          * Return result
          * http://localhost:61682/api/UserAPI/CreateUser?email=aaa263@aaa.com&password=T123456%26t
          *******************************************************************************************************/
        [Route("CreateUser")]
        public async Task<JsonResult> CreateUser(RegisterViewModel model)
        {

            var user = new Users { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            
            if (result.Succeeded)
            {
                _context.SaveChanges();                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Json(new { Succeeded = true, statusCode = 200 });
            }
            else
            {
                return Json(result);
            }

        }

        [Route("GetUserInfo")]
        public Users GetUserInfo(Users users)
        {

            var item = _context.Users.FirstOrDefault(t => t.Email == users.Email);
            if (item == null)
            {
                return null;
            }

            return item;

        }

        [Route("GetUserInfoByEmail")]
        public async Task<Users> GetUserInfoAsync(string email, string password)
        {
            if (await GetUserValidationAsync(email, password))
            {
                var item = _context.Users.FirstOrDefault(t => t.Email == email);
                return item;

            } 

            return null;

        }

        public async Task<Boolean> GetUserValidationAsync(string email, string password)
        {

            var result = await _signInManager.PasswordSignInAsync(email, password,false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        [Route("CreateUserTest")]
        public async Task<JsonResult> CreateUserTest(RegisterViewModel model)
        {

                var user = new Users { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _context.SaveChanges();                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Json(new { Succeeded = true, statusCode = 200 });
                }
                else
                {
                    return Json(result);
                }

        }


        //[HttpPost]
        //public IActionResult Create([FromBody] TodoItem item)
        //{
        //    if (item == null)
        //    {
        //        return BadRequest();
        //    }

        //    _context.TodoItems.Add(item);
        //    _context.SaveChanges();

        //    return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(long id, [FromBody] TodoItem item)
        //{
        //    if (item == null || item.Id != id)
        //    {
        //        return BadRequest();
        //    }

        //    var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    todo.IsComplete = item.IsComplete;
        //    todo.Name = item.Name;

        //    _context.TodoItems.Update(todo);
        //    _context.SaveChanges();
        //    return new NoContentResult();
        //}


        //[HttpDelete("{id}")]
        //public IActionResult Delete(long id)
        //{
        //    var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TodoItems.Remove(todo);
        //    _context.SaveChanges();
        //    return new NoContentResult();
        //}
    }




}