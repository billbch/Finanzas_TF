using Cartera.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public class GastosFinalesRepository : IGastosFinalesRepository
    {
        private readonly CarteraDbContext _context;

        public GastosFinalesRepository(CarteraDbContext context)
        {
            _context = context;
        }
        public async Task Create(GastosFinales entity)
        {
            await _context.Set<GastosFinales>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new GastosFinales
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<GastosFinales>> GetCollection()
        {
            var collection = await _context.GastosFinaless
                .ToListAsync();

            return collection;
        }

        public async Task<GastosFinales> GetItem(int id)
        {
            return await _context.GastosFinaless.FindAsync(id);
        }

        public async Task Update(GastosFinales entity)
        {
            _context.Set<GastosFinales>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }
    }
}
