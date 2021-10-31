using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cartera.Entities;

namespace Cartera.DataAccess
{
    public interface IAccountRepository
    {
        Task AddAsyn(Account account);
        Task<IEnumerable<Account>> ListAsync();

        Task<Account> GetByUserandPasswordIdAsync(string username, string password);
    }
}
