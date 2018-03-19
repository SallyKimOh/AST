using coreTest11.Data;
using coreTest11.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Module.API
{
    public class ActivityConfirmModule
    {
        private readonly SchoolDbContext _context;

        public ActivityConfirmModule(SchoolDbContext context)
        {
            _context = context;
        }

        public List<SchoolActivity> GetList()
        {
            var resultVal = _context.SchoolActivity
               .Include(f => f.ActivityConfirm)
               .Where(g => g.ApplicationYN == true)
               .ToList();
            

            return resultVal;
        }
        public IQueryable<SchoolActivity> GetApplicationList()
        {
            /*            
                        var employees = (from emps in _context.SchoolActivity
                                        join de in _context.ActivityConfirm 
                                        on emps.ActivityID equals de.ActivityID into dep
                                        from dept in dep.DefaultIfEmpty()
                                         select new SchoolActivity()
                                        {
                                            ActivityID = emps.ActivityID,
                                            ApplicationYN = emps.ApplicationYN,
                                            TripName = emps.TripName

                                        });
            */

            /*
                      var employees = (from emps in _context.SchoolActivity
                                         .Where (x => x.ApplicationYN == true)
                                         .DefaultIfEmpty()
                                        join de in _context.ActivityConfirm
                                        .Where(z => z.Parent == 1)
                                         .DefaultIfEmpty()
                                         on emps.ActivityID equals de.ActivityID into dep
                                       from dept in dep.DefaultIfEmpty()
                                       select new SchoolActivity()
                                         {
                                           ActivityID = emps.ActivityID,
                                           ApplicationYN = emps.ApplicationYN,
                                           TripName = emps.TripName
                                       });
            */

            var employees = (from emps in _context.SchoolActivity
                            join de in _context.ActivityConfirm.Where(x => x.ParentID == 1)
                            on emps.ActivityID equals de.ActivityID into dep
                             where emps.ApplicationYN == true 
                             from dept in dep.DefaultIfEmpty()
                             select new SchoolActivity()
                             {
                                 ActivityID = emps.ActivityID,
                                 ApplicationYN = emps.ApplicationYN,
                                 TripName = emps.TripName,
                                 ActivityConfirm = dept

                             });


            return employees;
        }
    }
}
