using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Models.Polygons.Quadrilaterals
{
    public class Trapeze : Quadrilateral
    {
        public Trapeze(decimal height, decimal _base, decimal side2, decimal side3, decimal side4)
        {
            Base = _base;
            Height = height;
            Side2 = side2;
            Side3 = side3;
            Side4 = side4;

        }

        public override decimal CalculateArea()
        {
            return Height * (Base + Side3) / 2;
        }

        public override decimal CalculatePerimeter()
        {
            return Base + Side2 + Side3 + Side4;
        }
    }
}
