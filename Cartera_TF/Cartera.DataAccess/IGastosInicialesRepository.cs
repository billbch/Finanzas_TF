using Cartera.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public interface IGastosInicialesRepository
    {
        Task<ICollection<GastosIniciales>> GetCollection();

        Task<GastosIniciales> GetItem(int id);

        Task Create(GastosIniciales entity);

        Task Update(GastosIniciales entity);

        Task Delete(int id);
    }
}
