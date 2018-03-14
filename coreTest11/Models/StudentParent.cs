using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class StudentParent
    {
        [Key]
        public int StudentParentID { get; set; }
        [ForeignKey("StudentID")]
        public int StudentID { get; set; }
        [ForeignKey("ParentID")]
        public int ParentID { get; set; }
        //[DefaultValue(false)]
        //public bool IsActive { get; set; }

    }
}
