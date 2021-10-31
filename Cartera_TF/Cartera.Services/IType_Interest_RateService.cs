using Cartera.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Services
{
    public interface IType_Interest_RateService
    {
        Task<ICollection<Type_Interest_RateDto>> GetCollection(/*string filter*/);

        Task<ResponseDto<Type_Interest_RateDto>> GetItem(int id);

        Task Create(Type_Interest_RateDto tp);
        Task Update(int id, Type_Interest_RateDto tp);
        Task Delete(int id);
    }
}
