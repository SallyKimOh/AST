using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class Form
    {
        [Key]
        public long FormID { get; set; }
        [ForeignKey("ClassroomID")]
        public int ClassroomID { get; set; }
        [ForeignKey("BankAccountID")]
        public int BankAccountID { get; set; }
        [Required]
        public int FormType { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [StringLength(50), Required]
        public string TripName { get; set; }
        [StringLength(100), Required]
        public string Address { get; set; }
        [Required]
        public DateTime DepartAt { get; set; }
        [Required]
        public DateTime ArriveOn { get; set; }
        [DefaultValue(false)]
        public bool VolunteenRequest { get; set; }
        [DefaultValue(false)]
        public bool RequiresPayment { get; set; }
        public Decimal Amount { get; set; }
        [DefaultValue(false)]
        public bool Notify { get; set; }

    }
}
