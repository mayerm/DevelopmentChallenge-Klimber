using System;

namespace DevelopmentChallenge.Data.Models
{
    public sealed class Square : GeometricForm
    {
        public decimal Side { get; }

        public override string SingularResourceKey => "Square";
        public override string PluralResourceKey => "Squares";

        public Square(decimal side)
        {
            if (side <= 0m) throw new ArgumentOutOfRangeException(nameof(side));
            Side = side;
        }

        public override decimal CalculateArea() => Side * Side;
        public override decimal CalculatePerimeter() => 4m * Side;
    }
}
