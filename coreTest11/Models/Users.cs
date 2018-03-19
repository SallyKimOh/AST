using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreTest11.Models
{
    public class Users : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }


        public string FaceboookURL { get; set; }

        public string InstagramURL { get; set; }

        public string TwitterURL { get; set; }

        public string SteamURL { get; set; }

//        [NotMapped]
//        public Student Student { get; set; }
//        [NotMapped]
//        public Parent Parent { get; set; }
//        [NotMapped]
//        public StudentParent StudentParent { get; set; }

        [NotMapped]
        public int ParentID { get; set; }
        [NotMapped]
        public int StudentID { get; set; }


    }
}
