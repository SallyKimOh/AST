using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class ClassActivity
    {
        [Key]
        public int ClassActivityID {get; set;}
        [ForeignKey("ActivityID")]
        public long ActivityID { get; set; }
        [ForeignKey("ClassroomID")]
        public int ClassroomID { get; set; }
    }
}
