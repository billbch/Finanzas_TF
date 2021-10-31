using Cartera.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public class PortfolioRepository : IPortolioRepository
    {
        private readonly CarteraDbContext _context;

        public PortfolioRepository(CarteraDbContext context)
        {
            _context = context;
        }
        public async Task Create(Portfolio entity)
        {
            await _context.Set<Portfolio>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Portfolio
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Portfolio>> GetCollection()
        {
            var collection = await _context.Portfolios
                .ToListAsync();

            return collection;
        }

        public async Task<Portfolio> GetItem(int id)
        {
            return await _context.Portfolios.FindAsync(id);
        }

        public async Task Update(Portfolio entity)
        {
            _context.Set<Portfolio>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }
    }
}
