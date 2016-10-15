using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required(ErrorMessage ="Last name is requied.")]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First name is requied.")]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column(TypeName ="image")]
        public byte[] Picture { get; set; }
        public string ImagePath { get; set; }

        [Timestamp]
        public byte[] stamp { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

    }
}