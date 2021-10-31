using Cartera.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Services
{
    public interface IBillService
    {
        Task<ICollection<BillDto>> GetCollection(/*string filter*/);

        Task<ResponseDto<BillDto>> GetItem(int id);

        Task Create(BillDto Bill);
        Task Update(int id, BillDto Bill);
        Task Delete(int id);
    }
}
