using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    //[Table("Student")]
    public class Student : Person
    {
        //[Key]
        //public int PersonId { set; get;}
        //[Required(ErrorMessage ="First name is required")]
        //[MaxLength(50)]
        //[Display(Name = "First Name")]
        //public string FirstName { set; get; }

        //[Required(ErrorMessage = "Last name is required")]
        //[MaxLength(50)]
        //[Display(Name ="Family Name")]
        //public string LastName { set; get; }

        [Required(ErrorMessage ="Enrollment date is required")]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString ="{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}