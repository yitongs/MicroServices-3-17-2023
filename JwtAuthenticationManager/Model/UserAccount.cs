﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Model
{
    public class UserAccount
    {
        public string Username { get; set; }
        public  string  Password{ get; set; }

        public string Role { get; set; }
    }
}
