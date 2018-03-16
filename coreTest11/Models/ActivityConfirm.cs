using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class ActivityConfirm
    {
        [Key]
        public int ActivityConfirmID { get; set; }
        public bool Completed { get; set; }
        public DateTime CompletedOn { get; set; }
        [StringLength(410)]
        public String CompletedBy { get; set; }
        [ForeignKey("StudentID")]
        public int StudentID { get; set; }
        [ForeignKey("ActivityID")]
        public long ActivityID { get; set; }
        [ForeignKey("ApplicationID")]
        public long ApplicationID { get; set; }
        public String SignatureURL { get; set; }

    }
}
