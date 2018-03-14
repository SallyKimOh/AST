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
    public class StudentParentModule : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentParentModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<StudentParent> GetList()
        {
            var resultVal = _context.StudentParent.ToList();
            return resultVal;
        }

        public StudentParent GetInfo(int id)
        {
            var item = _context.StudentParent.FirstOrDefault(t => t.StudentID == id);
            return item;
        }

        public int CreateStudentParent(StudentParent item)
        {
            _context.StudentParent.Add(item);
            _context.SaveChanges();

            return item.StudentParentID;

        }

    }
}