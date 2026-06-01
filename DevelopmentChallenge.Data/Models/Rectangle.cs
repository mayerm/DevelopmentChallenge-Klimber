using System;

namespace DevelopmentChallenge.Data.Models
{
    public sealed class Rectangle : GeometricForm
    {
        public decimal Width { get; }
        public decimal Height { get; }

        public override string SingularResourceKey => "Rectangle";
        public override string PluralResourceKey => "Rectangles";

        public Rectangle(decimal width, decimal height)
        {
            if (width <= 0m) throw new ArgumentOutOfRangeException(nameof(width));
            if (height <= 0m) throw new ArgumentOutOfRangeException(nameof(height));
            Width = width;
            Height = height;
        }

        public override decimal CalculateArea() => Width * Height;
        public override decimal CalculatePerimeter() => 2m * (Width + Height);
    }
}
