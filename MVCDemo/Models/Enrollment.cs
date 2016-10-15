using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int PersonId { get; set; }
        [DisplayFormat(DataFormatString="{0:#.#}",ApplyFormatInEditMode=true,NullDisplayText ="No Grade")]
        public decimal? Grade { get; set; }
        public virtual Student student { get; set; }
        public virtual Course course { get; set; }
    }
}