using System;
using System.Collections.Generic;
using System.Text;

namespace Cartera.DTO
{
    public class GastosInicialesDto
    {
        public int Id { get; set; }
        
        public int Monto { get; set; }
        
        public string Tipo { get; set; }

        public int BillId { get; set; }
    }
}
