using MVCDemo.Models;
using MVCDemo.ViweModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class XyzController : Controller
    {
        // GET: Xyz
        private SchoolContext db = new SchoolContext();
        public ActionResult abc()
        {
            var students = db.Students.ToList();
            return View(students);
            //Course course = new Course();
            //course.courseName = "Math 101";
            //course.totalCredits = 4;
 
            //Student Joey = new Student();
            //Joey.lastName = "Fachini";
            //Joey.firstName = "Joey";
            //Student Lynda = new Student();
            //Lynda.lastName = "Fachini";
            //Lynda.firstName = "Lynda";
            //Student John = new Student();
            //John.lastName = "Neilson";
            //John.firstName = "John";

            //List<Student> list = new List<Student>();
            //list.Add(Joey);
            //list.Add(Lynda);
            //list.Add(John);

            //Course_Student obj = new Course_Student();
            //obj.course = course;
            //obj.students = list;
            //return View(obj);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}