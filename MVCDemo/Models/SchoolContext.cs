using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }
        public DbSet<Person> People { get; set; }

        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }


        //this remove the "s" from the end of the table name
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>().Map(mc =>
            { mc.Properties(x => new { x.Id, x.Username, x.Email }); mc.ToTable("User"); });

            modelBuilder.Entity<User>().Map(mc =>
            { mc.Properties(x => new { x.Id, x.FirstName, x.MiddleName, x.LastName }); mc.ToTable("UserProfiles"); });

            modelBuilder.Entity<Customer>()
                .HasRequired(p => p.Address)
                .WithRequiredPrincipal(a => a.Customer);

            modelBuilder.Entity<Customer>().ToTable("CustAdd");
            modelBuilder.Entity<Address>().ToTable("CustAdd");
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    modelBuilder.Entity<Course>()
        //        .HasMany(c => c.Instructors).WithMany(i => i.Courses)
        //        .Map(t => t.MapLeftKey("CourseID")
        //        .MapRightKey("PersonId")
        //        .ToTable("tb_Course_Instructor"));
        //}
    }

} 