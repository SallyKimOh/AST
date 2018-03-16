using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using coreTest11.Models;
using Microsoft.EntityFrameworkCore;

namespace coreTest11.Module.API
{
    public class CredentialsModule
    {
        private readonly SchoolDbContext _context;

        public CredentialsModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<Credentials> GetList()
        {
            var resultVal = _context.Credentials.ToList();
            return resultVal;
        }

        public Credentials GetInfo(int id)
        {
            var item = _context.Credentials.FirstOrDefault(t => t.CredentialsID == id);
            return item;
        }
        public Credentials GetInfo(string key)
        {
//            var item = _context.Credentials.FirstOrDefault(t => t.Key == key);
            var item = _context.Credentials
                .Include(f => f.Teacher)
                .FirstOrDefault(t => t.Key == key);

            return item;
        }
    }
}