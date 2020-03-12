using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public abstract class Forma
    {

        public int Tipo { get; set; }
        public decimal Lado { get; set; }
        public abstract decimal CalcularPerimetro();
        public abstract decimal CalcularArea();
    }
}
