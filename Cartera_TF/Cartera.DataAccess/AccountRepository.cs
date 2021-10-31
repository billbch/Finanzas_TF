using Cartera.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CarteraDbContext _context;
        public AccountRepository(CarteraDbContext context)
        {
            _context = context;
        }
        public async Task AddAsyn(Account account)
        {
            await _context.Set<Account>().AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public Task<Account> GetByUserandPasswordIdAsync(string username, string password) =>
            _context.Accounts
           .Where(x => x.User == username && x.Password == password)
           .FirstAsync();
       
    }
}
