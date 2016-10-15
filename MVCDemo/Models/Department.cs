using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    [Table("tb_Department")]
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage ="Department name is required.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString ="{0:c}")]
        [Required(ErrorMessage ="Budget is required.")]
        [Column(TypeName = "money")]
        public decimal? Budget { get; set; }

        [Required(ErrorMessage ="Start date is required.")]
        [DisplayFormat(DataFormatString ="{0:d}",ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Timestamp]
        public byte[] stamp { get; set; }



        public int? PersonId { get; set; }

        [Display(Name = "Administrator")]
        public virtual Instructor Administator { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
    

}