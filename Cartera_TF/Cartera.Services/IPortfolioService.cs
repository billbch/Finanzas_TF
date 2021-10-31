using Cartera.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Services
{
    public interface IPortfolioService
    {
        Task<ICollection<PortfolioDto>> GetCollection(/*string filter*/);

        Task<ResponseDto<PortfolioDto>> GetItem(int id);

        Task Create(PortfolioDto p);
        Task Update(int id, PortfolioDto p);
        Task Delete(int id);
    }
}
