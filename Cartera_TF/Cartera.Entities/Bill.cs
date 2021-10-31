using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cartera.Entities
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public DateTime DEmission { get; set; }

        [Required]
        public DateTime DPayment { get; set; }

        [Required]
        public int QTotal_Bill { get; set; }

        [Required]
        public int Type_Interest_RateId { get; set; }

        public Type_Interest_Rate Type_Interest_Rate { get; set; }

        [Required]
        public DateTime DDiscount_Date { get; set; }

        [Required]
        public string Type_Capitalizacion { get; set; }

        [Required]
        public int NumTotal_Retention{ get; set; }

        [Required]
        public int PortfolioId { get; set; }

        public Portfolio Portfolio { get; set; }
    }
}
