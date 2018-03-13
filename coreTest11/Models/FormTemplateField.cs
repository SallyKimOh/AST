using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class FormTemplateField
    {

        [Key]
        public int FormTemplateFieldID { get; set; }
        [ForeignKey("FormTemplateID")]
        public long FormTemplateID { get; set; }
        public string Label { get; set; }
        public int PageNumber { get; set; }
        [ForeignKey("FormFieldTypeID")]
        public int FormFieldTypeID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }


    }
}
