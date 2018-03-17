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
using coreTest11.Module.API;

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


        [Route("UserList")]
        public JsonResult GetUserList()
        {
            UserModule module = new UserModule(_context,_userManager, _signInManager);
            var returnVal = module.GetList();
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

            UserModule module = new UserModule(_context, _userManager, _signInManager);
            var result = await module.CreateUser(model);
            return Json(result);

        }

        [Route("GetUserInfo")]
        public Users GetUserInfo(Users users)
        {

            UserModule module = new UserModule(_context, _userManager, _signInManager);
            var item = module.GetUserInfo(users);
            if (item == null)
            {
                return null;
            }

            return item;

        }

        [Route("GetUserInfoByEmail")]
        public async Task<Users> GetUserInfoAsync(string email, string password)
        {
            UserModule module = new UserModule(_context, _userManager, _signInManager);

            var flag = await module.GetUserValidationAsync(email, password);

            Users user = new Users { Email = email };
            if (flag)
            {
                var item = module.GetUserInfo(user);
                return item;

            } 

            return null;

        }

        
        [Route("UserValidationCheck")]
        public async Task<Boolean> GetUserValidationAsync(string email, string password)
        {
            UserModule module = new UserModule(_context, _userManager, _signInManager);

            var result = await module.GetUserValidationAsync(email, password);
            return result;

        }



    }




}