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
    public class FormModule
    {
        private readonly SchoolDbContext _context;

        public FormModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<Form> GetList()
        {
            var resultVal = _context.Form.ToList();
            return resultVal;
        }

        public Form GetInfo(int id)
        {
            var item = _context.Form.FirstOrDefault(t => t.FormID == id);
            return item;
        }
    }
}