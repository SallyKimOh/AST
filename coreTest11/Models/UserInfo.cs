using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class UserInfo
    {
        [Key]
        public int id { get; set; }
        public Users User { get; set; }
        public Student Student { get; set; }
        public Parent Parent { get; set; }
        public StudentParent StudentParent { get; set; }

    }
}
