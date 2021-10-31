using Cartera.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cartera.DataAccess;
using System.Linq;

namespace Cartera.Services
{
    public class GastosInicialesService : IGastosInicialesService
    {
        private readonly IGastosInicialesRepository _AppointmentRepository;
        public GastosInicialesService(IGastosInicialesRepository AppointmentRepository)
        {
            _AppointmentRepository = AppointmentRepository;
        }
        public async Task Create(GastosInicialesDto gi)
        {
            try
            {
                await _AppointmentRepository.Create(new Entities.GastosIniciales
                {

                    Monto = gi.Monto,
                    Tipo = gi.Tipo,
                    BillId = gi.BillId,


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

        public async Task<ICollection<GastosInicialesDto>> GetCollection()
        {
            var collection = await _AppointmentRepository.GetCollection();
            return collection
                .Select(gf => new GastosInicialesDto
                {

                    Monto = gf.Monto,
                    Tipo = gf.Tipo,
                    BillId = gf.BillId,


                }).ToList();
        }

        public async Task<ResponseDto<GastosInicialesDto>> GetItem(int id)
        {
            var response = new ResponseDto<GastosInicialesDto>();
            var Bill = await _AppointmentRepository.GetItem(id);

            if (Bill == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new GastosInicialesDto
            {
                Monto = Bill.Monto,
                Tipo = Bill.Tipo,
                BillId = Bill.BillId
            };

            response.Success = true;

            return response;
        }


        public async Task Update(int id, GastosInicialesDto gi)
        {
            await _AppointmentRepository.Update(new Entities.GastosIniciales
            {
                Id = id,
                Monto = gi.Monto,
                Tipo = gi.Tipo,
                BillId = gi.BillId

            });
        }
    }

}

