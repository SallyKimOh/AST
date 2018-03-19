using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using Microsoft.AspNetCore.Identity;
using coreTest11.Models;
using Microsoft.EntityFrameworkCore;

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

        public IQueryable<Users> GetParentInfo(string email)
        {
            var item =(
            from a in _context.Parent
            join b in _context.Users.Where(x => x.Email.Equals(email))
            on a.UserId equals b.Id
            join c in _context.StudentParent
            on a.ParentID equals c.ParentID
            select new Users()
            {
                Id = b.Id,
                UserName = b.UserName,
                ParentID = a.ParentID,
                StudentID = c.StudentID
            });

            return item;

        }


    }
}
