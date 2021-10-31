using Cartera.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Services
{
    public interface IGastosFinalesService
    {
        Task<ICollection<GastosFinalesDto>> GetCollection();

        Task<ResponseDto<GastosFinalesDto>> GetItem(int id);

        Task Create(GastosFinalesDto gf);
        Task Update(int id, GastosFinalesDto gf);
        Task Delete(int id);
    }
}
