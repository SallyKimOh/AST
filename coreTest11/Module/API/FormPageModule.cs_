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
    public class FormPageModule
    {
        private readonly SchoolDbContext _context;

        public FormPageModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<FormPage> GetList()
        {
            var resultVal = _context.FormPage.ToList();
            return resultVal;
        }

        public FormPage GetInfo(int id)
        {
            var item = _context.FormPage.FirstOrDefault(t => t.FormPageID == id);
            return item;
        }
    }
}