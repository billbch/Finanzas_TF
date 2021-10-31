using Cartera.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly CarteraDbContext _context;

        public UserRepository(CarteraDbContext context)
        {
            _context = context;
        }
        public async Task Create(User entity)
        {
            await _context.Set<User>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new User
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetCollection()
        {
            var collection = await _context.Users
                .ToListAsync();

            return collection;
        }

        public async Task<User> GetItem(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Update(User entity)
        {
            _context.Set<User>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }
    }
}
