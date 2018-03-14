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

namespace coreTest11.Module.API
{
    public class UserModule
    {

        private readonly SchoolDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public UserModule(SchoolDbContext context, UserManager<Users> userManager,SignInManager<Users> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public List<Users> GetList()
        {
            var returnVal = _context.Users.ToList();
            return returnVal;
        }

        public async Task<ReturnMessage> CreateUser(RegisterViewModel model)
        {
            var user = new Users { UserName = model.Email, Email = model.Email, IsActive = false };
            var result = await _userManager.CreateAsync(user, model.Password);

            ReturnMessage item;
            if (result.Succeeded)
            {
                _context.SaveChanges();                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                await _signInManager.SignInAsync(user, isPersistent: false);

                item = new ReturnMessage { Succeeded = true, StatusCode = 200 };
            }
            else
            {
                item = new ReturnMessage { Succeeded = false, StatusCode = 500 };
            }
            return item;

        }
        public async Task<ReturnMessage> CreateUserByDeskTop(Users model)
        {
			
            var user = new Users { UserName = model.Email, Email = model.Email, IsActive = false };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            var result = await _userManager.CreateAsync(user, model.PasswordHash);

            ReturnMessage item;
            if (result.Succeeded)
            {
                _context.SaveChanges();                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                await _signInManager.SignInAsync(user, isPersistent: false);

                item = new ReturnMessage { Succeeded = true, StatusCode = 200 };
            }
            else
            {
                item = new ReturnMessage { Succeeded = false, StatusCode = 500 };
            }
            return item;

        }

        public Users GetUserInfo(Users user)
        {

            var item = _context.Users.FirstOrDefault(t => t.Email == user.Email);
            return item;

        }

        public async Task<Users> GetUserInfoAsync(string email, string password)
        {
            if (await GetUserValidationAsync(email, password))
            {
                var item = _context.Users.FirstOrDefault(t => t.Email == email);
                return item;

            } 

            return null;

        }

		public bool GetUpdateUserInfo(Users item)
        {

            Users user = _context.Users.Where(f => f.Id == item.Id).FirstOrDefault();

            user.FirstName = item.FirstName;
            user.LastName = item.LastName;

            _context.SaveChanges();

            return true;
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