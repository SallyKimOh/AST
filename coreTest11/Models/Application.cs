using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class Application
    {
        [Key]
        public long ApplicationID { get; set; }
        public bool ParticipationYN { get; set; }
        public bool VolunteenYN { get; set; }
        public bool PayYN { get; set; }
        public string HealthIssue { get; set; }
        public Decimal DomationAmount { get; set; }
        [StringLength(1)]
        public string PaymentType { get; set; } //C: credit, D: debit, P: paypal
        public DateTime CreateDT { get; set; }
        public string ETC { get; set; }





    }
}
