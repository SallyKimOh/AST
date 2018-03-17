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
    public class FormTemplateFieldModule 
    {
        private readonly SchoolDbContext _context;

        public FormTemplateFieldModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<FormTemplateField> GetList()
        {
            var resultVal = _context.FormTemplateField.ToList();
            return resultVal;
        }

        public FormTemplateField GetInfo(int id)
        {
            var item = _context.FormTemplateField.FirstOrDefault(t => t.FormTemplateFieldID == id);
            return item;
        }
    }
}