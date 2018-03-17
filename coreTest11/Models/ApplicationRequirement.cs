using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class ApplicationRequirement
    {
        [Key]
        public long ApplRequireID { get; set; }
        public bool ParticipationYN { get; set; }
        public bool VolunteenYN { get; set; }
        public bool PayYN { get; set; }
        public bool HealthIssue { get; set; }
        public bool DomationYN { get; set; }
        public bool SignatureYN { get; set; } 
        public DateTime CreateDT { get; set; }
        public string ETC { get; set; }
        [ForeignKey("ActivityID")]
        public long ActivityID { get; set; }
        [Display]
        public bool ApplicationYN { get; set; }





    }
}
