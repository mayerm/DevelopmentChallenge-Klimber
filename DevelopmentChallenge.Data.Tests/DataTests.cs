using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DevelopmentChallenge.Data.Core.Reports;
using DevelopmentChallenge.Data.Models;
using NUnit.Framework;
using static DevelopmentChallenge.Data.Core.Enums.LanguageEnum;
using ReportStrings = DevelopmentChallenge.Data.Resources.Resources;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [Test]
        public void ResumenListaVacia()
        {
            Assert.AreEqual(
                "<h1>Lista vacía de formas!</h1>",
                GeoFormReportGenerator.Imprimir(
                    new List<GeometricForm>(),
                    Language.ES));
        }

        [Test]
        public void ResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual(
                "<h1>Empty list of shapes!</h1>",
                GeoFormReportGenerator.Imprimir(
                    new List<GeometricForm>(),
                    Language.EN));
        }

        [Test]
        public void ResumenListaConUnCuadrado()
        {
            var formas = new List<GeometricForm> { new Square(5m) };

            var resumen = GeoFormReportGenerator.Imprimir(
                formas, Language.ES);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25",
                resumen);
        }

        [Test]
        public void ResumenListaConMasCuadrados()
        {
            var formas = new List<GeometricForm>
            {
                new Square(5m),
                new Square(1m),
                new Square(3m)
            };

            var resumen = GeoFormReportGenerator.Imprimir(
                formas, Language.EN);

            Assert.AreEqual(
                "<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35",
                resumen);
        }

        [Test]
        public void ResumenListaConMasTipos()
        {
            var formas = new List<GeometricForm>
            {
                new Square(5m),
                new Circle(1.5m),
                new Triangle(4m, 4m, 4m),
                new Square(2m),
                new Triangle(9m, 9m, 9m),
                new Circle(1.375m),
                new Triangle(4.2m, 4.2m, 4.2m)
            };

            var resumen = GeoFormReportGenerator.Imprimir(
                formas, Language.EN);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [Test]
        public void ResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<GeometricForm>
            {
                new Square(5m),
                new Circle(1.5m),
                new Triangle(4m, 4m, 4m),
                new Square(2m),
                new Triangle(9m, 9m, 9m),
                new Circle(1.375m),
                new Triangle(4.2m, 4.2m, 4.2m)
            };

            var resumen = GeoFormReportGenerator.Imprimir(
                formas, Language.ES);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [Test]
        public void ResumenListaConTodosLosTiposImplementadosEnCastellano()
        {
            var formas = new List<GeometricForm>
            {
                new Trapeze(majorBase: 3m, minorBase: 1m, sideA: 2m, sideB: 4m, height: 3m),
                new Square(5m),
                new Circle(1.5m),
                new Rectangle(3m, 2m),
                new Triangle(4m, 4m, 4m),
                new Square(2m),
                new Triangle(9m, 9m, 9m),
                new Circle(1.375m),
                new Rectangle(2m, 4m),
                new Trapeze(majorBase: 4m, minorBase: 2m, sideA: 3m, sideB: 3m, height: 2m),
                new Triangle(4.2m, 4.2m, 4.2m)
            };

            var resumen = GeoFormReportGenerator.Imprimir(
                formas, Language.ES);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Trapecios | Area 12 | Perimetro 22 <br/>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>2 Rectángulos | Area 14 | Perimetro 22 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>11 formas Perimetro 141,66 Area 117,65",
                resumen);
        }

        [Test]
        public void ResumenListaConTodosLosTiposImplementados()
        {
            var formas = new List<GeometricForm>
            {
                new Trapeze(majorBase: 3m, minorBase: 1m, sideA: 2m, sideB: 4m, height: 3m),
                new Square(5m),
                new Circle(1.5m),
                new Rectangle(3m, 2m),
                new Triangle(4m, 4m, 4m),
                new Square(2m),
                new Triangle(9m, 9m, 9m),
                new Circle(1.375m),
                new Rectangle(2m, 4m),
                new Trapeze(majorBase: 4m, minorBase: 2m, sideA: 3m, sideB: 3m, height: 2m),
                new Triangle(4.2m, 4.2m, 4.2m)
            };

            var resumen = GeoFormReportGenerator.Imprimir(
                formas, Language.EN);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Trapezes | Area 12 | Perimeter 22 <br/>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>2 Rectangles | Area 14 | Perimeter 22 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>11 shapes Perimeter 141.66 Area 117.65",
                resumen);
        }

        [Test]
        public void TodosLosTiposEnItaliano()
        {
            var formas = new List<GeometricForm>
            {
                new Trapeze(majorBase: 3m, minorBase: 1m, sideA: 2m, sideB: 4m, height: 3m),
                new Square(5m),
                new Circle(1.5m),
                new Rectangle(3m, 2m),
                new Triangle(4m, 4m, 4m)
            };

            var resumen = GeoFormReportGenerator.Imprimir(
                formas, Language.IT);

            Assert.AreEqual(
                "<h1>Rapporto sulle Forme</h1>1 Trapezio | Area 6 | Perimetro 10 <br/>1 Quadrato | Area 25 | Perimetro 20 <br/>1 Cerchio | Area 7,07 | Perimetro 9,42 <br/>1 Rettangolo | Area 6 | Perimetro 10 <br/>1 Triangolo | Area 6,93 | Perimetro 12 <br/>TOTALE:<br/>5 forme Perimetro 61,42 Area 51",
                resumen);
        }

        [Test]
        public void ResumenListaConMasCuadradosEnItaliano()
        {
            var formas = new List<GeometricForm>
            {
                new Square(5m),
                new Square(1m),
                new Square(3m)
            };

            var resumen = GeoFormReportGenerator.Imprimir(
                formas, Language.IT);

            Assert.AreEqual(
                "<h1>Rapporto sulle Forme</h1>3 Quadrati | Area 35 | Perimetro 36 <br/>TOTALE:<br/>3 forme Perimetro 36 Area 35",
                resumen);
        }

        [Test]
        public void ResumenListaVaciaEnItaliano()
        {
            Assert.AreEqual(
                "<h1>Elenco vuoto di forme!</h1>",
                GeoFormReportGenerator.Imprimir(
                    new List<GeometricForm>(),
                    Language.IT));
        }

        [Test]
        public void ExcepcionDeCirculoConRadioMenorOIgualACero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0m));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1m));
        }

        [Test]
        public void ExcepcionDeCuadradoConLadoMenorOIgualACero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Square(0m));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Square(-5m));
        }

        [Test]
        public void ExcepcionDeRectanguloConLadoMenorOIgualACero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(0m, 1m));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(1m, -1m));
        }

        [Test]
        public void ExcepcionAlViolarDesigualdadTriangular()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1m, 1m, 10m));
        }

        [Test]
        public void ExcepcionDeTrapecioConBasesIguales()
        {
            Assert.Throws<ArgumentException>(
                () => new Trapeze(majorBase: 4m, minorBase: 4m, sideA: 3m, sideB: 3m, height: 2m));
        }


        private static IEnumerable<TestCaseData> FirstAppearanceCases()
        {
            GeometricForm Trapeze() => new Trapeze(majorBase: 3m, minorBase: 1m, sideA: 2m, sideB: 4m, height: 3m);
            GeometricForm Square() => new Square(5m);
            GeometricForm Circle() => new Circle(1.5m);
            GeometricForm Rect() => new Rectangle(3m, 2m);
            GeometricForm Tri() => new Triangle(4m, 4m, 4m);

            yield return new TestCaseData(
                    new List<GeometricForm>
                    {
                        Trapeze(), Square(), Circle(), Rect(), Tri(),
                        Trapeze(), Square(), Circle(), Rect(), Tri()
                    },
                    new[] { "Trapecios", "Cuadrados", "Círculos", "Rectángulos", "Triángulos" })
                .SetName("PrimeraAparicionTrapecioCuadradoCirculoRectanguloTriangulo");

            yield return new TestCaseData(
                    new List<GeometricForm>
                    {
                        Tri(), Rect(), Circle(), Square(), Trapeze(),
                        Tri(), Rect(), Circle(), Square(), Trapeze()
                    },
                    new[] { "Triángulos", "Rectángulos", "Círculos", "Cuadrados", "Trapecios" })
                .SetName("PrimeraAparicionAlReves");

            yield return new TestCaseData(
                    new List<GeometricForm>
                    {
                        Circle(), Tri(), Circle(), Square(), Tri(), Trapeze(), Rect(), Square(), Trapeze(), Rect()
                    },
                    new[] { "Círculos", "Triángulos", "Cuadrados", "Trapecios", "Rectángulos" })
                .SetName("PrimeraAparicionIntercalada");
        }

        [TestCaseSource(nameof(FirstAppearanceCases))]
        public void AgrupacionDeFormasPorPrimeraAparicionEnLista(
            List<GeometricForm> input, string[] expectedOrder)
        {
            var output = GeoFormReportGenerator.Imprimir(
                input, Language.ES);

            AssertShapeOrder(output, expectedOrder);
        }

        private static void AssertShapeOrder(string output, string[] pluralNamesInOrder)
        {
            var indices = pluralNamesInOrder
                .Select(name => new { Name = name, Index = output.IndexOf(name, StringComparison.Ordinal) })
                .ToList();

            foreach (var entry in indices)
                Assert.That(entry.Index, Is.GreaterThanOrEqualTo(0),
                    $"'{entry.Name}' no aparece en la salida.");

            for (var i = 1; i < indices.Count; i++)
                Assert.That(indices[i].Index, Is.GreaterThan(indices[i - 1].Index),
                    $"'{indices[i].Name}' debe aparecer después de '{indices[i - 1].Name}'.");
        }

        [Test]
        public void ConsistenciaMultiCulturalDeResourceKeys()
        {
            var neutralKeys = LoadResourceKeys(CultureInfo.InvariantCulture);

            foreach (var cultureName in new[] { "es", "it" })
            {
                var keys = LoadResourceKeys(CultureInfo.GetCultureInfo(cultureName));
                Assert.That(keys, Is.EquivalentTo(neutralKeys),
                    $"Las claves de '{cultureName}' difieren de las claves neutrales.");
            }
        }

        [Test]
        public void ExcepcionPorIdiomaNoSoportado()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GeoFormReportGenerator.Imprimir(new List<GeometricForm>(), (Language)999));
        }

        private static HashSet<string> LoadResourceKeys(CultureInfo culture)
        {
            var resourceSet = ReportStrings.ResourceManager.GetResourceSet(
                culture, createIfNotExists: true, tryParents: false);

            if (resourceSet == null) return new HashSet<string>();

            return new HashSet<string>(
                resourceSet
                    .Cast<System.Collections.DictionaryEntry>()
                    .Select(e => (string)e.Key));
        }
    }
}
