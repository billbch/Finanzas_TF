using Cartera.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Services
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetCollection(/*string filter*/);

        Task<ResponseDto<UserDto>> GetItem(int id);

        Task Create(UserDto u);
        Task Update(int id, UserDto u);
        Task Delete(int id);
    }
}
