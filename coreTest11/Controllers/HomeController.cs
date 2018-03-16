using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Models;
using Microsoft.AspNetCore.Identity;
using coreTest11.Data;

namespace coreTest11.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly SchoolDbContext _context;

        public HomeController(UserManager<Users> userManager, SchoolDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Login()
        {
            ViewData["Message"] = "Your contact page.";

//            return View();
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /*
                [HttpPost]
                public async Task<IActionResult> ShowNotifications()
                {
                    Users user = await _userManager.GetUserAsync(HttpContext.User);
                    var viewmodel = new NotificationListViewModel();


                    return PartialView("_Notifications", GetUserFriendsAndRequests(user));
                }
        */
        /**************************************************************
         * Name: Notifications
         * Description: Given the currently logged in user load the
         *              requests for that user
         * ***********************************************************/
/*        public async Task<IActionResult> Notifications()
        {
            Users user = await _userManager.GetUserAsync(HttpContext.User);
            return View(GetUserFriendsAndRequests(user));
        }
*/

        /**************************************************************
         * Name: ViewMessage
         * Description: A temporary spot for viewing messages
         * ***********************************************************/
        public IActionResult ViewMessage()
        {
            return View();
        }

        /**************************************************************
         * Name: ComposeMessage
         * Description: A temporary spot for sendiing messages
         * ***********************************************************/
        public async Task<IActionResult> ComposeMessage(string Id)
        {

            Users currentUser = await _userManager.GetUserAsync(HttpContext.User);
            string userId = Id;
            Users user = _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            return View("ComposeMessage", user);
        }


        /**************************************************************
         * Name: GetCurrentUserAsync
         * Description: Returns the  currently active user
         * ***********************************************************/
        private Task<Users> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }




    }
}
