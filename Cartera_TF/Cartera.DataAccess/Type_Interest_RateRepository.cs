using Cartera.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public class Type_Interest_RateRepository : IType_Interest_RateRepository
    {
        private readonly CarteraDbContext _context;

        public Type_Interest_RateRepository(CarteraDbContext context)
        {
            _context = context;
        }
        public async Task Create(Type_Interest_Rate entity)
        {
            await _context.Set<Type_Interest_Rate>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Type_Interest_Rate
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Type_Interest_Rate>> GetCollection()
        {
            var collection = await _context.Type_Interest_Rates
                .ToListAsync();

            return collection;
        }

        public async Task<Type_Interest_Rate> GetItem(int id)
        {
            return await _context.Type_Interest_Rates.FindAsync(id);
        }

        public async Task Update(Type_Interest_Rate entity)
        {
            _context.Set<Type_Interest_Rate>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }
    }
}
