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
    public class ClassroomModule
    {
        private readonly SchoolDbContext _context;

        public ClassroomModule()
        {
        }

        public ClassroomModule(SchoolDbContext context)
        {
            _context = context;
        }

        public List<Classroom> GetList()
        {
            var resultVal = _context.Classroom.ToList();
            return resultVal;
        }

        public Classroom GetInfo(int id)
        {
 //           return new Classroom();
            var item = _context.Classroom.FirstOrDefault(t => t.ClassroomID == id);
            return item;
        }

    }
}