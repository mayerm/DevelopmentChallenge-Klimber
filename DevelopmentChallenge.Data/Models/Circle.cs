using System;

namespace DevelopmentChallenge.Data.Models
{
    public sealed class Circle : GeometricForm
    {
        public decimal Radius { get; }

        public override string SingularResourceKey => "Circle";
        public override string PluralResourceKey => "Circles";

        public Circle(decimal radius)
        {
            if (radius <= 0m) throw new ArgumentOutOfRangeException(nameof(radius), "El radio no puede ser menor o igual a 0.");
            Radius = radius;
        }

        public override decimal CalculateArea() => (decimal)Math.PI * Radius * Radius;
        public override decimal CalculatePerimeter() => 2m * (decimal)Math.PI * Radius;
    }
}
