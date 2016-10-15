using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class CourseInstructor
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int PersonId { get; set; }

        public virtual Course course { get; set; }
        public virtual Instructor instructor { get; set; }
    }
}