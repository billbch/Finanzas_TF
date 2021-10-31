using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly CarteraDbContext _context;

        public UnitOfWork(CarteraDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
