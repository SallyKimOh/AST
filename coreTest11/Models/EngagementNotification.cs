using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class EngagementNotification
    {
        [Key]
        public int EngagementNotificationID { get; set; }
        [ForeignKey("EngagementID")]
        public int EngagementID { get; set; }
        [DefaultValue(false)]
        public  bool EmailYN { get; set; }
        [DefaultValue(false)]
        public bool PushYN { get; set; }
        [DefaultValue(false)]
        public bool SmsYN { get; set; }
        public int MinutesPrior { get; set; }
        [DefaultValue(false)]
        public bool ProcessedYN { get; set; }

    }
}
