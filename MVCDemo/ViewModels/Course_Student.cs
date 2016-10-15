using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.ViweModels
    
{
    public class Course_Student
    {
        public List<Student> students { set; get; }
        public Course course { set; get; }
    }
}