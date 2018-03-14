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
    public class BankAccountModule 
    {
        private readonly SchoolDbContext _context;

        public BankAccountModule(SchoolDbContext context)
        {
            _context = context;

        }

        public List<BankAccount> GetList()
        {
            var resultVal = _context.BankAccount.ToList();
            return resultVal;
        }

        public BankAccount GetBankAccountInfo(string id)
        {
            var item = _context.BankAccount.FirstOrDefault(t => t.UserId == id);
            return item;
        }


    }
}