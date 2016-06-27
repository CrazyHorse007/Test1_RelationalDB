using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Test1_RelationalDB.Models
{
    public abstract class Person
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        //[Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //[Required]
        //[StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        //[Column("MiddleName")]
        [Display(Name = "Middle Names")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        //[Column("LastName")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[Required]
        [Display(Name = "Unit/Street Number")]
        public string StreetNumber { get; set; }

        //[Required]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        //[Required]
        [Display(Name = "Street Type")]
        public string StreetType { get; set; }

        //[Required]
        [Display(Name = "Suburb/Town")]
        public string Suburb { get; set; }

        //[Required]
        public string State { get; set; }

        //[Required]
        [Display(Name = "Post Code")]
        [Range(3000, 3999)]
        public int PostCode { get; set; }

        public string Address
        {
            get
            {
                return StreetNumber + " " + StreetName + " " + StreetType + ", " + Suburb;
            }
        }

        //[Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }
}

