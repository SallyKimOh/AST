using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using coreTest11.Models;

namespace coreTest11.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolDbContext context)
        {
            //If you want db to delete, it will be working for delete.
//            context.Database.EnsureDeleted();

            //Ensure db for our current context exists, else create one
            // NOTE: Will have to change this once we implement migrations
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return; // db already seeded
            }

            //Make some users
            var users = new Users[]
            {
                new Users { FirstName="James", LastName="Rodney", Email="james@gmail.com", UserName="james", IsActive=true},
                new Users { FirstName="Ben", LastName="Barnaby", Email="ben@gmail.com", UserName="ben", IsActive=true},
                new Users { FirstName="Mister", LastName="Doctor", Email="Mister@gmail.com", UserName="mister" , IsActive=true},
                new Users { FirstName="Lara", LastName="Talbot", Email="lara@gmail.com", UserName="lara", IsActive=true },
                new Users { FirstName="Kelly", LastName="Yaraway", Email="kelly@gmail.com", UserName="kelly", IsActive=true },
                new Users { FirstName="Sam", LastName="SamLast", Email="sam@gmail.com", UserName="sam", IsActive=true },
                new Users { FirstName="Dean", LastName="DeanLast", Email="dean@gmail.com", UserName="dean", IsActive=true },
                new Users { FirstName="Christina", LastName="Chris", Email="chris@gmail.com", UserName="chris", IsActive=true },
                new Users { FirstName="John", LastName="John", Email="john@gmail.com", UserName="john", IsActive=true },
                new Users { FirstName="Johnny", LastName="Firechild", Email="johnny@gmail.com", UserName="johnny", IsActive=true }
            };

            foreach (Users u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();

            var classroom = new Classroom[]
            {
                new Classroom { Name="Grade1A", Grade="Grade1"},
                new Classroom { Name="Grade1B", Grade="Grade1"},
                new Classroom { Name="Grade2A", Grade="Grade2"},
                new Classroom { Name="Grade2B", Grade="Grade2"},
                new Classroom { Name="Grade3A", Grade="Grade3"},
                new Classroom { Name="Grade3B", Grade="Grade3"},
                new Classroom { Name="Grade4A", Grade="Grade4"},
                new Classroom { Name="Grade4B", Grade="Grade4"},
                new Classroom { Name="Grade5A", Grade="Grade5"},
                new Classroom { Name="Grade5B", Grade="Grade5"}
            };

            foreach (Classroom m in classroom)
            {
                context.Classroom.Add(m);
            }

            context.SaveChanges();


            var teacher = new Teacher[]
            {
                new Teacher { UserId=users[0].Id, ClassroomID = classroom [0].ClassroomID},
                new Teacher { UserId=users[1].Id, ClassroomID = classroom [1].ClassroomID},
                new Teacher { UserId=users[2].Id, ClassroomID = classroom [2].ClassroomID},
                new Teacher { UserId=users[3].Id, ClassroomID = classroom [3].ClassroomID},
                new Teacher { UserId=users[4].Id, ClassroomID = classroom [4].ClassroomID},
                new Teacher { UserId=users[5].Id, ClassroomID = classroom [5].ClassroomID},
                new Teacher { UserId=users[6].Id, ClassroomID = classroom [6].ClassroomID},
                new Teacher { UserId=users[7].Id, ClassroomID = classroom [7].ClassroomID},
                new Teacher { UserId=users[8].Id, ClassroomID = classroom [8].ClassroomID},
                new Teacher { UserId=users[9].Id, ClassroomID = classroom [9].ClassroomID}
            };

            foreach (Teacher m in teacher)
            {
                context.Teacher.Add(m);
            }

            context.SaveChanges();


            var credentials = new Credentials[]
            {
                new Credentials { Key = "AAA1234567890", CreateDT = DateTime.Parse("2018-03-10"), IsActive = true, TeacherID = teacher[0].TeacherID},
                new Credentials { Key = "BBB1234567890", CreateDT = DateTime.Parse("2018-03-10"), IsActive = true, TeacherID = teacher[1].TeacherID},
                new Credentials { Key = "CCC1234567890", CreateDT = DateTime.Parse("2018-03-10"), IsActive = true, TeacherID = teacher[2].TeacherID},
                new Credentials { Key = "DDD1234567890", CreateDT = DateTime.Parse("2018-03-10"), IsActive = true, TeacherID = teacher[3].TeacherID},
                new Credentials { Key = "EEE1234567890", CreateDT = DateTime.Parse("2018-03-10"), IsActive = true, TeacherID = teacher[4].TeacherID},
                new Credentials { Key = "FFF1234567890", CreateDT = DateTime.Parse("2018-03-10"), IsActive = true, TeacherID = teacher[5].TeacherID},
                new Credentials { Key = "GGG1234567890", CreateDT = DateTime.Parse("2018-03-10"), IsActive = true, TeacherID = teacher[6].TeacherID},
                new Credentials { Key = "HHH1234567890", CreateDT = DateTime.Parse("2018-03-10"), IsActive = true, TeacherID = teacher[7].TeacherID},
                new Credentials { Key = "III1234567890", CreateDT = DateTime.Parse("2018-03-10"), IsActive = true, TeacherID = teacher[8].TeacherID},
                new Credentials { Key = "JJJ1234567890", CreateDT = DateTime.Parse("2018-03-10"), IsActive = true, TeacherID = teacher[9].TeacherID}
            };

            foreach (Credentials m in credentials)
            {
                context.Credentials.Add(m);
            }

            context.SaveChanges();






        }

        internal static void Initialize(object context)
        {
            throw new NotImplementedException();
        }

    }
}
