using Cartera.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cartera.DataAccess;
using System.Linq;

namespace Cartera.Services
{
    public class Type_Interest_RateService : IType_Interest_RateService
    {
        private readonly  IType_Interest_RateRepository _AppointmentRepository;
        public Type_Interest_RateService(IType_Interest_RateRepository AppointmentRepository)
        {
            _AppointmentRepository = AppointmentRepository;
        }
        public async Task Create(Type_Interest_RateDto tp)
        {
            try
            {
                await _AppointmentRepository.Create(new Entities.Type_Interest_Rate
                {

                    N_Type_Interest_Rate = tp.N_Type_Interest_Rate,
                  
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

        public async Task<ICollection<Type_Interest_RateDto>> GetCollection()
        {
            var collection = await _AppointmentRepository.GetCollection(/*filter??string.Empty*/);
            return collection
                .Select(tp => new Type_Interest_RateDto
                {

                    N_Type_Interest_Rate = tp.N_Type_Interest_Rate,


                }).ToList();
        }

        public async Task<ResponseDto<Type_Interest_RateDto>> GetItem(int id)
        {
            var response = new ResponseDto<Type_Interest_RateDto>();
            var Bill = await _AppointmentRepository.GetItem(id);

            if (Bill == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new Type_Interest_RateDto
            {
                N_Type_Interest_Rate = Bill.N_Type_Interest_Rate,
            };

            response.Success = true;

            return response;
        }

        public async Task Update(int id, Type_Interest_RateDto tp)
        {
            await _AppointmentRepository.Update(new Entities.Type_Interest_Rate
            {
                Id = id,
                N_Type_Interest_Rate = tp.N_Type_Interest_Rate,


            });
        }
    }
}
