using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectazo_2.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        public string OperationType { get; set; } = string.Empty;
        public decimal Number1 { get; set; }
        public decimal Number2 { get; set; }
        public decimal Result { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}