using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Course ID")]
        public int CourseId { set; get; }

        [Required(ErrorMessage ="Title is required.")]
        [MaxLength(50)]
        [Display(Name ="Title")]
        public string CourseName { set; get; }
        
        [Required(ErrorMessage ="Number of credits is required.")]
        [Range(0,5, ErrorMessage ="Number of credits must between 0 and 5.")]
        [Display(Name = "Credits")]
        public int TotalCredits { set; get; }

        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [Timestamp]
        public byte[] stamp { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<CourseInstructor> courseInstructors { get; set; }
    }
}