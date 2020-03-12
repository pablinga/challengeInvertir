using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : Forma
    {
        public Rectangulo (int tipo, decimal lado, decimal base1)
        {
            this.Tipo = tipo;
            this.Lado = lado;
            this.Base = base1;
        }

        public decimal Base{get; set;}

        public override decimal CalcularArea()
        {
            return Base * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return (Lado + Base) * 2;
        }
    }
}
