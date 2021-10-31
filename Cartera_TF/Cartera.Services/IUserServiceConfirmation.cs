using System;
using System.Collections.Generic;
using System.Text;

namespace Cartera.Services
{
    public interface IUserServiceConfirmation
    {
        AuthenticateResponse Authenticate(AuthenticateRequest body/*, Task<List<Account>> list*/);

    }
}
