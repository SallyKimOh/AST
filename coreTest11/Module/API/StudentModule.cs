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
    public class StudentModule
    {
        private readonly SchoolDbContext _context;

        public StudentModule(SchoolDbContext context)
        {
            _context = context;

        }
        public List<Student> GetList()
        {
            var resultVal = _context.Student.ToList();
            return resultVal;
        }

        public Student GetInfo(int id)
        {
            var item = _context.Student.FirstOrDefault(t => t.StudentID == id);
            return item;
        }

        public int CreateStudent(Student item)
        {
            _context.Student.Add(item);
            _context.SaveChanges();
            return item.StudentID;

        }


    }
}
