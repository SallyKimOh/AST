using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class FormFieldType
    {

        [Key]
        public int FormFieldTypeID { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [StringLength(50), Required]
        public string NameLocalizationKey { get; set; }
        [StringLength(500), Required]
        public string Description { get; set; }
        [StringLength(50), Required]
        public string DescriptionLocalizationKey { get; set; }
        public int SampleTextType { get; set; }
        [StringLength(100), Required]
        public string SampleTextExpression { get; set; }
        [StringLength(50), Required]
        public string Grouping { get; set; }
        [StringLength(500), Required]
        public string ImageUrl { get; set; }
        [StringLength(200), Required]
        public string ValidationExpression { get; set; }
        [StringLength(100), Required]
        public string Mask { get; set; }
        [StringLength(50), Required]
        public string InputType { get; set; }
        [StringLength(50), Required]
        public string DataType { get; set; }
        [DefaultValue(false)]
        public bool Active { get; set; }
        public int SortOrder { get; set; }

    }
}
