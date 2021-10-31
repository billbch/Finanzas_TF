using Cartera.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public interface IType_Interest_RateRepository
    {
        Task<ICollection<Type_Interest_Rate>> GetCollection();

        Task<Type_Interest_Rate> GetItem(int id);

        Task Create(Type_Interest_Rate entity);

        Task Update(Type_Interest_Rate entity);

        Task Delete(int id);
    }
}
