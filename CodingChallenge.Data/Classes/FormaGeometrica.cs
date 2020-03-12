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
        public const int Francés = 3;

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
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("FR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("FR");
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

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    else if (formas[i].Tipo == Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    else if (formas[i].Tipo == TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro();
                    }
                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(formas.Count + " " + Resources.Resources.Shapes + " ");
                sb.Append(Resources.Resources.Perimeter+ " " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad)} | Area {area:#.##} | {Resources.Resources.Perimeter} {perimetro:#.##} <br/>";
            }

            return string.Empty;
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
            }

            return string.Empty;
        }
    }
}
