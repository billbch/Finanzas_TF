using Cartera.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Services
{
    public interface IGastosInicialesService
    {
        Task<ICollection<GastosInicialesDto>> GetCollection(/*string filter*/);

        Task<ResponseDto<GastosInicialesDto>> GetItem(int id);

        Task Create(GastosInicialesDto gi);
        Task Update(int id, GastosInicialesDto gi);
        Task Delete(int id);
    }
}
