using Cartera.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public interface IGastosFinalesRepository
    {
        Task<ICollection<GastosFinales>> GetCollection();

        Task<GastosFinales> GetItem(int id);

        Task Create(GastosFinales entity);

        Task Update(GastosFinales entity);

        Task Delete(int id);
    }
}
