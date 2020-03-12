using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio : Forma
    {
        public Trapecio(int tipo, decimal lado, decimal base1, decimal base2)
        {
            this.Tipo = tipo;
            this.Lado = lado;
            this.Base1 = base1;
            this.Base2 = base2;
        }
        public decimal Base1 { get; set; }
        public decimal Base2 { get; set; }

        public override decimal CalcularArea()
        {
            return CalcularAltura() * ((Base1 + Base2) / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (Lado*2)+Base1+Base2;
        }

        private decimal CalcularAltura()
        {
            var baseTrianguloLado = Math.Abs((Base1 - Base2)) / 2;
            return (decimal) Math.Sqrt((double)Math.Abs((Lado * Lado) - (baseTrianguloLado * baseTrianguloLado)));
        }
    }
}
