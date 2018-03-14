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
    public class FormTemplateModule
    {
        private readonly SchoolDbContext _context;

        public FormTemplateModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<FormTemplate> GetList()
        {
            var resultVal = _context.FormTemplate.ToList();
            return resultVal;
        }

        public FormTemplate GetInfo(int id)
        {
            var item = _context.FormTemplate.FirstOrDefault(t => t.FormTemplateID == id);
            return item;
        }
    }
}