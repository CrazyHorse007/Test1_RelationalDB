using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test1_RelationalDB.Models
{
    public class Executor : Person
    {
        [Required]
        [Display(Name = "Relationship to Will Maker")]
        public string Relationship { get; set; }

        //[Key]
        [ForeignKey("TestatorID")]

        public int TestatorID { get; set; }
        public virtual Testator Testator { get; set; }
        
    }
}
