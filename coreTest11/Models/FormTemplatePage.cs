using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class FormTemplatePage
    {
        [Key]
        public int FormTemplatePageID { get; set; }
        [ForeignKey("FormTemplateID")]
        public long FormTemplateID { get; set; }
        public int Number { get; set; }
        public string Url { get; set; }


    }
}
