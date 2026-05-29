using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Models.Polygons
{
    public class Triangle : Polygon
    {
        public Triangle(decimal _base, decimal side2, decimal side3, decimal height = 0)
        {
            this.Base = _base;
            this.Height = height;
            this.Side2 = side2;
            this.Side3 = side3;
        }
        
        public override decimal CalculateArea()
        {
            if (Height == 0) return (((decimal)Math.Sqrt(3) / 4) * Base * Side2);
            return (Base * Height) / 2;
        }

        public override decimal CalculatePerimeter()
        {
            return Base + Side2 + Side3;
        }
    }
}
