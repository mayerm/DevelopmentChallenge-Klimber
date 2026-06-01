using System;

namespace DevelopmentChallenge.Data.Models
{
    public sealed class Triangle : GeometricForm
    {
        public decimal SideA { get; }
        public decimal SideB { get; }
        public decimal SideC { get; }

        public override string SingularResourceKey => "Triangle";
        public override string PluralResourceKey => "Triangles";

        public Triangle(decimal sideA, decimal sideB, decimal sideC)
        {
            if (sideA <= 0m) throw new ArgumentOutOfRangeException(nameof(sideA));
            if (sideB <= 0m) throw new ArgumentOutOfRangeException(nameof(sideB));
            if (sideC <= 0m) throw new ArgumentOutOfRangeException(nameof(sideC));
            if (!ValidateTriangleInequality(sideA, sideB, sideC))
                throw new ArgumentException("Los lados no satisfacen la desigualdad triangular.");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override decimal CalculateArea()
        {
            var s = (SideA + SideB + SideC) / 2m;
            var areaSquared = (double)(s * (s - SideA) * (s - SideB) * (s - SideC));
            return (decimal)Math.Sqrt(areaSquared);
        }

        public override decimal CalculatePerimeter() => SideA + SideB + SideC;

        private static bool ValidateTriangleInequality(decimal a, decimal b, decimal c) =>
            a + b > c && 
            b + c > a && 
            a + c > b;
    }
}
