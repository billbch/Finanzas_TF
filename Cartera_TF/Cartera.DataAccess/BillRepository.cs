using Cartera.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public class BIllRepository : IBillRepository
    {
        private readonly CarteraDbContext _context;

        public BIllRepository(CarteraDbContext context)
        {
            _context = context;
        }
        public async Task Create(Bill bill)
        {
            await _context.Set<Bill>().AddAsync(bill);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Bill
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Bill>> GetCollection()
        {
            var collection = await _context.Bills
                .ToListAsync();

            return collection;
        }

        public async Task<Bill> GetItem(int id)
        {
            return await _context.Bills.FindAsync(id);
        }

        public async Task Update(Bill bill)
        {
            _context.Set<Bill>().Attach(bill);
            _context.Entry(bill).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }
    }
}
