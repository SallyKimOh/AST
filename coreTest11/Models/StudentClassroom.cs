using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class StudentClassroom
    {
        [Key]
        public int StudentClassroomID { get; set; }
        [ForeignKey("StudentID")]
        public int StudentID { get; set; }
        [ForeignKey("ClassroomID")]
        public int ClassroomID { get; set; }

    }
}
