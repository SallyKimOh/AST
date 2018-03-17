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
    public class EngagementModule
    {
        private readonly SchoolDbContext _context;

        public EngagementModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<Engagement> GetList()
        {
            var resultVal = _context.Engagement.ToList();
            return resultVal;
        }

        public Engagement GetInfo(int id)
        {
            var item = _context.Engagement.FirstOrDefault(t => t.EngagementID == id);
            return item;
        }
    }
}