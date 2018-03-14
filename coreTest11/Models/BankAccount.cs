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
        [ForeignKey("UserId")]
        public String UserId { get; set; }
        [StringLength(50), Required]
        public String Name { get; set; }
        [StringLength(50), Required]
        public String AccountNumber { get; set; }

    }
}
