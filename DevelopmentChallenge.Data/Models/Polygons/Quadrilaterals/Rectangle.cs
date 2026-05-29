using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Models.Polygons.Quadrilaterals
{
    public class Rectangle : Quadrilateral
    {
        public override decimal Side2
        {
            get => Side2;
            set => base.Side2 = Height;
        }

        public override decimal Side3
        {
            get => Side3;
            set => base.Side3 = Base;
        }
        public override decimal Side4
        {
            get => Side4;
            set => base.Side4 = Height;
        }

        public override decimal CalculateArea()
        {
            return Base * Height;
        }

        public override decimal CalculatePerimeter()
        {
            return 2 * Base + 2 * Height;
        }

        public Rectangle(decimal _base, decimal height)
        {
            this.Base = _base;
            this.Height = height;
        }
    }
}
