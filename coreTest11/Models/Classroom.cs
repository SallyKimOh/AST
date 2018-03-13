using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class Classroom
    {
        [Key]
        public int ClassroomID { get; set; }
        //[ForeignKey("UserID")]
        //public string UserID { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [StringLength(10), Required]
        public string Grade { get; set; }

    }
}
