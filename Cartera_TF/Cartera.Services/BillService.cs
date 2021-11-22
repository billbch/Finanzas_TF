using Cartera.DataAccess;
using Cartera.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _AppointmentRepository;
        public BillService(IBillRepository AppointmentRepository)
        {
            _AppointmentRepository = AppointmentRepository;
        }
        public async Task Create(BillDto Bill)
        {
            try
            {
                await _AppointmentRepository.Create(new Entities.Bill
                {
                    Id=Bill.Id,
                    DEmission = Bill.DEmission,
                    DPayment = Bill.DPayment,
                    QTotal_Bill = Bill.QTotal_Bill,
                    Type_Interest_RateId = Bill.Type_Interest_RateId,
                    DDiscount_Date = Bill.DDiscount_Date,
                    Type_Capitalizacion = Bill.Type_Capitalizacion,
                    NumTotal_Retention = Bill.NumTotal_Retention,
                    PortfolioId=Bill.PortfolioId


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

        public async Task<ICollection<BillDto>> GetCollection()
        {
            var collection = await _AppointmentRepository.GetCollection(/*filter??string.Empty*/);
            return collection
                .Select(Bill => new BillDto
                {

                    DEmission = Bill.DEmission,
                    DPayment = Bill.DPayment,
                    QTotal_Bill = Bill.QTotal_Bill,
                    Type_Interest_RateId = Bill.Type_Interest_RateId,
                    DDiscount_Date = Bill.DDiscount_Date,
                    Type_Capitalizacion = Bill.Type_Capitalizacion,
                    NumTotal_Retention = Bill.NumTotal_Retention,
                    PortfolioId = Bill.PortfolioId


                }).ToList();
        }

        public async Task<ResponseDto<BillDto>> GetItem(int id)
        {
            var response = new ResponseDto<BillDto>();
            var Bill = await _AppointmentRepository.GetItem(id);

            if (Bill == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new BillDto
            {
                DEmission = Bill.DEmission,
                DPayment = Bill.DPayment,
                QTotal_Bill = Bill.QTotal_Bill,
                Type_Interest_RateId = Bill.Type_Interest_RateId,
                DDiscount_Date = Bill.DDiscount_Date,
                Type_Capitalizacion = Bill.Type_Capitalizacion,
                NumTotal_Retention = Bill.NumTotal_Retention,
                PortfolioId = Bill.PortfolioId
            };

            response.Success = true;

            return response;
        }

        public async Task Update(int id, BillDto Bill)
        {
            await _AppointmentRepository.Update(new Entities.Bill
            {
                Id = id,
                DEmission = Bill.DEmission,
                DPayment = Bill.DPayment,
                QTotal_Bill = Bill.QTotal_Bill,
                Type_Interest_RateId = Bill.Type_Interest_RateId,
                DDiscount_Date = Bill.DDiscount_Date,
                Type_Capitalizacion = Bill.Type_Capitalizacion,
                NumTotal_Retention = Bill.NumTotal_Retention,
                PortfolioId = Bill.PortfolioId


            });
        }
    }
}
