using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class Student
    {

        [Key]
        public int StudentID { get; set; }
//        [ForeignKey("UserId")]
        public String UserId { get; set; }
 //       [ForeignKey("ClassroomID")]
 //       public int ClassroomID { get; set; }
        //[StringLength(50), Required]
        //public string FirstName { get; set; }
        //[StringLength(50), Required]
        //public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [StringLength(50)]
        public string EmergencyContactName { get; set; }
        [StringLength(20)]
        public string EmergencyContactPhoneNumber { get; set; }
        [StringLength(50)]
        public string HealthCardNumber { get; set; }
        [StringLength(20)]
        public string DoctorPhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public string Key { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
//        [ForeignKey("ParentID")]
        public int ParentID { get; set; }
        [NotMapped]
        public Parent Parent { get; set; }

        [NotMapped]
        public StudentClassroom StudentClassroom { get; set; }



    }
}
