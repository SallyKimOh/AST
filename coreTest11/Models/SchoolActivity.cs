using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class SchoolActivity
    {
        [Key]
        public long ActivityID { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        public double Amount { get; set; }
        public DateTime ActivityDT { get; set; }
        public DateTime DepartAt { get; set; }
        public DateTime ArriveOn { get; set; }
        public DateTime Deadline { get; set; }
        [StringLength(50), Required]
        public string TripName { get; set; }
        [DefaultValue(false)]
        public bool Notify { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string SampleTextExpression { get; set; }
        public string FileUrl { get; set; }
        [DefaultValue(false)]
        public bool ApplicationYN { get; set; }
        public ActivityConfirm ActivityConfirm { get; set; }






    }
}
