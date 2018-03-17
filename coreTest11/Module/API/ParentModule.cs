using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using Microsoft.AspNetCore.Identity;
using coreTest11.Models;

namespace coreTest11.Module.API
{
    public class ParentModule
    {

        private readonly SchoolDbContext _context;

        public ParentModule(SchoolDbContext context)
        {
            _context = context;
        }

        public List<Parent> GetList()
        {
            var resultVal = _context.Parent.ToList();
            return resultVal;
        }

        public Parent Get(string id)
        {
            var item = _context.Parent.FirstOrDefault(t => t.UserId == id);
            return item;
        }


        public int CreateParent(Parent item)
        {
            _context.Parent.Add(item);
            _context.SaveChanges();

            return item.ParentID;
        }

 
    }
}
