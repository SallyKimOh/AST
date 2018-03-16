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
    public class StudentClassroomModule
    {
        private readonly SchoolDbContext _context;

        public StudentClassroomModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<StudentClassroom> GetList()
        {
            var resultVal = _context.StudentClassroom.ToList();
            return resultVal;
        }

        public StudentClassroom GetInfo(int id)
        {
            var item = _context.StudentClassroom.FirstOrDefault(t => t.StudentID == id);
            return item;
        }

        public int CreateStuClassroom(StudentClassroom item)
        {
            _context.StudentClassroom.Add(item);
            _context.SaveChanges();

            return item.StudentClassroomID;
        }

    }
}