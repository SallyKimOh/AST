using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class FormTemplate
    {
        [Key]
        public long FormTemplateID { get; set; }
        [ForeignKey("UserID")]
        public string UserID { get; set; }
        public int FormType { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }

    }
}
