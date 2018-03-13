using coreTest11.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace coreTest11.Data
{
    //    public class SchoolDbContext : DbContext
    //    {
    //        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
    //            : base(options)
    //        {

    //        }
    public class SchoolDbContext : IdentityDbContext<Users, Role, string>
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {

        }

        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Engagement> Engagement { get; set; }
        public DbSet<EngagementNotification> EngagementNotification { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<FormField> FormField { get; set; }
        public DbSet<FormFieldType> FormFieldType { get; set; }
        public DbSet<FormPage> FormPage { get; set; }
        public DbSet<FormTemplate> FormTemplate { get; set; }
        public DbSet<FormTemplateField> FormTemplateField { get; set; }
        public DbSet<FormTemplatePage> FormTemplatePage { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentClassroom> StudentClassroom { get; set; }
        public DbSet<StudentForm> StudentForm { get; set; }
        public DbSet<StudentformField> StudentformField { get; set; }
        public DbSet<StudentParent> StudentParent { get; set; }
        //        public DbSet<User> Users { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<BankAccount>().ToTable("BankAccount");
            builder.Entity<Classroom>().ToTable("Classroom");
            builder.Entity<Engagement>().ToTable("Engagement");
            builder.Entity<EngagementNotification>().ToTable("EngagementNotification");
            builder.Entity<Form>().ToTable("Form");
            builder.Entity<FormField>().ToTable("FormField");
            builder.Entity<FormFieldType>().ToTable("FormFieldType");
            builder.Entity<FormPage>().ToTable("FormPage");
            builder.Entity<FormTemplate>().ToTable("FormTemplate");
            builder.Entity<FormTemplateField>().ToTable("FormTemplateField");
            builder.Entity<FormTemplatePage>().ToTable("FormTemplatePage");
            builder.Entity<Parent>().ToTable("Parent");
            builder.Entity<Student>().ToTable("Student");
            builder.Entity<StudentClassroom>().ToTable("StudentClassroom");
            builder.Entity<StudentForm>().ToTable("StudentForm");
            builder.Entity<StudentformField>().ToTable("StudentformField");
            builder.Entity<StudentParent>().ToTable("StudentParent");
            builder.Entity<Users>().ToTable("AspNetUsers");
            builder.Entity<Credentials>().ToTable("Credentials");
            builder.Entity<Teacher>().ToTable("Teacher");
        }
    }
}
