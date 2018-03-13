﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

    }
}
