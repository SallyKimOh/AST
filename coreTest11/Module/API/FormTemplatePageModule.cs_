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
    public class FormTemplatePageModule
    {
        private readonly SchoolDbContext _context;

        public FormTemplatePageModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<FormTemplatePage> GetList()
        {
            var resultVal = _context.FormTemplatePage.ToList();
            return resultVal;
        }

        public FormTemplatePage GetInfo(int id)
        {
            var item = _context.FormTemplatePage.FirstOrDefault(t => t.FormTemplatePageID == id);
            return item;
        }
    }
}