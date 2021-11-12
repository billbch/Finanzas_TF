using System;
using System.Collections.Generic;
using System.Text;

namespace Cartera.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Userr { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public int Idf { get; set; }

        public User User { get; set; }

        //public PersonProfile PersonProfile { get; set; }
       // public Business BusinessProfile { get; set; }
    }
}
