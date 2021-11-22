using System;

namespace Cartera.DTO
{
    public class BillDto
    {
        public int Id { get; set; }

        public DateTime DEmission { get; set; }

        public DateTime DPayment { get; set; }

        public int QTotal_Bill { get; set; }

        public int Type_Interest_RateId { get; set; }

        public DateTime DDiscount_Date { get; set; }

        public string Type_Capitalizacion { get; set; }

        public float NumTotal_Retention { get; set; }

        public int PortfolioId { get; set; }
    }
}
