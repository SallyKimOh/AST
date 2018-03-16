using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using coreTest11.Models;
using coreTest11.Data;

namespace coreTest11.Helper
{
    public class NotificationsHelper
    {
        private readonly UserManager<Users> _userManager;
        private readonly SchoolDbContext _dbContext;

        public NotificationsHelper(UserManager<Users> userManager, SchoolDbContext context)
        {
            _userManager = userManager;
            _dbContext = context;
        }

        public List<Notification> GetUserNotifications(Users user)
        {
            var userNotifications = _dbContext.Notifications
                .Where(n => n.Notifiee.Id == user.Id).
                ToList();

            return userNotifications;
        }

        public void CreateNotification(string type, Users notifier, Users notifiee)
        {
            Notification note = new Notification();
            note.IsRead = 0;
            note.Type = type;
            note.Notifiee = notifiee;
            note.Timestamp = DateTime.Now;
            note.Notifier = notifier;

            switch (type)
            {
                case "FriendRequest":
                    if (notifier.FirstName == null || notifier.FirstName == "")
                        note.Value = "" + notifier.Email + " has sent you a friend request.";
                    else
                        note.Value = "" + notifier.FirstName + " has sent you a friend request.";
                    break;

                case "FriendAccepted":
                    if (notifier.FirstName == null)
                        note.Value = "" + notifier.Email + " has accepted your friend request.";
                    else
                        note.Value = "" + notifier.FirstName + " has accepted your friend request.";

                    break;

                case "ReceiveMessage":
                    if (notifier.FirstName == null)
                        note.Value = "" + notifier.Email + " has sent you a message.";
                    else
                        note.Value = "" + notifier.FirstName + " has sent you a message.";

                    break;

                default:
                    note.Value = "Invalid notification type ";
                    break;
            }

            _dbContext.Add(note);
            _dbContext.SaveChanges();

        }




        protected UserManager<Users> getUserManager()
        {
            return _userManager;
        }

        protected SchoolDbContext getDbContext()
        {
            return _dbContext;
        }
    }
}
