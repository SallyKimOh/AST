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

namespace coreTest11.Controllers
{
    [Produces("application/json")]
    [Route("api/Register")]
    public class RegisterController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public RegisterController(SchoolDbContext context, UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

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
         * 
         * **********************************************************/

        [Route("RegisterByDeskTop")]
        public JsonResult RegisterByDeskTop(Register model)
        {
            UserModule module = new UserModule(_context, _userManager, _signInManager);
            ParentModule parentMod = new ParentModule(_context);
            StudentModule studentMod = new StudentModule(_context);
            StudentParentModule stuParMod = new StudentParentModule(_context);

            var resultVal = module.CreateUserByDeskTop(model.Users);

            if (resultVal.Result.StatusCode == 200)     // success Users table
            {
                model.Parent.UserId = module.GetUserInfo(model.Users).Id;     //select userID
                int parentID = parentMod.CreateParent(model.Parent);                   //save parent info
                int studentID = studentMod.CreateStudent(model.Student);                //save student info

                StudentParent stuParModel = new StudentParent { ParentID = parentID, StudentID = studentID };

                stuParMod.CreateStudentParent(stuParModel);     //save StudentParent info

            }

            return Json(resultVal.Result);
        }

        /***************************************************
         * 
         * 유효한 인증 키 체크 및 정보 가져오기
         * 
         * *************************************************/
        [Route("GetCredentialsInfo")]
        public JsonResult GetCredentialsInfo(int id)
        {
            CredentialsModule module = new CredentialsModule(_context);
            return Json(module.GetInfo(id));
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


        [Route("Test")]
        public void GetTest(Users user)
        {
            UserModule module = new UserModule(_context, _userManager, _signInManager);
            module.GetUpdateUserInfo(user);
        }

        [Route("GetTestList")]
        public JsonResult GetTestList()
        {
            ClassroomModule list = new ClassroomModule(_context);

            var item = list.GetList();
            return Json(item);
        }




    }
}
 