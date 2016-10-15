using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student {FirstName = "James", LastName = "Dean",EnrollmentDate = DateTime.Parse("2014-01-02"), PersonId = 1},
                new Student {FirstName = "Lynda", LastName = "Thames", EnrollmentDate = DateTime.Parse("2014-01-02"), PersonId = 2}

            };
            foreach(var student in students)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor
                {
                    FirstName = "Peter",
                    LastName = "Lee",
                    HireDate = DateTime.Parse("2002.6.1"),
                },
                new Instructor
                {
                    FirstName = "Ruth",
                    LastName = "Zen",
                    HireDate = DateTime.Parse("2003.6.1"),
                }
            };
            foreach (var instructor in instructors)
            {
                context.Instructors.Add(instructor);
            };
            instructors.ForEach(s => context.Instructors.Add(s));
            context.SaveChanges();


            var departments = new List<Department>
            {
                new Department {Name = "English", Budget = 200000, StartDate=DateTime.Parse("2000.9.1"),PersonId = 3 },
                new Department {Name = "Computer Science", Budget = 400000, StartDate = DateTime.Parse("2000.9.1"), PersonId = 4}
            };
            //departments.ForEach(s => context.Departments.Add(s));
            foreach (var department in departments)
            {
                context.Departments.Add(department);
            };
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course {CourseId = 100, CourseName = "Java", TotalCredits = 4, DepartmentID = 2},
                new Course {CourseId = 200, CourseName = "C#", TotalCredits = 4,DepartmentID = 2}
            };
            foreach (var temp in courses)
            {
                context.Courses.Add(temp);
            }
            context.SaveChanges();

            var courseInstructors = new List<CourseInstructor>
            {
                new CourseInstructor {CourseId=100, PersonId = 3},
                new CourseInstructor {CourseId=200, PersonId = 4}
            };
            foreach(var ci in courseInstructors)
            {
                context.CourseInstructors.Add(ci);
            }
            //courseInstructors.ForEach(c => context.CourseInstructors.Add(c));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {PersonId = 1, CourseId = 100, Grade=3 },
                new Enrollment {PersonId = 1, CourseId = 200, Grade = 4 }
            };
            foreach (var temp in enrollments)
            {
                context.Enrollments.Add(temp);
            }
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer {FirstName = "Alex", LastName = "Rod", Address = new Address {StreetAddress = "One Baylor plaza" } },
                new Customer {FirstName = "Rose", LastName = "Lu", Address = new Address {StreetAddress = "201 cambridge st" } }
            };

            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();




        }
    }
}