﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using coreTest11.Models;

namespace coreTest11.Module.API
{
    public class TeacherModule : Controller
    {
        private readonly SchoolDbContext _context;

        public TeacherModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<Teacher> GetList()
        {
            var resultVal = _context.Teacher.ToList();
            return resultVal;
        }

        public Teacher GetTeacherInfo(int id)
        {
            var item = _context.Teacher.FirstOrDefault(t => t.TeacherID == id);
            return item;
        }
    }
}