using coreTest11.Data;
using coreTest11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Module.API
{
    public class SchoolActivityModule
    {
        private readonly SchoolDbContext _context;

        public SchoolActivityModule(SchoolDbContext context)
        {
            _context = context;
        }

        public List<SchoolActivity> GetList()
        {
            var resultVal = _context.SchoolActivity.ToList();
            return resultVal;
        }

        public SchoolActivity GetInfo(int id)
        {
            //           return new Classroom();
            var item = _context.SchoolActivity.FirstOrDefault(t => t.ActivityID == id);
            return item;
        }


    }
}
