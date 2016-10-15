using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    //[Table("Instructor")]
    public class Instructor : Person
    {
        //public int PersonId { get; set; }

        //[Required(ErrorMessage ="Last name is required.")]
        //[Display(Name ="Last Name")]
        //[MaxLength(50)]
        //public string LastName { get; set; }

        //[Required(ErrorMessage = "First name is required.")]
        //[Column("First_Name")]
        //[Display(Name = "First Name")]
        //[MaxLength(50)]
        //public string FirstName { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode =true )]
        [Required(ErrorMessage ="Hire Date is required.")]
        [Display(Name ="Hire Date")]
        public DateTime HireDate { get; set; }

        //public string FullName
        //{
        //    get
        //    {
        //        return LastName + ", " + FirstName;
        //    }
        //}

        public virtual ICollection<CourseInstructor> courseInstructors { get; set; }

    }
}