using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cartera.Entities
{
    public class GastosFinales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Monto { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public int BillId { get; set; }
        public Bill Bill { get; set; }
    }
}
