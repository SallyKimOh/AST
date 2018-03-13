using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class Engagement
    {
        [Key]
        public int EngagementID { get; set; }
        [ForeignKey("UserID")]
        public string UserID { get; set; }
        [ForeignKey("ClassroomID")]
        public int ClassroomID { get; set; }
        public int EngagementType { get; set; }
        [StringLength(100), Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EngagementDate { get; set; }

    }
}
