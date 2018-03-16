using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }

        //Foreign key for the type of notification
        public string Type { get; set; }

        public DateTime Timestamp { get; set; }

        public int IsRead { get; set; }

        public string Value { get; set; }

        public Users Notifiee { get; set; }

        public Users Notifier { get; set; }

        [NotMapped]
        public string DisplayTime { get; set; }
    }
}
