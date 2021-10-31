using Cartera.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public interface IBillRepository
    {
        Task<ICollection<Bill>> GetCollection(/*string filter*/);

        Task<Bill> GetItem(int id);

        Task Create(Bill bill);
        Task Update(Bill bill);
        Task Delete(int id);
    }
}
