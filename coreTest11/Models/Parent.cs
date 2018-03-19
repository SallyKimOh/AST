using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class Parent
    {

        [Key]
        public int ParentID { get; set; }
        //[StringLength(50), Required]
        //public string FirstName { get; set; }
        //[StringLength(50), Required]
        //public string LastName { get; set; }
        [StringLength(20)]
        public string HomePhone { get; set; }
        [StringLength(20)]
        public string CellPhone { get; set; }
        [StringLength(20)]
        public string PostalCode { get; set; }
        [NotMapped]
//        [ForeignKey("UserId")]
        public string UserId { get; set; }
        [NotMapped]
        public Users Users { get; set; }
//        public List<StudentParent> StudentParents { get; set; }
        public StudentParent StudentParent { get; set; }


    }
}
