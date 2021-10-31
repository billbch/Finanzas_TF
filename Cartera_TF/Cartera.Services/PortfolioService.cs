using Cartera.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cartera.DataAccess;
using System.Linq;

namespace Cartera.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortolioRepository _AppointmentRepository;
        public PortfolioService(IPortolioRepository AppointmentRepository)
        {
            _AppointmentRepository = AppointmentRepository;
        }
        public async Task Create(PortfolioDto p)
        {
            try
            {
                await _AppointmentRepository.Create(new Entities.Portfolio
                {

                    TIR = p.TIR,
                    UserId = p.UserId,

                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(int id)
        {
            await _AppointmentRepository.Delete(id);
        }

        public async Task<ICollection<PortfolioDto>> GetCollection()
        {
            var collection = await _AppointmentRepository.GetCollection(/*filter??string.Empty*/);
            return collection
                .Select(p => new PortfolioDto
                {

                    TIR = p.TIR,
                    UserId = p.UserId,


                }).ToList();
        }

        public async Task<ResponseDto<PortfolioDto>> GetItem(int id)
        {
            var response = new ResponseDto<PortfolioDto>();
            var p = await _AppointmentRepository.GetItem(id);

            if (p == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new PortfolioDto
            {
                TIR = p.TIR,
                UserId = p.UserId,
            };

            response.Success = true;
            return response;
        }

        public async Task Update(int id, PortfolioDto p)
        {
            await _AppointmentRepository.Update(new Entities.Portfolio
            {
                Id = id,
                TIR = p.TIR,
                UserId = p.UserId,


            });
        }
    }
}
