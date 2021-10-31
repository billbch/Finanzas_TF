using Cartera.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public interface IPortolioRepository
    {
        Task<ICollection<Portfolio>> GetCollection();

        Task<Portfolio> GetItem(int id);

        Task Create(Portfolio entity);

        Task Update(Portfolio entity);

        Task Delete(int id);
    }
}
