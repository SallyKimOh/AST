using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using coreTest11.Models;

namespace coreTest11.Module.API
{
    public class EngagementNotificationModule
    {
        private readonly SchoolDbContext _context;

        public EngagementNotificationModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<EngagementNotification> GetList()
        {
            var resultVal = _context.EngagementNotification.ToList();
            return resultVal;
        }

        public EngagementNotification GetInfo(int id)
        {
            var item = _context.EngagementNotification.FirstOrDefault(t => t.EngagementNotificationID == id);
            return item;
        }
    }
}