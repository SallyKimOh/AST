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
    public class FormFieldTypeModule
    {
        private readonly SchoolDbContext _context;

        public FormFieldTypeModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<FormFieldType> GetList()
        {
            var resultVal = _context.FormFieldType.ToList();
            return resultVal;
        }

        public FormFieldType GetInfo(int id)
        {
            var item = _context.FormFieldType.FirstOrDefault(t => t.FormFieldTypeID == id);
            return item;
        }
    }
}