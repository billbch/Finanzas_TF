﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cartera.DTO
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}