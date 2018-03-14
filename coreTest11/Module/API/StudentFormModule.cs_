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
    public class StudentFormModule
    {
        private readonly SchoolDbContext _context;

        public StudentFormModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<StudentForm> GetList()
        {
            var resultVal = _context.StudentForm.ToList();
            return resultVal;
        }

        public StudentForm GetInfo(int id)
        {
            var item = _context.StudentForm.FirstOrDefault(t => t.StudentID == id);
            return item;
        }
    }
}