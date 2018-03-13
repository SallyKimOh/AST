using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class Credentials
    {
        [Key]
        public int CredentialsID { get; set; }
        [ForeignKey("TeacherID")]
        public int TeacherID { get; set; }
        [StringLength(20), Required]
        public string Key { get; set; }
        public bool IsActive { get; set; }
       public DateTime CreateDT { get; set; }

    }
}
