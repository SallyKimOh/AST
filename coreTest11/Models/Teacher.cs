using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        [ForeignKey("UserId")]
        public String UserId { get; set; }
        [ForeignKey("ClassroomID")]
        public int ClassroomID { get; set; }
//        [StringLength(50), Required]
        //public string FirstName { get; set; }
        //[StringLength(50), Required]
        //public string LastName { get; set; }

    }
}
