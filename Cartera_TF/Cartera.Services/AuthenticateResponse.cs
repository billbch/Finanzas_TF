using System;
using System.Collections.Generic;
using System.Text;
using Cartera.Entities;

namespace Cartera.Services
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public int RolId { get; set; }
        public int Idf { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Account user, string token)
        {
            Id = user.Id;
            Username = user.Userr;
            Token = token;
            Idf = user.Idf;
            RolId = user.RolId;
        }
    }
}
