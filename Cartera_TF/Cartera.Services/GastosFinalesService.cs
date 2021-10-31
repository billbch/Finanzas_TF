using Cartera.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cartera.DataAccess;
using System.Linq;

namespace Cartera.Services
{
    public class GastosFinalesService : IGastosFinalesService
    {
        private readonly IGastosFinalesRepository _AppointmentRepository;
        public GastosFinalesService(IGastosFinalesRepository AppointmentRepository)
        {
            _AppointmentRepository = AppointmentRepository;
        }
        public async Task Create(GastosFinalesDto gf)
        {
            try
            {
                await _AppointmentRepository.Create(new Entities.GastosFinales
                {

                    Monto = gf.Monto,
                    Tipo = gf.Tipo,
                    BillId = gf.BillId,


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

        public async Task<ICollection<GastosFinalesDto>> GetCollection()
        {
            var collection = await _AppointmentRepository.GetCollection();
            return collection
                .Select(gf => new GastosFinalesDto
                {

                    Monto = gf.Monto,
                    Tipo = gf.Tipo,
                    BillId = gf.BillId,


                }).ToList();
        }

        public async Task<ResponseDto<GastosFinalesDto>> GetItem(int id)
        {
            var response = new ResponseDto<GastosFinalesDto>();
            var Bill = await _AppointmentRepository.GetItem(id);

            if (Bill == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new GastosFinalesDto
            {
                Monto = Bill.Monto,
                Tipo = Bill.Tipo,
                BillId = Bill.BillId
            };

            response.Success = true;

            return response;
        }

        public async Task Update(int id, GastosFinalesDto gf)
        {
            await _AppointmentRepository.Update(new Entities.GastosFinales
            {
                Id = id,
                Monto = gf.Monto,
                Tipo = gf.Tipo,
                BillId = gf.BillId


            });
        }
    }
}
