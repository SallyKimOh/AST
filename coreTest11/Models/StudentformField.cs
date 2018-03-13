using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class StudentformField
    {

        [Key]
        public int StudentformFieldID { get; set; }
        [ForeignKey("StudentFormID")]
        public int StudentFormID { get; set; }
        [ForeignKey("FormFieldID")]
        public int FormFieldID { get; set; }
        [StringLength(100),Required]
        public string Value { get; set; }

    }
}
