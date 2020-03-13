/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;
        public const int Rectangulo = 5;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Portugues = 3;

        #endregion

        public static string Imprimir(List<Forma> formas, int idioma)
        {
            switch(idioma)
            {
                case 2:
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("EN");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("EN");
                    break;
                case 3:
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("BR");
                    break;
                default:
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ES");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ES");
                    break;
            }

            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append("<h1>" + Resources.Resources.Empty + "</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append("<h1>" + Resources.Resources.Header + "</h1>");
                List<DTOFigura> listFiguras = new List<DTOFigura>();
                DTOFigura cuadrado = new DTOFigura() { tipo = Cuadrado };
                DTOFigura circulo = new DTOFigura() { tipo = Circulo };
                DTOFigura triangulo = new DTOFigura() { tipo = TrianguloEquilatero };
                DTOFigura trapecio = new DTOFigura() { tipo = Trapecio };
                DTOFigura rectangulo = new DTOFigura() { tipo = Rectangulo };

                for (var i = 0; i < formas.Count; i++)
                {
                    switch(formas[i].Tipo)
                    {
                        case Cuadrado:
                            cuadrado.cantidad++;
                            cuadrado.areaTotal += formas[i].CalcularArea();
                            cuadrado.perimetroTotal += formas[i].CalcularPerimetro();
                            break;
                        case Circulo:
                            circulo.cantidad++;
                            circulo.areaTotal += formas[i].CalcularArea();
                            circulo.perimetroTotal += formas[i].CalcularPerimetro();
                            break;
                        case TrianguloEquilatero:
                            triangulo.cantidad++;
                            triangulo.areaTotal += formas[i].CalcularArea();
                            triangulo.perimetroTotal += formas[i].CalcularPerimetro();
                            break;
                        case Trapecio:
                            trapecio.cantidad++;
                            trapecio.areaTotal += formas[i].CalcularArea();
                            trapecio.perimetroTotal += formas[i].CalcularPerimetro();
                            break; 
                        case Rectangulo:
                            rectangulo.cantidad++;
                            rectangulo.areaTotal += formas[i].CalcularArea();
                            rectangulo.perimetroTotal += formas[i].CalcularPerimetro();
                            break;
                    }                    
                }
                listFiguras.Add(cuadrado);
                listFiguras.Add(circulo);
                listFiguras.Add(triangulo);
                listFiguras.Add(trapecio);
                listFiguras.Add(rectangulo);

                ObtenerLinea(sb, listFiguras);
                
            }

            return sb.ToString();
        }

        private static void ObtenerLinea(StringBuilder sb, List<DTOFigura> listFiguras)
        {
            var totalPerimetro = 0m;
            var totalArea = 0m;
            var totalCantidad = 0;
            foreach (var figura in listFiguras)
            {
                if (figura.cantidad > 0)
                {
                    sb.Append($"{figura.cantidad} {TraducirForma(figura.tipo, figura.cantidad)} | {Resources.Resources.Area} {figura.areaTotal:#.##} | {Resources.Resources.Perimeter} {figura.perimetroTotal:#.##} <br/>");
                    totalCantidad += figura.cantidad;
                    totalPerimetro += figura.perimetroTotal;
                    totalArea += figura.areaTotal;
                }
            }
            sb.Append(Resources.Resources.Total + ":<br/>");
            sb.Append(totalCantidad + " " + Resources.Resources.Shapes + " ");
            sb.Append(Resources.Resources.Perimeter + " " + (totalPerimetro).ToString("#.##") + " ");
            sb.Append(Resources.Resources.Area + " " + (totalArea).ToString("#.##"));
        }

    
        private static string TraducirForma(int tipo, int cantidad)
        {
            switch (tipo)
            {
                case Cuadrado:
                    return cantidad == 1 ? Resources.Resources.Square : Resources.Resources.Squares;
                case Circulo:
                    return cantidad == 1 ? Resources.Resources.Circle : Resources.Resources.Circles;
                case TrianguloEquilatero:
                    return cantidad == 1 ? Resources.Resources.Triangle : Resources.Resources.Triangles;
                case Trapecio:
                    return cantidad == 1 ? Resources.Resources.Trapeze : Resources.Resources.Trapezoids;
                case Rectangulo:
                    return cantidad == 1 ? Resources.Resources.Rectangle : Resources.Resources.Rectangles;
            }

            return string.Empty;
        }

        private class DTOFigura
        {
            public int cantidad { get; set; }
            public decimal areaTotal { get; set; }
            public decimal perimetroTotal { get; set; }
            public int tipo { get; set; }
        }

    }
}
