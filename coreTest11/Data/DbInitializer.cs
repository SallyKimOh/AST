using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using coreTest11.Models;
using Microsoft.AspNetCore.Identity;

namespace coreTest11.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolDbContext context)
        {
            //If you want db to delete, it will be working for delete.
 //           context.Database.EnsureDeleted();

            //Ensure db for our current context exists, else create one
            // NOTE: Will have to change this once we implement migrations
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return; // db already seeded
            }


            //Make some Role
            var roles = new Role[]
            {
                new Role { Name="Admin", NormalizedName="Admin"},
                new Role { Name="Teacher", NormalizedName = "Teacher"},
                new Role { Name="Parent", NormalizedName = "Parent"},
                new Role { Name="Student", NormalizedName = "Student"}
           };

            foreach (Role u in roles)
            {
                context.Role.Add(u);
            }

            context.SaveChanges();


            //Make some users
            var users = new Users[]
            {
                new Users { FirstName="James", LastName="Rodney", Email="james@gmail.com", UserName="james", IsActive=true,PasswordHash="", NormalizedEmail="james@gmail.com", NormalizedUserName="james@gmail.com",SecurityStamp="111111"}, 
                new Users { FirstName="Ben", LastName="Barnaby", Email="ben@gmail.com", UserName="ben", IsActive=true, PasswordHash="",NormalizedEmail="ben@gmail.com", NormalizedUserName="ben@gmail.com",SecurityStamp="111111"},
                new Users { FirstName="Mister", LastName="Doctor", Email="Mister@gmail.com", UserName="mister" ,IsActive=true, PasswordHash="",NormalizedEmail="Mister@gmail.com", NormalizedUserName="Mister@gmail.com",SecurityStamp="111111"},
                new Users { FirstName="Lara", LastName="Talbot", Email="lara@gmail.com", UserName="lara", IsActive=true , PasswordHash="",NormalizedEmail="lara@gmail.com", NormalizedUserName="lara@gmail.com",SecurityStamp="111111"},
                new Users { FirstName="Kelly", LastName="Yaraway", Email="kelly@gmail.com", UserName="kelly", IsActive=true , PasswordHash="",NormalizedEmail="kelly@gmail.com", NormalizedUserName="kelly@gmail.com",SecurityStamp="111111"},
                new Users { FirstName="Sam", LastName="SamLast", Email="sam@gmail.com", UserName="sam", IsActive=true , PasswordHash="",NormalizedEmail="sam@gmail.com", NormalizedUserName="sam@gmail.com",SecurityStamp="111111"},
                new Users { FirstName="Dean", LastName="DeanLast", Email="dean@gmail.com", UserName="dean", IsActive=true , PasswordHash="",NormalizedEmail="dean@gmail.com", NormalizedUserName="dean@gmail.com",SecurityStamp="111111"},
                new Users { FirstName="Christina", LastName="Chris", Email="chris@gmail.com", UserName="chris", IsActive=true, PasswordHash="",NormalizedEmail="chris@gmail.com", NormalizedUserName="chris@gmail.com",SecurityStamp="111111" },
                new Users { FirstName="John", LastName="John", Email="john@gmail.com", UserName="john",IsActive=true, PasswordHash="",NormalizedEmail="john@gmail.com", NormalizedUserName="john@gmail.com",SecurityStamp="111111" },
                new Users { FirstName="Johnny", LastName="Firechild", Email="johnny@gmail.com", UserName="johnny",IsActive=true, PasswordHash="",NormalizedEmail="johnny@gmail.com", NormalizedUserName="johnny@gmail.com",SecurityStamp="111111" }
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


            var activity = new SchoolActivity[]
            {
                new SchoolActivity { Address = "Canada Aviation and Space Museum 11, prom. of Aviation, Ottawa, K1K 2X5", Amount = 11, ActivityDT = DateTime.Parse("2018-03-31"),Deadline = DateTime.Parse("2018-03-20"), ArriveOn = DateTime.Parse("2018-03-31 15:30:00"),  DepartAt = DateTime.Parse("2018-03-31 09:30:00"), Notify = true, TripName = "Aviation Museum",
                    ImageUrl = "activity/2018/sample1.jpg",
                    FileUrl = "activity/2018/Museum0331.pdf",
                    ApplicationYN = false,
                    Description ="Destination: Musée de l¶Aviation et de l'Espace du Canada 11, prom. de l¶Aviation, Ottawa, K1K 2X5 \n But de la sortie: Participer à l¶atelier «Le vol» et explorer le musée. \n Date et heure de départ: le mercredi 21 mars 2018 à 9 h 15 \n Date et heure de retour: le mercredi 21 mars 2018 à 15 h 15 ",
                    SampleTextExpression = ""},
                new SchoolActivity { Address = "Julie-Payette Ecole Elementaire Publique", Amount = 8.50, ActivityDT = DateTime.Parse("2018-03-25"),Deadline = DateTime.Parse("2018-03-20"), ArriveOn = DateTime.Parse("2018-03-31 18:00:00"), Notify = true, TripName = "Spaghett",
                    ImageUrl = "activity/2018/spaghetti5.jpg",
                    FileUrl = "activity/2018/spaghetti2018.docx",
                    ApplicationYN = false,
                    Description ="Chers parents, tuteurs et tutrices \n Dans le cadre de la Semaine de la Francophonie, l’école élémentaire publique \n Julie-Payette vous invite à son souper spaghetti annuel. Venez vous joindre à nous pour une soirée conviviale et amusante! ",
                    SampleTextExpression = ""},
                new SchoolActivity { Address = "Dôme LR de l’É.S.P. Louis-Riel.", Amount = 25, ActivityDT = DateTime.Parse("2018-04-27"),Deadline = DateTime.Parse("2018-04-20"), ArriveOn = DateTime.Parse("2018-04-27 9:00:00"),  DepartAt = DateTime.Parse("2018-04-27 17:30:00"), Notify = true, TripName = "Sessions de sports",
                    ImageUrl = "activity/2018/sample1.jpg",
                    FileUrl = "activity/2018/Journee_de_sports.pdf",
                    ApplicationYN = false,
                    Description ="Les sessions seront dirigées et supervisées par les entraîneurs et \n enseignants de l’École secondaire publique Louis-Riel. La session \n de soccer sera dirigée par le directeur technique et les entraîneurs de \n la FCB Escola Ottawa.",
                    SampleTextExpression = ""},
                new SchoolActivity { Address = "Dôme LR de l’É.S.P. Louis-Riel.", Amount = 25, ActivityDT = DateTime.Parse("2018-04-27"),Deadline = DateTime.Parse("2018-04-20"), ArriveOn = DateTime.Parse("2018-04-27 9:00:00"),  DepartAt = DateTime.Parse("2018-04-27 17:30:00"), Notify = true, TripName = "Sessions de sports",
                    ImageUrl = "activity/2018/sample1.jpg",
                    FileUrl = "activity/2018/Journee_de_sports.pdf",
                    ApplicationYN = false,
                    Description ="Les sessions seront dirigées et supervisées par les entraîneurs et \n enseignants de l’École secondaire publique Louis-Riel. La session \n de soccer sera dirigée par le directeur technique et les entraîneurs de \n la FCB Escola Ottawa.",
                    SampleTextExpression = ""},
                new SchoolActivity { Address = "Dôme LR de l’É.S.P. Louis-Riel.", Amount = 25, ActivityDT = DateTime.Parse("2018-04-27"),Deadline = DateTime.Parse("2018-04-20"), ArriveOn = DateTime.Parse("2018-04-27 9:00:00"),  DepartAt = DateTime.Parse("2018-04-27 17:30:00"), Notify = true, TripName = "Sessions de sports",
                    ImageUrl = "activity/2018/sample1.jpg",
                    FileUrl = "activity/2018/Journee_de_sports.pdf",
                    ApplicationYN = false,
                    Description ="Les sessions seront dirigées et supervisées par les entraîneurs et \n enseignants de l’École secondaire publique Louis-Riel. La session \n de soccer sera dirigée par le directeur technique et les entraîneurs de \n la FCB Escola Ottawa.",
                    SampleTextExpression = ""},
                new SchoolActivity { Address = "Dôme LR de l’É.S.P. Louis-Riel.", Amount = 25, ActivityDT = DateTime.Parse("2018-04-27"),Deadline = DateTime.Parse("2018-04-20"), ArriveOn = DateTime.Parse("2018-04-27 9:00:00"),  DepartAt = DateTime.Parse("2018-04-27 17:30:00"), Notify = true, TripName = "Sessions de sports",
                    ImageUrl = "activity/2018/sample1.jpg",
                    FileUrl = "activity/2018/Journee_de_sports.pdf",
                    ApplicationYN = false,
                    Description ="Les sessions seront dirigées et supervisées par les entraîneurs et \n enseignants de l’École secondaire publique Louis-Riel. La session \n de soccer sera dirigée par le directeur technique et les entraîneurs de \n la FCB Escola Ottawa.",
                    SampleTextExpression = ""},
                new SchoolActivity { Address = "Dôme LR de l’É.S.P. Louis-Riel.", Amount = 25, ActivityDT = DateTime.Parse("2018-04-27"),Deadline = DateTime.Parse("2018-04-20"), ArriveOn = DateTime.Parse("2018-04-27 9:00:00"),  DepartAt = DateTime.Parse("2018-04-27 17:30:00"), Notify = true, TripName = "Sessions de sports",
                    ImageUrl = "activity/2018/sample1.jpg",
                    FileUrl = "activity/2018/Journee_de_sports.pdf",
                    ApplicationYN = false,
                    Description ="Les sessions seront dirigées et supervisées par les entraîneurs et \n enseignants de l’École secondaire publique Louis-Riel. La session \n de soccer sera dirigée par le directeur technique et les entraîneurs de \n la FCB Escola Ottawa.",
                    SampleTextExpression = ""},
                new SchoolActivity { Address = "Dôme LR de l’É.S.P. Louis-Riel.", Amount = 25, ActivityDT = DateTime.Parse("2018-04-27"),Deadline = DateTime.Parse("2018-04-20"), ArriveOn = DateTime.Parse("2018-04-27 9:00:00"),  DepartAt = DateTime.Parse("2018-04-27 17:30:00"), Notify = true, TripName = "Sessions de sports",
                    ImageUrl = "activity/2018/sample1.jpg",
                    FileUrl = "activity/2018/Journee_de_sports.pdf",
                    ApplicationYN = false,
                    Description ="Les sessions seront dirigées et supervisées par les entraîneurs et \n enseignants de l’École secondaire publique Louis-Riel. La session \n de soccer sera dirigée par le directeur technique et les entraîneurs de \n la FCB Escola Ottawa.",
                    SampleTextExpression = ""},
                new SchoolActivity { Address = "Dôme LR de l’É.S.P. Louis-Riel.", Amount = 25, ActivityDT = DateTime.Parse("2018-04-27"),Deadline = DateTime.Parse("2018-04-20"), ArriveOn = DateTime.Parse("2018-04-27 9:00:00"),  DepartAt = DateTime.Parse("2018-04-27 17:30:00"), Notify = true, TripName = "Sessions de sports",
                    ImageUrl = "activity/2018/sample1.jpg",
                    FileUrl = "activity/2018/Journee_de_sports.pdf",
                    ApplicationYN = false,
                    Description ="Les sessions seront dirigées et supervisées par les entraîneurs et \n enseignants de l’École secondaire publique Louis-Riel. La session \n de soccer sera dirigée par le directeur technique et les entraîneurs de \n la FCB Escola Ottawa.",
                    SampleTextExpression = ""},
                new SchoolActivity { Address = "Julie-Payette Ecole Elementaire Publique", Amount = 0, ActivityDT = DateTime.Parse("2018-05-31"),Deadline = DateTime.Parse("2018-05-20"), ArriveOn = DateTime.Parse("2018-05-31 15:30:00"),  DepartAt = DateTime.Parse("2018-05-31 09:30:00"), Notify = true, TripName = "Carnaval",
                    ImageUrl = "activity/2018/sample1.jpg",
                    FileUrl = "activity/2018/carnaval2018.docx",
                    ApplicationYN = false,
                    Description ="Les élèves et le personnel de l’école seront séparés en deux groupes… l’équipe \n ROUGE et l’équipe BLEUE! L’équipe qui accumulera le plus haut taux de participation \n aux journées thèmes, gagnera des points pour son équipe!",
                    SampleTextExpression = ""}
            };

            foreach (SchoolActivity m in activity)
            {
                context.SchoolActivity.Add(m);
            }

            context.SaveChanges();





        }

        internal static void Initialize(object context)
        {
            throw new NotImplementedException();
        }

    }
}
