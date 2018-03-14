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
    public class FormFieldModule
    {
        private readonly SchoolDbContext _context;

        public FormFieldModule(SchoolDbContext context)
        {
            _context = context;
        }

        public List<FormField> GetList()
        {
            var resultVal = _context.FormField.ToList();
            return resultVal;
        }
        public FormField GetInfo(int id)
        {
            var item = _context.FormField.FirstOrDefault(t => t.FormFieldID == id);
            return item;
        }


    }
}