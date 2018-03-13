using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class BankAccount
    {

        [Key]
        public int BankAccountID { get; set; }
        [ForeignKey("UserID")]
        public String UserID { get; set; }
        [StringLength(50), Required]
        public String Name { get; set; }
        [StringLength(50), Required]
        public String AccountNumber { get; set; }

    }
}
