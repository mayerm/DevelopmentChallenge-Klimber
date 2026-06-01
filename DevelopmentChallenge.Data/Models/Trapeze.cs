using System;

namespace DevelopmentChallenge.Data.Models
{
    public sealed class Trapeze : GeometricForm
    {
        public decimal MajorBase { get; }
        public decimal MinorBase { get; }
        public decimal SideA { get; }
        public decimal SideB { get; }
        public decimal Height { get; }

        public override string SingularResourceKey => "Trapeze";
        public override string PluralResourceKey => "Trapezes";

        public Trapeze(decimal majorBase, decimal minorBase, decimal sideA, decimal sideB, decimal height)
        {
            if (majorBase <= 0m) throw new ArgumentOutOfRangeException(nameof(majorBase));
            if (minorBase <= 0m) throw new ArgumentOutOfRangeException(nameof(minorBase));
            if (sideA <= 0m) throw new ArgumentOutOfRangeException(nameof(sideA));
            if (sideB <= 0m) throw new ArgumentOutOfRangeException(nameof(sideB));
            if (height <= 0m) throw new ArgumentOutOfRangeException(nameof(height));
            if (majorBase == minorBase)
                throw new ArgumentException("Las bases deben ser distintas (de lo contrario es un paralelogramo).");

            MajorBase = majorBase;
            MinorBase = minorBase;
            SideA = sideA;
            SideB = sideB;
            Height = height;
        }

        public override decimal CalculateArea() => Height * (MajorBase + MinorBase) / 2m;
        public override decimal CalculatePerimeter() => MajorBase + MinorBase + SideA + SideB;
    }
}
