using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Models.AccountViewModels;
using coreTest11.Controllers.API;
using coreTest11.Module.API;
using coreTest11.Data;
using coreTest11.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace coreTest11.Controllers
{
    [Produces("application/json")]
    [Route("api/Register")]
    public class RegisterController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly ILogger _logger;


        public RegisterController(SchoolDbContext context, UserManager<Users> userManager, SignInManager<Users> signInManager, ILoggerFactory loggerFactory)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<RegisterController>();

        }

        //****************************************************************************//
        /**
         * Mobile register first page
         * http://localhost:61682/api/Register/Register?Email=sally2@gmail.com&Password=a1234567A!
         * 
         * ***************************************************************************/

        [Route("Register")]
        public JsonResult Register(RegisterViewModel model)
        {
            UserModule module = new UserModule(_context, _userManager, _signInManager);

            if (module.GetUserInfo(new Users { Email = model.Email }) != null)
            {
                return Json(new { Succeeded = false, statusCode = 100 });
            }

            var resultVal = module.CreateUser(model);

            return Json(resultVal.Result);
        }

        /************************************************************
         * ADD user info
         * ADD Parent info
         * ADD Student info
         * Add StudentParent info
         * Add StudentClassroom info
         * http://localhost:61682/api/Register/RegisterByDeskTop?Users.FirstName=Sally&Users.LastName=Kim&Users.Email=Sally2@gmail.com&Users.PasswordHash=A1234567!a&Student.FirstName=Justin&Student.LastName=Oh&Student.Key=AAA1234567890&Parent.CellPhone=613-222-2222
         * **********************************************************/

        [Route("RegisterByDeskTop")]
        public JsonResult RegisterByDeskTop(Register model)
        {
            UserModule module = new UserModule(_context, _userManager, _signInManager);
            ParentModule parentMod = new ParentModule(_context);
            StudentModule studentMod = new StudentModule(_context);
            StudentParentModule stuParMod = new StudentParentModule(_context);
            StudentClassroomModule stuClassMod = new StudentClassroomModule(_context);

            //=========== checking validation for credencials key ===============//
            var credInfo = GetCredentialsInfo(model.Student.Key);
//           if ( GetCredentialsInfo(model.Student.Key) == null )
           if (credInfo == null )
            {
                return Json(new { Succeeded = false, statusCode = 501 });
            }

            var resultVal = module.CreateUserByDeskTop(model.Users);
            if (resultVal.Result.StatusCode == 200)     // success Users table
            {
                if (module.GetUserInfo(model.Users) != null)
                {
                    if (model.Parent == null)
                    {
                        model.Parent = new Parent();
                    } 
                    model.Parent.UserId = module.GetUserInfo(model.Users).Id;     //select userID
                    int parentID = parentMod.CreateParent(model.Parent);                   //save parent info
                    int studentID = studentMod.CreateStudent(model.Student);                //save student info

                    StudentParent stuParModel = new StudentParent { ParentID = parentID, StudentID = studentID };

                    stuParMod.CreateStudentParent(stuParModel);     //save StudentParent info
                    StudentClassroom stuClassModel = new StudentClassroom { StudentID = studentID, IsActive = true, ClassroomID = credInfo.Teacher.ClassroomID };

                    stuClassMod.CreateStuClassroom(stuClassModel);      //save studentclassroom
//                    var roleresult = _userManager.AddToRoleAsync(model.Users, "Superusers");


                }
            }

            return Json(resultVal.Result);
        }



        /***************************************************
         * 
         * 유효한 인증 키 체크 및 정보 가져오기
         * 
         * *************************************************/
        [Route("GetCredentialsInfo")]
        public Credentials GetCredentialsInfo(string key)
        {
            CredentialsModule module = new CredentialsModule(_context);
            return module.GetInfo(key);
        }


        /***************************************************
         * 
         * Checking Member
         * 
         * **************************************************/

        [Route("CheckMember")]
        public bool CheckMember(RegisterViewModel model)
        {
            UserModule module = new UserModule(_context, _userManager, _signInManager);

            if (module.GetUserInfo(new Users { Email = model.Email }) != null)
            {
                return true;
            }

            return false;
        }


        /************************************************************
         * ADD Parent info
         * 
         * **********************************************************/

        [Route("RegisterParent")]
        public int RegisterParent(Parent model)
        {
            ParentModule parentMod = new ParentModule(_context);

            int parentID = parentMod.CreateParent(model);                   //save parent info

            return parentID;
        }

        /************************************************************
         * ADD Student info
         * 
         * **********************************************************/

        [Route("RegisterStudent")]
        public int RegisterStudent(Student model)
        {
            StudentModule studentMod = new StudentModule(_context);
            int studentID = studentMod.CreateStudent(model);                //save student info
            return studentID;
        }


        /************************************************************
         * Add StudentParent info
         * 
         * **********************************************************/

        [Route("RegisterStudentParent")]
        public int RegisterStudentParent(StudentParent model)
        {
            StudentParentModule stuParMod = new StudentParentModule(_context);
            int studentParentID = stuParMod.CreateStudentParent(model);     //save StudentParent info
            return studentParentID;
        }

        /****************************************************************************
         * 
         * User name update
         * 
         * *************************************************************************/
        [Route("GetUpdateUserInfo")]
        public void GetUpdateUserName(Users user)
        {
            UserModule module = new UserModule(_context, _userManager, _signInManager);
            module.GetUpdateUserInfo(user);
        }


        /***********************************************************************************
         * 
         * Login
         * 
         * *********************************************************************************/
        // GET: /api/Register/Login
        [HttpGet]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<JsonResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return Json(new { Succeeded = true, statusCode = 200 });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    return Json(new { Succeeded = false, statusCode = 502 }); //lock
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Json(new { Succeeded = false, statusCode = 500 });
                }
            }

            // If we got this far, something failed, redisplay form
            return Json(new { Succeeded = false, statusCode = 500 });
        }





        /*       // GET: /api/UserAPI/Login
               [HttpGet]
               [AllowAnonymous]
               public async Task<IActionResult> Login(string returnUrl = null)
               {
                   // Clear the existing external cookie to ensure a clean login process
                   ViewData["ReturnUrl"] = returnUrl;
                   return View();
               }

               //
               // POST: /api/UserAPI/Login
               [HttpPost]
               [AllowAnonymous]
               [ValidateAntiForgeryToken]
               public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
               {
                   ViewData["ReturnUrl"] = returnUrl;
                   if (ModelState.IsValid)
                   {
                       // This doesn't count login failures towards account lockout
                       // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                       var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                       if (result.Succeeded)
                       {
                           _logger.LogInformation(1, "User logged in.");
                           return RedirectToLocal(returnUrl);
                       }
                       if (result.IsLockedOut)
                       {
                           _logger.LogWarning(2, "User account locked out.");
                           return View("Lockout");
                       }
                       else
                       {
                           ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                           return View(model);
                       }
                   }

                   // If we got this far, something failed, redisplay form
                   return View(model);
       //            return View("../../../index");
               }

       */
        [Route("Test")]
        public async Task<JsonResult> GetTestAsync(RegisterViewModel model)
        {
            UserModule module = new UserModule(_context, _userManager, _signInManager);

            var user = new Users { UserName = model.Email, Email = model.Email, IsActive = false };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                _context.SaveChanges();                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
//            var resultVal = module.CreateUserByDeskTop(user);
//            module.GetUpdateUserInfo(user);
            return Json("FADSFA");
        }

        [Route("GetTestList")]
        public JsonResult GetTestList()
        {
            ClassroomModule list = new ClassroomModule(_context);

            var item = list.GetList();
            return Json(item);
        }


        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }


    }
}
 