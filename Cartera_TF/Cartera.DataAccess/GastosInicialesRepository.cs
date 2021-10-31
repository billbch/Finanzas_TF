using Cartera.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public class GastosInicialesRepository : IGastosInicialesRepository
    {
        private readonly CarteraDbContext _context;

        public GastosInicialesRepository(CarteraDbContext context)
        {
            _context = context;
        }

        public async Task Create(GastosIniciales entity)
        {
            await _context.Set<GastosIniciales>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new GastosIniciales
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<GastosIniciales>> GetCollection()
        {
            var collection = await _context.GastosInicialess
                .ToListAsync();

            return collection;
        }

        public async Task<GastosIniciales> GetItem(int id)
        {
            return await _context.GastosInicialess.FindAsync(id);
        }

        public async Task Update(GastosIniciales entity)
        {
            _context.Set<GastosIniciales>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }
    }
}
