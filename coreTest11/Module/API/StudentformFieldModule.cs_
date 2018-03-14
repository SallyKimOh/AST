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
    public class StudentformFieldModule
    {
        private readonly SchoolDbContext _context;

        public StudentformFieldModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<StudentformField> GetList()
        {
            var resultVal = _context.StudentformField.ToList();
            return resultVal;
        }

        public StudentformField GetInfo(int id)
        {
            var item = _context.StudentformField.FirstOrDefault(t => t.StudentformFieldID == id);
            return item;
        }
    }
}