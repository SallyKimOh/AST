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
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using AspNetCore.Http.Extensions;
using Newtonsoft.Json;

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
        private static string url = new ConstantValue().OAuthUrl;


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
/*
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
*/
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
                    Users user = new Users { UserName = model.Users.Email, PasswordHash = model.Users.PasswordHash };

                    string oauthResult = CreateOAuthUser(user);  // need validation check. if result is success return success value else delete MPXUser data and return error.

                    if (model.Parent == null)
                    {
                        model.Parent = new Parent();
                    } 
                    model.Parent.UserId = module.GetUserInfo(model.Users).Id;     //select userID
                    int parentID = parentMod.CreateParent(model.Parent);                   //save parent info
                    model.Student.ParentID = parentID;
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



        /*******************************************************************************************************
          * GET: /api/Register/CreateUser
          * user/{email}/{password}/Register
          * MPX Your account creates.
          * Return result
          * http://localhost:61682/api/Register/CreateUser?email=aaa263@aaa.com&password=T123456%26t
          *******************************************************************************************************/
        [Route("CreateUser")]
        public async Task<string> CreateUser(RegisterViewModel model)
        {

            UserModule module = new UserModule(_context, _userManager, _signInManager);

            if (module.GetUserInfo(new Users { Email = model.Email }) == null)
            {
                var result = await module.CreateUser(model);

                Users user = new Users { Email = model.Email };
                module.GetUserInfo(user);     //select userID

                user.UserName = model.Email;
                user.PasswordHash = model.Password;

                string oauthResult = CreateOAuthUser(user);  // need validation check. if result is success return success value else delete MPXUser data and return error.
                return module.GetUserInfo(user).Id;

            }

            return null;


        }

        /************************************************************
         * ADD Parent info
         * 
         * **********************************************************/
        //api/Register/RegisterParent?userid=fadsfad
/*
        [Route("RegisterParent")]
        public int RegisterParent(Parent model)
        {
            ParentModule parentMod = new ParentModule(_context);

            int parentID = parentMod.CreateParent(model);                   //save parent info
            
            return parentID;
        }
*/
        /************************************************************
         * ADD Parent info
         *  //api/Register/RegisterParent?userid=fadsfad
         * Users user = new Users{Id = id, FirstName = firstName, LastName=lastname}
         * 
         * **********************************************************/
 
        [Route("RegisterParent")]
        public int RegisterParent(string userid, string firstname, string lastname)
        {
            ParentModule parentMod = new ParentModule(_context);

            Parent parentItem = new Parent { UserId = userid };

            int parentID = parentMod.CreateParent(parentItem);                   //save parent info

            Users user = new Users { Id = userid, FirstName = firstname, LastName = lastname };
            UserModule module = new UserModule(_context, _userManager, _signInManager);
            module.GetUpdateUserInfo(user);

            return parentID;
        }


        /****************************************************************************
         * 
         * User name update
         * 
         * 
         * Users user = new Users{Id = id, FirstName = firstName, LastName=lastname}
         * 
         * *************************************************************************/
 /*       [Route("GetUpdateUserInfo")]
        public void GetUpdateUserName(Users user)
        {
            UserModule module = new UserModule(_context, _userManager, _signInManager);
            module.GetUpdateUserInfo(user);
        }
*/

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



        /************************************************************
         * ADD Student info
         * Firstname,lastname,parentid
          * http://localhost:61682/api/Register/RegisterStudent?FirstName=son&LastName=Oh&parentID=1&key=AAA1234567890
         * **********************************************************/
/*
        [Route("RegisterStudent")]
        public int RegisterStudent(Student model)
        {
            StudentModule studentMod = new StudentModule(_context);
            int studentID = studentMod.CreateStudent(model);                //save student info
            return studentID;
        }
*/

        /************************************************************
         * Add StudentParent info
         * 
         * **********************************************************/
/*
        [Route("RegisterStudentParent")]
        public int RegisterStudentParent(StudentParent model)
        {
            StudentParentModule stuParMod = new StudentParentModule(_context);
            int studentParentID = stuParMod.CreateStudentParent(model);     //save StudentParent info
            return studentParentID;
        }
*/
        /************************************************************
         * Add StudentClassroom
         * 
         * **********************************************************/
         /*
        [Route("RegisterStudentClass")]
        public int RegisterStudentClass(StudentClassroom model)
        {
            StudentClassroomModule stuClassMod = new StudentClassroomModule(_context);
            model.IsActive = true;
            int studentClassroomID = stuClassMod.CreateStuClassroom(model);      //save studentclassroom
           
            return studentClassroomID;
        }
        */
        /************************************************************
          * Add Child
          * http://localhost:61682/api/Register/RegisterStudent?FirstName=son&LastName=Oh&parentID=1
          * http://localhost:61682/api/Register/RegisterStudentClass?classroom=1&studentID=3
          * 
          * Student stu = new Student();
          * stu.FirstName = "ADFASF";
          * stu.LastName = "ADSFA";
          * stu.parentID=1;
          * stu.StudentClassroom.classroomID = 1
          * stu.StudentClassroom.StudentID = 2;
          * http://localhost:61682/api/Register/AddChild?FirstName=son&LastName=Oh&parentID=1&key=AAA1234567890&StudentClassroom.classroomID=1
          * **********************************************************/

        [Route("AddChild")]
        public int AddChild(Student model)
        {
            StudentModule studentMod = new StudentModule(_context);
            int studentID = studentMod.CreateStudent(model);                //save student info

            StudentClassroomModule stuClassMod = new StudentClassroomModule(_context);
            model.StudentClassroom.StudentID = studentID;
            model.StudentClassroom.IsActive = true;
            
            int classroomID = stuClassMod.CreateStuClassroom(model.StudentClassroom);      //save studentclassroom

            return classroomID;
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


        // After login returns user info
        [Route("Login2")]
        public async Task<JsonResult> Login2(LoginViewModel model)
        {
            ParentModule module = new ParentModule(_context);
 
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");

                    IQueryable<Users> item = module.GetParentInfo(model.Email);
                    return Json(item);
                }
            }

            // If we got this far, something failed, redisplay form
            return Json("error");
        }

        /***********************************************************************************
         * 
         * App Login
         * http://localhost:61682/api/Register/AppLogin?Email=sally@gmail.com&Password=A1234567!a
         * *********************************************************************************/
        // GET: /api/Register/AppLogin
        [Route("AppLogin")]
        public async Task<IActionResult> AppLogin(LoginViewModel model)
        {
            ParentModule module = new ParentModule(_context);

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");

                    UserModule module1 = new UserModule(_context, _userManager, _signInManager);
                    Users user = new Users { Email = model.Email };
                    string userid = module1.GetUserInfo(user).Id;     //select userID
                    if( userid.Length == 0)
                    {
                        return NotFound();
                    }
                    List<Parent> item = module.GetParentInfo2(userid);

                    var resultToken = GetToken(model);
                    
                    return CreatedAtAction("Get", new {Successed=true,statusCode=200,tokenResult=resultToken,item});
                    //return Json(item);
                }
            }

            // If we got this far, something failed, redisplay form
            return BadRequest();
        }

/*
        [Route("ChildList")]
        public JsonResult ChildList(string userid)
        {
            var child = _context.Parent
                .Include(m => m.Students)
                .Where(m => m.UserId == userid )
                .ToList();

            return Json(child);
        }
*/

        /*******************************************************************************************************
          * GET: /api/Register/CreatOAuthUser
          * user/{email}/{password}
          * Call OAuth Server
          * OAuth Your account creates.
          * Return result
          * 
          *******************************************************************************************************/

        [Route("CreateOAuthUser")]
        public string CreateOAuthUser(Users info)
        {
            var registerResult = Register(info.UserName, info.PasswordHash);

            return registerResult;
        }


        static String Register(String email, String password)
        {
            var registerModel = new
            {
                Email = email,
                Password = password,
                ConfirmPassword = password
            };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(
                    url + "api/Account/Register",
                    registerModel).Result;
                return response.StatusCode.ToString();

            }
        }

        /*******************************************************************************************************
         * 
          * GET: /api/Register/GetToken
         * 
         * 
         * Return Token Information
         * http://localhost:61682/api/Register/GetTokenAPI?email=a2@a.com&password=T123456%26t
         *
         *******************************************************************************************************/

        [Route("GetTokenAPI")]
        public async Task<JsonResult> GetTokenAPI(RegisterViewModel model)
        {

//            var user = await GetUserInfo(model.Email);

//            if (user == null)
//            {
//                return Json(new { Succeeded = false, result = "The User is not exist." });
//            }


            Dictionary<string, string> token = GetTokenDictionary(model.Email, model.Password);

            if (token.Keys.Count == 2)
            {
                var registerResult = Register(model.Email, model.Password);
                token = GetTokenDictionary(model.Email, model.Password);
            }


            AdmTokenModels p = new AdmTokenModels();

            foreach (var kvp in token)
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                p.access_token = token["access_token"];
                p.expires_in = token["expires_in"];
                p.userName = token["userName"];
                p.issued = token[".issued"];
                p.expires = token[".expires"];
            }


            return Json(new { Succeeded = true, result = p });
            //            return Json(new { Succeeded = true, result = token["error"] });
        }

        public JsonResult GetToken(LoginViewModel model)
        {

            //            var user = await GetUserInfo(model.Email);

            //            if (user == null)
            //            {
            //                return Json(new { Succeeded = false, result = "The User is not exist." });
            //            }


            Dictionary<string, string> token = GetTokenDictionary(model.Email, model.Password);

            if (token.Keys.Count == 2)
            {
                var registerResult = Register(model.Email, model.Password);
                token = GetTokenDictionary(model.Email, model.Password);
            }


            AdmTokenModels p = new AdmTokenModels();

            foreach (var kvp in token)
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                p.access_token = token["access_token"];
                p.expires_in = token["expires_in"];
                p.userName = token["userName"];
                p.issued = token[".issued"];
                p.expires = token[".expires"];
            }


            return Json(new { Succeeded = true, result = p });
            //            return Json(new { Succeeded = true, result = token["error"] });
        }



        /***********************************************************************************
         * 
         * InitPasswordReset
         * 
         * *********************************************************************************/
        //POST: /api/Register/InitPasswordReset
        [Route("InitPasswordReset")]
        public async Task<JsonResult> InitPasswordReset(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            string url = System.Web.HttpUtility.UrlDecode(model.Code);
            var result = await _userManager.ResetPasswordAsync(user, url, model.Password);
 //           var result = await _userManager.ResetPasswordAsync(user, "", model.Password);
//            if (result.Succeeded)
//            {
//                return Json(new { Succeeded = true, statusCode = 200 });
//            }
            return Json(result);
//            return Json(new { Succeeded = false, statusCode = 503 });
        }



        [Route("LoginTest")]
        public async Task<JsonResult> LoginTest(LoginViewModel model)
        {
            ParentModule module = new ParentModule(_context);
//            Users item = new Users();

            IQueryable<Users> item = module.GetParentInfo(model.Email);
            // If we got this far, something failed, redisplay form
            return Json(item);
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


        static Dictionary<string, string> GetTokenDictionary(String userName, String password)
        {
            var pairs = new List<KeyValuePair<String, String>>
            {
                new KeyValuePair<string, string>("grant_type","password"),
                new KeyValuePair<string, string>("username",userName),
                new KeyValuePair<string, string>("Password",password)

            };

            var content = new FormUrlEncodedContent(pairs);
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url+"Token", content).Result;

                var result = response.Content.ReadAsStringAsync().Result;

                Dictionary<string, string> tokenDictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                return tokenDictionary;

            }

        }


    }
}
 