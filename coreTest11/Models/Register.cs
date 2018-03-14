using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class Register
    {
        public Users Users { get; set; }
        public Parent Parent { get; set; }
        public int CredentialsID { get; set; }
        public Student Student { get; set; }

    }
}
