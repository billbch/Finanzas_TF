using Cartera.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.DataAccess
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetCollection();

        Task<User> GetItem(int id);

        Task Create(User entity);

        Task Update(User entity);

        Task Delete(int id);
    }
}
