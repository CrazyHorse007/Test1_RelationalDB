using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test1_RelationalDB.Models
{
    public class Testator : Person
    {

        //public int ExecutorID { get; set; }

        [Required]
        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        //[ForeignKey("ExecutorID")]
        //for 1 to 1 relationship
        //public virtual Executor Executors { get; set; }   
        //for 1 to many relationship
        public virtual List<Executor> Executors { get; set; }
    }
}
