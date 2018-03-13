using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class FormPage
    {
        [Key]
        public int FormPageID { get; set; }
        [ForeignKey("FormID")]
        public string FormID { get; set; }
        public long Number { get; set; }
        public string Url { get; set; }

    }
}
