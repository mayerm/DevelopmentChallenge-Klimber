using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Models;
using DevelopmentChallenge.Data.Models.Conics;
using DevelopmentChallenge.Data.Models.Polygons;
using DevelopmentChallenge.Data.Models.Polygons.Quadrilaterals;
using DevelopmentChallenge.Data.Core;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        

        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                GeoFormReportGenerator.Imprimir(new List<GeometricForm>(), 1));
        }

        
        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                GeoFormReportGenerator.Imprimir(new List<GeometricForm>(), 2));
        }
        [Obsolete("Clase FormaGeometrica deprecada. Este caso de prueba ha quedado obsoleto")]
        [TestCase]
        public void DEPRECATED_TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica(FormaGeometrica.Cuadrado, 5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }
        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<GeometricForm> { new Square(5) };

            var resumen = GeoFormReportGenerator.Imprimir(cuadrados, 1);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        
        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<GeometricForm>
            {
                new Square(5),
                new Square(1),
                new Square(3)
            };

            var resumen = GeoFormReportGenerator.Imprimir(cuadrados, 2);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }


        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<GeometricForm>
            {
                new Square(5),
                new Circle(3),
                new Triangle(4, 4, 4),
                new Square(2),
                new Triangle(9,9,9),
                new Circle(2.75m),
                new Triangle(4.2m, 4.2m, 4.2m)
            };

            var resumen = GeoFormReportGenerator.Imprimir(formas, 2);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<GeometricForm>
            {
                new Square(5),
                new Circle(3),
                new Triangle(4, 4, 4),
                new Square(2),
                new Triangle(9,9,9),
                new Circle(2.75m),
                new Triangle(4.2m, 4.2m, 4.2m)
            };

            var resumen = GeoFormReportGenerator.Imprimir(formas, 1);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTodosLosTiposImplementadosEnCastellano()
        {
            var formas = new List<GeometricForm>
            {
                new Trapeze(3,1,2,3,4),
                new Square(5),
                new Circle(3),
                new Rectangle(3,2),
                new Triangle(4, 4, 4),
                new Square(2),
                new Triangle(9,9,9),
                new Circle(2.75m),
                new Rectangle(2,4),
                new Trapeze(2,4,3,2,3),
                new Triangle(4.2m, 4.2m, 4.2m)
            };
            var resumen = GeoFormReportGenerator.Imprimir(formas, 1);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>2 Rectángulos | Area 14 | Perimetro 22 <br/>2 Trapecios | Area 12 | Perimetro 22 <br/>TOTAL:<br/>11 formas Perimetro 141,66 Area 117,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTodosLosTiposImplementados()
        {
            var formas = new List<GeometricForm>
            {
                new Trapeze(3,1,2,3,4),
                new Square(5),
                new Circle(3),
                new Rectangle(3,2),
                new Triangle(4, 4, 4),
                new Square(2),
                new Triangle(9,9,9),
                new Circle(2.75m),
                new Rectangle(2,4),
                new Trapeze(2,4,3,2,3),
                new Triangle(4.2m, 4.2m, 4.2m)
            };
            var resumen = GeoFormReportGenerator.Imprimir(formas, 2);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>2 Rectangles | Area 14 | Perimeter 22 <br/>2 Trapezes | Area 12 | Perimeter 22 <br/>TOTAL:<br/>11 shapes Perimeter 141,66 Area 117,65",
                resumen);
        }

        [TestCase]
        public void TestTodosLosTiposEnItaliano()
        {
            var formas = new List<GeometricForm>
            {
                new Trapeze(3,1,2,3,4), 
                new Square(5), 
                new Circle(3), 
                new Rectangle(3,2), 
                new Triangle(4, 4, 4) 
            };
            var resumen = GeoFormReportGenerator.Imprimir(formas, 3);
            Assert.AreEqual(
                    "<h1>Rapporto sulle Forme</h1>1 Quadrato | Area 25 | Perimetro 20 <br/>1 Cerchio | Area 7,07 | Perimetro 9,42 <br/>1 Triangolo | Area 6,93 | Perimetro 12 <br/>1 Rettangolo | Area 6 | Perimetro 10 <br/>1 Trapezio | Area 6 | Perimetro 10 <br/>TOTALE:<br/>5 forme Perimetro 61,42 Area 51",
                    resumen);

        }
        [TestCase]
        public void TestResumenListaConMasCuadradosEnItaliano()
        {
            var cuadrados = new List<GeometricForm>
            {
                new Square(5),
                new Square(1),
                new Square(3)
            };

            var resumen = GeoFormReportGenerator.Imprimir(cuadrados, 3);

            Assert.AreEqual("<h1>Rapporto sulle Forme</h1>3 Quadrati | Area 35 | Perimetro 36 <br/>TOTALE:<br/>3 forme Perimetro 36 Area 35", resumen);
        }
        [TestCase]
        public void TestResumenListaVaciaEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                GeoFormReportGenerator.Imprimir(new List<GeometricForm>(), 3));
        }

        /// <summary>
        /// Casos obsoletos. Se pueden ejecutar de todas maneras
        /// </summary>
        /// 
        [Obsolete("Clase FormaGeometrica deprecada. Este caso de prueba ha quedado obsoleto")]
        [TestCase]
        public void DEPRECATED_TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [Obsolete("Clase FormaGeometrica deprecada. Este caso de prueba ha quedado obsoleto")]
        [TestCase]
        public void DEPRECATED_TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [Obsolete("Clase FormaGeometrica deprecada. Este caso de prueba ha quedado obsoleto")]
        [TestCase]
        public void DEPRECATED_TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 1),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [Obsolete("Clase FormaGeometrica deprecada. Este caso de prueba ha quedado obsoleto")]
        [TestCase]
        public void DEPRECATED_TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Circulo, 3),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [Obsolete("Clase FormaGeometrica deprecada. Este caso de prueba ha quedado obsoleto")]
        [TestCase]
        public void DEPRECATED_TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Circulo, 3),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
    }
}
